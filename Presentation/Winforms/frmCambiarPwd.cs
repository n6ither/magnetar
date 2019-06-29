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
    public partial class frmCambiarPwd : Form
    {
        #region VARIABLES
        public static string Username = "";
        #endregion

        public frmCambiarPwd()
        {
            InitializeComponent();
        }

        private void frmCambiarPwd_Load(object sender, EventArgs e)
        {
            try
            {
                txtUsuario.Text = Username.Trim();
                txtPwdActual.Select();
            }
            catch (Exception) { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!GestorLogin.Autentificar(txtUsuario.Text.Trim(), txtPwdActual.Text.Trim())) { MessageBox.Show("La contraseña actual es incorrecta. Por favor, verifique el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtPwdNueva.Text.Length < 6) { MessageBox.Show("La contraseña debe tener por lo menos seis caracteres. Por favor, verifica el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtPwdNueva.Text.Trim() != txtPwdRepite.Text.Trim()) { MessageBox.Show("Las contraseñas no coinciden. Por favor, verifica el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                Usuarios oUsuarios = new Usuarios();
                oUsuarios.ChangePassword(txtUsuario.Text.Trim(), GestorLogin.EncriptarPWD(txtUsuario.Text.Trim() + txtPwdNueva.Text.Trim()));
                MessageBox.Show("La contraseña se cambio correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsuario.Clear(); txtPwdActual.Clear(); txtPwdNueva.Clear(); txtPwdRepite.Clear();
                this.Close();
            }
            catch (Exception) { MessageBox.Show("Se produjo un error al intentar cambiar la contraseña.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }
    }
}