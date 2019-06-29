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
    public partial class frmRegistrarEditarLocalidad : Form
    {
        #region VARIABLES
        public static int idLocalidad = 0;
        #endregion

        public frmRegistrarEditarLocalidad()
        {
            InitializeComponent();
        }

        #region FORM
        private void frmRegistrarEditarLocalidad_Load(object sender, EventArgs e)
        {
            try
            {
                cboPais.Text = "Argentina";
                txtNombre.Select();

                if (idLocalidad == 0)
                {

                }
                else
                {
                    Localidades oLocalidades = new Localidades();
                    Localidades.Localidad oLocalidad = oLocalidades.GetOne(idLocalidad);

                    txtNombre.Text = oLocalidad.Nombre;
                    txtCodigoPostal.Text = oLocalidad.CodigoPostal.ToString();
                    txtProvincia.Text = oLocalidad.Provincia;
                    cboPais.Text = oLocalidad.Pais;
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTON
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Localidades oLocalidades = new Localidades();
                Localidades.Localidad oLocalidad = new Localidades.Localidad();

                if (idLocalidad == 0)
                {
                    oLocalidad.Nombre = txtNombre.Text.Trim();
                    oLocalidad.CodigoPostal = Convert.ToInt32(txtCodigoPostal.Text);
                    oLocalidad.Provincia = txtProvincia.Text.Trim();
                    oLocalidad.Pais = cboPais.Text.Trim();

                    oLocalidades.Insert(oLocalidad);
                    MessageBox.Show("La localidad se registro correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oLocalidad.idLocalidad = idLocalidad;
                    oLocalidad.Nombre = txtNombre.Text.Trim();
                    oLocalidad.CodigoPostal = Convert.ToInt32(txtCodigoPostal.Text);
                    oLocalidad.Provincia = txtProvincia.Text.Trim();
                    oLocalidad.Pais = cboPais.Text.Trim();

                    oLocalidades.Update(oLocalidad);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ETC
        private void txtCodigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar)) { e.Handled = true; }
            }
            catch (Exception) { }
        }
        #endregion
    }
}