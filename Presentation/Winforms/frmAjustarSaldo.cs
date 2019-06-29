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
    public partial class frmAjustarSaldo : Form
    {
        public frmAjustarSaldo()
        {
            InitializeComponent();
        }

        #region FORM
        private void frmAjustarSaldo_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now.Date;
        }
        #endregion

        #region BUTTONS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Ajustes oAjustes = new Ajustes();   //Inserta el nuevo ajuste y actualiza el saldo del socio.
                Ajustes.Ajuste oAjuste = new Ajustes.Ajuste();
                oAjuste.idSocio = frmRegistrarEditarSocio.idSocio;
                oAjuste.Monto = numMonto.Value;
                oAjuste.Fecha = dtpFecha.Value.Date;
                oAjuste.Descripcion = txtDescripcion.Text.Trim();
                oAjustes.Insert(oAjuste);

                Socios oSocios = new Socios();
                oSocios.UpdateSaldo(frmRegistrarEditarSocio.idSocio, numMonto.Value.ToString());

                MessageBox.Show("El saldo se ha ajustado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { MessageBox.Show("Se ha producido un error al ajustar el saldo. Por favor, intente mas tarde.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
