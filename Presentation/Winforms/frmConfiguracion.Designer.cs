namespace Presentation.Winforms
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.gbGimnasio = new System.Windows.Forms.GroupBox();
            this.btnMiGimnasio = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.gbUsuario = new System.Windows.Forms.GroupBox();
            this.btnAdministrarUsuarios = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.gbPublicidad = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPublicidad = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEmail = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.gbGimnasio.SuspendLayout();
            this.gbUsuario.SuspendLayout();
            this.gbPublicidad.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // gbGimnasio
            // 
            this.gbGimnasio.Controls.Add(this.btnMiGimnasio);
            this.gbGimnasio.Controls.Add(this.label1);
            this.gbGimnasio.Location = new System.Drawing.Point(12, 204);
            this.gbGimnasio.Name = "gbGimnasio";
            this.gbGimnasio.Size = new System.Drawing.Size(400, 130);
            this.gbGimnasio.TabIndex = 0;
            this.gbGimnasio.TabStop = false;
            this.gbGimnasio.Text = "Mi Gimnasio";
            // 
            // btnMiGimnasio
            // 
            this.btnMiGimnasio.AutoSize = true;
            this.btnMiGimnasio.BackColor = System.Drawing.Color.Green;
            this.btnMiGimnasio.FlatAppearance.BorderSize = 0;
            this.btnMiGimnasio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMiGimnasio.ForeColor = System.Drawing.Color.White;
            this.btnMiGimnasio.Image = global::Presentation.Properties.Resources.home32;
            this.btnMiGimnasio.Location = new System.Drawing.Point(114, 76);
            this.btnMiGimnasio.Name = "btnMiGimnasio";
            this.btnMiGimnasio.Size = new System.Drawing.Size(187, 38);
            this.btnMiGimnasio.TabIndex = 11;
            this.btnMiGimnasio.Text = "Mi &Gimnasio";
            this.btnMiGimnasio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMiGimnasio.UseVisualStyleBackColor = false;
            this.btnMiGimnasio.Click += new System.EventHandler(this.btnMiGimnasio_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aqui puede detallar informacion sobre su gimnasio, tal como nombre, email, etc.";
            // 
            // gbUsuario
            // 
            this.gbUsuario.Controls.Add(this.btnAdministrarUsuarios);
            this.gbUsuario.Controls.Add(this.label9);
            this.gbUsuario.Location = new System.Drawing.Point(12, 340);
            this.gbUsuario.Name = "gbUsuario";
            this.gbUsuario.Size = new System.Drawing.Size(400, 130);
            this.gbUsuario.TabIndex = 12;
            this.gbUsuario.TabStop = false;
            this.gbUsuario.Text = "Administrar usuarios";
            // 
            // btnAdministrarUsuarios
            // 
            this.btnAdministrarUsuarios.AutoSize = true;
            this.btnAdministrarUsuarios.BackColor = System.Drawing.Color.Green;
            this.btnAdministrarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnAdministrarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdministrarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnAdministrarUsuarios.Image = global::Presentation.Properties.Resources.key;
            this.btnAdministrarUsuarios.Location = new System.Drawing.Point(114, 76);
            this.btnAdministrarUsuarios.Name = "btnAdministrarUsuarios";
            this.btnAdministrarUsuarios.Size = new System.Drawing.Size(187, 38);
            this.btnAdministrarUsuarios.TabIndex = 11;
            this.btnAdministrarUsuarios.Text = "Cuentas de usuario";
            this.btnAdministrarUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdministrarUsuarios.UseVisualStyleBackColor = false;
            this.btnAdministrarUsuarios.Click += new System.EventHandler(this.btnAdministrarUsuarios_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(388, 40);
            this.label9.TabIndex = 0;
            this.label9.Text = "Desde aquí puede crear y eliminar cuentas de usuario asi como tambien cambiar su " +
    "contraseña.";
            // 
            // gbPublicidad
            // 
            this.gbPublicidad.Controls.Add(this.label2);
            this.gbPublicidad.Controls.Add(this.btnPublicidad);
            this.gbPublicidad.Location = new System.Drawing.Point(418, 204);
            this.gbPublicidad.Name = "gbPublicidad";
            this.gbPublicidad.Size = new System.Drawing.Size(400, 130);
            this.gbPublicidad.TabIndex = 13;
            this.gbPublicidad.TabStop = false;
            this.gbPublicidad.Text = "Publicidad";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(388, 34);
            this.label2.TabIndex = 12;
            this.label2.Text = "En esta seccion puede configurar una publicidad para mostrar en la pantalla de bi" +
    "envenida de los socios.";
            // 
            // btnPublicidad
            // 
            this.btnPublicidad.AutoSize = true;
            this.btnPublicidad.BackColor = System.Drawing.Color.Green;
            this.btnPublicidad.FlatAppearance.BorderSize = 0;
            this.btnPublicidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicidad.ForeColor = System.Drawing.Color.White;
            this.btnPublicidad.Image = global::Presentation.Properties.Resources.advertising;
            this.btnPublicidad.Location = new System.Drawing.Point(114, 76);
            this.btnPublicidad.Name = "btnPublicidad";
            this.btnPublicidad.Size = new System.Drawing.Size(187, 38);
            this.btnPublicidad.TabIndex = 11;
            this.btnPublicidad.Text = "&Publicidad";
            this.btnPublicidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPublicidad.UseVisualStyleBackColor = false;
            this.btnPublicidad.Click += new System.EventHandler(this.btnPublicidad_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEmail);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(418, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 130);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Email";
            // 
            // btnEmail
            // 
            this.btnEmail.AutoSize = true;
            this.btnEmail.BackColor = System.Drawing.Color.Green;
            this.btnEmail.FlatAppearance.BorderSize = 0;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.ForeColor = System.Drawing.Color.White;
            this.btnEmail.Image = global::Presentation.Properties.Resources.email;
            this.btnEmail.Location = new System.Drawing.Point(114, 76);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(187, 38);
            this.btnEmail.TabIndex = 12;
            this.btnEmail.Text = "&Email";
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 40);
            this.label3.TabIndex = 1;
            this.label3.Text = "Desde aqui puede enviar un correo electronico a todos sus socios a la vez.";
            // 
            // pbLogo
            // 
            this.pbLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLogo.Image = global::Presentation.Properties.Resources.magnetarlogo;
            this.pbLogo.Location = new System.Drawing.Point(213, 12);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(398, 186);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbLogo.TabIndex = 15;
            this.pbLogo.TabStop = false;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(829, 482);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.gbUsuario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbPublicidad);
            this.Controls.Add(this.gbGimnasio);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Configuracion";
            this.gbGimnasio.ResumeLayout(false);
            this.gbGimnasio.PerformLayout();
            this.gbUsuario.ResumeLayout(false);
            this.gbUsuario.PerformLayout();
            this.gbPublicidad.ResumeLayout(false);
            this.gbPublicidad.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGimnasio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gbPublicidad;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMiGimnasio;
        private System.Windows.Forms.Button btnAdministrarUsuarios;
        private System.Windows.Forms.Button btnPublicidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbLogo;

    }
}