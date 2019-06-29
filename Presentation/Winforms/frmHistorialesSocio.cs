using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Presentation.Winforms;
using Logic;

namespace Presentation.Winforms
{
    public partial class frmHistorialesSocio : Form
    {
        #region VARIABLES
        public string s_FiltroMembresias = "Membresia.FechaInicio>='" + DateTime.Now.ToShortDateString() + "' AND Membresia.FechaInicio<='" + DateTime.Now.ToShortDateString() + "' ORDER BY Membresia.FechaInicio ASC";
        public string s_FiltroPagos = "PagoMembresia.Fecha>='" + DateTime.Now.ToShortDateString() + "' AND PagoMembresia.Fecha<='" + DateTime.Now.ToShortDateString() + "' ORDER BY PagoMembresia.Fecha ASC";
        #endregion

        public frmHistorialesSocio()
        {
            InitializeComponent();
        }

        #region LOAD
        private void frmHistorialesSocio_Load(object sender, EventArgs e)
        {
            try
            {
                f_FillGrids();
                Funciones.f_FillComboBox(cboActividades, "idActividad", "Nombre", "Nombre", "Actividad", "", "Nombre");
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            f_FillGrids();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvHistorialPagos.CurrentRow.Index;
                frmImprimirRecibo.s_Formula = "{PagoMembresia.idPagoMembresia}=" + dgvHistorialPagos["idPagoMembresia", i_Fila].Value.ToString();
                if (Application.OpenForms["frmImprimirRecibo"] != null) Application.OpenForms["frmImprimirRecibo"].Close();
                frmImprimirRecibo frm = new frmImprimirRecibo();
                frm.Show();
                
            }
            catch (Exception) { MessageBox.Show("Por favor, selecciona un pago.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkTodas.Checked)
                {
                    cboActividades.Enabled = false;
                    s_FiltroMembresias = "Membresia.FechaInicio>='" + dtpDesde.Value.ToShortDateString() + "' AND Membresia.FechaInicio<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY Membresia.FechaInicio ASC";
                    s_FiltroPagos = "PagoMembresia.Fecha>='" + dtpDesde.Value.ToShortDateString() + "' AND PagoMembresia.Fecha<='" + dtpHasta.Value.ToShortDateString() + "' ORDER BY PagoMembresia.Fecha ASC";
                }
                else
                {
                    cboActividades.Enabled = true;
                    s_FiltroMembresias = "Membresia.FechaInicio>='" + dtpDesde.Value.ToShortDateString() + "' AND Membresia.FechaInicio<='" + dtpHasta.Value.ToShortDateString() + "' AND Actividad.Nombre='" + cboActividades.Text.Trim() + "' ORDER BY Membresia.FechaInicio ASC";
                    s_FiltroPagos = "PagoMembresia.Fecha>='" + dtpDesde.Value.ToShortDateString() + "' AND PagoMembresia.Fecha<='" + dtpHasta.Value.ToShortDateString() + "' AND Actividad.Nombre='" + cboActividades.Text.Trim() + "' ORDER BY Membresia.FechaInicio ASC";
                }

                HistorialesMembresias oHistorialesMembresias = new HistorialesMembresias();
                DataTable dtHistorialMembresias = oHistorialesMembresias.GetAllMix("Actividad.Nombre as 'Actividad', HistorialMembresias.Fecha, HistorialMembresias.Concepto, Membresia.Total", "Socio.idSocio=" + frmRegistrarEditarSocio.idSocio + " AND Socio.idSocio=Membresia.idSocio AND Actividad.idActividad=Membresia.idActividad AND HistorialMembresias.idMembresia=Membresia.idMembresia AND " + s_FiltroMembresias);
                dgvHistorialMembresias.DataSource = dtHistorialMembresias;
                dgvHistorialMembresias.ClearSelection();

                PagosMembresias oPagosMembresias = new PagosMembresias();
                DataTable dtHistorialPagos = oPagosMembresias.GetAllMix("PagoMembresia.idPagoMembresia, Actividad.Nombre as 'Actividad', Membresia.FechaInicio as 'Fecha de Inicio', Membresia.FechaVencimiento as 'Fecha de Vencimiento', PagoMembresia.Fecha as 'Fecha del Pago', PagoMembresia.Monto", "PagoMembresia.idMembresia=Membresia.idMembresia AND Membresia.idSocio=Socio.idSocio AND Membresia.idActividad=Actividad.idActividad AND Socio.idSocio=" + frmRegistrarEditarSocio.idSocio + " AND " + s_FiltroPagos);
                dgvHistorialPagos.DataSource = dtHistorialPagos;
                dgvHistorialPagos.Columns["idPagoMembresia"].Visible = false;
                dgvHistorialPagos.ClearSelection();
                dgvHistorialPagos.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                f_Resumen();
            }
            catch (Exception) { }
        }
        #endregion

        #region ETC
        private void chkTodas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodas.Checked) { cboActividades.Enabled = false; } else { cboActividades.Enabled = true; }
        }
        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpHasta.MinDate = dtpDesde.Value;
            }
            catch (Exception) { }
        }

        private void txtTotalFecha_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDecimal(txtTotalFecha.Text) < 0) { txtTotalFecha.ForeColor = Color.Red; txtTotalFecha.BackColor = Color.White; } else { txtTotalFecha.ForeColor = Color.Green; txtTotalFecha.BackColor = Color.White; }
            }
            catch (Exception) { }
        }

        private void txtSubtotalPagos_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtSubtotalPagos.Text) < 0) { txtSubtotalPagos.ForeColor = Color.Red; txtSubtotalPagos.BackColor = Color.White; } else { txtSubtotalPagos.ForeColor = Color.Green; txtSubtotalPagos.BackColor = Color.White; }
        }

        private void txtSubtotalMembresias_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtSubtotalMembresias.Text) < 0) { txtSubtotalMembresias.ForeColor = Color.Red; txtSubtotalMembresias.BackColor = Color.White; } else { txtSubtotalMembresias.ForeColor = Color.Green; txtSubtotalMembresias.BackColor = Color.White; }
        }
        #endregion

        #region FUNCIONES
        public void f_FillGrids()
        {
            try
            {
                Socios oSocios = new Socios();
                Socios.Socio oSocio = oSocios.GetOne(frmRegistrarEditarSocio.idSocio);

                HistorialesMembresias oHistorialesMembresias = new HistorialesMembresias();
                DataTable dtHistorialMembresias = oHistorialesMembresias.GetAllMix("Actividad.Nombre as 'Actividad', HistorialMembresias.Fecha, HistorialMembresias.Concepto, Membresia.Total", "Socio.idSocio=" + frmRegistrarEditarSocio.idSocio + " AND Socio.idSocio=Membresia.idSocio AND Actividad.idActividad=Membresia.idActividad AND HistorialMembresias.idMembresia=Membresia.idMembresia");
                dgvHistorialMembresias.DataSource = dtHistorialMembresias;
                dgvHistorialMembresias.ClearSelection();
                lbSaldoActual.Text = "Saldo actual: $" + oSocio.Saldo.ToString();

                PagosMembresias oPagosMembresias = new PagosMembresias();
                DataTable dtHistorialPagos = oPagosMembresias.GetAllMix("PagoMembresia.idPagoMembresia, Actividad.Nombre as 'Actividad', Membresia.FechaInicio as 'Fecha de Inicio', Membresia.FechaVencimiento as 'Fecha de Vencimiento', PagoMembresia.Fecha as 'Fecha del Pago', PagoMembresia.Monto", "PagoMembresia.idMembresia=Membresia.idMembresia AND Membresia.idSocio=Socio.idSocio AND Membresia.idActividad=Actividad.idActividad AND Socio.idSocio=" + frmRegistrarEditarSocio.idSocio);
                dgvHistorialPagos.DataSource = dtHistorialPagos;
                dgvHistorialPagos.Columns["idPagoMembresia"].Visible = false;
                dgvHistorialPagos.ClearSelection();
                dgvHistorialPagos.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                f_Resumen();
            }
            catch (Exception) { }
        }

        public void f_Resumen()
        {
            try
            {
                decimal d_Subtotal = 0;
                foreach (DataGridViewRow row in dgvHistorialMembresias.Rows)
                {
                    if (row.Cells["Concepto"].Value.ToString() != "Baja") { d_Subtotal += Convert.ToDecimal(row.Cells["Total"].Value); }
                }
                txtSubtotalMembresias.Text = (d_Subtotal * -1).ToString();

                d_Subtotal = 0;
                foreach (DataGridViewRow row in dgvHistorialPagos.Rows)
                {
                    d_Subtotal += Convert.ToDecimal(row.Cells["Monto"].Value);
                }
                txtSubtotalPagos.Text = d_Subtotal.ToString();

                txtTotalFecha.Text = Convert.ToString(Convert.ToDecimal(txtSubtotalMembresias.Text) + Convert.ToDecimal(txtSubtotalPagos.Text));
            }
            catch (Exception) { }
        }
        #endregion
    }
}