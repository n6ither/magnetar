using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Logic;
using Presentation.Winforms;

namespace Presentation.Winforms
{
    public partial class frmSociosInactivos : Form
    {

        #region VARIABLES
        /// <summary>
        /// Filtro para realizar la busqueda de socios.
        /// </summary>
        public static string s_Filtro = "Socio.Apellido";
        #endregion

        public frmSociosInactivos()
        {
            InitializeComponent();
        }


        #region FORM
        private void frmSociosInactivos_Load(object sender, EventArgs e)
        {
            try
            {
                f_FillGridSociosInactivos();
                cboFiltroSociosInactivos.SelectedIndex = 0;
                txtBuscarSocio.Select();
                dgvSociosInactivos.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            }
            catch (Exception) { }
        }

        private void frmSociosInactivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region BUTTONS
        private void btnActivarSocio_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = (dgvSociosInactivos.CurrentRow.Index);
                DialogResult drActivar;
                drActivar = MessageBox.Show("Esta seguro que desea activar a " + dgvSociosInactivos["Nombre", i_Fila].Value.ToString() + " " + dgvSociosInactivos["Apellido", i_Fila].Value.ToString() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (drActivar == DialogResult.OK)
                {
                    Socios oSocios = new Socios();
                    oSocios.Enable(Convert.ToInt32(dgvSociosInactivos["idSocio", i_Fila].Value));
                    f_FillGridSociosInactivos();
                    MessageBox.Show("El socio ha sido activado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un socio.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvSociosInactivos.CurrentRow.Index;
                DialogResult drEliminar = MessageBox.Show("Esta seguro que desea eliminar definitivamente a " + dgvSociosInactivos["Nombre", i_Fila].Value.ToString() + " " + dgvSociosInactivos["Apellido", i_Fila].Value.ToString() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (drEliminar == DialogResult.OK)
                {
                    Socios oSocios = new Socios();
                    if (oSocios.Delete(Convert.ToInt32(dgvSociosInactivos["idSocio", i_Fila].Value))) { f_FillGridSociosInactivos(); MessageBox.Show("Socio eliminado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information); } else { MessageBox.Show("Se ha producido un error al intenar eliminar definitivamente al socio. Por favor, intente mas tarde.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un socio.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            f_BuscarSocio();
        }
        #endregion

        #region ETC
        private void cboFiltroSocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboFiltroSociosInactivos.SelectedItem.ToString().Trim())
                {
                    case "Apellido":
                        s_Filtro = "S.Apellido";
                        break;

                    case "Nombre":
                        s_Filtro = "S.Nombre";
                        break;

                    case "Nro. de Documento":
                        s_Filtro = "S.NroDoc";
                        break;

                    case "Fecha de registracion":
                        s_Filtro = "S.FechaRegistracion>='" + dtpSociosDesde.Value.ToShortDateString() + "' AND S.FechaRegistracion<='" + dtpSociosHasta.Value.ToShortDateString() + "' ORDER BY S.FechaRegistracion ASC";
                        txtBuscarSocio.Visible = false;
                        lbSociosDesde.Visible = true;
                        lbSociosHasta.Visible = true;
                        dtpSociosDesde.Visible = true;
                        dtpSociosHasta.Visible = true;
                        break;
                }

                if (cboFiltroSociosInactivos.SelectedItem.ToString().Trim() != "Fecha de registracion")
                {
                    txtBuscarSocio.Visible = true;
                    lbSociosDesde.Visible = false;
                    lbSociosHasta.Visible = false;
                    dtpSociosDesde.Visible = false;
                    dtpSociosHasta.Visible = false;
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public void f_FillGridSociosInactivos()
        {
            try
            {
                Socios oSocios = new Socios();
                DataTable dtSocios = oSocios.GetAllSL("S.idSocio, S.NroDoc as 'Nro. Doc.', S.Nombre, S.Apellido, S.FechaNacimiento as 'Fecha Nac.', S.Edad, S.Sexo, S.Direccion, L.Nombre as 'Localidad', S.TelefonoFijo as 'Tel. Fijo', S.TelefonoCelular as 'Tel. Celular', S.FechaRegistracion as 'Fecha Registro'", "S.Estado=0 ORDER BY S.Apellido ASC");
                dgvSociosInactivos.DataSource = dtSocios;
                dgvSociosInactivos.Columns["idSocio"].Visible = false;
                dgvSociosInactivos.ClearSelection();
                lbCantidad.Text = "Cantidad: " + dgvSociosInactivos.Rows.Count.ToString();
            }
            catch (Exception) { }
        }

        public void f_BuscarSocio()
        {
            try
            {
                Socios oSocios = new Socios();
                if (txtBuscarSocio.Visible == true)
                {
                    if (txtBuscarSocio.Text != "")
                    {
                        DataTable DT = oSocios.GetAllSL("S.idSocio, S.NroDoc as 'Nro. Doc.', S.Nombre, S.Apellido, S.FechaNacimiento as 'Fecha Nac.', S.Edad, S.Sexo, S.Direccion, L.Nombre as 'Localidad', S.TelefonoFijo as 'Tel. Fijo', S.TelefonoCelular as 'Tel. Celular', S.FechaRegistracion as 'Fecha Registro'", "S.Estado=0 AND " + s_Filtro + " LIKE '%" + txtBuscarSocio.Text.ToString() + "%' ORDER BY " + s_Filtro + " ASC");
                        dgvSociosInactivos.DataSource = DT;
                        dgvSociosInactivos.Columns["idSocio"].Visible = false;
                    }
                    else { f_FillGridSociosInactivos(); }
                }
                else
                {
                    s_Filtro = "S.FechaRegistracion>='" + dtpSociosDesde.Value.ToShortDateString() + "' AND S.FechaRegistracion<='" + dtpSociosHasta.Value.ToShortDateString() + "' ORDER BY S.FechaRegistracion ASC";
                    DataTable DT = oSocios.GetAllSL("S.idSocio, S.NroDoc as 'Nro. Doc.', S.Nombre, S.Apellido, S.FechaNacimiento as 'Fecha Nac.', S.Edad, S.Sexo, S.Direccion, L.Nombre as 'Localidad', S.TelefonoFijo as 'Tel. Fijo', S.TelefonoCelular as 'Tel. Celular', S.FechaRegistracion as 'Fecha Registro'", "S.Estado=0 AND " + s_Filtro);
                    dgvSociosInactivos.DataSource = DT;
                    dgvSociosInactivos.Columns["idSocio"].Visible = false;
                }
                lbCantidad.Text = "Cantidad: " + dgvSociosInactivos.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }
        #endregion
    }
}