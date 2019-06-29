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
    public partial class frmProfesoresInactivos : Form
    {
        #region VARIABLES
        /// <summary>
        /// Filtro para realizar la busqueda de profesores.
        /// </summary>
        public static string s_Filtro = "Profesor.Apellido";
        #endregion

        public frmProfesoresInactivos()
        {
            InitializeComponent();
        }

        #region FORM
        private void frmProfesoresInactivos_Load(object sender, EventArgs e)
        {
            try
            {
                f_FillGridProfesoresInactivos();
                cboFiltro.SelectedIndex = 0;
                txtBuscar.Select();
                dgvProfesoresInactivos.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            catch (Exception) { }
        }

        private void frmProfesoresInactivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region BUTTONS
        private void btnActivarProfesor_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = (dgvProfesoresInactivos.CurrentRow.Index);
                DialogResult drActivar;
                drActivar = MessageBox.Show("Esta seguro que desea activar a " + dgvProfesoresInactivos["Nombre", i_Fila].Value.ToString() + " " + dgvProfesoresInactivos["Apellido", i_Fila].Value.ToString() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (drActivar == DialogResult.OK)
                {
                    Profesores oProfesores = new Profesores();
                    oProfesores.Enable(Convert.ToInt32(dgvProfesoresInactivos["idProfesor", i_Fila].Value));
                    f_FillGridProfesoresInactivos();
                    MessageBox.Show("El profesor ha sido activado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un profesor.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvProfesoresInactivos.CurrentRow.Index;
                DialogResult drEliminar = MessageBox.Show("Esta seguro que desea eliminar definitivamente a " + dgvProfesoresInactivos["Nombre", i_Fila].Value.ToString() + " " + dgvProfesoresInactivos["Apellido", i_Fila].Value.ToString() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (drEliminar == DialogResult.OK)
                {
                    Profesores oProfesores = new Profesores();
                    if (oProfesores.Delete(Convert.ToInt32(dgvProfesoresInactivos["idProfesor", i_Fila].Value))) { f_FillGridProfesoresInactivos(); MessageBox.Show("Profesor eliminado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information); } else { MessageBox.Show("Se ha producido un error al intenar eliminar definitivamente al profesor. Por favor, intente mas tarde.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un profesor.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            f_BuscarProfesor();
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
                        s_Filtro = "P.Apellido";
                        break;

                    case "Nombre":
                        s_Filtro = "P.Nombre";
                        break;

                    case "Nro. de Documento":
                        s_Filtro = "P.NroDoc";
                        break;

                    case "Fecha de registracion":
                        s_Filtro = "P.FechaRegistracion>='" + dtpDesde.Value.ToShortDateString() + "' AND P.FechaRegistracion<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY P.FechaRegistracion ASC";
                        txtBuscar.Visible = false;
                        lbDesde.Visible = true;
                        lbHasta.Visible = true;
                        dtpDesde.Visible = true;
                        dtpHasta.Visible = true;
                        break;
                }

                if (cboFiltro.SelectedItem.ToString().Trim() != "Fecha de registracion")
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
        #endregion

        #region FUNCIONES
        public void f_FillGridProfesoresInactivos()
        {
            try
            {
                Profesores oProfesores = new Profesores();
                DataTable dtProfesores = oProfesores.GetAllPL("P.idProfesor, P.NroDoc as 'Nro. Doc.', P.Nombre, P.Apellido, P.FechaNacimiento as 'Fecha Nac.', P.Edad, P.Sexo, P.Direccion, L.Nombre as 'Localidad', P.TelefonoFijo as 'Tel. Fijo', P.TelefonoCelular as 'Tel. Celular', P.FechaRegistracion as 'Fecha Registro'", "P.Estado=0 ORDER BY P.Apellido ASC");
                dgvProfesoresInactivos.DataSource = dtProfesores;
                dgvProfesoresInactivos.Columns["idProfesor"].Visible = false;
                dgvProfesoresInactivos.ClearSelection();
                lbCantidad.Text = "Cantidad: " + dgvProfesoresInactivos.Rows.Count.ToString();
            }
            catch (Exception) { }
        }

        public void f_BuscarProfesor()
        {
            try
            {
                Profesores oProfesores = new Profesores();
                if (txtBuscar.Visible == true)
                {
                    if (txtBuscar.Text != "")
                    {
                        DataTable DT = oProfesores.GetAllPL("P.idProfesor, P.NroDoc as 'Nro. Doc.', P.Nombre, P.Apellido, P.FechaNacimiento as 'Fecha Nac.', P.Edad, P.Sexo, P.Direccion, L.Nombre as 'Localidad', P.TelefonoFijo as 'Tel. Fijo', P.TelefonoCelular as 'Tel. Celular', P.FechaRegistracion as 'Fecha Registro'", "P.Estado=0 AND " + s_Filtro + " LIKE '%" + txtBuscar.Text.ToString().Trim() + "%' ORDER BY " + s_Filtro + " ASC");
                        dgvProfesoresInactivos.DataSource = DT;
                        dgvProfesoresInactivos.Columns["idProfesor"].Visible = false;
                    }
                    else { f_FillGridProfesoresInactivos(); }
                }
                else
                {
                    s_Filtro = "P.FechaRegistracion>='" + dtpDesde.Value.ToShortDateString() + "' AND P.FechaRegistracion<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY P.FechaRegistracion ASC";
                    DataTable DT = oProfesores.GetAllPL("P.idProfesor, P.NroDoc as 'Nro. Doc.', P.Nombre, P.Apellido, P.FechaNacimiento as 'Fecha Nac.', P.Edad, P.Sexo, P.Direccion, L.Nombre as 'Localidad', P.TelefonoFijo as 'Tel. Fijo', P.TelefonoCelular as 'Tel. Celular', P.FechaRegistracion as 'Fecha Registro'", "P.Estado=0 AND " + s_Filtro);
                    dgvProfesoresInactivos.DataSource = DT;
                    dgvProfesoresInactivos.Columns["idProfesor"].Visible = false;
                }
                lbCantidad.Text = "Cantidad: " + dgvProfesoresInactivos.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }
        #endregion
    }
}
