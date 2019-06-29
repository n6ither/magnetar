using Logic;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Presentation.Winforms
{
    public partial class frmMain : Form
    {

        #region VARIABLES
        /// <summary>
        /// Filtro para realizar la busqueda de socios.
        /// </summary>
        public static string s_FiltroSocios = "Socio.Apellido";
        /// <summary>
        /// Filtro para realizar la busqueda de actividades, profesores y rutinas.
        /// </summary>
        public static string s_FiltroMas = "Actividad.Nombre";
        /// <summary>
        /// Cupo disponible para una actividad.
        /// </summary>
        public int i_Cupo = 0;
        /// <summary>
        /// Cantidad de socios inscriptos en ese turno.
        /// </summary>
        public int i_Inscriptos = 0;
        /// <summary>
        /// Define el SelectionFormula.
        /// </summary>
        public static string s_Formula = "Date({Asistencia.Fecha})>=#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "# and Date({Asistencia.Fecha})<=#" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "#";
        #endregion

        public frmMain()
        {
            InitializeComponent();
        }

        #region FORM & TABCONTROL
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                menuTop.Renderer = new myRenderer();

                btnInicio.Checked = true;
                this.Bounds = Screen.PrimaryScreen.Bounds;
                f_FillGridSocios(); f_FillGridActividades(); f_FillGridRutinas(); f_FillGridProfesores();

                dgvSocios.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False; dgvProfesores.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

                Gimnasios oGimnasios = new Gimnasios();
                Gimnasios.Gimnasio oGimnasio = oGimnasios.GetTheOne();
                if (oGimnasio == null || oGimnasio.Nombre == "" || oGimnasio.Email == "")
                {
                    DialogResult dr = MessageBox.Show("Aun no has completado los datos sobre tu gimnasio. Deseas completarlos ahora?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK) { frmMiGimnasio frm = new frmMiGimnasio(); frm.ShowDialog(); }
                }

                if (oGimnasio.Logo != "" && File.Exists(oGimnasio.Logo))
                {
                    pbLogoGimnasio.Load(oGimnasio.Logo);
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

                //Revisa todas las membresias y da de baja las incorrectas.
                Membresias oMembresias = new Membresias();
                DataTable dtMembresias = oMembresias.GetAllMix("*", "Membresia.Estado=1 AND Actividad.Estado=1 AND Membresia.idSocio=Socio.idSocio AND Membresia.idActividad=Actividad.idActividad AND Turno.idActividad=Actividad.idActividad AND Membresia.idTurno=Turno.idTurno");
                foreach (DataRow row in dtMembresias.Rows)
                {
                    oMembresias.EstadoDelPago(Convert.ToInt32(row["idMembresia"]), Convert.ToInt32(row["idTurno"]), Convert.ToInt32(row["Saldo"]));
                }

                //Revisa todos los casilleros y libera los vencidos
                Casilleros oCasilleros = new Casilleros();
                oCasilleros.LiberarVencidos();

                //Controla la fecha de la ultima copia de seguridad, si pasaron 15 dias muestra la opcion de ejecutarla.
                CopiasSeguridad oCopiasSeguridad = new CopiasSeguridad();
                if (oCopiasSeguridad.Pasaron15Dias())
                {
                    DialogResult drCopiaSeguridad = MessageBox.Show("Han pasado 15 dias de la ultima copia de seguridad de la base de datos. La puede realizar ahora mismo pulsando 'Aceptar' o desde el menu 'Herramientas'.", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (drCopiaSeguridad == DialogResult.OK)
                    {
                        frmBackup frm = new frmBackup();
                        frm.ShowDialog();
                    }
                }
            }
            catch (Exception) { }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DialogResult drCerrar = MessageBox.Show("Esta seguro que desea cerrar la aplicacion?", "Magnetar Gym Management", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drCerrar == DialogResult.No) { e.Cancel = true; }
            }
            catch (Exception) { }
        }

        private void tabWithoutHeader_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabWithoutHeader.SelectedIndex)
                {
                    case 0:
                        statusBar.Visible = true;
                        lbCantStatusBar.Visible = false;
                        break;

                    case 1:
                        statusBar.Visible = true;
                        lbCantStatusBar.Visible = true;
                        lbCantStatusBar.Text = "Cantidad: " + dgvSocios.Rows.Count.ToString().Trim();
                        this.AcceptButton = btnBuscarSocio;
                        break;

                    case 2:
                        statusBar.Visible = true;
                        lbCantStatusBar.Visible = false;
                        this.AcceptButton = btnBuscarTurno;
                        break;

                    case 3:
                        statusBar.Visible = false;
                        this.AcceptButton = btnGenerar;
                        break;

                    case 4:
                        statusBar.Visible = true;
                        lbCantStatusBar.Visible = true;
                        lbCantStatusBar.Text = "Actividades: " + dgvActividades.Rows.Count.ToString().Trim() + "     Rutinas: " + dgvRutinas.Rows.Count.ToString().Trim() + "     Profesores: " + dgvProfesores.Rows.Count.ToString().Trim();
                        this.AcceptButton = btnBuscarMas;
                        break;
                }
            }
            catch (Exception) { }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 0;
                btnInicio.Checked = true;
                btnSocios.Checked = false;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = false;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void btnSocios_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 1;
                btnInicio.Checked = false;
                btnSocios.Checked = true;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = false;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 2;
                btnInicio.Checked = false;
                btnSocios.Checked = false;
                btnTurnos.Checked = true;
                btnEstadisticas.Checked = false;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 3;
                btnInicio.Checked = false;
                btnSocios.Checked = false;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = true;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 4;
                btnInicio.Checked = false;
                btnSocios.Checked = false;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = false;
                btnMas.Checked = true;
            }
            catch (Exception) { }
        }

        private void lbTins_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("www.facebook.com/tins.software");
            }
            catch (Exception) { }
        }
        #endregion

        #region TAB INICIO
        private void tabInicio_Enter(object sender, EventArgs e)
        {
            try
            {
                Socios oSocios = new Socios();
                int i_Socios = oSocios.CountSocios();
                int i_SociosActivos = oSocios.CountSociosActivos();
                txtSociosRegistrados.Text = i_Socios.ToString() + " socios registrados";
                pbSociosActivos.Value = (i_SociosActivos * 100) / i_Socios;
                lbSociosActivos.Text = ((i_SociosActivos * 100) / i_Socios).ToString() + "% de socios activos.";

                Casilleros oCasilleros = new Casilleros();
                lbCasilleros.Text = oCasilleros.CountActivos().ToString() + " casilleros asignados.";

                lbMas.Text = dgvActividades.Rows.Count.ToString() + " actividades registradas.\n" + dgvRutinas.Rows.Count.ToString() + " rutinas registradas.\n" + dgvProfesores.Rows.Count.ToString() + " profesores registrados.";

                f_FillGridAsistenciasHoy();
                lbFecha.Text = DateTime.Now.ToString("dddd", new CultureInfo("es-AR")) + ", " + DateTime.Now.Date.Day.ToString() + " de " + DateTime.Now.ToString("MMMM") + " de " + DateTime.Now.Date.Year.ToString();
                lbAsistencias.Text = dgvAsistenciasHoy.Rows.Count.ToString() + " asistencia(s).";
            }
            catch (DivideByZeroException) { pbSociosActivos.Value = 0; }
            catch (Exception) { }
        }

        private void pbLogoGimnasio_Click(object sender, EventArgs e)
        {
            try
            {
                frmMiGimnasio frm = new frmMiGimnasio();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Gimnasios oGimnasios = new Gimnasios();
                    Gimnasios.Gimnasio oGimnasio = oGimnasios.GetTheOne();

                    if (oGimnasio.Logo != "" && File.Exists(oGimnasio.Logo))
                    {
                        pbLogoGimnasio.Load(oGimnasio.Logo);
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
                    else { pbLogoGimnasio.Image = Properties.Resources.gymdefault1; }
                }
            }
            catch (Exception) { }
        }

        private void btnBuscarSocioI_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 1;
                btnSocios.Checked = true;
                btnInicio.Checked = false;
                txtBuscarSocio.Select();
            }
            catch (Exception) { }
        }

        private void btnRegistrarSocioI_Click(object sender, EventArgs e)
        {
            f_RegistrarSocio();
        }

        private void btnAsistenciasI_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmAsistencias"] != null) Application.OpenForms["frmAsistencias"].Close();
                frmAsistencias frm = new frmAsistencias(); frm.Show();
            }
            catch (Exception) { }
        }

        private void btnEstadisticasI_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 3;
                btnEstadisticas.Checked = true;
                btnInicio.Checked = false;
            }
            catch (Exception) { }
        }

        private void btnRegistrarProfesorI_Click(object sender, EventArgs e)
        {
            f_RegistrarProfesor();
        }

        private void btnRegistrarActividadI_Click(object sender, EventArgs e)
        {
            f_RegistrarActividad();
        }

        private void btnRegistrarRutinaI_Click(object sender, EventArgs e)
        {
            f_RegistrarRutina();
        }

        private void btnCasillerosI_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmCasilleros"] != null) { Application.OpenForms["frmCasilleros"].BringToFront(); Application.OpenForms["frmCasilleros"].WindowState = FormWindowState.Normal; return; }
                frmCasilleros frm = new frmCasilleros(); frm.ShowDialog();

                Casilleros oCasilleros = new Casilleros();
                lbCasilleros.Text = oCasilleros.CountActivos().ToString() + " casilleros asignados.";
            }
            catch (Exception) { }
        }

        private void dgvAsistenciasHoy_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvAsistenciasHoy.Rows)
                {
                    if (Convert.ToInt32(row.Cells["Saldo"].Value) < 0) { row.DefaultCellStyle.ForeColor = Color.Red; } else { row.DefaultCellStyle.ForeColor = Color.Green; }
                }
            }
            catch (Exception) { }
        }

        private void dgvAsistenciasHoy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarSocio"] != null) Application.OpenForms["frmRegistrarEditarSocio"].Close();
                int i_Fila = dgvAsistenciasHoy.CurrentRow.Index;
                frmRegistrarEditarSocio.idSocio = Convert.ToInt32(dgvAsistenciasHoy["idSocio", i_Fila].Value);
                frmRegistrarEditarSocio frm = new frmRegistrarEditarSocio();
                frm.Text = "Magnetar Gym Management | Editar socio";
                frm.ShowDialog();
            }
            catch (Exception) { }
        }

        private void btnRefrescarAsistencias_Click(object sender, EventArgs e)
        {
            f_FillGridAsistenciasHoy();
        }
        #endregion

        #region TAB SOCIOS
        private void tabSocios_Enter(object sender, EventArgs e)
        {
            try
            {
                cboFiltroSocios.SelectedIndex = 0;
                txtBuscarSocio.Select();
            }
            catch (Exception) { }
        }

        private void btnRegistrarSocio_Click(object sender, EventArgs e)
        {
            f_RegistrarSocio();
        }

        private void dgvSocios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            f_EditarSocio();
        }

        private void dgvSocios_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvSocios.CurrentCell = dgvSocios.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void btnBuscarSocio_Click(object sender, EventArgs e)
        {
            f_BuscarSocio();
        }

        private void txtBuscarSocio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter) f_BuscarSocio();
            }
            catch (Exception) { }
        }

        private void cboFiltroSocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboFiltroSocios.SelectedItem.ToString().Trim())
                {
                    case "Apellido":
                        s_FiltroSocios = "S.Apellido";
                        break;

                    case "Nombre":
                        s_FiltroSocios = "S.Nombre";
                        break;

                    case "Nro. de Documento":
                        s_FiltroSocios = "S.NroDoc";
                        break;

                    case "Fecha de registracion":
                        s_FiltroSocios = "S.FechaRegistracion>='" + dtpSociosDesde.Value.ToShortDateString() + "' AND S.FechaRegistracion<='" + dtpSociosHasta.Value.ToShortDateString() + "' ORDER BY S.FechaRegistracion ASC";
                        txtBuscarSocio.Visible = false;
                        lbSociosDesde.Visible = true;
                        lbSociosHasta.Visible = true;
                        dtpSociosDesde.Visible = true;
                        dtpSociosHasta.Visible = true;
                        break;
                }

                if (cboFiltroSocios.SelectedItem.ToString().Trim() != "Fecha de registracion")
                {
                    txtBuscarSocio.Visible = true;
                    lbSociosDesde.Visible = false;
                    lbSociosHasta.Visible = false;
                    dtpSociosDesde.Visible = false;
                    dtpSociosHasta.Visible = false;
                }
                txtBuscarSocio.Select();
            }
            catch (Exception) { }
        }

        private void dtpSociosDesde_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                s_FiltroSocios = "S.FechaRegistracion>='" + dtpSociosDesde.Value.ToShortDateString() + "' AND S.FechaRegistracion<='" + dtpSociosHasta.Value.ToShortDateString() + "' ORDER BY S.FechaRegistracion ASC";
            }
            catch (Exception) { }
        }

        private void dtpSociosHasta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                s_FiltroSocios = "S.FechaRegistracion>='" + dtpSociosDesde.Value.ToShortDateString() + "' AND S.FechaRegistracion<='" + dtpSociosHasta.Value.ToShortDateString() + "' ORDER BY S.FechaRegistracion ASC";
            }
            catch (Exception) { }
        }
        #endregion

        #region TAB TURNOS
        private void tabTurnos_Enter(object sender, EventArgs e)
        {
            try
            {
                Funciones.f_FillComboBox(cboActividadesT, "idActividad", "Nombre", "Nombre", "Actividad", "Estado=1", "Nombre ASC");
                Funciones.f_FillComboBox(cboTurnos, "idTurno", "Hora", "Hora", "Turno", "idActividad=" + cboActividadesT.SelectedValue, "Hora ASC");
            }
            catch (Exception) { }
        }

        private void cboActividades_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Funciones.f_FillComboBox(cboTurnos, "idTurno", "Hora", "Hora", "Turno", "idActividad=" + cboActividadesT.SelectedValue, "Hora ASC");
            }
            catch (Exception) { }
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                txtCupo.Clear(); txtInscriptos.Clear(); txtLugaresDisponibles.Clear(); txtCupo.BackColor = Color.White; txtInscriptos.BackColor = Color.White; txtLugaresDisponibles.BackColor = Color.White; txtCupo.ForeColor = Color.Black; txtInscriptos.ForeColor = Color.Black; txtLugaresDisponibles.ForeColor = Color.Black;
                i_Inscriptos = 0; i_Cupo = 0;
                tlpSociosInscriptos.Controls.Clear();
                int i_Col = 0;
                int i_Row = 0;

                Actividades oActividades = new Actividades();
                i_Cupo = oActividades.GetCupo(Convert.ToInt32(cboActividadesT.SelectedValue));

                SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                DataTable dtSociosxTurnos = oSociosxTurnos.GetAll("*", "idTurno=" + cboTurnos.SelectedValue.ToString());

                if (dtSociosxTurnos.Rows.Count > 0 && i_Cupo > 0)
                {
                    Socios oSocios = new Socios();
                    Membresias oMembresias = new Membresias();

                    for (int i = 0; i <= dtSociosxTurnos.Rows.Count - 1; i++)
                    {
                        Socios.Socio oSocio = oSocios.GetOne(Convert.ToInt32(dtSociosxTurnos.Rows[i]["idSocio"]));

                        PictureBox pb = new PictureBox();
                        pb.Name = "pbImagenSocio" + (i + 1).ToString();
                        pb.Dock = DockStyle.Fill;
                        pb.SizeMode = PictureBoxSizeMode.StretchImage;
                        pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                        if (oSocio.Imagen != "" && File.Exists(oSocio.Imagen)) { pb.Load(oSocio.Imagen); } else { pb.Image = Properties.Resources.sociodefault; }
                        tlpSociosInscriptos.Controls.Add(pb, i_Col, i_Row);

                        i_Col++;
                        if (i == 8) { i_Row += 2; i_Col = 0; }
                        if (i == 17) { i_Row += 2; i_Col = 0; }
                        if (i == 26) { i_Row += 2; i_Col = 0; }
                    }

                    i_Col = 0;
                    i_Row = 1;
                    for (int i = 0; i <= dtSociosxTurnos.Rows.Count - 1; i++)
                    {
                        Socios.Socio oSocio = oSocios.GetOne(Convert.ToInt32(dtSociosxTurnos.Rows[i].ItemArray[1]));

                        Label lb = new Label();
                        lb.Name = "lbNombreSocio" + (i + 1).ToString();
                        lb.Text = oSocio.Nombre.Trim() + " " + oSocio.Apellido.Trim();
                        if (oSocio.Saldo < 0) { lb.ForeColor = Color.Red; } else { lb.ForeColor = Color.Green; }
                        lb.Dock = DockStyle.Fill;
                        lb.TextAlign = ContentAlignment.MiddleCenter;
                        tlpSociosInscriptos.Controls.Add(lb, i_Col, i_Row);

                        i_Col++;
                        if (i == 8) { i_Row += 2; i_Col = 0; }
                        if (i == 17) { i_Row += 2; i_Col = 0; }
                        if (i == 26) { i_Row += 2; i_Col = 0; }
                    }
                }

                Turnos oTurnos = new Turnos();
                i_Inscriptos = oTurnos.GetInscriptos(Convert.ToInt32(cboTurnos.SelectedValue));
                txtInscriptos.Text = i_Inscriptos.ToString();

                if (i_Inscriptos >= i_Cupo) { txtInscriptos.ForeColor = Color.Red; txtInscriptos.BackColor = Color.White; txtLugaresDisponibles.ForeColor = Color.Red; txtLugaresDisponibles.BackColor = Color.White; } else { txtInscriptos.ForeColor = Color.Black; txtInscriptos.BackColor = Color.White; }
                if (i_Cupo == 0) { txtCupo.Text = "Sin cupo"; lbSocios.Hide(); txtInscriptos.ForeColor = Color.Black; txtInscriptos.BackColor = Color.White; } else { txtCupo.Text = i_Cupo.ToString(); lbSocios.Show(); txtLugaresDisponibles.Text = (i_Cupo - i_Inscriptos).ToString(); }
                lbActividad.Text = cboActividadesT.Text + " - " + cboTurnos.Text;
            }
            catch (Exception) { }
        }
        #endregion

        #region TAB ESTADISTICAS
        private void tabEstadisticas_Enter(object sender, EventArgs e)
        {
            try
            {
                cboEstadisticas.SelectedIndex = 0;
                Funciones.f_FillComboBox(cboActividadesE, "idActividad", "Nombre", "Nombre", "Actividad", "Estado=1", "Nombre ASC");
                Funciones.f_FillComboBox(cboSociosE, "idSocio", "Nombre+' '+Apellido as 'Nombre'", "Nombre", "Socio", "Estado=1", "Nombre ASC");
            }
            catch (Exception) { }
        }

        private void chkTodosE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTodosE.Checked) { cboSociosE.Enabled = false; } else { cboSociosE.Enabled = true; }
            }
            catch (Exception) { }
        }

        private void chkTodasE_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkTodasE.Checked) { cboActividadesE.Enabled = false; } else { cboActividadesE.Enabled = true; }
            }
            catch (Exception) { }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                f_ConfigurarReporte();

                //switch (cboEstadisticas.Text.Trim())
                //{
                //    case "Asistencias":
                //        rptAsistencias rptAsistencias = new rptAsistencias();
                //        rptAsistencias.Load(Properties.Resources.rptAsistencias.ToString());
                //        rptAsistencias.SetDatabaseLogon("admin", "123456", "(local)", "GymDatabase");
                //        crvEstadisticas.SelectionFormula = s_Formula;
                //        crvEstadisticas.ReportSource = rptAsistencias;
                //        crvEstadisticas.Refresh();
                ////        break;

                //    case "Pagos":
                //        rptPagos rptPagos = new rptPagos();
                //        rptPagos.Load(Properties.Resources.rptPagos.ToString());
                //        rptPagos.SetDatabaseLogon("admin", "123456", "(local)", "GymDatabase");
                //        crvEstadisticas.SelectionFormula = s_Formula;
                //        crvEstadisticas.ReportSource = rptPagos;
                //        crvEstadisticas.Refresh();
                //        break;

                //    case "Membresias":
                //        rptMembresias rptMembresias = new rptMembresias();
                //        rptMembresias.Load(Properties.Resources.rptMembresias.ToString());
                //        rptMembresias.SetDatabaseLogon("admin", "123456", "(local)", "GymDatabase");
                //        crvEstadisticas.SelectionFormula = s_Formula;
                //        crvEstadisticas.ReportSource = rptMembresias;
                //        crvEstadisticas.Refresh();
                //        break;
                //}
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString(), "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region TAB MAS
        private void tabMas_Enter(object sender, EventArgs e)
        {
            try
            {
                cboFiltroMas.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void btnRegistrarActividad_Click(object sender, EventArgs e)
        {
            f_RegistrarActividad();
        }

        private void btnRegistrarProfesor_Click(object sender, EventArgs e)
        {
            f_RegistrarProfesor();
        }

        private void btnRegistrarRutina_Click(object sender, EventArgs e)
        {
            f_RegistrarRutina();
        }

        private void cboFiltroMas_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboFiltroMas.SelectedItem.ToString().Trim())
                {
                    case "Actividad: Nombre":
                        s_FiltroMas = "Actividad.Nombre";
                        break;

                    case "Profesor: Nombre":
                        s_FiltroMas = "P.Nombre";
                        break;

                    case "Profesor: Apellido":
                        s_FiltroMas = "P.Apellido";
                        break;

                    case "Rutina: Nombre":
                        s_FiltroMas = "Rutina.Nombre";
                        break;
                }
                txtBuscarMas.Select();
            }
            catch (Exception) { }
        }

        private void txtBuscarMas_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter) { f_BuscarMas(); }
            }
            catch (Exception) { }
        }

        private void btnBuscarMas_Click(object sender, EventArgs e)
        {
            f_BuscarMas();
        }

        private void dgvActividades_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            f_EditarActividad();
        }

        private void dgvActividades_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvActividades.CurrentCell = dgvActividades.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvRutinas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            f_EditarRutina();
        }

        private void dgvRutinas_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvRutinas.CurrentCell = dgvRutinas.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dgvProfesores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            f_EditarProfesor();
        }

        private void dgvProfesores_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.Button == MouseButtons.Right)
            {
                dgvProfesores.CurrentCell = dgvProfesores.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }
        #endregion

        #region MENU TOP
        private class myRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(e);
                    e.Item.BackColor = Color.White;
                }
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(Brushes.Green, rc);
                    e.Graphics.DrawRectangle(Pens.White, 1, 0, rc.Width - 2, rc.Height - 1);
                    e.Item.BackColor = Color.Green;
                }
            }
            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                base.OnRenderItemText(e);
                if (!e.Item.Selected)
                {
                    e.Item.ForeColor = Color.Black;
                }
                else
                {
                    e.Item.ForeColor = Color.White;
                }
            }
        }

        private void mtBloquearSistema_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Restart();
            }
            catch (Exception) { }
        }

        private void mtSalir_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception) { }
        }

        private void mtRegistrarSocio_Click(object sender, EventArgs e)
        {
            f_RegistrarSocio();
        }

        private void mtEditarSocio_Click(object sender, EventArgs e)
        {
            f_EditarSocio();
        }

        private void mtBajaSocio_Click(object sender, EventArgs e)
        {
            f_BajaSocio();
        }

        private void mtSociosInactivos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmSociosInactivos"] != null) Application.OpenForms["frmSociosInactivos"].Close();
                frmSociosInactivos frm = new frmSociosInactivos();
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridSocios(); }
            }
            catch (Exception) { }
        }

        private void mtCumples_Click(object sender, EventArgs e)
        {
            frmCumples frm = new frmCumples();
            frm.Show();
        }

        private void mtRegistrarActividad_Click(object sender, EventArgs e)
        {
            f_RegistrarActividad();
        }

        private void mtEditarActividad_Click(object sender, EventArgs e)
        {
            f_EditarActividad();
        }

        private void mtDarBajaActividad_Click(object sender, EventArgs e)
        {
            f_BajaActividad();
        }

        private void mtRegistrarProfesor_Click(object sender, EventArgs e)
        {
            f_RegistrarProfesor();
        }

        private void mtEditarProfesor_Click(object sender, EventArgs e)
        {
            f_EditarProfesor();
        }

        private void mtDarBajaProfesor_Click(object sender, EventArgs e)
        {
            f_BajaProfesor();
        }

        private void mtProfesoresInactivos_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmProfesoresInactivos"] != null) Application.OpenForms["frmProfesoresInactivos"].Close();
                frmProfesoresInactivos frm = new frmProfesoresInactivos();
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridProfesores(); }
            }
            catch (Exception) { }
        }

        private void mtRegistrarRutina_Click(object sender, EventArgs e)
        {
            f_RegistrarRutina();
        }

        private void mtEditarRutina_Click(object sender, EventArgs e)
        {
            f_EditarRutina();
        }

        private void mtEliminarRutina_Click(object sender, EventArgs e)
        {
            f_EliminarRutina();
        }

        private void mtCasilleros_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmCasilleros"] != null) { Application.OpenForms["frmCasilleros"].BringToFront(); Application.OpenForms["frmCasilleros"].WindowState = FormWindowState.Normal; return; }
                frmCasilleros frm = new frmCasilleros(); frm.Show();
            }
            catch (Exception) { }
        }

        private void mtCalcIMC_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmCalcIMC"] != null) { Application.OpenForms["frmCalcIMC"].BringToFront(); Application.OpenForms["frmCalcIMC"].WindowState = FormWindowState.Normal; return; }
                frmCalcIMC frm = new frmCalcIMC(); frm.Show();
            }
            catch (Exception) { }
        }

        private void mtLocalidades_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmLocalidades"] != null) Application.OpenForms["frmLocalidades"].Close();
                frmLocalidades frm = new frmLocalidades();
                frm.ShowDialog();
                f_FillGridSocios();
                f_FillGridProfesores();
            }
            catch (Exception) { }
        }

        private void mtConfiguracion_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmConfiguracion"] != null) Application.OpenForms["frmConfiguracion"].Close();
                frmConfiguracion frm = new frmConfiguracion(); frm.Show();
            }
            catch (Exception) { }
        }

        private void mtBackup_Click(object sender, EventArgs e)
        {
            try
            {
                //CopiasSeguridad oCopiasSeguridad = new CopiasSeguridad();
                //DialogResult drCopiaSeguridad = MessageBox.Show("La ultima copia de seguridad se realizo el " + oCopiasSeguridad.UltimaFecha().ToShortDateString() + ". Desea continuar?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                //if (drCopiaSeguridad == DialogResult.OK) { f_EjecutarCopiaSeguridad(); }


                frmBackup frm = new frmBackup();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }

        private void mtVerAyuda_Click(object sender, EventArgs e)
        {
            try
            {
                frmAyuda frm = new frmAyuda();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }

        private void mtAcercaDe_Click(object sender, EventArgs e)
        {
            try
            {
                frmAcercaDe frm = new frmAcercaDe();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }


        private void tsmInicio_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 0;
                btnInicio.Checked = true;
                btnSocios.Checked = false;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = false;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void tsmSocios_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 1;
                btnInicio.Checked = false;
                btnSocios.Checked = true;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = false;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void tsmTurnos_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 2;
                btnInicio.Checked = false;
                btnSocios.Checked = false;
                btnTurnos.Checked = true;
                btnEstadisticas.Checked = false;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void tsmEstadisticas_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 3;
                btnInicio.Checked = false;
                btnSocios.Checked = false;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = true;
                btnMas.Checked = false;
            }
            catch (Exception) { }
        }

        private void tsmMas_Click(object sender, EventArgs e)
        {
            try
            {
                tabWithoutHeader.SelectedIndex = 4;
                btnInicio.Checked = false;
                btnSocios.Checked = false;
                btnTurnos.Checked = false;
                btnEstadisticas.Checked = false;
                btnMas.Checked = true;
            }
            catch (Exception) { }
        }
        #endregion

        #region CONTEXT MENU
        private void cmsRegistrarSocio_Click(object sender, EventArgs e)
        {
            f_RegistrarSocio();
        }

        private void cmsEditarSocio_Click(object sender, EventArgs e)
        {
            f_EditarSocio();
        }

        private void cmsBajaSocio_Click(object sender, EventArgs e)
        {
            f_BajaSocio();
        }

        private void cmsRegistrarActividad_Click(object sender, EventArgs e)
        {
            f_RegistrarActividad();
        }

        private void cmsEditarActividad_Click(object sender, EventArgs e)
        {
            f_EditarActividad();
        }

        private void cmsBajaActividad_Click(object sender, EventArgs e)
        {
            f_BajaActividad();
        }

        private void cmsRegistrarProfesor_Click(object sender, EventArgs e)
        {
            f_RegistrarProfesor();
        }

        private void cmsEditarProfesor_Click(object sender, EventArgs e)
        {
            f_EditarProfesor();
        }

        private void cmsBajaProfesor_Click(object sender, EventArgs e)
        {
            f_BajaProfesor();
        }

        private void cmsRegistrarRutina_Click(object sender, EventArgs e)
        {
            f_RegistrarRutina();
        }

        private void cmsEditarRutina_Click(object sender, EventArgs e)
        {
            f_EditarRutina();
        }

        private void cmsEliminarRutina_Click(object sender, EventArgs e)
        {
            f_EliminarRutina();
        }
        #endregion

        #region FUNCIONES
        public void f_FillGridAsistenciasHoy()
        {
            try
            {
                Asistencias oAsistencias = new Asistencias();
                DataTable dtAsistencias = oAsistencias.GetTop100Mix("Asistencia.idAsistencia, Socio.idSocio, Socio.Saldo, Socio.NroDoc as 'Nro. Doc.', Socio.Nombre, Socio.Apellido, Actividad.Nombre as 'Actividad', Asistencia.Hora", "Socio.idSocio=Asistencia.idSocio AND Actividad.idActividad=Asistencia.idActividad AND Asistencia.Fecha='" + DateTime.Now.Date.ToShortDateString() + "' ORDER BY Asistencia.Fecha DESC, Asistencia.Hora DESC");
                dgvAsistenciasHoy.DataSource = dtAsistencias;
                dgvAsistenciasHoy.Columns["idAsistencia"].Visible = false;
                dgvAsistenciasHoy.Columns["idSocio"].Visible = false;
                dgvAsistenciasHoy.Columns["Saldo"].Visible = false;
                dgvAsistenciasHoy.ClearSelection();

                lbAsistencias.Text = dgvAsistenciasHoy.Rows.Count.ToString() + " asistencia(s).";

            }
            catch (Exception) { }
        }

        public void f_RegistrarSocio()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarSocio"] != null) Application.OpenForms["frmRegistrarEditarSocio"].Close();
                frmRegistrarEditarSocio.idSocio = 0;
                frmRegistrarEditarSocio frm = new frmRegistrarEditarSocio();
                frm.Text = "Magnetar Gym Management | Registrar socio";
                frm.ShowDialog();
                f_FillGridSocios();
            }
            catch (Exception) { }
        }

        public void f_BuscarSocio()
        {
            try
            {
                Socios oSocios = new Socios();
                if (txtBuscarSocio.Visible == true)
                {
                    if (txtBuscarSocio.Text != "")
                    {
                        DataTable dtSocios = oSocios.GetAllSL("S.idSocio, S.NroDoc as 'Nro. Doc.', S.Nombre, S.Apellido, S.FechaNacimiento as 'Fecha Nac.', S.Edad, S.Sexo, S.Direccion, L.Nombre as 'Localidad', S.TelefonoFijo as 'Tel. Fijo', S.TelefonoCelular as 'Tel. Celular', S.FechaRegistracion as 'Fecha Registro'", "S.Estado=1 AND " + s_FiltroSocios + " LIKE '%" + txtBuscarSocio.Text.ToString() + "%' ORDER BY " + s_FiltroSocios + " ASC");
                        dgvSocios.DataSource = dtSocios;
                        dgvSocios.Columns["idSocio"].Visible = false;
                    }
                    else { f_FillGridSocios(); }
                }
                else
                {
                    DataTable dtSocios = oSocios.GetAllSL("S.idSocio, S.NroDoc as 'Nro. Doc.', S.Nombre, S.Apellido, S.FechaNacimiento as 'Fecha Nac.', S.Edad, S.Sexo, S.Direccion, L.Nombre as 'Localidad', S.TelefonoFijo as 'Tel. Fijo', S.TelefonoCelular as 'Tel. Celular', S.FechaRegistracion as 'Fecha Registro'", "S.Estado=1 AND " + s_FiltroSocios);
                    dgvSocios.DataSource = dtSocios;
                    dgvSocios.Columns["idSocio"].Visible = false;
                }
                lbCantStatusBar.Text = "Cantidad: " + dgvSocios.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_EditarSocio()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarSocio"] != null) Application.OpenForms["frmRegistrarEditarSocio"].Close();
                int intFila = dgvSocios.CurrentRow.Index;
                frmRegistrarEditarSocio.idSocio = Convert.ToInt32(dgvSocios["idSocio", intFila].Value);
                frmRegistrarEditarSocio frm = new frmRegistrarEditarSocio();
                frm.Text = "Magnetar Gym Management | Editar socio";
                frm.ShowDialog();
                f_FillGridSocios();
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un socio", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void f_BajaSocio()
        {
            try
            {
                int i_Fila = (dgvSocios.CurrentRow.Index);
                Membresias oMembresias = new Membresias();
                DataTable dtMembresias = oMembresias.GetAll("*", "Estado=1 AND idSocio=" + dgvSocios["idSocio", i_Fila].Value.ToString());
                if (dtMembresias.Rows.Count > 0) { MessageBox.Show("Antes de dar de baja un socio debes dar de baja o eliminar todas sus membresias activas.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                DialogResult drBaja = MessageBox.Show("Esta seguro que desea dar de baja a " + dgvSocios["Nombre", i_Fila].Value.ToString() + " " + dgvSocios["Apellido", i_Fila].Value.ToString() + "?", "Dar de baja socio", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drBaja == DialogResult.OK)
                {
                    Socios oSocios = new Socios();
                    oSocios.Disable(Convert.ToInt32(dgvSocios["idSocio", i_Fila].Value));
                    f_FillGridSocios();
                    MessageBox.Show("El socio ha sido dado de baja correctamente", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un socio.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void f_FillGridSocios()
        {
            try
            {
                Socios oSocios = new Socios();
                DataTable dtSocios = oSocios.GetTop100SL("S.idSocio, S.NroDoc as 'Nro. Doc.', S.Nombre, S.Apellido, S.FechaNacimiento as 'Fecha Nac.', S.Edad, S.Sexo, S.Direccion, L.Nombre as 'Localidad', S.TelefonoFijo as 'Tel. Fijo', S.TelefonoCelular as 'Tel. Celular', S.FechaRegistracion as 'Fecha Registro'", "S.Estado=1 ORDER BY S.Apellido ASC");
                dgvSocios.DataSource = dtSocios;
                dgvSocios.Columns["idSocio"].Visible = false;
                dgvSocios.ClearSelection();
                lbCantStatusBar.Text = "Cantidad: " + dgvSocios.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_ConfigurarReporte()
        {
            try
            {
                if (chkTodosE.Checked && chkTodasE.Checked)
                {
                    switch (cboEstadisticas.Text.Trim())
                    {
                        case "Asistencias":
                            s_Formula = "Date({Asistencia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Asistencia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "#";
                            break;

                        case "Pagos":
                            s_Formula = "Date({PagoMembresia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({PagoMembresia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "#";
                            break;

                        case "Membresias":
                            s_Formula = "Date({Membresia.FechaInicio})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Membresia.FechaInicio})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "#";
                            break;
                    }
                }
                if (!chkTodosE.Checked && !chkTodasE.Checked)
                {
                    switch (cboEstadisticas.Text.Trim())
                    {
                        case "Asistencias":
                            s_Formula = "Date({Asistencia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Asistencia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and CStr({Actividad.Nombre})='" + cboActividadesE.Text.ToString() + "' and {@Socio}='" + cboSociosE.Text.Trim() + "'";
                            break;

                        case "Pagos":
                            s_Formula = "Date({PagoMembresia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({PagoMembresia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and CStr({Actividad.Nombre})='" + cboActividadesE.Text.ToString() + "' and {@Socio}='" + cboSociosE.Text.Trim() + "'";
                            break;

                        case "Membresias":
                            s_Formula = "Date({Membresia.FechaInicio})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Membresia.FechaInicio})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and CStr({Actividad.Nombre})='" + cboActividadesE.Text.ToString() + "' and {@Socio}='" + cboSociosE.Text.Trim() + "'";
                            break;
                    }
                }

                if (!chkTodosE.Checked && chkTodasE.Checked)
                {
                    switch (cboEstadisticas.Text.Trim())
                    {
                        case "Asistencias":
                            s_Formula = "Date({Asistencia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Asistencia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and {@Socio}='" + cboSociosE.Text.Trim() + "'";
                            break;

                        case "Pagos":
                            s_Formula = "Date({PagoMembresia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({PagoMembresia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and {@Socio}='" + cboSociosE.Text.Trim() + "'";
                            break;

                        case "Membresias":
                            s_Formula = "Date({Membresia.FechaInicio})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Membresia.FechaInicio})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and {@Socio}='" + cboSociosE.Text.Trim() + "'";
                            break;
                    }
                }

                if (chkTodosE.Checked && !chkTodasE.Checked)
                {
                    switch (cboEstadisticas.Text.Trim())
                    {
                        case "Asistencias":
                            s_Formula = "Date({Asistencia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Asistencia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and CStr({Actividad.Nombre})='" + cboActividadesE.Text.ToString() + "'";
                            break;

                        case "Pagos":
                            s_Formula = "Date({PagoMembresia.Fecha})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({PagoMembresia.Fecha})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and CStr({Actividad.Nombre})='" + cboActividadesE.Text.ToString() + "'";
                            break;

                        case "Membresias":
                            s_Formula = "Date({Membresia.FechaInicio})>=#" + dtpDesdeEstadisticas.Value.ToString("MM/dd/yyyy") + "# and Date({Membresia.FechaInicio})<=#" + dtpHastaEstadisticas.Value.ToString("MM/dd/yyyy") + "# and CStr({Actividad.Nombre})='" + cboActividadesE.Text.ToString() + "'";
                            break;
                    }
                }
            }
            catch (Exception) { }
        }

        public void f_BuscarMas()
        {
            try
            {
                if (txtBuscarMas.Text != "")
                {
                    if (cboFiltroMas.Text.Contains("Actividad"))
                    {
                        Actividades oActividades = new Actividades();
                        DataTable dtActividades = oActividades.GetAll("idActividad, Nombre, PrecioClase as 'Clase', PrecioMes as 'Mes'", "Actividad.Estado=1 AND " + s_FiltroMas + " LIKE '%" + txtBuscarMas.Text.ToString().Trim() + "%' ORDER BY " + s_FiltroMas + " ASC");
                        dgvActividades.DataSource = dtActividades;
                        dgvActividades.Columns["idActividad"].Visible = false;
                    }

                    if (cboFiltroMas.Text.Contains("Profesor"))
                    {
                        Profesores oProfesores = new Profesores();
                        DataTable dtProfesores = oProfesores.GetAllPL("P.idProfesor, P.NroDoc as 'Nro. Doc.', P.Nombre, P.Apellido, P.FechaNacimiento as 'Fecha Nac.', P.Edad, P.Sexo, P.Direccion, L.Nombre as 'Localidad', P.TelefonoFijo as 'Tel. Fijo', P.TelefonoCelular as 'Tel. Celular', P.FechaRegistracion as 'Fecha Registro'", "P.Estado=1 AND " + s_FiltroMas + " LIKE '%" + txtBuscarMas.Text.ToString().Trim() + "%' ORDER BY " + s_FiltroMas + " ASC");
                        dgvProfesores.DataSource = dtProfesores;
                        dgvProfesores.Columns["idProfesor"].Visible = false;
                    }

                    if (cboFiltroMas.Text.Contains("Rutina"))
                    {
                        Rutinas oRutinas = new Rutinas();
                        DataTable dtRutinas = oRutinas.GetAll("idRutina, Nombre, Duracion as 'Duracion en semanas'", s_FiltroMas + " LIKE '%" + txtBuscarMas.Text.ToString().Trim() + "%' ORDER BY " + s_FiltroMas + " ASC");
                        dgvRutinas.DataSource = dtRutinas;
                        dgvRutinas.Columns["idRutina"].Visible = false;
                    }
                }
                else { f_FillGridActividades(); f_FillGridProfesores(); f_FillGridRutinas(); }
                lbCantStatusBar.Text = "Actividades: " + dgvActividades.Rows.Count.ToString().Trim() + "     Rutinas: " + dgvRutinas.Rows.Count.ToString().Trim() + "     Profesores: " + dgvProfesores.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_FillGridActividades()
        {
            try
            {
                Actividades oActividades = new Actividades();
                DataTable dtActividades = oActividades.GetAll("idActividad, Nombre, PrecioClase as 'Clase', PrecioMes as 'Mes'", "Estado=1");
                dgvActividades.DataSource = dtActividades;
                dgvActividades.Columns["idActividad"].Visible = false;
                lbCantStatusBar.Text = "Actividades: " + dgvActividades.Rows.Count.ToString().Trim() + "     Rutinas: " + dgvRutinas.Rows.Count.ToString().Trim() + "     Profesores: " + dgvProfesores.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_RegistrarActividad()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarActividad"] != null) Application.OpenForms["frmRegistrarEditarActividad"].Close();
                frmRegistrarEditarActividad.idActividad = 0;
                frmRegistrarEditarActividad frm = new frmRegistrarEditarActividad();
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridActividades(); }
            }
            catch (Exception) { }
        }

        public void f_EditarActividad()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarActividad"] != null) Application.OpenForms["frmRegistrarEditarActividad"].Close();
                int intFila = dgvActividades.CurrentRow.Index;
                frmRegistrarEditarActividad.idActividad = Convert.ToInt32(dgvActividades["idActividad", intFila].Value);
                frmRegistrarEditarActividad frm = new frmRegistrarEditarActividad();
                frm.Text = "Magnetar Gym Management | Editar actividad";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridActividades(); }
            }
            catch (Exception) { }
        }

        public void f_BajaActividad()
        {
            try
            {
                int i_Fila = dgvActividades.CurrentRow.Index;
                Actividades oActividades = new Actividades();
                Actividades.Actividad oActividad = oActividades.GetOne(Convert.ToInt32(dgvActividades["idActividad", i_Fila].Value));

                DialogResult drBaja;
                drBaja = MessageBox.Show("Esta seguro que desea dar de baja " + oActividad.Nombre.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drBaja == DialogResult.OK)
                {
                    oActividades.Disable(Convert.ToInt32(dgvActividades["idActividad", i_Fila].Value));
                    MessageBox.Show("La actividad ha sido eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    f_FillGridActividades();
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione una actividad.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void f_FillGridProfesores()
        {
            try
            {
                Profesores oProfesores = new Profesores();
                DataTable dtProfesores = oProfesores.GetTop100PL("P.idProfesor, P.NroDoc as 'Nro. Doc.', P.Nombre, P.Apellido, P.FechaNacimiento as 'Fecha Nac.', P.Edad, P.Sexo, P.Direccion, L.Nombre as 'Localidad', P.TelefonoFijo as 'Tel. Fijo', P.TelefonoCelular as 'Tel. Celular', P.FechaRegistracion as 'Fecha Registro'", "P.Estado=1 ORDER BY P.Apellido ASC");
                dgvProfesores.DataSource = dtProfesores;
                dgvProfesores.Columns["idProfesor"].Visible = false;
                lbCantStatusBar.Text = "Actividades: " + dgvActividades.Rows.Count.ToString().Trim() + "     Rutinas: " + dgvRutinas.Rows.Count.ToString().Trim() + "     Profesores: " + dgvProfesores.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_RegistrarProfesor()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarProfesor"] != null) Application.OpenForms["frmRegistrarEditarProfesor"].Close();
                frmRegistrarEditarProfesor frm = new frmRegistrarEditarProfesor();
                frmRegistrarEditarProfesor.idProfesor = 0;
                frm.Text = "Registrar profesor";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridProfesores(); }
            }
            catch (Exception) { }
        }

        public void f_EditarProfesor()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarProfesor"] != null) Application.OpenForms["frmRegistrarEditarProfesor"].Close();
                int intFila = dgvProfesores.CurrentRow.Index;
                frmRegistrarEditarProfesor.idProfesor = Convert.ToInt32(dgvProfesores["idProfesor", intFila].Value);
                frmRegistrarEditarProfesor frm = new frmRegistrarEditarProfesor();
                frm.Text = "Magnetar Gym Management | Editar profesor";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridProfesores(); }
            }
            catch (Exception) { }
        }

        public void f_BajaProfesor()
        {
            try
            {
                int i_Fila = dgvProfesores.CurrentRow.Index;
                Profesores oProfesores = new Profesores();
                Profesores.Profesor oProfesor = oProfesores.GetOne(Convert.ToInt32(dgvProfesores["idProfesor", i_Fila].Value));

                DialogResult drBaja;
                drBaja = MessageBox.Show("Esta seguro que desea dar de baja a " + oProfesor.Nombre.Trim() + " " + oProfesor.Apellido.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drBaja == DialogResult.OK)
                {
                    oProfesores.Disable(Convert.ToInt32(dgvProfesores["idProfesor", i_Fila].Value));
                    MessageBox.Show("El profesor ha sido dado de baja correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    f_FillGridProfesores();
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione un profesor.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void f_FillGridRutinas()
        {
            try
            {
                Rutinas oRutinas = new Rutinas();
                DataTable dtRutinas = oRutinas.GetAll("idRutina, Nombre, Duracion as 'Duracion en semanas'", "");
                dgvRutinas.DataSource = dtRutinas;
                dgvRutinas.Columns["idRutina"].Visible = false;
                lbCantStatusBar.Text = "Actividades: " + dgvActividades.Rows.Count.ToString().Trim() + "     Rutinas: " + dgvRutinas.Rows.Count.ToString().Trim() + "     Profesores: " + dgvProfesores.Rows.Count.ToString().Trim();
            }
            catch (Exception) { }
        }

        public void f_RegistrarRutina()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarRutina"] != null) Application.OpenForms["frmRegistrarEditarRutina"].Close();
                frmRegistrarEditarRutina.idRutina = 0;
                frmRegistrarEditarRutina frm = new frmRegistrarEditarRutina();
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridRutinas(); }
            }
            catch (Exception) { }
        }

        public void f_EditarRutina()
        {
            try
            {
                if (Application.OpenForms["frmRegistrarEditarRutina"] != null) Application.OpenForms["frmRegistrarEditarRutina"].Close();
                int intFila = dgvRutinas.CurrentRow.Index;
                frmRegistrarEditarRutina.idRutina = Convert.ToInt32(dgvRutinas["idRutina", intFila].Value);
                frmRegistrarEditarRutina frm = new frmRegistrarEditarRutina();
                frm.Text = "Magnetar Gym Management | Editar rutina";
                if (frm.ShowDialog() == DialogResult.OK) { f_FillGridRutinas(); }
            }
            catch (Exception) { }
        }

        public void f_EliminarRutina()
        {
            try
            {
                int i_Fila = dgvRutinas.CurrentRow.Index;
                Rutinas oRutinas = new Rutinas();
                Rutinas.Rutina oRutina = oRutinas.GetOne(Convert.ToInt32(dgvRutinas["idRutina", i_Fila].Value));

                DialogResult drEliminar;
                drEliminar = MessageBox.Show("Esta seguro que desea eliminar " + oRutina.Nombre.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK)
                {
                    oRutinas.Delete("Rutina", "idRutina=" + Convert.ToInt32(dgvRutinas["idRutina", i_Fila].Value));
                    MessageBox.Show("La rutina ha sido eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    f_FillGridRutinas();
                }
            }
            catch (Exception) { MessageBox.Show("Por favor, seleccione una rutina.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public void f_EjecutarCopiaSeguridad()
        {
            try
            {
                string sNombre = "C:\\DATABASE BACKUP CLUB GYM\\" + DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year.ToString() + ".bak";
                string sBackup = "BACKUP DATABASE GymDatabase TO DISK = N'" + sNombre + "' WITH NOFORMAT, NOINIT, NAME =N'GymDatabase', SKIP, STATS = 10";

                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                csb.DataSource = "(local)";
                csb.InitialCatalog = "GymDatabase";
                csb.IntegratedSecurity = false;
                csb.UserID = "admin";
                csb.Password = "123456";

                using (SqlConnection con = new SqlConnection(csb.ConnectionString))
                {
                    con.Open();
                    SqlCommand cmdBackUp = new SqlCommand(sBackup, con);
                    cmdBackUp.ExecuteNonQuery();
                    con.Close();
                }

                CopiasSeguridad oCopiasSeguridad = new CopiasSeguridad();
                CopiasSeguridad.CopiaSeguridad oCopiaSeguridad = new CopiasSeguridad.CopiaSeguridad();
                oCopiaSeguridad.FechaHora = DateTime.Now;
                oCopiaSeguridad.Ruta = sNombre;
                oCopiasSeguridad.Insert(oCopiaSeguridad);

                MessageBox.Show("La operacion se ha completado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion  
    }
}