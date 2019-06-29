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
    public partial class frmLocalidades : Form
    {
        public frmLocalidades()
        {
            InitializeComponent();
        }

        #region FORM & DATAGRIDVIEW
        private void frmLocalidades_Load(object sender, EventArgs e)
        {
            f_FillGridLocalidades();
        }

        private void dgvLocalidades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int i_Fila = dgvLocalidades.CurrentRow.Index;
                frmRegistrarEditarLocalidad.idLocalidad = Convert.ToInt32(dgvLocalidades["idLocalidad", i_Fila].Value);
                frmRegistrarEditarLocalidad frm = new frmRegistrarEditarLocalidad();
                frm.Text = "Magnetar Gym Management | Editar localidad";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    f_FillGridLocalidades();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarLocalidad"] != null) Application.OpenForms["frmRegistrarEditarLocalidad"].Close();
                frmRegistrarEditarLocalidad.idLocalidad = 0;
                frmRegistrarEditarLocalidad frm = new frmRegistrarEditarLocalidad();
                frm.Text = "Magnetar Gym Management | Registrar localidad";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    f_FillGridLocalidades();
                }
            }
            catch (Exception) { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvLocalidades.CurrentRow.Index;
                Localidades oLocalidades = new Localidades();
                DialogResult drEliminar = MessageBox.Show("Esta seguro que desea eliminar a " + dgvLocalidades["Nombre", i_Fila].Value.ToString().Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (drEliminar == DialogResult.OK)
                {
                    oLocalidades.Delete("idLocalidad=" + Convert.ToInt32(dgvLocalidades["idLocalidad", i_Fila].Value));
                    f_FillGridLocalidades();
                    MessageBox.Show("Localidad eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FUNCIONES
        public void f_FillGridLocalidades()
        {
            try
            {
                Localidades oLocalidades = new Localidades();
                DataTable dtLocalidades = oLocalidades.GetAll("idLocalidad, Nombre, CodigoPostal as 'Codigo Postal', Provincia, Pais", "");
                dgvLocalidades.DataSource = dtLocalidades;
                dgvLocalidades.Columns["idLocalidad"].Visible = false;
                dgvLocalidades.ClearSelection();
            }
            catch (Exception) { }
        }
        #endregion
    }
}
