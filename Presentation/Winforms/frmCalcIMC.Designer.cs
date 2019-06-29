namespace Presentation.Winforms
{
    partial class frmCalcIMC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCalcIMC));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnAltamenteActivo = new System.Windows.Forms.RadioButton();
            this.rbtnMuyActivo = new System.Windows.Forms.RadioButton();
            this.rbtnModeradamenteActivo = new System.Windows.Forms.RadioButton();
            this.rbtnAlgoActivo = new System.Windows.Forms.RadioButton();
            this.rbtnSedentario = new System.Windows.Forms.RadioButton();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.numPeso = new System.Windows.Forms.NumericUpDown();
            this.numAltura = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIMC = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbMasInformacion = new System.Windows.Forms.ToolStripStatusLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCalorias = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusBar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(974, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnAltamenteActivo);
            this.groupBox1.Controls.Add(this.rbtnMuyActivo);
            this.groupBox1.Controls.Add(this.rbtnModeradamenteActivo);
            this.groupBox1.Controls.Add(this.rbtnAlgoActivo);
            this.groupBox1.Controls.Add(this.rbtnSedentario);
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.numPeso);
            this.groupBox1.Controls.Add(this.numAltura);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 73);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(501, 261);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Completa";
            // 
            // rbtnAltamenteActivo
            // 
            this.rbtnAltamenteActivo.AutoSize = true;
            this.rbtnAltamenteActivo.Location = new System.Drawing.Point(9, 186);
            this.rbtnAltamenteActivo.Name = "rbtnAltamenteActivo";
            this.rbtnAltamenteActivo.Size = new System.Drawing.Size(275, 21);
            this.rbtnAltamenteActivo.TabIndex = 11;
            this.rbtnAltamenteActivo.Text = "Altamente activo: atleta profesional";
            this.rbtnAltamenteActivo.UseVisualStyleBackColor = true;
            this.rbtnAltamenteActivo.CheckedChanged += new System.EventHandler(this.rbtnAltamenteActivo_CheckedChanged);
            // 
            // rbtnMuyActivo
            // 
            this.rbtnMuyActivo.AutoSize = true;
            this.rbtnMuyActivo.Location = new System.Drawing.Point(9, 159);
            this.rbtnMuyActivo.Name = "rbtnMuyActivo";
            this.rbtnMuyActivo.Size = new System.Drawing.Size(386, 21);
            this.rbtnMuyActivo.TabIndex = 10;
            this.rbtnMuyActivo.Text = "Muy activo: ejercicio intenso 5 a 7 dias por semana";
            this.rbtnMuyActivo.UseVisualStyleBackColor = true;
            this.rbtnMuyActivo.CheckedChanged += new System.EventHandler(this.rbtnMuyActivo_CheckedChanged);
            // 
            // rbtnModeradamenteActivo
            // 
            this.rbtnModeradamenteActivo.AutoSize = true;
            this.rbtnModeradamenteActivo.Checked = true;
            this.rbtnModeradamenteActivo.Location = new System.Drawing.Point(9, 132);
            this.rbtnModeradamenteActivo.Name = "rbtnModeradamenteActivo";
            this.rbtnModeradamenteActivo.Size = new System.Drawing.Size(489, 21);
            this.rbtnModeradamenteActivo.TabIndex = 9;
            this.rbtnModeradamenteActivo.TabStop = true;
            this.rbtnModeradamenteActivo.Text = "Moderadamente activo: ejercicio moderado 3 a 5 dias por semana";
            this.rbtnModeradamenteActivo.UseVisualStyleBackColor = true;
            this.rbtnModeradamenteActivo.CheckedChanged += new System.EventHandler(this.rbtnModeradamenteActivo_CheckedChanged);
            // 
            // rbtnAlgoActivo
            // 
            this.rbtnAlgoActivo.AutoSize = true;
            this.rbtnAlgoActivo.Location = new System.Drawing.Point(9, 105);
            this.rbtnAlgoActivo.Name = "rbtnAlgoActivo";
            this.rbtnAlgoActivo.Size = new System.Drawing.Size(375, 21);
            this.rbtnAlgoActivo.TabIndex = 8;
            this.rbtnAlgoActivo.Text = "Algo activo: ejercicio ligero 1 a 3 dias por semana";
            this.rbtnAlgoActivo.UseVisualStyleBackColor = true;
            this.rbtnAlgoActivo.CheckedChanged += new System.EventHandler(this.rbtnAlgoActivo_CheckedChanged);
            // 
            // rbtnSedentario
            // 
            this.rbtnSedentario.AutoSize = true;
            this.rbtnSedentario.Location = new System.Drawing.Point(9, 78);
            this.rbtnSedentario.Name = "rbtnSedentario";
            this.rbtnSedentario.Size = new System.Drawing.Size(283, 21);
            this.rbtnSedentario.TabIndex = 7;
            this.rbtnSedentario.Text = "Sedentario: poco o nada de ejercicio";
            this.rbtnSedentario.UseVisualStyleBackColor = true;
            this.rbtnSedentario.CheckedChanged += new System.EventHandler(this.rbtnSedentario_CheckedChanged);
            // 
            // btnCalcular
            // 
            this.btnCalcular.AutoSize = true;
            this.btnCalcular.BackColor = System.Drawing.Color.Green;
            this.btnCalcular.FlatAppearance.BorderSize = 0;
            this.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcular.ForeColor = System.Drawing.Color.White;
            this.btnCalcular.Location = new System.Drawing.Point(9, 213);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(100, 38);
            this.btnCalcular.TabIndex = 6;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = false;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // numPeso
            // 
            this.numPeso.AutoSize = true;
            this.numPeso.Location = new System.Drawing.Point(68, 48);
            this.numPeso.Maximum = new decimal(new int[] {
            250,
            0,
            0,
            0});
            this.numPeso.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numPeso.Name = "numPeso";
            this.numPeso.Size = new System.Drawing.Size(51, 24);
            this.numPeso.TabIndex = 5;
            this.numPeso.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // numAltura
            // 
            this.numAltura.AutoSize = true;
            this.numAltura.Location = new System.Drawing.Point(68, 18);
            this.numAltura.Maximum = new decimal(new int[] {
            230,
            0,
            0,
            0});
            this.numAltura.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numAltura.Name = "numAltura";
            this.numAltura.Size = new System.Drawing.Size(51, 24);
            this.numAltura.TabIndex = 4;
            this.numAltura.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "kgs.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "cms.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Peso:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Altura:";
            // 
            // txtIMC
            // 
            this.txtIMC.Location = new System.Drawing.Point(194, 17);
            this.txtIMC.Name = "txtIMC";
            this.txtIMC.ReadOnly = true;
            this.txtIMC.Size = new System.Drawing.Size(100, 24);
            this.txtIMC.TabIndex = 1;
            this.txtIMC.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Indice de Masa Corporal:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation.Properties.Resources.imc;
            this.pictureBox1.Location = new System.Drawing.Point(519, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(464, 393);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Green;
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.lbMasInformacion});
            this.statusBar.Location = new System.Drawing.Point(0, 481);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(992, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 4;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(802, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // lbMasInformacion
            // 
            this.lbMasInformacion.BackColor = System.Drawing.SystemColors.Control;
            this.lbMasInformacion.IsLink = true;
            this.lbMasInformacion.LinkColor = System.Drawing.Color.White;
            this.lbMasInformacion.Name = "lbMasInformacion";
            this.lbMasInformacion.Size = new System.Drawing.Size(144, 17);
            this.lbMasInformacion.Text = "Mas informacion aqui!";
            this.lbMasInformacion.Click += new System.EventHandler(this.lbMasInformacion_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Calorias por dia:";
            // 
            // txtCalorias
            // 
            this.txtCalorias.Location = new System.Drawing.Point(194, 47);
            this.txtCalorias.Name = "txtCalorias";
            this.txtCalorias.ReadOnly = true;
            this.txtCalorias.Size = new System.Drawing.Size(100, 24);
            this.txtCalorias.TabIndex = 6;
            this.txtCalorias.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtIMC);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtCalorias);
            this.groupBox2.Location = new System.Drawing.Point(12, 340);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(501, 126);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resultados";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(489, 37);
            this.label7.TabIndex = 7;
            this.label7.Text = "Compara tus resultados con la tabla desarrollada por la Organizacion Mundial de l" +
    "a Salud.";
            // 
            // frmCalcIMC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(992, 503);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "frmCalcIMC";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Calculadora del IMC";
            this.Load += new System.EventHandler(this.frmCalcIMC_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPeso)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.NumericUpDown numPeso;
        private System.Windows.Forms.NumericUpDown numAltura;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIMC;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel lbMasInformacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCalorias;
        private System.Windows.Forms.RadioButton rbtnAltamenteActivo;
        private System.Windows.Forms.RadioButton rbtnMuyActivo;
        private System.Windows.Forms.RadioButton rbtnModeradamenteActivo;
        private System.Windows.Forms.RadioButton rbtnAlgoActivo;
        private System.Windows.Forms.RadioButton rbtnSedentario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
    }
}