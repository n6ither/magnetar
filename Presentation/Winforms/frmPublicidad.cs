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
    public partial class frmPublicidad : Form
    {
        #region VARIABLES
        public static string s_SizeMode = "Normal";
        #endregion

        public frmPublicidad()
        {
            InitializeComponent();
        }

        private void frmPublicidad_Load(object sender, EventArgs e)
        {
            try
            {
                Publicidades oPublicidades = new Publicidades();
                Publicidades.Publicidad oPublicidad = oPublicidades.GetTheOne();

                txtTexto.Rtf = oPublicidad.Texto.Replace("$$", "'");
                txtTexto.SelectAll();
                txtTexto.SelectionAlignment = HorizontalAlignment.Center;

                if (oPublicidad.Imagen != "" && File.Exists(oPublicidad.Imagen)) { pbPublicidad.Load(oPublicidad.Imagen); } else { pbPublicidad.Image = null; }
                switch (oPublicidad.SizeMode.Trim())
                {
                    case "Zoom":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.Zoom;
                        break;

                    case "CenterImage":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;

                    case "Normal":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.Normal;
                        break;

                    case "StretchImage":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;
                }
            }
            catch (Exception) { }
        }

        #region BUTTONS
        private void btnFuente_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialogoFuente.ShowDialog() == DialogResult.OK) { if (txtTexto.SelectedText != "") { txtTexto.SelectionFont = dialogoFuente.Font; } }
                txtTexto.SelectAll();
                txtTexto.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception) { }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialogoColor.ShowDialog() == DialogResult.OK) { txtTexto.SelectionColor = dialogoColor.Color; }
            }
            catch (Exception) { }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgImagen.ShowDialog() == DialogResult.OK) { pbPublicidad.Load(dlgImagen.FileName); }
            }
            catch (Exception) { }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                pbPublicidad.Image = null; pbPublicidad.ImageLocation = "";
            }
            catch (Exception) { }
        }

        private void btnRedimensionar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (pbPublicidad.SizeMode.ToString().Trim())
                {
                    case "Zoom":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.CenterImage; s_SizeMode = "CenterImage";
                        break;

                    case "CenterImage":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.Normal; s_SizeMode = "Normal";
                        break;

                    case "Normal":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.StretchImage; s_SizeMode = "StretchImage";
                        break;

                    case "StretchImage":
                        pbPublicidad.SizeMode = PictureBoxSizeMode.Zoom; s_SizeMode = "Zoom";
                        break;
                }
            }
            catch (Exception) { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Publicidades oPublicidades = new Publicidades();
                Publicidades.Publicidad oPublicidad = new Publicidades.Publicidad();
                oPublicidades.TruncateTable();

                txtTexto.SelectAll();
                txtTexto.SelectionAlignment = HorizontalAlignment.Center;
                oPublicidad.Texto = txtTexto.Rtf.Replace("'", "$$");
                oPublicidad.Imagen = pbPublicidad.ImageLocation;
                oPublicidad.SizeMode = s_SizeMode;
                oPublicidades.Insert(oPublicidad);

                this.Close();
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}