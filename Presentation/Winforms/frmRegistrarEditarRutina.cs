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
    public partial class frmRegistrarEditarRutina : Form
    {
        #region VARIABLES
        /// <summary>
        /// Variable estatica del form frmRegistrarEditarRutina.
        /// </summary>
        public static int idRutina = 0;
        #endregion

        public frmRegistrarEditarRutina()
        {
            InitializeComponent();
        }

        #region LOAD
        private void frmRegistrarEditarRutina_Load(object sender, EventArgs e)
        {
            try
            {
                if (idRutina == 0)
                {
                    f_ClearAll();
                }
                else
                {
                    Rutinas oRutinas = new Rutinas();
                    Rutinas.Rutina oRutina = oRutinas.GetOne(idRutina);

                    txtNombre.Text = oRutina.Nombre.Trim();
                    numDuracion.Value = Convert.ToDecimal(oRutina.Duracion);
                    txtContenido.Rtf = oRutina.Contenido.Replace("$$", "'");
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region BUTTONS
        private void btnNuevoRutina_Click(object sender, EventArgs e)
        {
            f_ClearAll();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f_ValidarRutina()) { return; }

                Rutinas oRutinas = new Rutinas();
                Rutinas.Rutina oRutina = new Rutinas.Rutina();
                if (idRutina == 0)
                {
                    oRutina.Nombre = txtNombre.Text.ToString().Trim();
                    oRutina.Duracion = Convert.ToInt32(numDuracion.Value);
                    oRutina.Contenido = txtContenido.Rtf.Replace("'", "$$");
                    oRutinas.Insert(oRutina);

                    MessageBox.Show("La rutina se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oRutina.idRutina = idRutina;
                    oRutina.Nombre = txtNombre.Text.ToString().Trim();
                    oRutina.Duracion = Convert.ToInt32(numDuracion.Value);
                    oRutina.Contenido = txtContenido.Rtf.Replace("'", "$$");
                    oRutinas.Update(oRutina);
                }
            }
            catch (Exception) { }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Rutinas oRutinas = new Rutinas();
                Rutinas.Rutina oRutina = oRutinas.GetOne(idRutina);

                DialogResult drEliminar;
                drEliminar = MessageBox.Show("Esta seguro que desea eliminar " + oRutina.Nombre.Trim() + "?", "Magnetar Gym Management", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (drEliminar == DialogResult.OK)
                {
                    oRutinas.Delete("Rutina", "idRutina=" + idRutina);
                    MessageBox.Show("La rutina ha sido eliminada correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!f_ValidarRutina()) { return; }

                Rutinas oRutinas = new Rutinas();
                Rutinas.Rutina oRutina = new Rutinas.Rutina();
                if (idRutina == 0)
                {
                    oRutina.Nombre = txtNombre.Text.ToString().Trim();
                    oRutina.Duracion = Convert.ToInt32(numDuracion.Value);
                    oRutina.Contenido = txtContenido.Rtf.Replace("'", "$$");
                    oRutinas.Insert(oRutina);

                    MessageBox.Show("La rutina se ha registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    oRutina.idRutina = idRutina;
                    oRutina.Nombre = txtNombre.Text.ToString().Trim();
                    oRutina.Duracion = Convert.ToInt32(numDuracion.Value);
                    oRutina.Contenido = txtContenido.Rtf.Replace("'", "$$");
                    oRutinas.Update(oRutina);
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialogoImportar.ShowDialog() == DialogResult.OK)
                {
                    StreamReader sr = new StreamReader(dialogoImportar.FileName.Trim(), Encoding.Default);
                    txtContenido.Text = sr.ReadToEnd();
                    sr.Close();
                }
            }
            catch (Exception) { MessageBox.Show("El archivo no pudo importarse de forma correcta.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnFuente_Click(object sender, EventArgs e)
        {
            f_Fuente();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            f_Color();
        }
        #endregion

        #region MENU CONTEXTUAL
        private void cmCortar_Click(object sender, EventArgs e)
        {
            try
            {
                txtContenido.Cut();
            }
            catch (Exception) { }
        }

        private void cmCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtContenido.Text.Trim(), TextDataFormat.Rtf);
            }
            catch (Exception) { }
        }

        private void cmPegar_Click(object sender, EventArgs e)
        {
            try
            {
                txtContenido.Text = Clipboard.GetText();
            }
            catch (Exception) { }
        }

        private void cmFuente_Click(object sender, EventArgs e)
        {
            f_Fuente();
        }

        private void cmColor_Click(object sender, EventArgs e)
        {
            f_Color();
        }
        #endregion

        #region ETC
        private void txtContenido_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    txtContenido.ContextMenuStrip = cmEdicion;
                }
            }
            catch (Exception) { }
        }
        #endregion

        #region FUNCIONES
        public bool f_ValidarRutina()
        {
            try
            {
                if (txtNombre.Text == "") { MessageBox.Show("La rutina debe tener un nombre. Por favor, completa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                if (txtContenido.Text == "") { MessageBox.Show("La rutina debe tener un contenido. Por favor, completa el campo.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return false; }
                return true;
            }
            catch (Exception) { return false; }
        }

        public void f_ClearAll()
        {
            try
            {
                idRutina = 0;
                txtNombre.Clear();
                numDuracion.Value = 4;
                txtContenido.Clear();
                txtNombre.Select();
            }
            catch (Exception) { }
        }

        public void f_Fuente()
        {
            try
            {
                if (dialogoFuente.ShowDialog() == DialogResult.OK) { if (txtContenido.SelectedText != "") { txtContenido.SelectionFont = dialogoFuente.Font; } }
            }
            catch (Exception) { }
        }

        public void f_Color()
        {
            try
            {
                if (dialogoColor.ShowDialog() == DialogResult.OK) { txtContenido.SelectionColor = dialogoColor.Color; }
            }
            catch (Exception) { }
        }
        #endregion
    }
}