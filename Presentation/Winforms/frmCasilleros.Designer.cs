namespace Presentation.Winforms
{
    partial class frmCasilleros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCasilleros));
            this.dgvCasilleros = new System.Windows.Forms.DataGridView();
            this.pbSocio = new System.Windows.Forms.PictureBox();
            this.lbSocio = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFechaInicio = new System.Windows.Forms.TextBox();
            this.txtFechaVencimiento = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.lbDiasVencimiento = new System.Windows.Forms.Label();
            this.tlpSocio = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.btnAsignar = new System.Windows.Forms.Button();
            this.btnLiberar = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lbCantidadCasilleros = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCasilleros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSocio)).BeginInit();
            this.tlpSocio.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCasilleros
            // 
            this.dgvCasilleros.AllowUserToAddRows = false;
            this.dgvCasilleros.AllowUserToDeleteRows = false;
            this.dgvCasilleros.AllowUserToOrderColumns = true;
            this.dgvCasilleros.AllowUserToResizeRows = false;
            this.dgvCasilleros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCasilleros.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCasilleros.BackgroundColor = System.Drawing.Color.White;
            this.dgvCasilleros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCasilleros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvCasilleros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCasilleros.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCasilleros.Location = new System.Drawing.Point(12, 86);
            this.dgvCasilleros.MultiSelect = false;
            this.dgvCasilleros.Name = "dgvCasilleros";
            this.dgvCasilleros.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvCasilleros.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCasilleros.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvCasilleros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCasilleros.Size = new System.Drawing.Size(132, 226);
            this.dgvCasilleros.TabIndex = 4;
            this.dgvCasilleros.SelectionChanged += new System.EventHandler(this.dgvCasilleros_SelectionChanged);
            // 
            // pbSocio
            // 
            this.pbSocio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSocio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbSocio.Image = global::Presentation.Properties.Resources.sociodefault;
            this.pbSocio.Location = new System.Drawing.Point(3, 3);
            this.pbSocio.Name = "pbSocio";
            this.pbSocio.Size = new System.Drawing.Size(195, 171);
            this.pbSocio.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSocio.TabIndex = 5;
            this.pbSocio.TabStop = false;
            // 
            // lbSocio
            // 
            this.lbSocio.AutoSize = true;
            this.lbSocio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSocio.Location = new System.Drawing.Point(3, 177);
            this.lbSocio.Name = "lbSocio";
            this.lbSocio.Size = new System.Drawing.Size(195, 20);
            this.lbSocio.TabIndex = 7;
            this.lbSocio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vencimiento:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Precio:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Casillero Nro.:";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(326, 23);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(36, 24);
            this.txtNumero.TabIndex = 12;
            this.txtNumero.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(213, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Inicio:";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.Location = new System.Drawing.Point(326, 53);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.ReadOnly = true;
            this.txtFechaInicio.Size = new System.Drawing.Size(100, 24);
            this.txtFechaInicio.TabIndex = 14;
            this.txtFechaInicio.TabStop = false;
            // 
            // txtFechaVencimiento
            // 
            this.txtFechaVencimiento.Location = new System.Drawing.Point(326, 83);
            this.txtFechaVencimiento.Name = "txtFechaVencimiento";
            this.txtFechaVencimiento.ReadOnly = true;
            this.txtFechaVencimiento.Size = new System.Drawing.Size(100, 24);
            this.txtFechaVencimiento.TabIndex = 15;
            this.txtFechaVencimiento.TabStop = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(326, 113);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(100, 24);
            this.txtPrecio.TabIndex = 16;
            this.txtPrecio.TabStop = false;
            // 
            // lbDiasVencimiento
            // 
            this.lbDiasVencimiento.AutoSize = true;
            this.lbDiasVencimiento.Location = new System.Drawing.Point(432, 86);
            this.lbDiasVencimiento.Name = "lbDiasVencimiento";
            this.lbDiasVencimiento.Size = new System.Drawing.Size(0, 17);
            this.lbDiasVencimiento.TabIndex = 17;
            // 
            // tlpSocio
            // 
            this.tlpSocio.ColumnCount = 1;
            this.tlpSocio.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSocio.Controls.Add(this.pbSocio, 0, 0);
            this.tlpSocio.Controls.Add(this.lbSocio, 0, 1);
            this.tlpSocio.Location = new System.Drawing.Point(6, 23);
            this.tlpSocio.Name = "tlpSocio";
            this.tlpSocio.RowCount = 2;
            this.tlpSocio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSocio.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSocio.Size = new System.Drawing.Size(201, 197);
            this.tlpSocio.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Pagó:";
            // 
            // txtPago
            // 
            this.txtPago.Location = new System.Drawing.Point(326, 143);
            this.txtPago.Name = "txtPago";
            this.txtPago.ReadOnly = true;
            this.txtPago.Size = new System.Drawing.Size(100, 24);
            this.txtPago.TabIndex = 20;
            this.txtPago.TabStop = false;
            // 
            // btnAsignar
            // 
            this.btnAsignar.AutoSize = true;
            this.btnAsignar.BackColor = System.Drawing.Color.Green;
            this.btnAsignar.FlatAppearance.BorderSize = 0;
            this.btnAsignar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignar.ForeColor = System.Drawing.Color.White;
            this.btnAsignar.Image = global::Presentation.Properties.Resources.casilleroin;
            this.btnAsignar.Location = new System.Drawing.Point(12, 12);
            this.btnAsignar.Name = "btnAsignar";
            this.btnAsignar.Size = new System.Drawing.Size(132, 38);
            this.btnAsignar.TabIndex = 21;
            this.btnAsignar.Text = "&Asignar";
            this.btnAsignar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignar.UseVisualStyleBackColor = false;
            this.btnAsignar.Click += new System.EventHandler(this.btnAsignar_Click);
            // 
            // btnLiberar
            // 
            this.btnLiberar.AutoSize = true;
            this.btnLiberar.BackColor = System.Drawing.Color.Green;
            this.btnLiberar.FlatAppearance.BorderSize = 0;
            this.btnLiberar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiberar.ForeColor = System.Drawing.Color.White;
            this.btnLiberar.Image = global::Presentation.Properties.Resources.casilleroout;
            this.btnLiberar.Location = new System.Drawing.Point(150, 12);
            this.btnLiberar.Name = "btnLiberar";
            this.btnLiberar.Size = new System.Drawing.Size(132, 38);
            this.btnLiberar.TabIndex = 22;
            this.btnLiberar.Text = "&Liberar";
            this.btnLiberar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLiberar.UseVisualStyleBackColor = false;
            this.btnLiberar.Click += new System.EventHandler(this.btnLiberar_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Green;
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbCantidadCasilleros});
            this.statusBar.Location = new System.Drawing.Point(0, 334);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(689, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 23;
            this.statusBar.Text = "statusStrip1";
            // 
            // lbCantidadCasilleros
            // 
            this.lbCantidadCasilleros.ForeColor = System.Drawing.Color.White;
            this.lbCantidadCasilleros.Name = "lbCantidadCasilleros";
            this.lbCantidadCasilleros.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlpSocio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtPago);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtFechaInicio);
            this.groupBox1.Controls.Add(this.lbDiasVencimiento);
            this.groupBox1.Controls.Add(this.txtFechaVencimiento);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Location = new System.Drawing.Point(150, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 237);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // frmCasilleros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(689, 356);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnLiberar);
            this.Controls.Add(this.btnAsignar);
            this.Controls.Add(this.dgvCasilleros);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCasilleros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Casilleros";
            this.Load += new System.EventHandler(this.frmCasilleros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCasilleros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSocio)).EndInit();
            this.tlpSocio.ResumeLayout(false);
            this.tlpSocio.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCasilleros;
        private System.Windows.Forms.PictureBox pbSocio;
        private System.Windows.Forms.Label lbSocio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFechaInicio;
        private System.Windows.Forms.TextBox txtFechaVencimiento;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label lbDiasVencimiento;
        private System.Windows.Forms.TableLayoutPanel tlpSocio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.Button btnAsignar;
        private System.Windows.Forms.Button btnLiberar;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lbCantidadCasilleros;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}