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
    public partial class frmRegistrarEditarServicio : Form
    {

        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarServicio.
        /// </summary>
        public static int idServicio = 0;
        #endregion

        public frmRegistrarEditarServicio()
        {
            InitializeComponent();
        }


        private void frmRegistrarEditarServicio_Load(object sender, EventArgs e)
        {
            try
            {
                if (idServicio == 0)
                {
                    f_ClearAll();
                }
                else
                {
                    Servicios oServicios = new Servicios();
                    Servicios.Servicio oServicio = oServicios.GetOne(idServicio);

                    txtNombre.Text = oServicio.Nombre.Trim();
                    numPrecio1.Value = oServicio.Precio1;
                    numPrecio2.Value = oServicio.Precio2;
                    txtDescripcion.Text = oServicio.Descripcion.Trim();
                }
            }
            catch (Exception) { }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Servicios oServicios = new Servicios();
                Servicios.Servicio oServicio = new Servicios.Servicio();

                if (idServicio == 0)
                {
                    oServicio.Nombre = txtNombre.Text.Trim();
                    oServicio.Precio1 = numPrecio1.Value;
                    oServicio.Precio2 = numPrecio2.Value;
                    oServicio.Descripcion = txtDescripcion.Text.Trim();
                    oServicio.Estado = 1;

                    oServicios.Insert(oServicio);
                    f_ClearAll();
                    MessageBox.Show("El servicio se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oServicio.idServicio = idServicio;
                    oServicio.Nombre = txtNombre.Text.Trim();
                    oServicio.Precio1 = numPrecio1.Value;
                    oServicio.Precio2 = numPrecio2.Value;
                    oServicio.Descripcion = txtDescripcion.Text.Trim();
                    oServicio.Estado = 1;

                    oServicios.Update(oServicio);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region FUNCIONES
        public void f_ClearAll()
        {
            try
            {
                txtNombre.Clear();
                numPrecio1.Value = 0;
                numPrecio2.Value = 0;
                txtDescripcion.Clear();
            }
            catch (Exception) { }
        }
        #endregion
    }
}