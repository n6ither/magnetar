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
    public partial class frmRegistrarEditarUsuario : Form
    {
        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarUsuario.
        /// </summary>
        public static int idUsuario = 0;
        #endregion

        public frmRegistrarEditarUsuario()
        {
            InitializeComponent();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text.Length < 6) { MessageBox.Show("El nombre de usuario debe tener por lo menos seis caracteres. Por favor, verifica el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtPassword.Text.Length < 6) { MessageBox.Show("La contraseña debe tener por lo menos seis caracteres. Por favor, verifica el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtPassword.Text.Trim() != txtRepetirPassword.Text.Trim()) { MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                if (idUsuario == 0)
                {
                    Usuarios oUsuarios = new Usuarios();
                    Usuarios.Usuario oUsuario = new Usuarios.Usuario();
                    GestorLogin oGestorLogin = new GestorLogin();

                    oUsuario.Username = txtUsuario.Text.Trim();
                    oUsuario.Password = GestorLogin.EncriptarPWD(txtUsuario.Text.Trim() + txtPassword.Text.Trim());
                    oUsuario.Email=txtEmail.Text.Trim();

                    oUsuarios.Insert(oUsuario);
                    MessageBox.Show("El usuario ha sido creado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
