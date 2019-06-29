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
    public partial class frmRegistrarPagoMembresia : Form
    {
        public frmRegistrarPagoMembresia()
        {
            InitializeComponent();
        }

        #region LOAD & DATAGRIDVIEW
        private void frmRegistrarCobro_Load(object sender, EventArgs e)
        {
            f_FillGridMembresias();
        }

        private void dgvMembresias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMembresias.CurrentCell.ColumnIndex == 0)
                {
                    dgvMembresias.EditMode = DataGridViewEditMode.EditOnF2;
                }
                else
                {
                    dgvMembresias.EditMode = DataGridViewEditMode.EditProgrammatically;
                }
            }
            
            catch (Exception) { }
        }

        private void dgvMembresias_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvMembresias.CurrentRow.Index;
                numMonto.Value = Convert.ToDecimal(dgvMembresias["Adeudado", i_Fila].Value);
            }
            catch (Exception) { }
        }

        private void dgvMembresias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                Membresias oMembresias = new Membresias();
                foreach (DataGridViewRow row in dgvMembresias.Rows)   //Coloca los colores de las filas segun los pagos. Si esta totalmente pagada, la fila es eliminada.
                {
                    switch (oMembresias.ColorMembresia(Convert.ToInt32(row.Cells["idMembresia"].Value)))
                    {
                        case "Rojo":
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            break;

                        case "Amarillo":
                            row.DefaultCellStyle.ForeColor = Color.Gold;
                            break;

                        case "Verde":
                            dgvMembresias.Rows.Remove(row); dgvMembresias.Refresh();
                            break;
                    }
                }
                dgvMembresias.ClearSelection();
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drEliminar = MessageBox.Show("Esta a punto de eliminar una membresia, esto significa que se elimininaran los cobros e historiales relacionados a dicha membresia y se reestablecera el saldo del socio. Desea continuar?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK) 
                {
                    int i_Fila= dgvMembresias.CurrentRow.Index;

                    Membresias oMembresias = new Membresias();
                    Socios oSocios = new Socios();
                    Turnos oTurnos = new Turnos();
                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();

                    //Actualiza el saldo, obtiene el nuevo saldo, elimina la membresia, resta un inscripto al turno, elimina los sociosxturno.
                    oSocios.UpdateSaldo(Convert.ToInt32(dgvMembresias["idSocio", i_Fila].Value), (Convert.ToDecimal(dgvMembresias["Adeudado", i_Fila].Value)).ToString());
                    
                    oMembresias.Delete(Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value));
                    oTurnos.AddInscripto(Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value), -1);
                    oSociosxTurnos.Delete("SocioxTurno", "SocioxTurno.idSocio=" + Convert.ToInt32(dgvMembresias["idSocio", i_Fila].Value) + " AND SocioxTurno.idTurno=" + Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value));

                    f_FillGridMembresias();
                    MessageBox.Show("La membresia ha sido eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (IndexOutOfRangeException) { MessageBox.Show("Por favor, selecciona un registro.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            catch (Exception) { MessageBox.Show("Se ha producido un error, por favor intenta nuevamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvMembresias.CurrentRow.Index;
                if (numMonto.Value <= 0) { MessageBox.Show("El monto debe ser mayor a $0,00. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (numMonto.Value > Convert.ToDecimal(dgvMembresias["Adeudado", i_Fila].Value)) { MessageBox.Show("El monto a pagar no puede ser mayor al adeudado. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                PagosMembresias oPagosMembresias = new PagosMembresias();
                PagosMembresias.PagoMembresia oPagoMembresia = new PagosMembresias.PagoMembresia();
                oPagoMembresia.idMembresia = Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value);
                oPagoMembresia.Fecha = DateTime.Now.Date;
                oPagoMembresia.Monto = numMonto.Value;
                oPagosMembresias.Insert(oPagoMembresia);

                Socios oSocios = new Socios();
                oSocios.UpdateSaldo(frmRegistrarEditarSocio.idSocio, numMonto.Value.ToString());

                MessageBox.Show("El pago se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (NullReferenceException) { MessageBox.Show("Por favor, selecciona una membresia.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region FUNCIONES
        public void f_FillGridMembresias()
        {
            try
            {
                Membresias oMembresias = new Membresias();
                DataTable dtMembresias = oMembresias.GetAllMix("Membresia.idMembresia, Actividad.idActividad, Socio.idSocio, Turno.idTurno, Actividad.Nombre as 'Actividad', Turno.Hora as 'Turno', Membresia.FechaInicio as 'Inicio', Membresia.FechaVencimiento as 'Vencimiento', Membresia.Precio, Membresia.Descuento, Membresia.Total", "Socio.idSocio=" + frmRegistrarEditarSocio.idSocio + " AND Actividad.Estado=1 AND Membresia.idSocio=Socio.idSocio AND Membresia.idActividad=Actividad.idActividad AND Turno.idActividad=Actividad.idActividad AND Membresia.idTurno=Turno.idTurno");

                if (!dtMembresias.Columns.Contains("Pagado"))   //Crea la columna Pagado.
                {
                    DataColumn colPagado = new DataColumn();
                    dtMembresias.Columns.Add("Pagado", typeof(string));
                }

                if (!dtMembresias.Columns.Contains("Adeudado"))   //Crea la columna Adeudado.
                {
                    DataColumn colAdeudado = new DataColumn();
                    dtMembresias.Columns.Add("Adeudado", typeof(string));
                }

                for (int i = 0; i < dtMembresias.Rows.Count; i++)   //Asigna los valores a las columnas creadas.
                {
                    dtMembresias.Rows[i]["Pagado"] = oMembresias.CuantoPago(Convert.ToInt32(dtMembresias.Rows[i]["idMembresia"]));
                    dtMembresias.Rows[i]["Adeudado"] = Convert.ToString(Convert.ToDecimal(dtMembresias.Rows[i]["Total"]) - Convert.ToDecimal(dtMembresias.Rows[i]["Pagado"]));
                }

                dgvMembresias.DataSource = dtMembresias;
                dgvMembresias.Columns["idMembresia"].Visible = false;
                dgvMembresias.Columns["idActividad"].Visible = false;
                dgvMembresias.Columns["idSocio"].Visible = false;
                dgvMembresias.Columns["idTurno"].Visible = false;
                dgvMembresias.ClearSelection();
            }
            catch (Exception) { }
        }
        #endregion
    }
}