namespace Presentation.Winforms
{
    partial class frmSociosInactivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSociosInactivos));
            this.dgvSociosInactivos = new System.Windows.Forms.DataGridView();
            this.lbSociosDesde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboFiltroSociosInactivos = new System.Windows.Forms.ComboBox();
            this.dtpSociosHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpSociosDesde = new System.Windows.Forms.DateTimePicker();
            this.lbSociosHasta = new System.Windows.Forms.Label();
            this.txtBuscarSocio = new System.Windows.Forms.TextBox();
            this.btnActivarSocio = new System.Windows.Forms.Button();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lbCantidad = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnEliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSociosInactivos)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSociosInactivos
            // 
            this.dgvSociosInactivos.AllowUserToAddRows = false;
            this.dgvSociosInactivos.AllowUserToDeleteRows = false;
            this.dgvSociosInactivos.AllowUserToOrderColumns = true;
            this.dgvSociosInactivos.AllowUserToResizeRows = false;
            this.dgvSociosInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSociosInactivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSociosInactivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSociosInactivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvSociosInactivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSociosInactivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvSociosInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSociosInactivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvSociosInactivos.Location = new System.Drawing.Point(12, 73);
            this.dgvSociosInactivos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvSociosInactivos.MultiSelect = false;
            this.dgvSociosInactivos.Name = "dgvSociosInactivos";
            this.dgvSociosInactivos.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvSociosInactivos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSociosInactivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvSociosInactivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSociosInactivos.Size = new System.Drawing.Size(1324, 382);
            this.dgvSociosInactivos.TabIndex = 1;
            // 
            // lbSociosDesde
            // 
            this.lbSociosDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSociosDesde.AutoSize = true;
            this.lbSociosDesde.Location = new System.Drawing.Point(935, 17);
            this.lbSociosDesde.Name = "lbSociosDesde";
            this.lbSociosDesde.Size = new System.Drawing.Size(58, 17);
            this.lbSociosDesde.TabIndex = 40;
            this.lbSociosDesde.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(935, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Filtro:";
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
            this.btnBuscar.Location = new System.Drawing.Point(1269, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(67, 54);
            this.btnBuscar.TabIndex = 38;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboFiltroSociosInactivos
            // 
            this.cboFiltroSociosInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFiltroSociosInactivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltroSociosInactivos.FormattingEnabled = true;
            this.cboFiltroSociosInactivos.Items.AddRange(new object[] {
            "Apellido",
            "Nombre",
            "Nro. de Documento",
            "Fecha de registracion"});
            this.cboFiltroSociosInactivos.Location = new System.Drawing.Point(999, 42);
            this.cboFiltroSociosInactivos.Name = "cboFiltroSociosInactivos";
            this.cboFiltroSociosInactivos.Size = new System.Drawing.Size(264, 24);
            this.cboFiltroSociosInactivos.TabIndex = 37;
            this.cboFiltroSociosInactivos.SelectedIndexChanged += new System.EventHandler(this.cboFiltroSocios_SelectedIndexChanged);
            // 
            // dtpSociosHasta
            // 
            this.dtpSociosHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSociosHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSociosHasta.Location = new System.Drawing.Point(1164, 14);
            this.dtpSociosHasta.Name = "dtpSociosHasta";
            this.dtpSociosHasta.Size = new System.Drawing.Size(99, 24);
            this.dtpSociosHasta.TabIndex = 36;
            this.dtpSociosHasta.Visible = false;
            // 
            // dtpSociosDesde
            // 
            this.dtpSociosDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSociosDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSociosDesde.Location = new System.Drawing.Point(999, 14);
            this.dtpSociosDesde.Name = "dtpSociosDesde";
            this.dtpSociosDesde.Size = new System.Drawing.Size(99, 24);
            this.dtpSociosDesde.TabIndex = 34;
            this.dtpSociosDesde.Visible = false;
            // 
            // lbSociosHasta
            // 
            this.lbSociosHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSociosHasta.AutoSize = true;
            this.lbSociosHasta.Location = new System.Drawing.Point(1104, 17);
            this.lbSociosHasta.Name = "lbSociosHasta";
            this.lbSociosHasta.Size = new System.Drawing.Size(54, 17);
            this.lbSociosHasta.TabIndex = 35;
            this.lbSociosHasta.Text = "Hasta:";
            this.lbSociosHasta.Visible = false;
            // 
            // txtBuscarSocio
            // 
            this.txtBuscarSocio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscarSocio.Location = new System.Drawing.Point(938, 14);
            this.txtBuscarSocio.Name = "txtBuscarSocio";
            this.txtBuscarSocio.Size = new System.Drawing.Size(325, 24);
            this.txtBuscarSocio.TabIndex = 1;
            // 
            // btnActivarSocio
            // 
            this.btnActivarSocio.AutoSize = true;
            this.btnActivarSocio.BackColor = System.Drawing.Color.Green;
            this.btnActivarSocio.FlatAppearance.BorderSize = 0;
            this.btnActivarSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarSocio.ForeColor = System.Drawing.Color.White;
            this.btnActivarSocio.Image = global::Presentation.Properties.Resources.light;
            this.btnActivarSocio.Location = new System.Drawing.Point(12, 20);
            this.btnActivarSocio.Name = "btnActivarSocio";
            this.btnActivarSocio.Size = new System.Drawing.Size(139, 38);
            this.btnActivarSocio.TabIndex = 41;
            this.btnActivarSocio.Text = "&Activar socio";
            this.btnActivarSocio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActivarSocio.UseVisualStyleBackColor = false;
            this.btnActivarSocio.Click += new System.EventHandler(this.btnActivarSocio_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.Green;
            this.statusBar.Font = new System.Drawing.Font("Verdana", 9F);
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbCantidad});
            this.statusBar.Location = new System.Drawing.Point(0, 459);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1348, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 42;
            this.statusBar.Text = "statusStrip1";
            // 
            // lbCantidad
            // 
            this.lbCantidad.BackColor = System.Drawing.SystemColors.Control;
            this.lbCantidad.ForeColor = System.Drawing.Color.White;
            this.lbCantidad.Name = "lbCantidad";
            this.lbCantidad.Size = new System.Drawing.Size(69, 17);
            this.lbCantidad.Text = "Cantidad:";
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.BackColor = System.Drawing.Color.Green;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::Presentation.Properties.Resources.delete;
            this.btnEliminar.Location = new System.Drawing.Point(157, 20);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 38);
            this.btnEliminar.TabIndex = 43;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmSociosInactivos
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 481);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnActivarSocio);
            this.Controls.Add(this.lbSociosDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboFiltroSociosInactivos);
            this.Controls.Add(this.dtpSociosHasta);
            this.Controls.Add(this.dtpSociosDesde);
            this.Controls.Add(this.lbSociosHasta);
            this.Controls.Add(this.txtBuscarSocio);
            this.Controls.Add(this.dgvSociosInactivos);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSociosInactivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Socios inactivos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSociosInactivos_FormClosing);
            this.Load += new System.EventHandler(this.frmSociosInactivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSociosInactivos)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSociosInactivos;
        private System.Windows.Forms.Label lbSociosDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboFiltroSociosInactivos;
        private System.Windows.Forms.DateTimePicker dtpSociosHasta;
        private System.Windows.Forms.DateTimePicker dtpSociosDesde;
        private System.Windows.Forms.Label lbSociosHasta;
        private System.Windows.Forms.TextBox txtBuscarSocio;
        private System.Windows.Forms.Button btnActivarSocio;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lbCantidad;
        private System.Windows.Forms.Button btnEliminar;
    }
}