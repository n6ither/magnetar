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
    public partial class frmServicios : Form
    {
        public frmServicios()
        {
            InitializeComponent();
        }


        #region LOAD Y DATAGRIDVIEW
        private void frmServicios_Load(object sender, EventArgs e)
        {
            f_FillGridServicios();
        }

        private void dgvServicios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i_Fila = dgvServicios.CurrentRow.Index;
                frmRegistrarEditarServicio.idServicio = Convert.ToInt32(dgvServicios["idServicio", i_Fila].Value);
                frmRegistrarEditarServicio frm = new frmRegistrarEditarServicio();
                frm.Text = "Magnetar Gym Management | Editar servicio";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridServicios(); }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnRegistrarServicio_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarEditarServicio.idServicio = 0;
                frmRegistrarEditarServicio frm = new frmRegistrarEditarServicio();
                frm.Text = "Magnetar Gym Management | Registrar servicio";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridServicios(); }
            }
            catch (Exception) { }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvServicios.CurrentRow.Index;
                DialogResult drBaja = MessageBox.Show("Esta seguro que desea dar de baja el servicio " + dgvServicios["Nombre", i_Fila].Value.ToString() + "?", "Dar de baja servicio", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (drBaja == DialogResult.OK)
                {
                    Servicios oServicios = new Servicios();
                    oServicios.Disable(Convert.ToInt32(dgvServicios["idServicio", i_Fila].Value));
                    f_FillGridServicios();
                    MessageBox.Show("El servicio ha sido dado de baja correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBuscar.Text != "")
                {
                    Servicios oServicios = new Servicios();
                    DataTable dtServicios = oServicios.GetAll("idServicio, Nombre, Precio1 as 'Precio 1'", "Estado=1 AND Nombre LIKE '%" + txtBuscar.Text.Trim() + "%' ORDER BY Nombre ASC");
                    dgvServicios.DataSource = dtServicios;
                    dgvServicios.Columns["idServicio"].Visible = false;
                }
                else
                {
                    f_FillGridServicios();
                }
            }
            catch (Exception) { f_FillGridServicios(); }
        }
        #endregion

        #region FUNCIONES
        public void f_FillGridServicios()
        {
            try
            {
                Servicios oServicios = new Servicios();
                DataTable dtServicios = oServicios.GetAll("idServicio, Nombre, Precio1 as 'Precio 1'", "Estado=1");
                dgvServicios.DataSource = dtServicios;
                dgvServicios.Columns["idServicio"].Visible = false;
            }
            catch (Exception) { }
        }
        #endregion
    }
}