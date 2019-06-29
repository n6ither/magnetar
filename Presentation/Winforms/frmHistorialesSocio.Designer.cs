namespace Presentation.Winforms
{
    partial class frmHistorialesSocio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHistorialesSocio));
            this.dgvHistorialMembresias = new System.Windows.Forms.DataGridView();
            this.dgvHistorialPagos = new System.Windows.Forms.DataGridView();
            this.gbHistorialMembresias = new System.Windows.Forms.GroupBox();
            this.gbHistorialPagos = new System.Windows.Forms.GroupBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lbSaldoActual = new System.Windows.Forms.ToolStripStatusLabel();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lbHasta = new System.Windows.Forms.Label();
            this.lbDesde = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.chkTodas = new System.Windows.Forms.CheckBox();
            this.cboActividades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.gbResumen = new System.Windows.Forms.GroupBox();
            this.txtTotalFecha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSubtotalPagos = new System.Windows.Forms.TextBox();
            this.txtSubtotalMembresias = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialMembresias)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPagos)).BeginInit();
            this.gbHistorialMembresias.SuspendLayout();
            this.gbHistorialPagos.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.gbBusqueda.SuspendLayout();
            this.gbResumen.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHistorialMembresias
            // 
            this.dgvHistorialMembresias.AllowUserToAddRows = false;
            this.dgvHistorialMembresias.AllowUserToDeleteRows = false;
            this.dgvHistorialMembresias.AllowUserToOrderColumns = true;
            this.dgvHistorialMembresias.AllowUserToResizeRows = false;
            this.dgvHistorialMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialMembresias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialMembresias.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistorialMembresias.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialMembresias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialMembresias.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHistorialMembresias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialMembresias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHistorialMembresias.Location = new System.Drawing.Point(8, 23);
            this.dgvHistorialMembresias.MultiSelect = false;
            this.dgvHistorialMembresias.Name = "dgvHistorialMembresias";
            this.dgvHistorialMembresias.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvHistorialMembresias.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistorialMembresias.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvHistorialMembresias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialMembresias.Size = new System.Drawing.Size(523, 247);
            this.dgvHistorialMembresias.TabIndex = 2;
            // 
            // dgvHistorialPagos
            // 
            this.dgvHistorialPagos.AllowUserToAddRows = false;
            this.dgvHistorialPagos.AllowUserToDeleteRows = false;
            this.dgvHistorialPagos.AllowUserToOrderColumns = true;
            this.dgvHistorialPagos.AllowUserToResizeRows = false;
            this.dgvHistorialPagos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialPagos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorialPagos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHistorialPagos.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorialPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorialPagos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvHistorialPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialPagos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvHistorialPagos.Location = new System.Drawing.Point(8, 23);
            this.dgvHistorialPagos.MultiSelect = false;
            this.dgvHistorialPagos.Name = "dgvHistorialPagos";
            this.dgvHistorialPagos.RowHeadersVisible = false;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvHistorialPagos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistorialPagos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvHistorialPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialPagos.Size = new System.Drawing.Size(671, 247);
            this.dgvHistorialPagos.TabIndex = 3;
            // 
            // gbHistorialMembresias
            // 
            this.gbHistorialMembresias.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHistorialMembresias.Controls.Add(this.dgvHistorialMembresias);
            this.gbHistorialMembresias.Location = new System.Drawing.Point(12, 111);
            this.gbHistorialMembresias.Name = "gbHistorialMembresias";
            this.gbHistorialMembresias.Size = new System.Drawing.Size(537, 276);
            this.gbHistorialMembresias.TabIndex = 4;
            this.gbHistorialMembresias.TabStop = false;
            this.gbHistorialMembresias.Text = "Historial de membresias";
            // 
            // gbHistorialPagos
            // 
            this.gbHistorialPagos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbHistorialPagos.Controls.Add(this.dgvHistorialPagos);
            this.gbHistorialPagos.Location = new System.Drawing.Point(555, 110);
            this.gbHistorialPagos.Name = "gbHistorialPagos";
            this.gbHistorialPagos.Size = new System.Drawing.Size(685, 276);
            this.gbHistorialPagos.TabIndex = 5;
            this.gbHistorialPagos.TabStop = false;
            this.gbHistorialPagos.Text = "Historial de pagos";
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Green;
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbSaldoActual});
            this.statusBar.Location = new System.Drawing.Point(0, 514);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1252, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 6;
            this.statusBar.Text = "statusStrip1";
            // 
            // lbSaldoActual
            // 
            this.lbSaldoActual.BackColor = System.Drawing.SystemColors.Control;
            this.lbSaldoActual.ForeColor = System.Drawing.Color.White;
            this.lbSaldoActual.Name = "lbSaldoActual";
            this.lbSaldoActual.Size = new System.Drawing.Size(109, 17);
            this.lbSaldoActual.Text = "Saldo actual: $0";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(252, 50);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(99, 24);
            this.dtpHasta.TabIndex = 12;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(87, 50);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(99, 24);
            this.dtpDesde.TabIndex = 10;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // lbHasta
            // 
            this.lbHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(192, 56);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(54, 17);
            this.lbHasta.TabIndex = 11;
            this.lbHasta.Text = "Hasta:";
            // 
            // lbDesde
            // 
            this.lbDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(14, 56);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(58, 17);
            this.lbDesde.TabIndex = 9;
            this.lbDesde.Text = "Desde:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSize = true;
            this.btnBuscar.BackColor = System.Drawing.Color.Green;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Image = global::Presentation.Properties.Resources.search48;
            this.btnBuscar.Location = new System.Drawing.Point(357, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 54);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBusqueda.Controls.Add(this.chkTodas);
            this.gbBusqueda.Controls.Add(this.cboActividades);
            this.gbBusqueda.Controls.Add(this.label4);
            this.gbBusqueda.Controls.Add(this.btnBuscar);
            this.gbBusqueda.Controls.Add(this.dtpHasta);
            this.gbBusqueda.Controls.Add(this.lbDesde);
            this.gbBusqueda.Controls.Add(this.dtpDesde);
            this.gbBusqueda.Controls.Add(this.lbHasta);
            this.gbBusqueda.Location = new System.Drawing.Point(806, 11);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(434, 93);
            this.gbBusqueda.TabIndex = 13;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Busqueda";
            // 
            // chkTodas
            // 
            this.chkTodas.AutoSize = true;
            this.chkTodas.Location = new System.Drawing.Point(281, 23);
            this.chkTodas.Name = "chkTodas";
            this.chkTodas.Size = new System.Drawing.Size(70, 21);
            this.chkTodas.TabIndex = 15;
            this.chkTodas.Text = "Todas";
            this.chkTodas.UseVisualStyleBackColor = true;
            this.chkTodas.CheckedChanged += new System.EventHandler(this.chkTodas_CheckedChanged);
            // 
            // cboActividades
            // 
            this.cboActividades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActividades.FormattingEnabled = true;
            this.cboActividades.Location = new System.Drawing.Point(87, 20);
            this.cboActividades.Name = "cboActividades";
            this.cboActividades.Size = new System.Drawing.Size(188, 24);
            this.cboActividades.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Actividad:";
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.AutoSize = true;
            this.btnRefrescar.BackColor = System.Drawing.Color.Green;
            this.btnRefrescar.FlatAppearance.BorderSize = 0;
            this.btnRefrescar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefrescar.ForeColor = System.Drawing.Color.White;
            this.btnRefrescar.Image = global::Presentation.Properties.Resources.refresh;
            this.btnRefrescar.Location = new System.Drawing.Point(12, 39);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(116, 38);
            this.btnRefrescar.TabIndex = 14;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // gbResumen
            // 
            this.gbResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbResumen.Controls.Add(this.txtTotalFecha);
            this.gbResumen.Controls.Add(this.label3);
            this.gbResumen.Controls.Add(this.txtSubtotalPagos);
            this.gbResumen.Controls.Add(this.txtSubtotalMembresias);
            this.gbResumen.Controls.Add(this.label2);
            this.gbResumen.Controls.Add(this.label1);
            this.gbResumen.Location = new System.Drawing.Point(12, 393);
            this.gbResumen.Name = "gbResumen";
            this.gbResumen.Size = new System.Drawing.Size(1228, 118);
            this.gbResumen.TabIndex = 15;
            this.gbResumen.TabStop = false;
            this.gbResumen.Text = "Resumen";
            // 
            // txtTotalFecha
            // 
            this.txtTotalFecha.Location = new System.Drawing.Point(173, 77);
            this.txtTotalFecha.Name = "txtTotalFecha";
            this.txtTotalFecha.ReadOnly = true;
            this.txtTotalFecha.Size = new System.Drawing.Size(100, 24);
            this.txtTotalFecha.TabIndex = 6;
            this.txtTotalFecha.TextChanged += new System.EventHandler(this.txtTotalFecha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Total a la fecha:";
            // 
            // txtSubtotalPagos
            // 
            this.txtSubtotalPagos.Location = new System.Drawing.Point(173, 47);
            this.txtSubtotalPagos.Name = "txtSubtotalPagos";
            this.txtSubtotalPagos.ReadOnly = true;
            this.txtSubtotalPagos.Size = new System.Drawing.Size(100, 24);
            this.txtSubtotalPagos.TabIndex = 3;
            this.txtSubtotalPagos.TextChanged += new System.EventHandler(this.txtSubtotalPagos_TextChanged);
            // 
            // txtSubtotalMembresias
            // 
            this.txtSubtotalMembresias.Location = new System.Drawing.Point(173, 17);
            this.txtSubtotalMembresias.Name = "txtSubtotalMembresias";
            this.txtSubtotalMembresias.ReadOnly = true;
            this.txtSubtotalMembresias.Size = new System.Drawing.Size(100, 24);
            this.txtSubtotalMembresias.TabIndex = 2;
            this.txtSubtotalMembresias.TextChanged += new System.EventHandler(this.txtSubtotalMembresias_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Subtotal Pagos:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subtotal Membresias:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.BackColor = System.Drawing.Color.Green;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.ForeColor = System.Drawing.Color.White;
            this.btnImprimir.Image = global::Presentation.Properties.Resources.print;
            this.btnImprimir.Location = new System.Drawing.Point(134, 39);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(155, 38);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "Imprimir recibo";
            this.btnImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // frmHistorialesSocio
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1252, 536);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.gbResumen);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.gbBusqueda);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.gbHistorialPagos);
            this.Controls.Add(this.gbHistorialMembresias);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmHistorialesSocio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Historiales";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHistorialesSocio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialMembresias)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialPagos)).EndInit();
            this.gbHistorialMembresias.ResumeLayout(false);
            this.gbHistorialPagos.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbResumen.ResumeLayout(false);
            this.gbResumen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialMembresias;
        private System.Windows.Forms.DataGridView dgvHistorialPagos;
        private System.Windows.Forms.GroupBox gbHistorialMembresias;
        private System.Windows.Forms.GroupBox gbHistorialPagos;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lbSaldoActual;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.GroupBox gbResumen;
        private System.Windows.Forms.TextBox txtTotalFecha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubtotalPagos;
        private System.Windows.Forms.TextBox txtSubtotalMembresias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboActividades;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkTodas;
        private System.Windows.Forms.Button btnImprimir;
    }
}