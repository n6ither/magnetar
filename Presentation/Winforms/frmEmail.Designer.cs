namespace Presentation.Winforms
{
    partial class frmEmail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmail));
            this.cboDestinatario = new System.Windows.Forms.ComboBox();
            this.txtDestinatario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdjuntar = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFuente = new System.Windows.Forms.Button();
            this.txtCuerpo = new System.Windows.Forms.RichTextBox();
            this.txtAsunto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dialogoColor = new System.Windows.Forms.ColorDialog();
            this.dialogoFuente = new System.Windows.Forms.FontDialog();
            this.cmEdicion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmCortar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPegar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmFuente = new System.Windows.Forms.ToolStripMenuItem();
            this.cmColor = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dialogoAdjuntar = new System.Windows.Forms.OpenFileDialog();
            this.cmEdicion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboDestinatario
            // 
            this.cboDestinatario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDestinatario.FormattingEnabled = true;
            this.cboDestinatario.Items.AddRange(new object[] {
            "Socios activos",
            "Socios inactivos",
            "Todos",
            "Otro"});
            this.cboDestinatario.Location = new System.Drawing.Point(112, 114);
            this.cboDestinatario.Name = "cboDestinatario";
            this.cboDestinatario.Size = new System.Drawing.Size(133, 24);
            this.cboDestinatario.TabIndex = 3;
            this.cboDestinatario.SelectedIndexChanged += new System.EventHandler(this.cboDestinatario_SelectedIndexChanged);
            // 
            // txtDestinatario
            // 
            this.txtDestinatario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestinatario.Location = new System.Drawing.Point(251, 114);
            this.txtDestinatario.Name = "txtDestinatario";
            this.txtDestinatario.ReadOnly = true;
            this.txtDestinatario.Size = new System.Drawing.Size(677, 24);
            this.txtDestinatario.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Para:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Mensaje:";
            // 
            // btnAdjuntar
            // 
            this.btnAdjuntar.AutoSize = true;
            this.btnAdjuntar.BackColor = System.Drawing.Color.Green;
            this.btnAdjuntar.FlatAppearance.BorderSize = 0;
            this.btnAdjuntar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdjuntar.ForeColor = System.Drawing.Color.White;
            this.btnAdjuntar.Image = global::Presentation.Properties.Resources.adjuntar;
            this.btnAdjuntar.Location = new System.Drawing.Point(324, 522);
            this.btnAdjuntar.Name = "btnAdjuntar";
            this.btnAdjuntar.Size = new System.Drawing.Size(112, 38);
            this.btnAdjuntar.TabIndex = 8;
            this.btnAdjuntar.Text = "Adjuntar";
            this.btnAdjuntar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdjuntar.UseVisualStyleBackColor = false;
            this.btnAdjuntar.Click += new System.EventHandler(this.btnAdjuntar_Click);
            // 
            // btnColor
            // 
            this.btnColor.AutoSize = true;
            this.btnColor.BackColor = System.Drawing.Color.Green;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Image = global::Presentation.Properties.Resources.brush;
            this.btnColor.Location = new System.Drawing.Point(218, 522);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 38);
            this.btnColor.TabIndex = 7;
            this.btnColor.Text = "Color";
            this.btnColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnFuente
            // 
            this.btnFuente.AutoSize = true;
            this.btnFuente.BackColor = System.Drawing.Color.Green;
            this.btnFuente.FlatAppearance.BorderSize = 0;
            this.btnFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuente.ForeColor = System.Drawing.Color.White;
            this.btnFuente.Image = global::Presentation.Properties.Resources.font;
            this.btnFuente.Location = new System.Drawing.Point(112, 522);
            this.btnFuente.Name = "btnFuente";
            this.btnFuente.Size = new System.Drawing.Size(100, 38);
            this.btnFuente.TabIndex = 6;
            this.btnFuente.Text = "Fuente";
            this.btnFuente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFuente.UseVisualStyleBackColor = false;
            this.btnFuente.Click += new System.EventHandler(this.btnFuente_Click);
            // 
            // txtCuerpo
            // 
            this.txtCuerpo.AcceptsTab = true;
            this.txtCuerpo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCuerpo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCuerpo.Location = new System.Drawing.Point(112, 174);
            this.txtCuerpo.Name = "txtCuerpo";
            this.txtCuerpo.Size = new System.Drawing.Size(816, 342);
            this.txtCuerpo.TabIndex = 6;
            this.txtCuerpo.Text = "";
            // 
            // txtAsunto
            // 
            this.txtAsunto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAsunto.Location = new System.Drawing.Point(112, 144);
            this.txtAsunto.Name = "txtAsunto";
            this.txtAsunto.Size = new System.Drawing.Size(816, 24);
            this.txtAsunto.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Asunto:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.AutoSize = true;
            this.btnEnviar.BackColor = System.Drawing.Color.Green;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.ForeColor = System.Drawing.Color.White;
            this.btnEnviar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnviar.Location = new System.Drawing.Point(721, 570);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(100, 38);
            this.btnEnviar.TabIndex = 9;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(827, 570);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 38);
            this.btnCancelar.TabIndex = 10;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dialogoColor
            // 
            this.dialogoColor.AllowFullOpen = false;
            this.dialogoColor.SolidColorOnly = true;
            // 
            // cmEdicion
            // 
            this.cmEdicion.Font = new System.Drawing.Font("Verdana", 10F);
            this.cmEdicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmCortar,
            this.cmCopiar,
            this.cmPegar,
            this.toolStripSeparator1,
            this.cmFuente,
            this.cmColor});
            this.cmEdicion.Name = "cmEdicion";
            this.cmEdicion.Size = new System.Drawing.Size(177, 120);
            // 
            // cmCortar
            // 
            this.cmCortar.Name = "cmCortar";
            this.cmCortar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cmCortar.Size = new System.Drawing.Size(176, 22);
            this.cmCortar.Text = "Cortar";
            this.cmCortar.Click += new System.EventHandler(this.cmCortar_Click);
            // 
            // cmCopiar
            // 
            this.cmCopiar.Name = "cmCopiar";
            this.cmCopiar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cmCopiar.Size = new System.Drawing.Size(176, 22);
            this.cmCopiar.Text = "Copiar";
            this.cmCopiar.Click += new System.EventHandler(this.cmCopiar_Click);
            // 
            // cmPegar
            // 
            this.cmPegar.Name = "cmPegar";
            this.cmPegar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cmPegar.Size = new System.Drawing.Size(176, 22);
            this.cmPegar.Text = "Pegar";
            this.cmPegar.Click += new System.EventHandler(this.cmPegar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // cmFuente
            // 
            this.cmFuente.Name = "cmFuente";
            this.cmFuente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.cmFuente.Size = new System.Drawing.Size(176, 22);
            this.cmFuente.Text = "Fuente";
            this.cmFuente.Click += new System.EventHandler(this.cmFuente_Click);
            // 
            // cmColor
            // 
            this.cmColor.Name = "cmColor";
            this.cmColor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.cmColor.Size = new System.Drawing.Size(176, 22);
            this.cmColor.Text = "Color";
            this.cmColor.Click += new System.EventHandler(this.cmColor_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtPwd);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(917, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Antes de enviar un correo debes especificar la cuenta que utilizaras.";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(107, 26);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 24);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(107, 56);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(200, 24);
            this.txtPwd.TabIndex = 2;
            this.txtPwd.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Contraseña:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "E-mail:";
            // 
            // dialogoAdjuntar
            // 
            this.dialogoAdjuntar.FileName = "openFileDialog1";
            // 
            // frmEmail
            // 
            this.AcceptButton = this.btnEnviar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(939, 620);
            this.Controls.Add(this.cboDestinatario);
            this.Controls.Add(this.txtDestinatario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdjuntar);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.txtCuerpo);
            this.Controls.Add(this.btnFuente);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAsunto);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Email";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.cmEdicion.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtCuerpo;
        private System.Windows.Forms.TextBox txtAsunto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAdjuntar;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFuente;
        private System.Windows.Forms.TextBox txtDestinatario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColorDialog dialogoColor;
        private System.Windows.Forms.FontDialog dialogoFuente;
        private System.Windows.Forms.ContextMenuStrip cmEdicion;
        private System.Windows.Forms.ToolStripMenuItem cmCortar;
        private System.Windows.Forms.ToolStripMenuItem cmCopiar;
        private System.Windows.Forms.ToolStripMenuItem cmPegar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmFuente;
        private System.Windows.Forms.ToolStripMenuItem cmColor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog dialogoAdjuntar;
        private System.Windows.Forms.ComboBox cboDestinatario;
    }
}