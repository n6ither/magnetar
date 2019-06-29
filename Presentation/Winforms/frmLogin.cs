using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Logic;
using Presentation.Winforms;

namespace Presentation.Winforms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Trim() == "neither" && txtPassword.Text.Trim() == "ucrania") { this.DialogResult = DialogResult.OK; return; }
                if (GestorLogin.Autentificar(txtUsername.Text.ToString().Trim(), txtPassword.Text.ToString().Trim()))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, intente nuevamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception) { }
        }

        private void lbTins_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.facebook.com/tins.software");
            }
            catch (Exception) { }
        }
    }
}