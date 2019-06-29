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
    public partial class frmMiGimnasio : Form
    {
        public frmMiGimnasio()
        {
            InitializeComponent();
        }

        #region FORM
        private void frmMiGimnasio_Load(object sender, EventArgs e)
        {
            try
            {
                Funciones.f_FillComboBox(cboLocalidad, "idLocalidad", "Nombre", "", "Localidad", "", "Nombre");

                Gimnasios oGimnasios = new Gimnasios();
                Gimnasios.Gimnasio oGimnasio = oGimnasios.GetTheOne();

                if (oGimnasio == null) 
                { 
                    cboLocalidad.SelectedIndex = 0; 
                }
                else
                {
                    txtNombre.Text = oGimnasio.Nombre.ToString().Trim();
                    txtDireccion.Text = oGimnasio.Direccion.ToString().Trim();
                    cboLocalidad.SelectedValue = oGimnasio.idLocalidad;
                    txtTelefonoFijo.Text = oGimnasio.TelefonoFijo.ToString().Trim();
                    txtTelefonoCelular.Text = oGimnasio.TelefonoCelular.ToString().Trim();
                    txtEmail.Text = oGimnasio.Email.ToString().Trim();
                    if (oGimnasio.Logo != "" && File.Exists(oGimnasio.Logo)) { pbLogoGimnasio.Load(oGimnasio.Logo); } else { pbLogoGimnasio.Image = Properties.Resources.gymdefault1; }
                    if (oGimnasio.SizeMode != null || oGimnasio.SizeMode != "")
                    {
                        switch (oGimnasio.SizeMode.Trim())
                        {
                            case "Zoom":
                                pbLogoGimnasio.SizeMode = PictureBoxSizeMode.Zoom;
                                break;

                            case "CenterImage":
                                pbLogoGimnasio.SizeMode = PictureBoxSizeMode.CenterImage;
                                break;

                            case "Normal":
                                pbLogoGimnasio.SizeMode = PictureBoxSizeMode.Normal;
                                break;

                            case "StretchImage":
                                pbLogoGimnasio.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                        }
                    }
                    else { pbLogoGimnasio.SizeMode = PictureBoxSizeMode.Normal; }
                }

                
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnRegistrarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmLocalidades"] != null) Application.OpenForms["frmLocalidades"].Close();
                frmLocalidades frm = new frmLocalidades();
                frm.ShowDialog();
                Funciones.f_FillComboBox(cboLocalidad, "idLocalidad", "Nombre", "", "Localidad", "", "Nombre");
            }
            catch (Exception) { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombre.Text == "" || txtDireccion.Text == "" || cboLocalidad.SelectedIndex==-1) { MessageBox.Show("Nombre, direccion y localidad son campos obligatorios, por favor completalos.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                Gimnasios oGimnasios = new Gimnasios();
                Gimnasios.Gimnasio oGimnasio = new Gimnasios.Gimnasio();
                oGimnasio.Nombre = txtNombre.Text.ToString().Trim();
                oGimnasio.Direccion = txtDireccion.Text.ToString().Trim();
                oGimnasio.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                oGimnasio.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                oGimnasio.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                oGimnasio.Email = txtEmail.Text.ToString().Trim();

                if (pbLogoGimnasio.ImageLocation == "" || pbLogoGimnasio.ImageLocation == null)
                {
                    oGimnasio.Logo = ""; oGimnasio.SizeMode = "Normal";
                }
                else
                {
                    oGimnasio.Logo = pbLogoGimnasio.ImageLocation; oGimnasio.SizeMode = pbLogoGimnasio.SizeMode.ToString();
                }

                oGimnasios.TruncateTable();
                oGimnasios.Insert(oGimnasio);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { MessageBox.Show("Se ha producido un error al intentar actualizar los datos del gimnasio. Por favor, intente mas tarde.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ETC
        private void pbLogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgLogo.ShowDialog() == DialogResult.OK) { pbLogoGimnasio.Load(dlgLogo.FileName); }
            }
            catch (Exception) { }
        }
        #endregion

        #region CONTEXT MENU
        private void cmsCargarLogo_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgLogo.ShowDialog() == DialogResult.OK) { pbLogoGimnasio.Load(dlgLogo.FileName); }
            }
            catch (Exception) { }
        }

        private void cmsRedimensionarLogo_Click(object sender, EventArgs e)
        {
            try
            {
                switch (pbLogoGimnasio.SizeMode.ToString().Trim())
                {
                    case "Zoom":
                        pbLogoGimnasio.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;

                    case "CenterImage":
                        pbLogoGimnasio.SizeMode = PictureBoxSizeMode.Normal;
                        break;

                    case "Normal":
                        pbLogoGimnasio.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                    case "StretchImage":
                        pbLogoGimnasio.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                }
            }
            catch (Exception) { }
        }

        private void cmsQuitarLogo_Click(object sender, EventArgs e)
        {
            try
            {
                pbLogoGimnasio.Image = Properties.Resources.gymdefault1; pbLogoGimnasio.ImageLocation = ""; pbLogoGimnasio.SizeMode = PictureBoxSizeMode.Normal;
            }
            catch (Exception) { }
        }
        #endregion
    }
}
