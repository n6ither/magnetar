namespace Presentation.Winforms
{
    partial class frmPublicidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPublicidad));
            this.btnRedimensionar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.pbPublicidad = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnFuente = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.RichTextBox();
            this.dlgImagen = new System.Windows.Forms.OpenFileDialog();
            this.dialogoFuente = new System.Windows.Forms.FontDialog();
            this.dialogoColor = new System.Windows.Forms.ColorDialog();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbPublicidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRedimensionar
            // 
            this.btnRedimensionar.AutoSize = true;
            this.btnRedimensionar.BackColor = System.Drawing.Color.Green;
            this.btnRedimensionar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnRedimensionar.FlatAppearance.BorderSize = 0;
            this.btnRedimensionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRedimensionar.ForeColor = System.Drawing.Color.White;
            this.btnRedimensionar.Image = global::Presentation.Properties.Resources.resize;
            this.btnRedimensionar.Location = new System.Drawing.Point(382, 193);
            this.btnRedimensionar.Name = "btnRedimensionar";
            this.btnRedimensionar.Size = new System.Drawing.Size(250, 38);
            this.btnRedimensionar.TabIndex = 7;
            this.btnRedimensionar.Text = "Redimensionar";
            this.btnRedimensionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRedimensionar.UseVisualStyleBackColor = false;
            this.btnRedimensionar.Click += new System.EventHandler(this.btnRedimensionar_Click);
            // 
            // btnCargar
            // 
            this.btnCargar.AutoSize = true;
            this.btnCargar.BackColor = System.Drawing.Color.Green;
            this.btnCargar.FlatAppearance.BorderSize = 0;
            this.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Image = global::Presentation.Properties.Resources.upload;
            this.btnCargar.Location = new System.Drawing.Point(382, 149);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(122, 38);
            this.btnCargar.TabIndex = 5;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCargar.UseVisualStyleBackColor = false;
            this.btnCargar.Click += new System.EventHandler(this.btnCargar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.AutoSize = true;
            this.btnQuitar.BackColor = System.Drawing.Color.Green;
            this.btnQuitar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.ForeColor = System.Drawing.Color.White;
            this.btnQuitar.Image = global::Presentation.Properties.Resources.cancel;
            this.btnQuitar.Location = new System.Drawing.Point(510, 149);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(122, 38);
            this.btnQuitar.TabIndex = 6;
            this.btnQuitar.Text = "Quitar";
            this.btnQuitar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // pbPublicidad
            // 
            this.pbPublicidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPublicidad.Location = new System.Drawing.Point(349, 33);
            this.pbPublicidad.Name = "pbPublicidad";
            this.pbPublicidad.Size = new System.Drawing.Size(319, 110);
            this.pbPublicidad.TabIndex = 12;
            this.pbPublicidad.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(346, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(258, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "Tambien puedes cargar una imagen";
            // 
            // btnFuente
            // 
            this.btnFuente.AutoSize = true;
            this.btnFuente.BackColor = System.Drawing.Color.Green;
            this.btnFuente.FlatAppearance.BorderSize = 0;
            this.btnFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuente.ForeColor = System.Drawing.Color.White;
            this.btnFuente.Image = global::Presentation.Properties.Resources.font;
            this.btnFuente.Location = new System.Drawing.Point(38, 149);
            this.btnFuente.Name = "btnFuente";
            this.btnFuente.Size = new System.Drawing.Size(122, 38);
            this.btnFuente.TabIndex = 3;
            this.btnFuente.Text = "Fuente";
            this.btnFuente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFuente.UseVisualStyleBackColor = false;
            this.btnFuente.Click += new System.EventHandler(this.btnFuente_Click);
            // 
            // btnColor
            // 
            this.btnColor.AutoSize = true;
            this.btnColor.BackColor = System.Drawing.Color.Green;
            this.btnColor.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Image = global::Presentation.Properties.Resources.brush;
            this.btnColor.Location = new System.Drawing.Point(166, 149);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(122, 38);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Color";
            this.btnColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Escribe un texto corto";
            // 
            // txtTexto
            // 
            this.txtTexto.AcceptsTab = true;
            this.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTexto.Location = new System.Drawing.Point(12, 33);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtTexto.Size = new System.Drawing.Size(319, 110);
            this.txtTexto.TabIndex = 2;
            this.txtTexto.Text = "";
            // 
            // dlgImagen
            // 
            this.dlgImagen.Filter = "Archivos de imagen (*.BMP;*.JPG;*.JPEG;*.GIF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            this.dlgImagen.Title = "Abrir";
            // 
            // dialogoColor
            // 
            this.dialogoColor.AllowFullOpen = false;
            this.dialogoColor.SolidColorOnly = true;
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Green;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(462, 271);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 38);
            this.btnAceptar.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(568, 271);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 38);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmPublicidad
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(682, 330);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnRedimensionar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.pbPublicidad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnFuente);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmPublicidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Publicidad";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmPublicidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPublicidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRedimensionar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.PictureBox pbPublicidad;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnFuente;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtTexto;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.OpenFileDialog dlgImagen;
        private System.Windows.Forms.FontDialog dialogoFuente;
        private System.Windows.Forms.ColorDialog dialogoColor;
    }
}