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
    public partial class frmRegistrarPagoCasillero : Form
    {
        public frmRegistrarPagoCasillero()
        {
            InitializeComponent();
        }

        #region FORM && DATAGRIDVIEW
        private void frmRegistrarPagoCasillero_Load(object sender, EventArgs e)
        {
            try
            {
                Casilleros oCasilleros = new Casilleros();
                DataTable dtCasilleros = oCasilleros.GetAll("idCasillero, Numero as 'Casillero #', FechaInicio as 'Inicio', FechaVencimiento as 'Vencimiento', Precio", "Casillero.idSocio=" + frmRegistrarEditarSocio.idSocio);

                if (!dtCasilleros.Columns.Contains("Pagado"))   //Crea la columna Pagado.
                {
                    DataColumn colPagado = new DataColumn();
                    dtCasilleros.Columns.Add("Pagado", typeof(string));
                }

                if (!dtCasilleros.Columns.Contains("Adeudado"))   //Crea la columna Adeudado.
                {
                    DataColumn colAdeudado = new DataColumn();
                    dtCasilleros.Columns.Add("Adeudado", typeof(string));
                }

                for (int i = 0; i < dtCasilleros.Rows.Count; i++)   //Asigna los valores a las columnas creadas.
                {
                    dtCasilleros.Rows[i]["Pagado"] = oCasilleros.CuantoPago(Convert.ToInt32(dtCasilleros.Rows[i]["idCasillero"]));
                    dtCasilleros.Rows[i]["Adeudado"] = Convert.ToString(Convert.ToDecimal(dtCasilleros.Rows[i]["Precio"]) - Convert.ToDecimal(dtCasilleros.Rows[i]["Pagado"]));
                }

                dgvCasilleros.DataSource = dtCasilleros;
                dgvCasilleros.Columns["idCasillero"].Visible = false;
                dgvCasilleros.ClearSelection();
            }
            catch (Exception) { }
        }

        private void dgvCasilleros_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                Casilleros oCasilleros = new Casilleros();
                foreach (DataGridViewRow row in dgvCasilleros.Rows)   //Coloca los colores de las filas segun los pagos. Si esta totalmente pagado, la fila es eliminada.
                {
                    switch (oCasilleros.ColorCasillero(Convert.ToInt32(row.Cells["idCasillero"].Value)))
                    {
                        case "Rojo":
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            break;

                        case "Amarillo":
                            row.DefaultCellStyle.ForeColor = Color.Gold;
                            break;

                        case "Verde":
                            dgvCasilleros.Rows.Remove(row); dgvCasilleros.Refresh();
                            break;
                    }
                }
                dgvCasilleros.ClearSelection();
            }
            catch (Exception) { }
        }

        private void dgvCasilleros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCasilleros.CurrentCell.ColumnIndex == 0)
                {
                    dgvCasilleros.EditMode = DataGridViewEditMode.EditOnF2;
                }
                else
                {
                    dgvCasilleros.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
            }

            catch (Exception) { }
        }

        private void dgvCasilleros_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvCasilleros.CurrentRow.Index;
                numMonto.Value = Convert.ToDecimal(dgvCasilleros["Adeudado", i_Fila].Value);
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvCasilleros.CurrentRow.Index;
                if (numMonto.Value <= 0) { MessageBox.Show("El monto debe ser mayor a $0,00. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (numMonto.Value > Convert.ToDecimal(dgvCasilleros["Adeudado", i_Fila].Value)) { MessageBox.Show("El monto a pagar no puede ser mayor al adeudado. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                PagosCasilleros oPagosCasilleros = new PagosCasilleros();
                PagosCasilleros.PagoCasillero oPagoCasillero = new PagosCasilleros.PagoCasillero();

                oPagoCasillero.idCasillero = Convert.ToInt32(dgvCasilleros["idCasillero", i_Fila].Value);
                oPagoCasillero.Fecha = DateTime.Now.Date;
                oPagoCasillero.Monto = numMonto.Value;
                oPagosCasilleros.Insert(oPagoCasillero);

                Socios oSocios = new Socios();
                oSocios.UpdateSaldo(frmRegistrarEditarSocio.idSocio, numMonto.Value.ToString());

                MessageBox.Show("El pago se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (NullReferenceException) { MessageBox.Show("Por favor, selecciona un casillero.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
