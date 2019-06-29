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
    public partial class frmAsignarCasillero : Form
    {
        #region VARIABLES
        /// <summary>
        /// Obtiene o establece el socio que ocupa determinado casillero.
        /// </summary>
        public static int idSocio = 0;
        #endregion

        public frmAsignarCasillero()
        {
            InitializeComponent();
        }

        #region FORM
        private void frmAsignarCasillero_Load(object sender, EventArgs e)
        {
            try
            {
                dtpInicio.MinDate = DateTime.Now.Date;
                dtpVencimiento.MinDate = dtpInicio.Value;
                Funciones.f_FillComboBox(cboSocios, "idSocio", "Nombre+' '+Apellido as 'Nombre'", "Nombre", "Socio", "Estado=1", "Nombre ASC");
                if (idSocio != 0) { cboSocios.SelectedValue = idSocio; }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Valida la operacion.
                Casilleros oCasilleros = new Casilleros();
                DataTable dtCasilleros = oCasilleros.GetAll("*", "Estado=1 AND Numero=" + numNumero.Value.ToString());
                if (dtCasilleros.Rows.Count > 0) { MessageBox.Show("El casillero Nro. " + numNumero.Value.ToString() + " ya se encuentra ocupado. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (cboSocios.SelectedIndex == -1) { MessageBox.Show("Debe seleccionar un socio. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (numPrecio.Value <= 0) { MessageBox.Show("El precio debe ser mayor a cero. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                dtCasilleros = oCasilleros.GetAll("*", "Estado=1 AND idSocio=" + cboSocios.SelectedValue.ToString());
                if (dtCasilleros.Rows.Count > 0) { MessageBox.Show("Este socio ya cuenta con un casillero asignado. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                Casilleros.Casillero oCasillero = new Casilleros.Casillero();
                oCasillero.Numero = Convert.ToInt32(numNumero.Value);
                oCasillero.idSocio = Convert.ToInt32(cboSocios.SelectedValue);
                oCasillero.FechaInicio = dtpInicio.Value;
                oCasillero.FechaVencimiento = dtpVencimiento.Value;
                oCasillero.Precio = numPrecio.Value;
                oCasillero.Estado = 1;

                int idCasillero = oCasilleros.Insert(oCasillero);

                Socios oSocios = new Socios();
                oSocios.UpdateSaldo(Convert.ToInt32(cboSocios.SelectedValue), Convert.ToString(numPrecio.Value * -1));

                MessageBox.Show("El casillero se ha asignado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                f_ClearAll();
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ETc
        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpVencimiento.MinDate = dtpInicio.Value;
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public void f_ClearAll()
        {
            try
            {
                numNumero.Value = 1;
                cboSocios.SelectedIndex = 0;
                dtpInicio.Value = DateTime.Now;
                dtpVencimiento.Value = DateTime.Now;
                numPrecio.Value = 0;
            }
            catch (Exception) { }
        }
        #endregion
    }
}
