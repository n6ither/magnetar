namespace Presentation.Winforms
{
    partial class frmRegistrarEditarMembresia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarEditarMembresia));
            this.numDescuento = new System.Windows.Forms.NumericUpDown();
            this.numPrecio = new System.Windows.Forms.NumericUpDown();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cboDuracion = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.label35 = new System.Windows.Forms.Label();
            this.cboTurnos = new System.Windows.Forms.ComboBox();
            this.cboActividades = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.gbTurno = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInscriptos = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.txtDias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).BeginInit();
            this.gbTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // numDescuento
            // 
            this.numDescuento.AutoSize = true;
            this.numDescuento.DecimalPlaces = 2;
            this.numDescuento.Location = new System.Drawing.Point(110, 335);
            this.numDescuento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numDescuento.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numDescuento.Name = "numDescuento";
            this.numDescuento.Size = new System.Drawing.Size(88, 24);
            this.numDescuento.TabIndex = 51;
            this.numDescuento.ThousandsSeparator = true;
            this.numDescuento.ValueChanged += new System.EventHandler(this.numDescuento_ValueChanged);
            // 
            // numPrecio
            // 
            this.numPrecio.AutoSize = true;
            this.numPrecio.DecimalPlaces = 2;
            this.numPrecio.Location = new System.Drawing.Point(110, 303);
            this.numPrecio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.numPrecio.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numPrecio.Name = "numPrecio";
            this.numPrecio.Size = new System.Drawing.Size(88, 24);
            this.numPrecio.TabIndex = 50;
            this.numPrecio.ThousandsSeparator = true;
            this.numPrecio.ValueChanged += new System.EventHandler(this.numPrecio_ValueChanged);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(11, 337);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(89, 17);
            this.label39.TabIndex = 49;
            this.label39.Text = "Descuento:";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(11, 305);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(55, 17);
            this.label38.TabIndex = 48;
            this.label38.Text = "Precio:";
            // 
            // cboDuracion
            // 
            this.cboDuracion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDuracion.FormattingEnabled = true;
            this.cboDuracion.Items.AddRange(new object[] {
            "Clase",
            "Semana",
            "Mes",
            "Trimestre",
            "Otro 1",
            "Otro 2"});
            this.cboDuracion.Location = new System.Drawing.Point(110, 207);
            this.cboDuracion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboDuracion.Name = "cboDuracion";
            this.cboDuracion.Size = new System.Drawing.Size(281, 24);
            this.cboDuracion.TabIndex = 47;
            this.cboDuracion.SelectedIndexChanged += new System.EventHandler(this.cboDuracion_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(11, 210);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(76, 17);
            this.label37.TabIndex = 46;
            this.label37.Text = "Duracion:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(110, 239);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(281, 24);
            this.dtpFechaInicio.TabIndex = 44;
            this.dtpFechaInicio.ValueChanged += new System.EventHandler(this.dtpFechaInicio_ValueChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(11, 245);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(93, 17);
            this.label35.TabIndex = 42;
            this.label35.Text = "Fecha inicio:";
            // 
            // cboTurnos
            // 
            this.cboTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTurnos.FormattingEnabled = true;
            this.cboTurnos.Location = new System.Drawing.Point(98, 24);
            this.cboTurnos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboTurnos.Name = "cboTurnos";
            this.cboTurnos.Size = new System.Drawing.Size(267, 24);
            this.cboTurnos.TabIndex = 41;
            this.cboTurnos.SelectedIndexChanged += new System.EventHandler(this.cboTurnos_SelectedIndexChanged);
            // 
            // cboActividades
            // 
            this.cboActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividades.FormattingEnabled = true;
            this.cboActividades.Location = new System.Drawing.Point(110, 13);
            this.cboActividades.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboActividades.Name = "cboActividades";
            this.cboActividades.Size = new System.Drawing.Size(281, 24);
            this.cboActividades.TabIndex = 39;
            this.cboActividades.SelectedIndexChanged += new System.EventHandler(this.cboActividades_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(11, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(77, 17);
            this.label28.TabIndex = 38;
            this.label28.Text = "Actividad:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 57;
            this.label6.Text = "Inscriptos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 56;
            this.label5.Text = "Cupo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Fecha vto.:";
            // 
            // dtpFechaVencimiento
            // 
            this.dtpFechaVencimiento.Location = new System.Drawing.Point(110, 271);
            this.dtpFechaVencimiento.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            this.dtpFechaVencimiento.Size = new System.Drawing.Size(281, 24);
            this.dtpFechaVencimiento.TabIndex = 55;
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
            this.btnCancelar.Location = new System.Drawing.Point(291, 412);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 38);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Green;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(185, 412);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 38);
            this.btnAceptar.TabIndex = 52;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 59;
            this.label2.Text = "Total:";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(110, 366);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(88, 24);
            this.txtTotal.TabIndex = 60;
            this.txtTotal.Text = "0,00";
            // 
            // gbTurno
            // 
            this.gbTurno.Controls.Add(this.label4);
            this.gbTurno.Controls.Add(this.txtInscriptos);
            this.gbTurno.Controls.Add(this.txtCupo);
            this.gbTurno.Controls.Add(this.txtDias);
            this.gbTurno.Controls.Add(this.label3);
            this.gbTurno.Controls.Add(this.cboTurnos);
            this.gbTurno.Controls.Add(this.label5);
            this.gbTurno.Controls.Add(this.label6);
            this.gbTurno.Location = new System.Drawing.Point(12, 44);
            this.gbTurno.Name = "gbTurno";
            this.gbTurno.Size = new System.Drawing.Size(379, 156);
            this.gbTurno.TabIndex = 61;
            this.gbTurno.TabStop = false;
            this.gbTurno.Text = "Turno";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 63;
            this.label4.Text = "Horario:";
            // 
            // txtInscriptos
            // 
            this.txtInscriptos.Location = new System.Drawing.Point(98, 115);
            this.txtInscriptos.Name = "txtInscriptos";
            this.txtInscriptos.Size = new System.Drawing.Size(93, 24);
            this.txtInscriptos.TabIndex = 62;
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(98, 85);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.ReadOnly = true;
            this.txtCupo.Size = new System.Drawing.Size(93, 24);
            this.txtCupo.TabIndex = 61;
            // 
            // txtDias
            // 
            this.txtDias.Location = new System.Drawing.Point(98, 55);
            this.txtDias.Name = "txtDias";
            this.txtDias.ReadOnly = true;
            this.txtDias.Size = new System.Drawing.Size(267, 24);
            this.txtDias.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 59;
            this.label3.Text = "Dias:";
            // 
            // frmRegistrarEditarMembresia
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(403, 465);
            this.Controls.Add(this.gbTurno);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.dtpFechaVencimiento);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.numDescuento);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.cboActividades);
            this.Controls.Add(this.cboDuracion);
            this.Controls.Add(this.numPrecio);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label39);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarEditarMembresia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Registrar membresia";
            this.Load += new System.EventHandler(this.frmRegistrarEditarMembresia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecio)).EndInit();
            this.gbTurno.ResumeLayout(false);
            this.gbTurno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numDescuento;
        private System.Windows.Forms.NumericUpDown numPrecio;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.ComboBox cboDuracion;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox cboTurnos;
        private System.Windows.Forms.ComboBox cboActividades;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaVencimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.GroupBox gbTurno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtInscriptos;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.TextBox txtDias;
    }
}