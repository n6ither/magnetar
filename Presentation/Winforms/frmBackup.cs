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

namespace Presentation.Winforms
{
    public partial class frmBackup : Form
    {
        public frmBackup()
        {
            InitializeComponent();
        }

        private void frmBackup_Load(object sender, EventArgs e)
        {
            try
            {
                CopiasSeguridad oCopiasSeguridad = new CopiasSeguridad();
                CopiasSeguridad.CopiaSeguridad oCopiaSeguridad = oCopiasSeguridad.GetUltimaCopia();

                if (oCopiaSeguridad != null)
                {
                    txtFecha.Text = oCopiaSeguridad.FechaHora.ToShortDateString();
                    txtHora.Text = oCopiaSeguridad.FechaHora.ToShortTimeString();
                    txtUbicacion.Text = oCopiaSeguridad.Ruta;
                }

            }
            catch (Exception) { }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (fbdRuta.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = fbdRuta.SelectedPath;
                }
            }
            catch (Exception) { }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtRuta.Text.Length < 1) { MessageBox.Show("Por favor, selecciona una ubicacion válida.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                string sNombre = txtRuta.Text + "\\" + DateTime.Now.Day.ToString("00") + "-" + DateTime.Now.Month.ToString("00") + "-" + DateTime.Now.Year.ToString("00") + " " + DateTime.Now.Hour.ToString("00") + "-" + DateTime.Now.Minute.ToString("00") + ".bak";
                string sBackup = "BACKUP DATABASE GymDatabase TO DISK = N'" + sNombre + "' WITH NOFORMAT, NOINIT, NAME =N'GymDatabase', SKIP, STATS = 10";

                SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();
                csb.DataSource = "(local)";
                csb.InitialCatalog = "GymDatabase";
                csb.IntegratedSecurity = false;
                csb.UserID = "sa";
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
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
