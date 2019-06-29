namespace Presentation.Winforms
{
    partial class frmMiGimnasio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMiGimnasio));
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTelefonoCelular = new System.Windows.Forms.TextBox();
            this.txtTelefonoFijo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmsLogo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCargarLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsQuitarLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRedimensionarLogo = new System.Windows.Forms.ToolStripMenuItem();
            this.pbLogoGimnasio = new System.Windows.Forms.PictureBox();
            this.dlgLogo = new System.Windows.Forms.OpenFileDialog();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRegistrarLocalidad = new System.Windows.Forms.Button();
            this.cmsLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoGimnasio)).BeginInit();
            this.SuspendLayout();
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(107, 104);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(210, 24);
            this.cboLocalidad.TabIndex = 3;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(107, 194);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(250, 24);
            this.txtEmail.TabIndex = 6;
            // 
            // txtTelefonoCelular
            // 
            this.txtTelefonoCelular.Location = new System.Drawing.Point(107, 164);
            this.txtTelefonoCelular.Name = "txtTelefonoCelular";
            this.txtTelefonoCelular.Size = new System.Drawing.Size(250, 24);
            this.txtTelefonoCelular.TabIndex = 5;
            // 
            // txtTelefonoFijo
            // 
            this.txtTelefonoFijo.Location = new System.Drawing.Point(107, 134);
            this.txtTelefonoFijo.Name = "txtTelefonoFijo";
            this.txtTelefonoFijo.Size = new System.Drawing.Size(250, 24);
            this.txtTelefonoFijo.TabIndex = 4;
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(107, 74);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(250, 24);
            this.txtDireccion.TabIndex = 2;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(107, 44);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 24);
            this.txtNombre.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Email:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tel. Celular:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tel. Fijo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Localidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Direccion:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Green;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(815, 299);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 38);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(921, 299);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 38);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // cmsLogo
            // 
            this.cmsLogo.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmsLogo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCargarLogo,
            this.cmsQuitarLogo,
            this.cmsRedimensionarLogo});
            this.cmsLogo.Name = "cmsLogo";
            this.cmsLogo.Size = new System.Drawing.Size(168, 70);
            // 
            // cmsCargarLogo
            // 
            this.cmsCargarLogo.Name = "cmsCargarLogo";
            this.cmsCargarLogo.Size = new System.Drawing.Size(167, 22);
            this.cmsCargarLogo.Text = "Cargar";
            this.cmsCargarLogo.Click += new System.EventHandler(this.cmsCargarLogo_Click);
            // 
            // cmsQuitarLogo
            // 
            this.cmsQuitarLogo.Name = "cmsQuitarLogo";
            this.cmsQuitarLogo.Size = new System.Drawing.Size(167, 22);
            this.cmsQuitarLogo.Text = "Quitar";
            this.cmsQuitarLogo.Click += new System.EventHandler(this.cmsQuitarLogo_Click);
            // 
            // cmsRedimensionarLogo
            // 
            this.cmsRedimensionarLogo.Name = "cmsRedimensionarLogo";
            this.cmsRedimensionarLogo.Size = new System.Drawing.Size(167, 22);
            this.cmsRedimensionarLogo.Text = "Redimensionar";
            this.cmsRedimensionarLogo.Click += new System.EventHandler(this.cmsRedimensionarLogo_Click);
            // 
            // pbLogoGimnasio
            // 
            this.pbLogoGimnasio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogoGimnasio.ContextMenuStrip = this.cmsLogo;
            this.pbLogoGimnasio.Image = global::Presentation.Properties.Resources.gymdefault1;
            this.pbLogoGimnasio.Location = new System.Drawing.Point(363, 12);
            this.pbLogoGimnasio.Name = "pbLogoGimnasio";
            this.pbLogoGimnasio.Size = new System.Drawing.Size(658, 247);
            this.pbLogoGimnasio.TabIndex = 15;
            this.pbLogoGimnasio.TabStop = false;
            this.pbLogoGimnasio.Click += new System.EventHandler(this.pbLogo_Click);
            // 
            // dlgLogo
            // 
            this.dlgLogo.Filter = "Archivos de imagen (*.BMP;*.JPG;*.JPEG;*.GIF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            this.dlgLogo.Title = "Abrir";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(582, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Esta imagen también será visualizada por los socios en su pantalla de bienvenida." +
    "";
            // 
            // btnRegistrarLocalidad
            // 
            this.btnRegistrarLocalidad.AutoSize = true;
            this.btnRegistrarLocalidad.BackColor = System.Drawing.Color.Green;
            this.btnRegistrarLocalidad.FlatAppearance.BorderSize = 0;
            this.btnRegistrarLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarLocalidad.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarLocalidad.Location = new System.Drawing.Point(324, 102);
            this.btnRegistrarLocalidad.Name = "btnRegistrarLocalidad";
            this.btnRegistrarLocalidad.Size = new System.Drawing.Size(33, 27);
            this.btnRegistrarLocalidad.TabIndex = 43;
            this.btnRegistrarLocalidad.Text = "...";
            this.btnRegistrarLocalidad.UseVisualStyleBackColor = false;
            this.btnRegistrarLocalidad.Click += new System.EventHandler(this.btnRegistrarLocalidad_Click);
            // 
            // frmMiGimnasio
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(1035, 353);
            this.Controls.Add(this.btnRegistrarLocalidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pbLogoGimnasio);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtTelefonoCelular);
            this.Controls.Add(this.txtTelefonoFijo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMiGimnasio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Mi Gimnasio";
            this.Load += new System.EventHandler(this.frmMiGimnasio_Load);
            this.cmsLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoGimnasio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTelefonoCelular;
        private System.Windows.Forms.TextBox txtTelefonoFijo;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ContextMenuStrip cmsLogo;
        private System.Windows.Forms.ToolStripMenuItem cmsCargarLogo;
        private System.Windows.Forms.ToolStripMenuItem cmsQuitarLogo;
        private System.Windows.Forms.ToolStripMenuItem cmsRedimensionarLogo;
        private System.Windows.Forms.PictureBox pbLogoGimnasio;
        private System.Windows.Forms.OpenFileDialog dlgLogo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegistrarLocalidad;
    }
}