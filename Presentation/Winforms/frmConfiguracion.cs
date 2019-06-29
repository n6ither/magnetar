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
using Presentation.Winforms;

namespace Presentation.Winforms
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void btnAdministrarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmUsuarios"] != null) Application.OpenForms["frmUsuarios"].Close();
                frmUsuarios frm = new frmUsuarios();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }

        private void btnPublicidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmPublicidad"] != null) Application.OpenForms["frmPublicidad"].Close();
                frmPublicidad frm = new frmPublicidad();
                frm.Show();
            }
            catch (Exception) { }
        }

        private void btnMiGimnasio_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmMiGimnasio"] != null) Application.OpenForms["frmMiGimnasio"].Close();
                frmMiGimnasio frm = new frmMiGimnasio();
                frm.Show();
            }
            catch (Exception) { }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmEmail"] != null) Application.OpenForms["frmEmail"].Close();
                frmEmail frm = new frmEmail();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }
    }
}