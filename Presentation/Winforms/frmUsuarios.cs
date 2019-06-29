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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
        }


        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            f_FillGridUsuarios();
        }

        private void btnCambiarPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmCambiarPwd"] != null) Application.OpenForms["frmCambiarPwd"].Close();
                int i_Fila=dgvUsuarios.CurrentRow.Index;
                frmCambiarPwd.Username = dgvUsuarios["Usuario", i_Fila].Value.ToString().Trim();
                frmCambiarPwd frm = new frmCambiarPwd();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvUsuarios.CurrentRow.Index;
                if (dgvUsuarios["Usuario", i_Fila].Value.ToString() == "admin") { MessageBox.Show("El usuario administrador no puede ser eliminado.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                DialogResult drEliminar = MessageBox.Show("Esta seguro que desea eliminar al usuario '" + dgvUsuarios["Usuario", i_Fila].Value.ToString() + "'?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK)
                {
                    Usuarios oUsuarios = new Usuarios();
                    oUsuarios.Delete("Usuario", "idUsuario=" + Convert.ToInt32(dgvUsuarios["idUsuario", i_Fila].Value));
                    MessageBox.Show("Usuario eliminado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_FillGridUsuarios();
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un usuario.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarEditarUsuario.idUsuario = 0;
                frmRegistrarEditarUsuario frm = new frmRegistrarEditarUsuario();
                frm.Text = "Magnetar Gym Management | Registrar usuario";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridUsuarios(); }
            }
            catch (Exception) { }
        }

        #region FUNCIONES
        public void f_FillGridUsuarios()
        {
            try
            {
                Usuarios oUsuarios = new Usuarios();
                DataTable dtUsuarios = oUsuarios.GetAll("idUsuario, Username as 'Usuario', Email", "");
                dgvUsuarios.DataSource = dtUsuarios;
                dgvUsuarios.Columns["idUsuario"].Visible = false;
                dgvUsuarios.ClearSelection();
            }
            catch (Exception) { }
        }
        #endregion
    }
}
