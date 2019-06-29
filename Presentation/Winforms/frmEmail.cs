using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Logic;

namespace Presentation.Winforms
{
    public partial class frmEmail : Form
    {
        #region VARIABLES
        public string s_Correos = null;
        public string s_Adjunto = null;
        #endregion

        public frmEmail()
        {
            InitializeComponent();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            try
            {
                Gimnasios oGimnasios = new Gimnasios();
                Gimnasios.Gimnasio oGimnasio = oGimnasios.GetTheOne();
                if (oGimnasio != null && oGimnasio.Email.Trim() != "") { oGimnasio.Email.Trim(); }

                txtAsunto.Clear(); txtCuerpo.Clear(); txtPwd.Clear(); txtEmail.Select(); cboDestinatario.Text = "Todos";
            }
            catch (Exception) { }
        }

        private void cboDestinatario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Socios oSocios = new Socios();
                DataTable dtCorreos;
                s_Correos = "";

                switch (cboDestinatario.SelectedItem.ToString().Trim())
                {
                    case "Socios activos":
                        dtCorreos = oSocios.GetAllSL("Email", "Estado=1");

                        foreach (DataRow row in dtCorreos.Rows)
                        {
                            if (row["Email"].ToString().Trim() != "")
                            {
                                if (s_Correos == "") { s_Correos = row["Email"].ToString().Trim(); } else { s_Correos += "," + row["Email"].ToString().Trim(); }
                            }
                        }
                        break;

                    case "Socios inactivos":
                        dtCorreos = oSocios.GetAllSL("Email", "Estado=0");
                        foreach (DataRow row in dtCorreos.Rows)
                        {
                            if (row["Email"].ToString().Trim() != "")
                            {
                                if (s_Correos == "") { s_Correos = row["Email"].ToString().Trim(); } else { s_Correos += "," + row["Email"].ToString().Trim(); }
                            }
                        }
                        break;

                    case "Todos":
                        dtCorreos = oSocios.GetAllSL("Email", "");
                        foreach (DataRow row in dtCorreos.Rows)
                        {
                            if (row["Email"].ToString().Trim() != "")
                            {
                                if (s_Correos == "") { s_Correos = row["Email"].ToString().Trim(); } else { s_Correos += "," + row["Email"].ToString().Trim(); }
                            }
                        }
                        break;

                    case "Otro":
                        txtDestinatario.ReadOnly = false; txtDestinatario.Clear(); txtDestinatario.Select();
                        break;
                }
                s_Correos = s_Correos.Replace(" ", "");
                txtDestinatario.Text = s_Correos;
            }
            catch (Exception) { }
        }

        #region BUTTONS
        private void btnFuente_Click(object sender, EventArgs e)
        {
            f_Fuente();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            f_Color();
        }

        private void btnAdjuntar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dialogoAdjuntar.ShowDialog() == DialogResult.OK)
                {
                    s_Adjunto = dialogoAdjuntar.FileName;
                }
            }
            catch (Exception) { }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() == "") { MessageBox.Show("Por favor, completa el campo email.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
                if (txtPwd.Text.Trim() == "") { MessageBox.Show("Por favor, completa el campo contraseña.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(txtEmail.Text.Trim());
                message.To.Add(txtDestinatario.Text.Trim());
                message.Subject = txtAsunto.Text.Trim();
                message.IsBodyHtml = true;
                message.Body = txtCuerpo.Text.Trim();
                if (s_Adjunto != null) { message.Attachments.Add(new Attachment(s_Adjunto)); }

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(txtEmail.Text.Trim(), txtPwd.Text.Trim());
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

                MessageBox.Show("El correo se envio correctamente.", "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPwd.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Magnetar Gym Management", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CONTEXT MENU
        private void cmCortar_Click(object sender, EventArgs e)
        {
            try
            {
                txtCuerpo.Cut();
            }
            catch (Exception) { }
        }

        private void cmCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(txtCuerpo.Text.Trim(), TextDataFormat.Rtf);
            }
            catch (Exception) { }
        }

        private void cmPegar_Click(object sender, EventArgs e)
        {
            try
            {
                txtCuerpo.Text = Clipboard.GetText();
            }
            catch (Exception) { }
        }

        private void cmFuente_Click(object sender, EventArgs e)
        {
            try
            {
                f_Fuente();
            }
            catch (Exception) { }
        }

        private void cmColor_Click(object sender, EventArgs e)
        {
            f_Color();
        }
        #endregion

        #region FUNCIONES
        public void f_Fuente()
        {
            try
            {
                if (dialogoFuente.ShowDialog() == DialogResult.OK) { if (txtCuerpo.SelectedText != "") { txtCuerpo.SelectionFont = dialogoFuente.Font; } }
            }
            catch (Exception) { }
        }

        public void f_Color()
        {
            try
            {
                if (dialogoColor.ShowDialog() == DialogResult.OK) { txtCuerpo.SelectionColor = dialogoColor.Color; }
            }
            catch (Exception) { }
        }
        #endregion
    }
}