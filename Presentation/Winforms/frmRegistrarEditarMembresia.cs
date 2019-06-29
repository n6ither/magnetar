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
    public partial class frmRegistrarEditarMembresia : Form
    {
        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarMembresia.
        /// </summary>
        public static int idMembresia = 0;
        public int i_Cupo = 0;
        public int i_Inscriptos = 0;
        /// <summary>
        /// Para cuando se va a cambiar el turno de la membresia.
        /// </summary>
        public int i_idTurnoAnterior = 0;
        #endregion

        public frmRegistrarEditarMembresia()
        {
            InitializeComponent();
        }

        #region LOAD
        private void frmRegistrarEditarMembresia_Load(object sender, EventArgs e)
        {
            try
            {
                Funciones.f_FillComboBox(cboActividades, "idActividad", "Nombre", "Nombre", "Actividad", "Estado=1", "Nombre ASC");
                Funciones.f_FillComboBox(cboTurnos, "idTurno", "Hora", "Hora", "Turno", "idActividad=" + cboActividades.SelectedValue, "Hora ASC");

                if (idMembresia == 0)
                {
                    cboActividades.SelectedIndex = 0; cboTurnos.SelectedIndex = 0; cboDuracion.SelectedIndex = 0;
                    dtpFechaInicio.Value = DateTime.Now; dtpFechaVencimiento.Value = DateTime.Now;
                    numDescuento.Value = 0;
                }
                else
                {
                    Membresias oMembresias = new Membresias();
                    Membresias.Membresia oMembresia = oMembresias.GetOne(idMembresia);

                    cboActividades.SelectedValue = oMembresia.idActividad; cboActividades.Enabled = false;
                    cboTurnos.SelectedValue = oMembresia.idTurno;
                    cboDuracion.Text = oMembresia.Duracion; cboDuracion.Enabled = false;
                    dtpFechaInicio.Value = oMembresia.FechaInicio; dtpFechaInicio.Enabled = false;
                    dtpFechaVencimiento.Value = oMembresia.FechaVencimiento; dtpFechaVencimiento.Enabled = false;
                    numPrecio.Value = oMembresia.Precio; numPrecio.Enabled = false;
                    numDescuento.Value = oMembresia.Descuento; numDescuento.Enabled = false;
                    txtTotal.Text = oMembresia.Total.ToString();
                    i_idTurnoAnterior = Convert.ToInt32(cboTurnos.SelectedValue);
                }

            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drVencida = DialogResult.OK;
                if (dtpFechaVencimiento.Value < DateTime.Now.Date || dtpFechaInicio.Value.AddDays(30)<DateTime.Now.Date) { drVencida = MessageBox.Show("Cuidado! Estas a punto de registrar una membresia que ya se ha vencido. Esto quiere decir que se dara de baja cuando se reinicie el sistema. Desea continuar?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning); }

                if (drVencida == DialogResult.OK)
                {
                    if (Convert.ToDecimal(txtTotal.Text) <= 0) { MessageBox.Show("El total debe ser mayor a $0,00. Por favor, verifica.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    if (i_Inscriptos >= i_Cupo && !txtCupo.Text.Contains("Sin cupo")) { MessageBox.Show("No es posible registrarse en este turno ya que se encuentra con el cupo lleno.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                    
                    Membresias oMembresias = new Membresias();
                    Membresias.Membresia oMembresia = new Membresias.Membresia();

                    if (idMembresia == 0)
                    {
                        DataTable dtMembresias = oMembresias.GetAll("Membresia.idMembresia, Membresia.idSocio, Membresia.idActividad, Membresia.idTurno, Membresia.Duracion, Membresia.FechaInicio, Membresia.FechaVencimiento, Membresia.Estado", "Membresia.Estado=1 AND Membresia.idActividad=" + cboActividades.SelectedValue + " AND Membresia.idSocio=" + frmRegistrarEditarSocio.idSocio);
                        if (dtMembresias.Rows.Count > 0) { MessageBox.Show("El socio actualmente posee una membresia activa en esta actividad. Si deseas volver a registrarla, primero debes dar de baja o eliminar la membresia actual.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                        oMembresia.idSocio = frmRegistrarEditarSocio.idSocio;
                        oMembresia.idActividad = Convert.ToInt32(cboActividades.SelectedValue);
                        oMembresia.idTurno = Convert.ToInt32(cboTurnos.SelectedValue);
                        oMembresia.Duracion = cboDuracion.SelectedItem.ToString().Trim();
                        oMembresia.FechaInicio = dtpFechaInicio.Value;
                        oMembresia.FechaVencimiento = dtpFechaVencimiento.Value;
                        oMembresia.Precio = numPrecio.Value;
                        oMembresia.Descuento = numDescuento.Value;
                        oMembresia.Total = Convert.ToDecimal(txtTotal.Text);
                        oMembresia.Estado = 1;
                        idMembresia = oMembresias.Insert(oMembresia);

                        Socios oSocios = new Socios();
                        oSocios.UpdateSaldo(frmRegistrarEditarSocio.idSocio, Convert.ToString(Convert.ToDecimal(txtTotal.Text) * -1));

                        HistorialesMembresias oHistorialesMembresias = new HistorialesMembresias();
                        HistorialesMembresias.HistorialMembresias oHistorialMembresia = new HistorialesMembresias.HistorialMembresias();
                        oHistorialMembresia.idMembresia = idMembresia;
                        oHistorialMembresia.Fecha = DateTime.Now.Date;
                        oHistorialMembresia.Concepto = "Alta";
                        oHistorialMembresia.Saldo = oSocios.GetSaldo(frmRegistrarEditarSocio.idSocio);
                        oHistorialesMembresias.Insert(oHistorialMembresia);

                        Turnos oTurnos = new Turnos();
                        oTurnos.AddInscripto(Convert.ToInt32(cboTurnos.SelectedValue), 1);

                        SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                        SociosxTurnos.SocioxTurno oSocioxTurno = new SociosxTurnos.SocioxTurno();
                        oSocioxTurno.idSocio = frmRegistrarEditarSocio.idSocio;
                        oSocioxTurno.idTurno = Convert.ToInt32(cboTurnos.SelectedValue);
                        oSociosxTurnos.Insert(oSocioxTurno);

                        MessageBox.Show("La membresia se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        oMembresia.idMembresia = idMembresia;
                        oMembresia.idSocio = frmRegistrarEditarSocio.idSocio;
                        oMembresia.idActividad = Convert.ToInt32(cboActividades.SelectedValue);
                        oMembresia.idTurno = Convert.ToInt32(cboTurnos.SelectedValue);
                        oMembresia.Duracion = cboDuracion.SelectedItem.ToString().Trim();
                        oMembresia.FechaInicio = dtpFechaInicio.Value;
                        oMembresia.FechaVencimiento = dtpFechaVencimiento.Value;
                        oMembresia.Precio = numPrecio.Value;
                        oMembresia.Descuento = numDescuento.Value;
                        oMembresia.Total = Convert.ToDecimal(txtTotal.Text);
                        oMembresia.Estado = 1;
                        oMembresias.Update(oMembresia);

                        Turnos oTurnos = new Turnos(); //Le resta un inscripto al turno anterior y le suma uno al nuevo turno.
                        oTurnos.AddInscripto(i_idTurnoAnterior, -1);
                        oTurnos.AddInscripto(Convert.ToInt32(cboTurnos.SelectedValue), 1);

                        SociosxTurnos oSociosxTurnos = new SociosxTurnos(); //Actualiza SocioxTurno con el nuevo turno.
                        oSociosxTurnos.Delete("SocioxTurno", "SocioxTurno.idSocio=" + frmRegistrarEditarSocio.idSocio + " AND SocioxTurno.idTurno=" + i_idTurnoAnterior);

                        SociosxTurnos.SocioxTurno oSocioxTurno = new SociosxTurnos.SocioxTurno();
                        oSocioxTurno.idSocio = frmRegistrarEditarSocio.idSocio;
                        oSocioxTurno.idTurno = Convert.ToInt32(cboTurnos.SelectedValue);
                        oSociosxTurnos.Insert(oSocioxTurno);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ETC
        private void cboActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Funciones.f_FillComboBox(cboTurnos, "idTurno", "Hora", "Hora", "Turno", "idActividad=" + cboActividades.SelectedValue, "Hora ASC");
                f_CalcularDuracionPrecio();
            }
            catch (Exception) { }
        }

        private void cboTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_Inscriptos();
        }

        private void cboDuracion_SelectedIndexChanged(object sender, EventArgs e)
        {
            f_CalcularDuracionPrecio();
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            f_CalcularDuracionPrecio();
        }

        private void numPrecio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = Convert.ToString(numPrecio.Value - numDescuento.Value);
            }
            catch (Exception) { }
        }

        private void numDescuento_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotal.Text = Convert.ToString(numPrecio.Value - numDescuento.Value);
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public void f_CalcularDuracionPrecio()
        {
            try
            {
                dtpFechaVencimiento.MinDate = dtpFechaInicio.Value;
                Actividades oActividades = new Actividades();
                i_Cupo = oActividades.GetCupo(Convert.ToInt32(cboActividades.SelectedValue));
                if (i_Cupo == 0) { txtCupo.Text = "Sin cupo"; } else { txtCupo.Text = i_Cupo.ToString() + " socios"; }

                f_Inscriptos();

                decimal d_Precio = 0;
                switch (cboDuracion.SelectedItem.ToString().Trim())
                {
                    case "Clase":
                        d_Precio = oActividades.GetPrecio(Convert.ToInt32(cboActividades.SelectedValue), "PrecioClase");
                        dtpFechaVencimiento.Value = dtpFechaInicio.Value.AddDays(1);
                        break;

                    case "Semana":
                        d_Precio = oActividades.GetPrecio(Convert.ToInt32(cboActividades.SelectedValue), "PrecioSemana");
                        dtpFechaVencimiento.Value = dtpFechaInicio.Value.AddDays(7);
                        break;

                    case "Mes":
                        d_Precio = oActividades.GetPrecio(Convert.ToInt32(cboActividades.SelectedValue), "PrecioMes");
                        dtpFechaVencimiento.Value = dtpFechaInicio.Value.AddDays(30);
                        break;

                    case "Trimestre":
                        d_Precio = oActividades.GetPrecio(Convert.ToInt32(cboActividades.SelectedValue), "PrecioTrimestre");
                        dtpFechaVencimiento.Value = dtpFechaInicio.Value.AddDays(90);
                        break;

                    case "Otro 1":
                        d_Precio = oActividades.GetPrecio(Convert.ToInt32(cboActividades.SelectedValue), "PrecioOtro1");
                        break;

                    case "Otro 2":
                        d_Precio = oActividades.GetPrecio(Convert.ToInt32(cboActividades.SelectedValue), "PrecioOtro2");
                        break;
                }
                numPrecio.Value = d_Precio;
            }
            catch (Exception) { }
        }

        public void f_Inscriptos()
        {
            try
            {
                Turnos oTurnos = new Turnos();
                Actividades oActividades = new Actividades();

                i_Inscriptos = oTurnos.GetInscriptos(Convert.ToInt32(cboTurnos.SelectedValue));
                txtInscriptos.Text = i_Inscriptos.ToString() + " socio(s)";
                i_Cupo = oActividades.GetCupo(Convert.ToInt32(cboActividades.SelectedValue));

                if (i_Inscriptos >= i_Cupo)
                {
                    txtInscriptos.ReadOnly = false; txtInscriptos.BackColor = Color.White; txtInscriptos.ForeColor = Color.Red;
                }
                else 
                {
                    txtInscriptos.ReadOnly = false; txtInscriptos.BackColor = Color.White; txtInscriptos.ForeColor = Color.Black; 
                } 
                txtInscriptos.ReadOnly = true;

                if (txtCupo.Text.Contains("Sin cupo")) { txtInscriptos.ForeColor = Color.Black; }
                txtDias.Text = oTurnos.GetDias(Convert.ToInt32(cboTurnos.SelectedValue));
            }
            catch (Exception) { }
        }
        #endregion
    }
}