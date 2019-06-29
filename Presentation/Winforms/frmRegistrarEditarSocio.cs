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
using System.Diagnostics;
using Logic;

namespace Presentation.Winforms
{
    public partial class frmRegistrarEditarSocio : Form
    {
        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarSocio.
        /// </summary>
        public static int idSocio = 0;
        #endregion

        public frmRegistrarEditarSocio()
        {
            InitializeComponent();
        }

        #region FORM && DATAGRIDVIEW
        private void frmRegistrarEditarSocio_Load(object sender, EventArgs e)
        {
            try
            {
                btnMembresias.Checked = true;
                twhSocio.SelectedIndex = 1;
                dtpFechaNac.Value = DateTime.Now.Date; dtpFechaNac.MaxDate = DateTime.Now.Date;
                cboSexo.SelectedIndex = 0;
                cboLocalidad.SelectedIndex = 0;
                txtNroDoc.Select();

                Funciones.f_FillComboBox(cboLocalidad, "idLocalidad", "Nombre", "", "Localidad", "", "Nombre");
                Funciones.f_FillComboBox(cboRutinas, "idRutina", "Nombre", "", "Rutina", "", "Nombre");

                if (idSocio == 0)
                {
                    f_ClearAll();
                }
                else
                {
                    Socios oSocios = new Socios();
                    Socios.Socio oSocio = oSocios.GetOne(idSocio);

                    txtNroDoc.Text = oSocio.NroDoc.ToString().Trim();
                    txtNombre.Text = oSocio.Nombre.ToString().Trim();
                    txtApellido.Text = oSocio.Apellido.ToString().Trim();
                    dtpFechaNac.Value = oSocio.FechaNacimiento;
                    txtEdad.Text = oSocio.Edad.ToString().Trim();
                    cboSexo.SelectedItem = oSocio.Sexo.ToString().Trim();
                    txtDireccion.Text = oSocio.Direccion.ToString().Trim();
                    cboLocalidad.SelectedValue = oSocio.idLocalidad;
                    txtOcupacion.Text = oSocio.Ocupacion.ToString().Trim();
                    txtOrganizacion.Text = oSocio.Organizacion.ToString().Trim();
                    txtTelefonoFijo.Text = oSocio.TelefonoFijo.ToString().Trim();
                    txtTelefonoCelular.Text = oSocio.TelefonoCelular.ToString().Trim();
                    txtEmail.Text = oSocio.Email.ToString().Trim();
                    if (oSocio.Medicamentos.ToString().Trim() == "" || oSocio.Medicamentos.ToString().Trim() == null) { rbMedicamentosNO.Checked = true; txtMedicamentos.Clear(); } else { rbMedicamentosSI.Checked = true; txtMedicamentos.Text = oSocio.Medicamentos.ToString().Trim(); }
                    if (oSocio.idRutina == 0) { chkNinguna.Checked = true; } else { cboRutinas.SelectedValue = oSocio.idRutina; }
                    if (cboRutinas.SelectedIndex == -1) { chkNinguna.Checked = true; }
                    txtNombreEmergencia.Text = oSocio.NombreEmergencia.ToString().Trim();
                    txtApellidoEmergencia.Text = oSocio.ApellidoEmergencia.ToString().Trim();
                    txtTelefonoEmergencia.Text = oSocio.NumeroEmergencia.ToString().Trim();
                    chFuma.Checked = Convert.ToBoolean(oSocio.Fuma);
                    chAlcohol.Checked = Convert.ToBoolean(oSocio.Alcohol);
                    chExperienciaPesas.Checked = Convert.ToBoolean(oSocio.ExperienciaPesas);
                    numPeso.Value = oSocio.Peso;
                    numAltura.Value = oSocio.Altura;
                    txtNotas.Text = oSocio.Notas.ToString().Trim();
                    if (oSocio.Imagen != "" && File.Exists(oSocio.Imagen)) { pbImagen.Load(oSocio.Imagen); } else { pbImagen.Image = Properties.Resources.sociodefault; }
                    if (oSocio.SizeMode != null || oSocio.SizeMode != "")
                    {
                        switch (oSocio.SizeMode.Trim())
                        {
                            case "Zoom":
                                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                                break;

                            case "CenterImage":
                                pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;
                                break;

                            case "Normal":
                                pbImagen.SizeMode = PictureBoxSizeMode.Normal;
                                break;

                            case "StretchImage":
                                pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                        }
                    }
                    else { pbImagen.SizeMode = PictureBoxSizeMode.Normal; }
                    if (pbImagen.ImageLocation == null) { pbImagen.SizeMode = PictureBoxSizeMode.Zoom; }
                    txtSaldo.Text = oSocio.Saldo.ToString(); if (oSocio.Saldo < 0) { txtSaldo.BackColor = Color.White; txtSaldo.ForeColor = Color.Red; } else { txtSaldo.BackColor = Color.White; txtSaldo.ForeColor = Color.Green; }; txtSaldo.ReadOnly = true;

                    f_FillGridMembresias();
                    f_GetAsistencias();
                    f_GetCasillero();
                    f_FillGridAjustes();

                    Lesiones oLesiones = new Lesiones();
                    DataTable dtLesiones = oLesiones.GetAll("Lesion.Nombre, Lesion.Tipo", "Lesion.idSocio=" + idSocio);
                    if (dtLesiones.Rows.Count != 0)
                    {
                        foreach (DataRow row in dtLesiones.Rows)
                        {
                            switch (row["Tipo"].ToString().Trim())
                            {
                                case "Respiratorio":
                                    rbRespiratorioSI.Checked = true;
                                    txtRespiratorio.Text = row["Nombre"].ToString().Trim();
                                    break;

                                case "Digestivo":
                                    rbDigestivoSI.Checked = true;
                                    txtDigestivo.Text = row["Nombre"].ToString().Trim();
                                    break;

                                case "Oseo":
                                    rbOseoSI.Checked = true;
                                    txtOseo.Text = row["Nombre"].ToString().Trim();
                                    break;

                                case "Otro":
                                    rbOtroSI.Checked = true;
                                    txtOtro.Text = row["Nombre"].ToString().Trim();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        rbRespiratorioNO.Checked = true; rbDigestivoNO.Checked = true; rbOseoNO.Checked = true; rbOtroNO.Checked = true;
                        txtRespiratorio.Clear(); txtDigestivo.Clear(); txtOseo.Clear(); txtOtro.Clear();
                    }
                }
                txtNroDoc.Select();
            }
            catch (Exception) { }
        }

        private void dgvMembresias_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                Membresias oMembresias = new Membresias();
                foreach (DataGridViewRow row in dgvMembresias.Rows)
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
                            row.DefaultCellStyle.ForeColor = Color.Green;
                            break;
                    }
                }
                dgvMembresias.ClearSelection();
            }
            catch (Exception) { }
        }

        private void txtAsistencias_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsistencias.idSocio = idSocio;
                frmAsistencias frm = new frmAsistencias();
                frm.ShowDialog();
                f_GetAsistencias();
            }
            catch (Exception) { }
        }

        private void txtUltimaAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsistencias.idSocio = idSocio;
                frmAsistencias frm = new frmAsistencias();
                frm.ShowDialog();
                f_GetAsistencias();
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

        #region MENU TOP
        private void btnNuevoSocio_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult drClear = MessageBox.Show("Se van a limpiar todos los campos. ¿Desea continuar?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (drClear == DialogResult.OK) { f_ClearAll(); }
            }
            catch (Exception) { }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Socios oSocios = new Socios();
                Socios.Socio oSocio = new Socios.Socio();

                if (txtNroDoc.Text == "" || txtNroDoc.Text.Replace(" ", string.Empty).Length < 8) { MessageBox.Show("El numero de documento no puede quedar en blanco o tener espacios.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); twhSocio.SelectedIndex = 0; txtNroDoc.Select(); return; }
                string s_Doc = oSocios.ValidarDocumento(txtNroDoc.Text.Trim()); if (s_Doc != "" && idSocio == 0) { MessageBox.Show(s_Doc, "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtNroDoc.Select(); return; }
                if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "") { MessageBox.Show("Nombre y apellido son obligatorios. Por favor, completa los campos.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); twhSocio.SelectedIndex = 0; if (txtNombre.Text == "") { txtNombre.Select(); } else { txtApellido.Select(); } return; }
                if (txtEdad.Text == "") { MessageBox.Show("La fecha de nacimiento es obligatoria. Por favor, completa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); twhSocio.SelectedIndex = 0; dtpFechaNac.Select(); return; }
                if (Convert.ToInt32(txtEdad.Text) <= 0) { MessageBox.Show("La edad debe ser mayor a cero. Por favor, revisa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); twhSocio.SelectedIndex = 0; dtpFechaNac.Select(); return; }
                if (cboLocalidad.SelectedIndex == -1) { MessageBox.Show("El socio debe tener una localidad. Por favor, revisa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); twhSocio.SelectedIndex = 0; cboLocalidad.Select(); return; }

                if (idSocio == 0)
                {
                    oSocio.NroDoc = Convert.ToInt32(txtNroDoc.Text.ToString().Trim());
                    oSocio.Nombre = txtNombre.Text.ToString().Trim();
                    oSocio.Apellido = txtApellido.Text.ToString().Trim();
                    oSocio.FechaNacimiento = dtpFechaNac.Value;
                    oSocio.Edad = Convert.ToInt32(txtEdad.Text.ToString().Trim());
                    oSocio.Sexo = cboSexo.SelectedItem.ToString().Trim();
                    oSocio.Direccion = txtDireccion.Text.ToString().Trim();
                    oSocio.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                    oSocio.Ocupacion = txtOcupacion.Text.ToString().Trim();
                    oSocio.Organizacion = txtOrganizacion.Text.ToString().Trim();
                    oSocio.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                    oSocio.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                    oSocio.Email = txtEmail.Text.ToString().Trim();
                    oSocio.Medicamentos = txtMedicamentos.Text.ToString().Trim();
                    if (chkNinguna.Checked) { oSocio.idRutina = 0; } else { oSocio.idRutina = Convert.ToInt32(cboRutinas.SelectedValue); }
                    oSocio.NombreEmergencia = txtNombreEmergencia.Text.ToString().Trim();
                    oSocio.ApellidoEmergencia = txtApellidoEmergencia.Text.ToString().Trim();
                    oSocio.NumeroEmergencia = txtTelefonoEmergencia.Text.ToString().Trim();
                    oSocio.Fuma = Convert.ToInt32(chFuma.CheckState);
                    oSocio.Alcohol = Convert.ToInt32(chAlcohol.CheckState);
                    oSocio.ExperienciaPesas = Convert.ToInt32(chExperienciaPesas.CheckState);
                    oSocio.Peso = Convert.ToInt32(numPeso.Value);
                    oSocio.Altura = Convert.ToInt32(numAltura.Value);
                    oSocio.Notas = txtNotas.Text.ToString().Trim();
                    if (pbImagen.ImageLocation != null) { oSocio.Imagen = pbImagen.ImageLocation; oSocio.SizeMode = pbImagen.SizeMode.ToString(); } else { oSocio.Imagen = ""; oSocio.SizeMode = "Normal"; }
                    oSocio.Saldo = Convert.ToDecimal(txtSaldo.Text);
                    oSocio.FechaRegistracion = DateTime.Now.Date;
                    oSocio.Estado = 1;

                    idSocio = oSocios.Insert(oSocio);

                    Lesiones oLesiones = new Lesiones();
                    Lesiones.Lesion oLesion = new Lesiones.Lesion();
                    oLesion.idSocio = idSocio;
                    if (rbRespiratorioSI.Checked)
                    {
                        oLesion.Nombre = txtRespiratorio.Text.ToString().Trim();
                        oLesion.Tipo = "Respiratorio";
                        oLesiones.Insert(oLesion);
                    }
                    if (rbDigestivoSI.Checked)
                    {
                        oLesion.Nombre = txtDigestivo.Text.ToString().Trim();
                        oLesion.Tipo = "Digestivo";
                        oLesiones.Insert(oLesion);
                    }
                    if (rbOseoSI.Checked)
                    {
                        oLesion.Nombre = txtOseo.Text.ToString().Trim();
                        oLesion.Tipo = "Oseo";
                        oLesiones.Insert(oLesion);
                    }
                    if (rbOtroSI.Checked)
                    {
                        oLesion.Nombre = txtOtro.Text.ToString().Trim();
                        oLesion.Tipo = "Otro";
                        oLesiones.Insert(oLesion);
                    }

                    btnRegistrarMembresia.Enabled = true; btnRegistrarMembresia.BackColor = Color.Green;
                    btnBajaMembresia.Enabled = true; btnBajaMembresia.BackColor = Color.Green;
                    btnEliminarMembresia.Enabled = true; btnEliminarMembresia.BackColor = Color.Green;
                    btnRenovar.Enabled = true; btnRenovar.BackColor = Color.Green;
                    btnCambiarTurno.Enabled = true; btnCambiarTurno.BackColor = Color.Green;
                    btnHistoriales.Enabled = true; btnHistoriales.BackColor = Color.Green;
                    btnRegistrarPago.Enabled = true; btnRegistrarPago.BackColor = Color.Green;
                    btnAsignar.Enabled = true; btnAsignar.BackColor = Color.Green;
                    btnPagarCasillero.Enabled = true; btnPagarCasillero.BackColor = Color.Green;
                    MessageBox.Show("El nuevo socio se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oSocio.idSocio = idSocio;
                    oSocio.NroDoc = Convert.ToInt32(txtNroDoc.Text.ToString().Trim());
                    oSocio.Nombre = txtNombre.Text.ToString().Trim();
                    oSocio.Apellido = txtApellido.Text.ToString().Trim();
                    oSocio.FechaNacimiento = dtpFechaNac.Value;
                    oSocio.Edad = Convert.ToInt32(txtEdad.Text.ToString().Trim());
                    oSocio.Sexo = cboSexo.SelectedItem.ToString().Trim();
                    oSocio.Direccion = txtDireccion.Text.ToString().Trim();
                    oSocio.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                    oSocio.Ocupacion = txtOcupacion.Text.ToString().Trim();
                    oSocio.Organizacion = txtOrganizacion.Text.ToString().Trim();
                    oSocio.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                    oSocio.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                    oSocio.Email = txtEmail.Text.ToString().Trim();
                    oSocio.Medicamentos = txtMedicamentos.Text.ToString().Trim();
                    if (chkNinguna.Checked) { oSocio.idRutina = 0; } else { oSocio.idRutina = Convert.ToInt32(cboRutinas.SelectedValue); }
                    oSocio.NombreEmergencia = txtNombreEmergencia.Text.ToString().Trim();
                    oSocio.ApellidoEmergencia = txtApellidoEmergencia.Text.ToString().Trim();
                    oSocio.NumeroEmergencia = txtTelefonoEmergencia.Text.ToString().Trim();
                    oSocio.Fuma = Convert.ToInt32(chFuma.CheckState);
                    oSocio.Alcohol = Convert.ToInt32(chAlcohol.CheckState);
                    oSocio.ExperienciaPesas = Convert.ToInt32(chExperienciaPesas.CheckState);
                    oSocio.Peso = Convert.ToInt32(numPeso.Value);
                    oSocio.Altura = Convert.ToInt32(numAltura.Value);
                    oSocio.Notas = txtNotas.Text.ToString().Trim();
                    if (pbImagen.ImageLocation != null) { oSocio.Imagen = pbImagen.ImageLocation; oSocio.SizeMode = pbImagen.SizeMode.ToString(); } else { oSocio.Imagen = ""; oSocio.SizeMode = "Normal"; }
                    oSocio.Saldo = Convert.ToDecimal(txtSaldo.Text);

                    oSocios.Update(oSocio);

                    Lesiones oLesiones = new Lesiones();
                    oLesiones.Delete("Lesion", "idSocio=" + idSocio);

                    Lesiones.Lesion oLesion = new Lesiones.Lesion();
                    oLesion.idSocio = idSocio;
                    if (rbRespiratorioSI.Checked)
                    {
                        oLesion.Nombre = txtRespiratorio.Text.ToString().Trim();
                        oLesion.Tipo = "Respiratorio";
                        oLesiones.Insert(oLesion);
                    }
                    if (rbDigestivoSI.Checked)
                    {
                        oLesion.Nombre = txtDigestivo.Text.ToString().Trim();
                        oLesion.Tipo = "Digestivo";
                        oLesiones.Insert(oLesion);
                    }
                    if (rbOseoSI.Checked)
                    {
                        oLesion.Nombre = txtOseo.Text.ToString().Trim();
                        oLesion.Tipo = "Oseo";
                        oLesiones.Insert(oLesion);
                    }
                    if (rbOtroSI.Checked)
                    {
                        oLesion.Nombre = txtOtro.Text.ToString().Trim();
                        oLesion.Tipo = "Otro";
                        oLesiones.Insert(oLesion);
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception) { }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSocio == 0) { return; }
                if (dgvMembresias.Rows.Count > 0) { MessageBox.Show("Antes de dar de baja un socio debes dar de baja o eliminar todas sus membresias activas.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

                
                DialogResult drBaja = MessageBox.Show("Esta seguro que desea dar de baja a " + txtNombre.Text.Trim() + " " + txtApellido.Text.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drBaja == DialogResult.OK)
                {
                    Socios oSocios = new Socios();
                    oSocios.Disable(idSocio);
                    MessageBox.Show("El socio ha sido dado de baja correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception) { }
        }

        private void btnRegistrarAsistencia_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSocio == 0) { return; }
                if (Application.OpenForms["frmRegistrarAsistencia"] != null) Application.OpenForms["frmRegistrarAsistencia"].Close();
                frmRegistrarAsistencia.idSocio = idSocio;
                frmRegistrarAsistencia.s_Socio = txtNombre.Text.Trim() + " " + txtApellido.Text.Trim();
                frmRegistrarAsistencia frm = new frmRegistrarAsistencia();
                frm.ShowDialog();

                Asistencias oAsistencias = new Asistencias();
                txtAsistencias.Text = oAsistencias.CountAsistenciasSocio(idSocio).ToString();
                txtUltimaAsistencia.Text = oAsistencias.UltimaAsistenciaSocio(idSocio);
            }
            catch (Exception) { }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region MENU LEFT
        private void btnDatosClinicos_Click(object sender, EventArgs e)
        {
            twhSocio.SelectedIndex = 0;
            btnDatosClinicos.Checked = true;
            btnMembresias.Checked = false;
            btnCuenta.Checked = false;
            btnDatosExtra.Checked = false;
        }

        private void btnMembresias_Click(object sender, EventArgs e)
        {
            twhSocio.SelectedIndex = 1;
            btnDatosClinicos.Checked = false;
            btnMembresias.Checked = true;
            btnCuenta.Checked = false;
            btnDatosExtra.Checked = false;
        }

        private void btnCuenta_Click(object sender, EventArgs e)
        {
            twhSocio.SelectedIndex = 2;
            btnDatosClinicos.Checked = false;
            btnMembresias.Checked = false;
            btnCuenta.Checked = true;
            btnDatosExtra.Checked = false;
        }

        private void btnDatosExtra_Click(object sender, EventArgs e)
        {
            twhSocio.SelectedIndex = 3;
            btnDatosClinicos.Checked = false;
            btnMembresias.Checked = false;
            btnCuenta.Checked = false;
            btnDatosExtra.Checked = true;
        }
        #endregion

        #region DATOS PERSONALES
        private void pbImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgImagen.ShowDialog() == DialogResult.OK) { pbImagen.Load(dlgImagen.FileName); }
            }
            catch (Exception) { }
        }

        private void dtpFechaNac_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtEdad.Text = Convert.ToString((Convert.ToInt32(f_CalcularEdad(dtpFechaNac.Value))));
            }
            catch (Exception) { }
        }

        private void btnRegistrarLocalidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmLocalidades"] != null) Application.OpenForms["frmLocalidades"].Close();
                frmLocalidades frm = new frmLocalidades();
                frm.ShowDialog();
                Funciones.f_FillComboBox(cboLocalidad, "idLocalidad", "Nombre", "", "Localidad", "", "Nombre");
            }
            catch (Exception) { }
        }
        #endregion

        #region DATOS CLINICOS
        private void rbRespiratorioSI_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbRespiratorioSI.Checked) { txtRespiratorio.Enabled = true; } else { txtRespiratorio.Clear(); txtRespiratorio.Enabled = false; }
            }
            catch (Exception) { }
        }

        private void rbDigestivoSI_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDigestivoSI.Checked) { txtDigestivo.Enabled = true; } else { txtDigestivo.Clear(); txtDigestivo.Enabled = false; }
        }

        private void rbOseoSI_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOseoSI.Checked) { txtOseo.Enabled = true; } else { txtOseo.Clear(); txtOseo.Enabled = false; }
        }

        private void rbOtroSI_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOtroSI.Checked) { txtOtro.Enabled = true; } else { txtOtro.Clear(); txtOtro.Enabled = false; }
        }

        private void rbMedicamentosSI_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMedicamentosSI.Checked) { txtMedicamentos.Enabled = true; } else { txtMedicamentos.Enabled = false; txtMedicamentos.Clear(); }
        }

        private void numPeso_ValueChanged(object sender, EventArgs e)
        {
            f_CalcularIMC();
        }

        private void numAltura_ValueChanged(object sender, EventArgs e)
        {
            f_CalcularIMC();
        }
        #endregion

        #region MEMBRESIAS
        private void btnRegistrarMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarEditarMembresia.idMembresia = 0;
                frmRegistrarEditarMembresia frm = new frmRegistrarEditarMembresia();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    f_FillGridMembresias();
                    Socios oSocios = new Socios();
                    txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString();
                    if (Convert.ToInt32(txtSaldo.Text) < 0) { txtSaldo.ForeColor = Color.Red; }
                }
            }
            catch (Exception) { }
        }

        private void btnBajaMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = (dgvMembresias.CurrentRow.Index);
                DialogResult drEliminar = MessageBox.Show("Esta seguro que desea dar de baja esta membresia?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK)
                {
                    Membresias oMembresias = new Membresias();
                    oMembresias.Disable(Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value));

                    HistorialesMembresias oHistorialesMembresias = new HistorialesMembresias();
                    HistorialesMembresias.HistorialMembresias oHistorialMembresia = new HistorialesMembresias.HistorialMembresias();
                    oHistorialMembresia.idMembresia = Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value);
                    oHistorialMembresia.Fecha = DateTime.Now.Date;
                    oHistorialMembresia.Concepto = "Baja";
                    oHistorialMembresia.Saldo = Convert.ToDecimal(txtSaldo.Text);

                    oHistorialesMembresias.Insert(oHistorialMembresia);

                    SociosxTurnos oSociosxTurnos = new SociosxTurnos();
                    oSociosxTurnos.Delete("SocioxTurno", "SocioxTurno.idSocio=" + idSocio + " AND SocioxTurno.idTurno=" + Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value));

                    Turnos oTurnos = new Turnos();
                    oTurnos.AddInscripto(Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value), -1);
                    f_FillGridMembresias();
                    MessageBox.Show("La membresia ha sido dado de baja correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) { }
        }

        private void btnEliminarMembresia_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    int i_Fila = dgvMembresias.CurrentRow.Index;
                    DialogResult drEliminar = MessageBox.Show("Esta a punto de eliminar una membresia, esto significa que se elimininaran los cobros e historiales relacionados a dicha membresia y se reestablecera el saldo del socio. Desea continuar?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                    if (drEliminar == DialogResult.OK)
                    {
                        Membresias oMembresias = new Membresias();
                        Socios oSocios = new Socios();
                        Turnos oTurnos = new Turnos();
                        SociosxTurnos oSociosxTurnos = new SociosxTurnos();

                        //Actualiza el saldo, obtiene el nuevo saldo, elimina la membresia, resta un inscripto al turno, elimina los sociosxturno.
                        oSocios.UpdateSaldo(idSocio, (Convert.ToDecimal(dgvMembresias["Precio", i_Fila].Value) - Convert.ToDecimal(dgvMembresias["Descuento", i_Fila].Value) - Convert.ToDecimal(oMembresias.CuantoPago(Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value)))).ToString());
                        txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString(); if (Convert.ToDecimal(txtSaldo.Text) < 0) { txtSaldo.ForeColor = Color.Red; }
                        oMembresias.Delete(Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value));
                        oTurnos.AddInscripto(Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value), -1);
                        oSociosxTurnos.Delete("SocioxTurno", "SocioxTurno.idSocio=" + idSocio + " AND SocioxTurno.idTurno=" + Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value));

                        f_FillGridMembresias();
                        MessageBox.Show("La membresia ha sido eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception) { }
            }
            catch (Exception) { }
        }

        private void btnRenovar_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvMembresias.CurrentRow.Index;
                if (dgvMembresias.Rows[i_Fila].DefaultCellStyle.ForeColor == Color.Red || dgvMembresias.Rows[i_Fila].DefaultCellStyle.ForeColor == Color.Gold) { MessageBox.Show("No puedes renovar una membresia que no ha sido pagada.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                int i_Dias = Convert.ToDateTime(dgvMembresias["Vencimiento", i_Fila].Value).Subtract(DateTime.Now).Days;
                if (i_Dias > 3) { MessageBox.Show("Las membresias pueden renovarse con un maximo de tres dias de anticipacion a su vencimiento. Aun faltan " + i_Dias.ToString() + " dias para este vencimiento.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                DialogResult drRenovar = MessageBox.Show("La membresia se va a renovar utilizando los mismos datos. Desea continuar?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                if (drRenovar == DialogResult.OK)
                {
                    Membresias oMembresias = new Membresias();
                    oMembresias.Disable(Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value));

                    Membresias.Membresia oMembresia = new Membresias.Membresia();
                    oMembresia.idSocio = idSocio;
                    oMembresia.idActividad = Convert.ToInt32(dgvMembresias["idActividad", i_Fila].Value);
                    oMembresia.idTurno = Convert.ToInt32(dgvMembresias["idTurno", i_Fila].Value);
                    oMembresia.Duracion = dgvMembresias["Duracion", i_Fila].Value.ToString().Trim();
                    oMembresia.FechaInicio = Convert.ToDateTime(dgvMembresias["Vencimiento", i_Fila].Value);
                    switch (oMembresia.Duracion.Trim())
                    {
                        case "Clase":
                            oMembresia.FechaVencimiento = oMembresia.FechaInicio.AddDays(1);
                            break;

                        case "Semana":
                            oMembresia.FechaVencimiento = oMembresia.FechaInicio.AddDays(7);
                            break;

                        case "Mes":
                            oMembresia.FechaVencimiento = oMembresia.FechaInicio.AddDays(30);
                            break;

                        case "Trimestre":
                            oMembresia.FechaVencimiento = oMembresia.FechaInicio.AddDays(90);
                            break;
                    }
                    oMembresia.Precio = Convert.ToDecimal(dgvMembresias["Precio", i_Fila].Value);
                    oMembresia.Descuento = Convert.ToDecimal(dgvMembresias["Descuento", i_Fila].Value);
                    oMembresia.Estado = 1;

                    int idMembresia = oMembresias.Insert(oMembresia);

                    Socios oSocios = new Socios();
                    oSocios.UpdateSaldo(idSocio, Convert.ToString((oMembresia.Precio - oMembresia.Descuento) * -1));
                    txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString().Trim();

                    HistorialesMembresias oHistorialesMembresias = new HistorialesMembresias();
                    HistorialesMembresias.HistorialMembresias oHistorialMembresias = new HistorialesMembresias.HistorialMembresias();
                    oHistorialMembresias.idMembresia = idMembresia;
                    oHistorialMembresias.Fecha = oMembresia.FechaInicio;
                    oHistorialMembresias.Concepto = "Renovacion";
                    oHistorialMembresias.Saldo = Convert.ToDecimal(txtSaldo.Text);
                    oHistorialesMembresias.Insert(oHistorialMembresias);

                    MessageBox.Show("Membresia renovada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    f_FillGridMembresias();
                }
            }
            catch (Exception) { }
        }

        private void btnCambiarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                int i_Fila = dgvMembresias.CurrentRow.Index;
                frmRegistrarEditarMembresia.idMembresia = Convert.ToInt32(dgvMembresias["idMembresia", i_Fila].Value);
                frmRegistrarEditarMembresia frm = new frmRegistrarEditarMembresia();
                frm.Text = "Magnetar Gym Management | Cambiar turno";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    f_FillGridMembresias();
                    Socios oSocios = new Socios();
                    txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString();
                }
            }
            catch (Exception) { }
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarPagoMembresia frm = new frmRegistrarPagoMembresia();
                frm.ShowDialog();
                Socios oSocios = new Socios();
                txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString();
                f_FillGridMembresias();
            }
            catch (Exception) { }
        }

        private void btnHistoriales_Click(object sender, EventArgs e)
        {
            try
            {
                if (Application.OpenForms["frmHistorialesSocio"] != null) Application.OpenForms["frmHistorialesSocio"].Close();
                frmHistorialesSocio frm = new frmHistorialesSocio();
                frm.ShowDialog();
            }
            catch (Exception) { }
        }
        #endregion

        #region CUENTA
        private void btnAjustarSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                frmAjustarSaldo frm = new frmAjustarSaldo();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    f_FillGridAjustes();
                    Socios oSocios = new Socios();
                    txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region DATOS EXTRA
        private void chkNinguna_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkNinguna.Checked) { cboRutinas.Enabled = false; cboRutinas.SelectedIndex = -1; } else { cboRutinas.Enabled = true; cboRutinas.SelectedIndex = 0; }
            }
            catch (Exception) { }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                frmAsignarCasillero frm = new frmAsignarCasillero();
                frmAsignarCasillero.idSocio = idSocio;
                frm.ShowDialog();
                f_GetCasillero();

                Socios oSocios = new Socios();
                txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString(); if (Convert.ToInt32(txtSaldo.Text) < 0) { txtSaldo.ForeColor = Color.Red; }
            }
            catch (Exception) { }
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {

        }

        private void btnPagarCasillero_Click(object sender, EventArgs e)
        {
            try
            {
                frmRegistrarPagoCasillero frm = new frmRegistrarPagoCasillero();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Socios oSocios = new Socios();
                    txtSaldo.Text = oSocios.GetSaldo(idSocio).ToString();
                    f_GetCasillero();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region CONTEXT MENU
        private void cmsCargar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dlgImagen.ShowDialog() == DialogResult.OK) { pbImagen.Load(dlgImagen.FileName); }
            }
            catch (Exception) { }
        }

        private void cmsQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                pbImagen.Image = Properties.Resources.sociodefault; pbImagen.ImageLocation = ""; pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception) { }
        }

        private void cmsRedimensionar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (pbImagen.SizeMode.ToString().Trim())
                {
                    case "Zoom":
                        pbImagen.SizeMode = PictureBoxSizeMode.CenterImage;
                        break;

                    case "CenterImage":
                        pbImagen.SizeMode = PictureBoxSizeMode.Normal;
                        break;

                    case "Normal":
                        pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                        break;

                    case "StretchImage":
                        pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                        break;
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public int f_CalcularEdad(DateTime fechaNac)
        {
            try
            {
                int Edad = DateTime.Now.Year - fechaNac.Year;
                if (DateTime.Now.Month < fechaNac.Month || (DateTime.Now.Month == fechaNac.Month && DateTime.Now.Day < fechaNac.Day)) Edad--;
                return Edad;
            }
            catch (Exception) { return 0; }
        }

        public void f_ClearAll()
        {
            try
            {
                idSocio = 0;
                twhSocio.SelectedIndex = 1;
                pbImagen.Image = Properties.Resources.sociodefault;
                txtAsistencias.Clear();
                txtUltimaAsistencia.Clear();
                txtNroDoc.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                dtpFechaNac.Value = DateTime.Now.Date;
                txtEdad.Clear();
                cboSexo.SelectedIndex = 0;
                txtDireccion.Clear();
                cboLocalidad.SelectedIndex = 0;
                txtOcupacion.Clear();
                txtOrganizacion.Clear();
                txtTelefonoFijo.Clear();
                txtTelefonoCelular.Clear();
                txtEmail.Clear();
                txtSaldo.Text = "0,00"; txtSaldo.BackColor = Color.White; txtSaldo.ForeColor = Color.Green; txtSaldo.ReadOnly = true;
                txtAsistencias.ReadOnly = true;
                txtUltimaAsistencia.ReadOnly = true;
                rbRespiratorioNO.Checked = true; txtRespiratorio.Clear(); txtRespiratorio.Enabled = false;
                rbDigestivoNO.Checked = true; txtDigestivo.Clear(); txtDigestivo.Enabled = false;
                rbOseoNO.Checked = true; txtOseo.Clear(); txtOseo.Enabled = false;
                rbOtroNO.Checked = true; txtOtro.Clear(); txtOtro.Enabled = false;
                rbMedicamentosNO.Checked = true;
                txtMedicamentos.Clear();
                txtMedicamentos.Enabled = false;
                txtNombreEmergencia.Clear();
                txtApellidoEmergencia.Clear();
                txtTelefonoEmergencia.Clear();
                chFuma.Checked = false;
                chAlcohol.Checked = false;
                chExperienciaPesas.Checked = false;
                numPeso.Value = numPeso.Minimum;
                numAltura.Value = numAltura.Minimum;
                txtIMC.Clear();
                txtNotas.Clear();
                chkNinguna.Checked = true;
                dgvMembresias.DataSource = null; dgvMembresias.Rows.Clear();
                btnRegistrarMembresia.Enabled = false; btnRegistrarMembresia.BackColor = Color.Silver;
                btnBajaMembresia.Enabled = false; btnBajaMembresia.BackColor = Color.Silver;
                btnRegistrarPago.Enabled = false; btnRegistrarPago.BackColor = Color.Silver;
                btnRenovar.Enabled = false; btnRenovar.BackColor = Color.Silver;
                btnHistoriales.Enabled = false; btnHistoriales.BackColor = Color.Silver;
                btnEliminarMembresia.Enabled = false; btnEliminarMembresia.BackColor = Color.Silver;
                btnCambiarTurno.Enabled = false; btnCambiarTurno.BackColor = Color.Silver;
                btnAsignar.Enabled = false; btnAsignar.BackColor = Color.Silver;
                btnPagarCasillero.Enabled = false; btnPagarCasillero.BackColor = Color.Silver;
                txtNroDoc.Select();
            }
            catch (Exception) { }
        }

        public void f_CalcularIMC()
        {
            try
            {
                decimal imc = (numPeso.Value / (numAltura.Value * numAltura.Value)) * 10000;
                txtIMC.Text = imc.ToString().Trim();
                if (imc <= 16) { txtDescIMC.Text = "Delgadez severa"; txtDescIMC.ForeColor = Color.Red; }
                if (imc >= 16 && imc <= 17) { txtDescIMC.Text = "Delgadez moderada"; txtDescIMC.ForeColor = Color.Orange; }
                if (imc >= 17 && imc <= 18.49m) { txtDescIMC.Text = "Delgadez leve"; txtDescIMC.ForeColor = Color.GreenYellow; }
                if (imc >= 18.5m && imc <= 24.99m) { txtDescIMC.Text = "Normal"; txtDescIMC.ForeColor = Color.Green; }
                if (imc >= 25 && imc <= 29.99m) { txtDescIMC.Text = "Sobrepeso leve"; txtDescIMC.ForeColor = Color.GreenYellow; }
                if (imc >= 30 && imc <= 34.99m) { txtDescIMC.Text = "Obesidad leve"; txtDescIMC.ForeColor = Color.Orange; }
                if (imc >= 35 && imc <= 39.99m) { txtDescIMC.Text = "Obesidad media"; txtDescIMC.ForeColor = Color.OrangeRed; }
                if (imc >= 40) { txtDescIMC.Text = "Obesidad morbida"; txtDescIMC.ForeColor = Color.Red; }
            }
            catch (Exception) { }
        }

        public void f_FillGridMembresias()
        {
            try
            {
                Membresias oMembresias = new Membresias();
                DataTable dtMembresias = oMembresias.GetAllMix("Membresia.idMembresia, Actividad.idActividad, Actividad.Nombre as 'Actividad', Turno.idTurno, Turno.Hora as 'Turno', Membresia.FechaInicio as 'Inicio', Membresia.FechaVencimiento as 'Vencimiento', Membresia.Duracion, Membresia.Precio, Membresia.Descuento, Membresia.Total", "Socio.idSocio=" + idSocio + " AND Membresia.Estado=1 AND Actividad.Estado=1 AND Membresia.idSocio=Socio.idSocio AND Membresia.idActividad=Actividad.idActividad AND Turno.idActividad=Actividad.idActividad AND Membresia.idTurno=Turno.idTurno");
                dgvMembresias.DataSource = dtMembresias;
                dgvMembresias.Columns["idMembresia"].Visible = false;
                dgvMembresias.Columns["idTurno"].Visible = false;
                dgvMembresias.Columns["idActividad"].Visible = false;
                dgvMembresias.Columns["Duracion"].Visible = false;
                dgvMembresias.Columns["Precio"].Visible = false;
                dgvMembresias.Columns["Descuento"].Visible = false;
                dgvMembresias.ClearSelection();
            }
            catch (Exception) { }
        }

        public void f_GetAsistencias()
        {
            try
            {
                Asistencias oAsistencias = new Asistencias();
                txtAsistencias.Text = oAsistencias.CountAsistenciasSocio(idSocio).ToString(); txtAsistencias.ReadOnly = true;
                txtUltimaAsistencia.Text = oAsistencias.UltimaAsistenciaSocio(idSocio).ToString(); txtUltimaAsistencia.ReadOnly = true;
            }
            catch (Exception) { }
        }

        public void f_GetCasillero()
        {
            try
            {
                Casilleros oCasilleros = new Casilleros();
                txtCasillero.Text = oCasilleros.GetCasillero(idSocio);
                txtCasillero.ReadOnly = true;
                if (txtCasillero.Text == "Ninguno") { btnAsignar.Enabled = true; }
            }
            catch (Exception) { }
        }

        public void f_FillGridAjustes()
        {
            try
            {
                Ajustes oAjustes = new Ajustes();
                DataTable dtAjustes = oAjustes.GetTop100("*", "idSocio=" + idSocio);
                dgvAjustes.DataSource = dtAjustes;
                dgvAjustes.Columns["idAjuste"].Visible = false;
                dgvAjustes.Columns["idSocio"].Visible = false;
                dgvAjustes.ClearSelection();
            }
            catch (Exception) { }
        }
        #endregion
    }
}
