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
using Logic;

namespace Presentation.Winforms
{
    public partial class frmRegistrarEditarProfesor : Form
    {
        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarProfesor.
        /// </summary>
        public static int idProfesor = 0;
        #endregion

        public frmRegistrarEditarProfesor()
        {
            InitializeComponent();
        }

        #region LOAD
        private void frmRegistrarEditarProfesor_Load(object sender, EventArgs e)
        {
            try
            {
                Funciones.f_FillComboBox(cboLocalidad, "idLocalidad", "Nombre", "", "Localidad", "", "Nombre");

                if (idProfesor == 0)
                {
                    f_ClearAll();
                }
                else
                {
                    Profesores oProfesores = new Profesores();
                    Profesores.Profesor oProfesor = oProfesores.GetOne(idProfesor);
                    txtNroDoc.Text = oProfesor.NroDoc.ToString().Trim();
                    txtNombre.Text = oProfesor.Nombre.ToString().Trim();
                    txtApellido.Text = oProfesor.Apellido.ToString().Trim();
                    dtpFechaNac.Value = oProfesor.FechaNacimiento;
                    txtEdad.Text = oProfesor.Edad.ToString().Trim();
                    cboSexo.SelectedItem = oProfesor.Sexo.ToString().Trim();
                    txtDireccion.Text = oProfesor.Direccion.ToString().Trim();
                    cboLocalidad.SelectedValue = oProfesor.idLocalidad;
                    txtOcupacion.Text = oProfesor.Ocupacion.ToString().Trim();
                    txtTelefonoFijo.Text = oProfesor.TelefonoFijo.ToString().Trim();
                    txtTelefonoCelular.Text = oProfesor.TelefonoCelular.ToString().Trim();
                    txtEmail.Text = oProfesor.Email.ToString().Trim();
                    if (oProfesor.Imagen != "" && File.Exists(oProfesor.Imagen)) { pbImagen.Load(oProfesor.Imagen); } else { pbImagen.Image = Properties.Resources.sociodefault; }
                    if (oProfesor.SizeMode != null)
                    {
                        switch (oProfesor.SizeMode.Trim())
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
                    else
                    {
                        pbImagen.SizeMode = PictureBoxSizeMode.Normal;
                    }
                    if (pbImagen.ImageLocation == null) { pbImagen.SizeMode = PictureBoxSizeMode.Zoom; }

                    Actividades oActividades = new Actividades();
                    DataTable dtActividades = oActividades.GetAllProfesor(idProfesor);
                    dgvActividades.DataSource = dtActividades;
                    dgvActividades.ClearSelection();
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnNuevoProfesor_Click(object sender, EventArgs e)
        {
            f_ClearAll();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f_ValidarProfesor()) { return; }
                if (!f_ValidarDocumento()) { return; }

                Profesores oProfesores = new Profesores();
                Profesores.Profesor oProfesor = new Profesores.Profesor();

                if (idProfesor == 0)
                {
                    oProfesor.NroDoc = Convert.ToInt32(txtNroDoc.Text.ToString().Trim());
                    oProfesor.Nombre = txtNombre.Text.ToString().Trim();
                    oProfesor.Apellido = txtApellido.Text.ToString().Trim();
                    oProfesor.FechaNacimiento = dtpFechaNac.Value;
                    oProfesor.Edad = Convert.ToInt32(txtEdad.Text.ToString().Trim());
                    oProfesor.Sexo = cboSexo.SelectedItem.ToString().Trim();
                    oProfesor.Direccion = txtDireccion.Text.ToString().Trim();
                    oProfesor.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                    oProfesor.Ocupacion = txtOcupacion.Text.ToString().Trim();
                    oProfesor.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                    oProfesor.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                    oProfesor.Email = txtEmail.Text.ToString().Trim();
                    if (pbImagen.ImageLocation != null) { oProfesor.Imagen = pbImagen.ImageLocation; oProfesor.SizeMode = pbImagen.SizeMode.ToString(); } else { oProfesor.Imagen = ""; oProfesor.SizeMode = "Normal"; }
                    oProfesor.Estado = 1;

                    oProfesores.Insert(oProfesor);
                    MessageBox.Show("El nuevo profesor se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oProfesor.idProfesor = idProfesor;
                    oProfesor.NroDoc = Convert.ToInt32(txtNroDoc.Text.ToString().Trim());
                    oProfesor.Nombre = txtNombre.Text.ToString().Trim();
                    oProfesor.Apellido = txtApellido.Text.ToString().Trim();
                    oProfesor.FechaNacimiento = dtpFechaNac.Value;
                    oProfesor.Edad = Convert.ToInt32(txtEdad.Text.ToString().Trim());
                    oProfesor.Sexo = cboSexo.SelectedItem.ToString().Trim();
                    oProfesor.Direccion = txtDireccion.Text.ToString().Trim();
                    oProfesor.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                    oProfesor.Ocupacion = txtOcupacion.Text.ToString().Trim();
                    oProfesor.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                    oProfesor.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                    oProfesor.Email = txtEmail.Text.ToString().Trim();
                    if (pbImagen.ImageLocation != null) { oProfesor.Imagen = pbImagen.ImageLocation; oProfesor.SizeMode = pbImagen.SizeMode.ToString(); } else { oProfesor.Imagen = ""; oProfesor.SizeMode = "Normal"; }
                    oProfesor.Estado = 1;

                    oProfesores.Update(oProfesor);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            try
            {
                Profesores oProfesores = new Profesores();
                Profesores.Profesor oProfesor = oProfesores.GetOne(idProfesor);

                DialogResult drBaja;
                drBaja = MessageBox.Show("Esta seguro que desea dar de baja a " + oProfesor.Nombre.Trim() + " " + oProfesor.Apellido.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drBaja == DialogResult.OK)
                {
                    oProfesores.Disable(idProfesor);
                    MessageBox.Show("El profesor ha sido dado de baja correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception) { }
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f_ValidarProfesor()) { return; }
                if (!f_ValidarDocumento()) { return; }

                Profesores oProfesores = new Profesores();
                Profesores.Profesor oProfesor = new Profesores.Profesor();

                if (idProfesor == 0)
                {
                    oProfesor.NroDoc = Convert.ToInt32(txtNroDoc.Text.ToString().Trim());
                    oProfesor.Nombre = txtNombre.Text.ToString().Trim();
                    oProfesor.Apellido = txtApellido.Text.ToString().Trim();
                    oProfesor.FechaNacimiento = dtpFechaNac.Value;
                    oProfesor.Edad = Convert.ToInt32(txtEdad.Text.ToString().Trim());
                    oProfesor.Sexo = cboSexo.SelectedItem.ToString().Trim();
                    oProfesor.Direccion = txtDireccion.Text.ToString().Trim();
                    oProfesor.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                    oProfesor.Ocupacion = txtOcupacion.Text.ToString().Trim();
                    oProfesor.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                    oProfesor.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                    oProfesor.Email = txtEmail.Text.ToString().Trim();
                    if (pbImagen.ImageLocation != null) { oProfesor.Imagen = pbImagen.ImageLocation; oProfesor.SizeMode = pbImagen.SizeMode.ToString(); } else { oProfesor.Imagen = ""; oProfesor.SizeMode = "Normal"; }
                    oProfesor.FechaRegistracion = DateTime.Now.Date;
                    oProfesor.Estado = 1;

                    oProfesores.Insert(oProfesor);
                    MessageBox.Show("El nuevo profesor se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oProfesor.idProfesor = idProfesor;
                    oProfesor.NroDoc = Convert.ToInt32(txtNroDoc.Text.ToString().Trim());
                    oProfesor.Nombre = txtNombre.Text.ToString().Trim();
                    oProfesor.Apellido = txtApellido.Text.ToString().Trim();
                    oProfesor.FechaNacimiento = dtpFechaNac.Value;
                    oProfesor.Edad = Convert.ToInt32(txtEdad.Text.ToString().Trim());
                    oProfesor.Sexo = cboSexo.SelectedItem.ToString().Trim();
                    oProfesor.Direccion = txtDireccion.Text.ToString().Trim();
                    oProfesor.idLocalidad = Convert.ToInt32(cboLocalidad.SelectedValue);
                    oProfesor.Ocupacion = txtOcupacion.Text.ToString().Trim();
                    oProfesor.TelefonoFijo = txtTelefonoFijo.Text.ToString().Trim();
                    oProfesor.TelefonoCelular = txtTelefonoCelular.Text.ToString().Trim();
                    oProfesor.Email = txtEmail.Text.ToString().Trim();
                    if (pbImagen.ImageLocation != null) { oProfesor.Imagen = pbImagen.ImageLocation; oProfesor.SizeMode = pbImagen.SizeMode.ToString(); } else { oProfesor.Imagen = ""; oProfesor.SizeMode = "Normal"; }
                    oProfesor.Estado = 1;

                    oProfesores.Update(oProfesor);
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
        private void pbImagenProfesor_Click(object sender, EventArgs e)
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
        public bool f_ValidarDocumento()
        {
            try
            {
                if (txtNroDoc.Text != "")
                {
                    Profesores oProfesores = new Profesores();
                    string s_Doc = oProfesores.ValidarDocumento(txtNroDoc.Text.Trim());
                    if (s_Doc != "" && idProfesor == 0) { MessageBox.Show(s_Doc, "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Warning); txtNroDoc.Select(); return false; }
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        public int f_CalcularEdad(DateTime fechaNac)
        {
            try
            {
                int edad = DateTime.Now.Year - fechaNac.Year;
                if (DateTime.Now.Month < fechaNac.Month || (DateTime.Now.Month == fechaNac.Month && DateTime.Now.Day < fechaNac.Day)) edad--;
                return edad;
            }
            catch (Exception) { return 0; }
        }

        public void f_ClearAll()
        {
            try
            {
                idProfesor = 0;
                pbImagen.Image = Properties.Resources.sociodefault; pbImagen.ImageLocation = "";
                txtNroDoc.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                dtpFechaNac.Value = DateTime.Now.Date;
                txtEdad.Clear();
                cboSexo.SelectedIndex = 0;
                txtDireccion.Clear();
                cboLocalidad.SelectedIndex = 0;
                txtOcupacion.Clear();
                txtTelefonoFijo.Clear();
                txtTelefonoCelular.Clear();
                txtEmail.Clear();
            }
            catch (Exception) { }
        }

        public bool f_ValidarProfesor()
        {
            try
            {
                if (txtNroDoc.Text == "" || txtNroDoc.Text.Replace(" ", string.Empty).Length < 8) { MessageBox.Show("El numero de documento no puede quedar en blanco o tener espacios.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); txtNroDoc.Select(); return false; }
                if (txtNombre.Text.Trim() == "" || txtApellido.Text.Trim() == "") { MessageBox.Show("Nombre y apellido son obligatorios. Por favor, completa los campos.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); if (txtNombre.Text == "") { txtNombre.Select(); } else { txtApellido.Select(); } return false; }
                if (txtEdad.Text == "") { MessageBox.Show("La fecha de nacimiento es obligatoria. Por favor, completa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); dtpFechaNac.Select(); return false; }
                if (Convert.ToInt32(txtEdad.Text) <= 0) { MessageBox.Show("La edad debe ser mayor a cero. Por favor, revisa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); dtpFechaNac.Select(); return false; }
                return true;
            }
            catch (Exception) { return false; }
        }
        #endregion
    }
}