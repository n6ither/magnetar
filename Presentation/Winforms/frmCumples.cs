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
    public partial class frmCumples : Form
    {
        public frmCumples()
        {
            InitializeComponent();
        }

        private void frmCumples_Load(object sender, EventArgs e)
        {
            f_FillGrid();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            f_FillGrid();
        }

        private void dgvSocios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i_Fila = dgvSocios.CurrentRow.Index;
                frmRegistrarEditarSocio.idSocio = Convert.ToInt32(dgvSocios["idSocio", i_Fila].Value);
                if (Application.OpenForms["frmRegistrarEditarSocio"] != null) Application.OpenForms["frmRegistrarEditarSocio"].Close();
                frmRegistrarEditarSocio frm = new frmRegistrarEditarSocio();
                frm.Show();
            }
            catch (Exception) { }
        }

        #region FUNCIONES
        public void f_FillGrid()
        {
            try
            {
                Socios oSocios = new Socios();
                DataTable dtSocios = oSocios.GetAllSL("idSocio, NroDoc as 'Nro. Doc.', Nombre, Apellido, Edad, Socio.TelefonoFijo as 'Tel. Fijo', Socio.TelefonoCelular as 'Tel. Celular'", "Estado=1 AND DATEPART(d, FechaNacimiento) = DATEPART(d, '" + dtpFecha.Value.ToShortDateString() + "') AND DATEPART(m, FechaNacimiento) = DATEPART(m, '" + dtpFecha.Value.ToShortDateString() + "')");
                dgvSocios.DataSource = dtSocios;
                dgvSocios.Columns["idSocio"].Visible = false;
                dgvSocios.ClearSelection();
            }
            catch (Exception) { }
        }
        #endregion
    }
}
