using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Logic;
using Presentation.Winforms;

namespace Presentation.Winforms
{
    public partial class frmRegistrarAsistencia : Form
    {
        #region Variables
        /// <summary>
        /// Variable estatica del form Checkin.
        /// </summary>
        public static int idSocio = 0;
        /// <summary>
        /// Variable estatica con el nombre y apellido del socio.
        /// </summary>
        public static string s_Socio = "";
        #endregion

        public frmRegistrarAsistencia()
        {
            InitializeComponent();
        }

        private void frmRegistrarAsistencia_Load(object sender, EventArgs e)
        {
            try
            {
                txtSocio.Text = s_Socio.ToString().Trim();
                txtFecha.Text = DateTime.Now.Date.ToShortDateString();
                txtHora.Text = DateTime.Now.ToString("HH:mm");
                Funciones.f_FillComboBox(cboActividad, "Actividad.idActividad", "Actividad.Nombre", "Actividad.Nombre", "Actividad, Membresia, Socio", "Actividad.idActividad=Membresia.idActividad AND Socio.idSocio=" + idSocio + " AND Socio.idSocio=Membresia.idSocio AND Actividad.Estado=1 AND Membresia.Estado=1", "Actividad.Nombre");
                cboActividad.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        #region BUTTONS
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Asistencias oAsistencias = new Asistencias();
                Asistencias.Asistencia oAsistencia = new Asistencias.Asistencia();

                oAsistencia.idSocio = idSocio;
                oAsistencia.Fecha = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                oAsistencia.Hora = DateTime.Now.ToString("HH:mm");
                if (cboActividad.SelectedValue != null) { oAsistencia.idActividad = Convert.ToInt32(cboActividad.SelectedValue); } else { MessageBox.Show("Por favor, seleccione una actividad.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                oAsistencias.Insert(oAsistencia);
                MessageBox.Show("El ingreso del socio ha sido registrado correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception) { }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
