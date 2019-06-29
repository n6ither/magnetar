using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace Presentation.Winforms
{
    public partial class frmAsistencias : Form
    {
        #region VARIABLES
        public static string s_Filtro = "Socio.Apellido";
        /// <summary>
        /// Si es distinto de cero, el grid se llenara con las asistencias de un socio en particular.
        /// </summary>
        public static int idSocio = 0;
        #endregion

        public frmAsistencias()
        {
            InitializeComponent();
        }

        #region FORM & DATAGRIDVIEW
        private void frmAsistencias_Load(object sender, EventArgs e)
        {
            try
            {
                if (idSocio == 0) { cboFiltro.SelectedIndex = 0; } else { cboFiltro.Text = "Fecha"; cboFiltro.Enabled = false; }
                
                f_FillGrid();
            }
            catch (Exception) { }
        }

        private void dgvAsistencias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvAsistencias.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Saldo"].Value) < 0) { row.DefaultCellStyle.ForeColor = Color.Red; } else { row.DefaultCellStyle.ForeColor = Color.Green; }
                }
            }
            catch (Exception) { }
        }

        private void dgvAsistencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarSocio"] != null) Application.OpenForms["frmRegistrarEditarSocio"].Close();
                int i_Fila = dgvAsistencias.CurrentRow.Index;
                frmRegistrarEditarSocio.idSocio = Convert.ToInt32(dgvAsistencias["idSocio", i_Fila].Value);
                frmRegistrarEditarSocio frm = new frmRegistrarEditarSocio();
                frm.Text = "Magnetar Gym Management | Editar socio";
                frm.ShowDialog();
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            f_Buscar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = (dgvAsistencias.CurrentRow.Index);
                DialogResult drEliminar;
                drEliminar = MessageBox.Show("Esta seguro que desea eliminar la asistencia de " + dgvAsistencias["Nombre", i_Fila].Value.ToString() + " " + dgvAsistencias["Apellido", i_Fila].Value.ToString() + " el dia " + dgvAsistencias["Fecha", i_Fila].Value.ToString().Remove(10) + " y hora " + dgvAsistencias["Hora", i_Fila].Value.ToString() + "?", "Eliminar asistencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK)
                {
                    Asistencias oAsistencias = new Asistencias();
                    oAsistencias.Delete("Asistencia", "Asistencia.idAsistencia=" + Convert.ToInt32(dgvAsistencias["idAsistencia", i_Fila].Value));
                    f_FillGrid();
                    MessageBox.Show("La asistencia ha sido eliminada correctamente", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione una asistencia.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region ETC
        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboFiltro.SelectedItem.ToString().Trim())
                {
                    case "Apellido":
                        s_Filtro = "Socio.Apellido";
                        break;

                    case "Nombre":
                        s_Filtro = "Socio.Nombre";
                        break;

                    case "Nro. de Documento":
                        s_Filtro = "Socio.NroDoc";
                        break;

                    case "Fecha":
                        s_Filtro = "Asistencia.Fecha>='" + dtpDesde.Value.ToShortDateString() + "' AND Asistencia.Fecha<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY Asistencia.Fecha ASC, Asistencia.Hora DESC";
                        txtBuscar.Clear();
                        txtBuscar.Visible = false;
                        lbDesde.Visible = true;
                        lbHasta.Visible = true;
                        dtpDesde.Visible = true;
                        dtpHasta.Visible = true;
                        dtpDesde.Format = DateTimePickerFormat.Short;
                        dtpHasta.Format = DateTimePickerFormat.Short;
                        break;

                    case "Actividad":
                        s_Filtro = "Actividad.Nombre";
                        break;
                }

                if (cboFiltro.SelectedItem.ToString().Trim() == "Apellido" || cboFiltro.SelectedItem.ToString().Trim() == "Nombre" || cboFiltro.SelectedItem.ToString().Trim() == "Nro. de Documento")
                {
                    txtBuscar.Visible = true;
                    lbDesde.Visible = false;
                    lbHasta.Visible = false;
                    dtpDesde.Visible = false;
                    dtpHasta.Visible = false;
                }
            }
            catch (Exception) { }
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                s_Filtro = "Asistencia.Fecha>='" + dtpDesde.Value.ToShortDateString() + "' AND Asistencia.Fecha<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY Asistencia.Fecha ASC, Asistencia.Hora DESC";
                dtpHasta.MinDate = dtpDesde.Value;
            }
            catch (Exception) { }
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                s_Filtro = "Asistencia.Fecha>='" + dtpDesde.Value.ToShortDateString() + "' AND Asistencia.Fecha<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY Asistencia.Fecha ASC, Asistencia.Hora DESC";
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public void f_Buscar()
        {
            try
            {
                Asistencias oAsistencias = new Asistencias();
                if (txtBuscar.Text != "")
                {
                    DataTable dtAsistencias = oAsistencias.GetAllMix("Asistencia.idAsistencia, Socio.idSocio, Socio.Saldo, Socio.NroDoc as 'Nro. Doc.', Socio.Nombre, Socio.Apellido, Actividad.Nombre as 'Actividad', Asistencia.Fecha, Asistencia.Hora", "Socio.Estado=1 AND Socio.idSocio=Asistencia.idSocio AND Actividad.idActividad=Asistencia.idActividad AND " + s_Filtro + " LIKE '%" + txtBuscar.Text.ToString() + "%' ORDER BY " + s_Filtro + " ASC");
                    dgvAsistencias.DataSource = dtAsistencias;
                    dgvAsistencias.Columns["idAsistencia"].Visible = false;
                    dgvAsistencias.Columns["idSocio"].Visible = false;
                }
                else
                {
                    if (txtBuscar.Visible == false)
                    {
                        DataTable dtAsistencias;
                        if (idSocio != 0)
                        {
                            dtAsistencias = oAsistencias.GetTop100Mix("Asistencia.idAsistencia, Socio.idSocio, Socio.Saldo, Socio.NroDoc as 'Nro. Doc.', Socio.Nombre, Socio.Apellido, Actividad.Nombre as 'Actividad', Asistencia.Fecha, Asistencia.Hora", "Socio.idSocio=" + idSocio + " AND Socio.idSocio=Asistencia.idSocio AND Actividad.idActividad=Asistencia.idActividad ORDER BY Asistencia.Fecha DESC, Asistencia.Hora DESC");
                        }
                        else
                        {

                            dtAsistencias = oAsistencias.GetTop100Mix("Asistencia.idAsistencia, Socio.idSocio, Socio.Saldo, Socio.NroDoc as 'Nro. Doc.', Socio.Nombre, Socio.Apellido, Actividad.Nombre as 'Actividad', Asistencia.Fecha, Asistencia.Hora", "Socio.idSocio=Asistencia.idSocio AND Actividad.idActividad=Asistencia.idActividad ORDER BY Asistencia.Fecha DESC, Asistencia.Hora DESC");
                        }
                        
                        dgvAsistencias.DataSource = dtAsistencias;
                        dgvAsistencias.Columns["idAsistencia"].Visible = false;
                        dgvAsistencias.Columns["idSocio"].Visible = false;
                    }
                    else
                    {
                        f_FillGrid();
                    }
                }
                dgvAsistencias.ClearSelection();
                lbCantStatusBar.Text = "Cantidad: " + dgvAsistencias.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_FillGrid()
        {
            try
            {
                Asistencias oAsistencias = new Asistencias();
                DataTable dtAsistencias;

                if (idSocio != 0)
                {
                    dtAsistencias = oAsistencias.GetTop100Mix("Asistencia.idAsistencia, Socio.idSocio, Socio.Saldo, Socio.NroDoc as 'Nro. Doc.', Socio.Nombre, Socio.Apellido, Actividad.Nombre as 'Actividad', Asistencia.Fecha, Asistencia.Hora", "Socio.idSocio=" + idSocio + " AND Socio.idSocio=Asistencia.idSocio AND Actividad.idActividad=Asistencia.idActividad ORDER BY Asistencia.Fecha DESC, Asistencia.Hora DESC");
                }
                else
                {

                    dtAsistencias = oAsistencias.GetTop100Mix("Asistencia.idAsistencia, Socio.idSocio, Socio.Saldo, Socio.NroDoc as 'Nro. Doc.', Socio.Nombre, Socio.Apellido, Actividad.Nombre as 'Actividad', Asistencia.Fecha, Asistencia.Hora", "Socio.idSocio=Asistencia.idSocio AND Actividad.idActividad=Asistencia.idActividad ORDER BY Asistencia.Fecha DESC, Asistencia.Hora DESC");
                }

                dgvAsistencias.DataSource = dtAsistencias;
                dgvAsistencias.Columns["idAsistencia"].Visible = false;
                dgvAsistencias.Columns["idSocio"].Visible = false;
                dgvAsistencias.Columns["Saldo"].Visible = false;
                dgvAsistencias.ClearSelection();
                lbCantStatusBar.Text = "Cantidad: " + dgvAsistencias.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }
        #endregion
    }
}