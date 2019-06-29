using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Logic;

namespace Presentation.Winforms
{
    public partial class frmCasilleros : Form
    {
        public frmCasilleros()
        {
            InitializeComponent();
        }

        #region FORM && DATAGRIDVIEW
        private void frmCasilleros_Load(object sender, EventArgs e)
        {
            f_FillGrid();
        }

        private void dgvCasilleros_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvCasilleros.CurrentRow.Index;
                Socios oSocios = new Socios();
                Socios.Socio oSocio = oSocios.GetOne(Convert.ToInt32(dgvCasilleros["idSocio", i_Fila].Value));

                if (oSocio.Imagen != "" && File.Exists(oSocio.Imagen)) { pbSocio.Load(oSocio.Imagen); } else { pbSocio.Image = Properties.Resources.sociodefault; }
                lbSocio.Text = oSocio.Nombre.Trim() + " " + oSocio.Apellido.Trim();
                txtNumero.Text = dgvCasilleros["Casillero #", i_Fila].Value.ToString();
                txtFechaInicio.Text = Convert.ToDateTime(dgvCasilleros["FechaInicio", i_Fila].Value).ToShortDateString();
                txtFechaVencimiento.Text = Convert.ToDateTime(dgvCasilleros["FechaVencimiento", i_Fila].Value).ToShortDateString();
                txtPrecio.Text = dgvCasilleros["Precio", i_Fila].Value.ToString();

                TimeSpan ts_Dias = Convert.ToDateTime(dgvCasilleros["FechaVencimiento", i_Fila].Value) - DateTime.Now.Date;
                lbDiasVencimiento.Text = ts_Dias.Days.ToString() + " dia(s)";

                Casilleros oCasilleros = new Casilleros();
                txtPago.Text = oCasilleros.CuantoPago(Convert.ToInt32(dgvCasilleros["idCasillero", i_Fila].Value));

                txtPago.BackColor = Color.White;
                switch(oCasilleros.ColorCasillero(Convert.ToInt32(dgvCasilleros["idCasillero", i_Fila].Value)))
                {
                    case "Rojo":
                        txtPago.ForeColor=Color.Red;
                        break;

                    case "Amarillo":
                        txtPago.ForeColor = Color.Gold;
                        break;

                    case "Verde":
                        txtPago.ForeColor = Color.Green;
                        break;
                }
            }
            catch (Exception) { f_ClearAll(); }
        }
        #endregion

        #region BUTTONS
        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsignarCasillero frm = new frmAsignarCasillero();
                frm.ShowDialog();
                f_FillGrid();
            }
            catch (Exception) { }
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvCasilleros.CurrentRow.Index;
                DialogResult drLiberar = MessageBox.Show("Esta seguro que desea liberar el casillero numero " + dgvCasilleros["Casillero #", i_Fila].Value.ToString() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drLiberar == DialogResult.OK)
                {
                    Casilleros oCasilleros = new Casilleros();
                    oCasilleros.Disable(Convert.ToInt32(dgvCasilleros["idCasillero", i_Fila].Value));
                    f_FillGrid();
                    f_ClearAll();
                    MessageBox.Show("El casillero se liberó correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public void f_FillGrid()
        {
            try
            {
                Casilleros oCasilleros = new Casilleros();
                DataTable dtCasilleros = oCasilleros.GetAll("idCasillero, idSocio, Numero as 'Casillero #', Precio, FechaInicio, FechaVencimiento, Estado", "Estado=1");
                dgvCasilleros.DataSource = dtCasilleros;
                dgvCasilleros.Columns["idCasillero"].Visible = false;
                dgvCasilleros.Columns["idSocio"].Visible = false;
                dgvCasilleros.Columns["Precio"].Visible = false;
                dgvCasilleros.Columns["FechaInicio"].Visible = false;
                dgvCasilleros.Columns["FechaVencimiento"].Visible = false;
                dgvCasilleros.Columns["Estado"].Visible = false;
                dgvCasilleros.ClearSelection();

                if (dgvCasilleros.Rows.Count == 0) { lbCantidadCasilleros.Text = "Aún no has asigado ningun casillero. Haz click en 'Asignar'."; } else { lbCantidadCasilleros.Text = "Cantidad: " + dgvCasilleros.Rows.Count.ToString(); }
            }
            catch (Exception) { }
        }

        public void f_ClearAll()
        {
            try
            {
                pbSocio.Image = null; pbSocio.ImageLocation = "";
                lbSocio.Text = "";
                txtNumero.Text = "";
                txtFechaInicio.Text = "";
                txtFechaVencimiento.Text = "";
                txtPrecio.Text = "";
                txtPago.Text = "";
                lbDiasVencimiento.Text = "";
            }
            catch (Exception) { }
        }
        #endregion
    }
}
