namespace Presentation.Winforms
{
    partial class frmProfesoresInactivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProfesoresInactivos));
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnActivarProfesor = new System.Windows.Forms.Button();
            this.lbDesde = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cboFiltro = new System.Windows.Forms.ComboBox();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lbHasta = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvProfesoresInactivos = new System.Windows.Forms.DataGridView();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.lbCantidad = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesoresInactivos)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = true;
            this.btnEliminar.BackColor = System.Drawing.Color.Green;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = global::Presentation.Properties.Resources.delete;
            this.btnEliminar.Location = new System.Drawing.Point(181, 21);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(107, 38);
            this.btnEliminar.TabIndex = 54;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnActivarProfesor
            // 
            this.btnActivarProfesor.AutoSize = true;
            this.btnActivarProfesor.BackColor = System.Drawing.Color.Green;
            this.btnActivarProfesor.FlatAppearance.BorderSize = 0;
            this.btnActivarProfesor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarProfesor.ForeColor = System.Drawing.Color.White;
            this.btnActivarProfesor.Image = global::Presentation.Properties.Resources.light;
            this.btnActivarProfesor.Location = new System.Drawing.Point(12, 20);
            this.btnActivarProfesor.Name = "btnActivarProfesor";
            this.btnActivarProfesor.Size = new System.Drawing.Size(163, 38);
            this.btnActivarProfesor.TabIndex = 53;
            this.btnActivarProfesor.Text = "&Activar profesor";
            this.btnActivarProfesor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActivarProfesor.UseVisualStyleBackColor = false;
            this.btnActivarProfesor.Click += new System.EventHandler(this.btnActivarProfesor_Click);
            // 
            // lbDesde
            // 
            this.lbDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDesde.AutoSize = true;
            this.lbDesde.Location = new System.Drawing.Point(935, 17);
            this.lbDesde.Name = "lbDesde";
            this.lbDesde.Size = new System.Drawing.Size(58, 17);
            this.lbDesde.TabIndex = 52;
            this.lbDesde.Text = "Desde:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(935, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 51;
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
            this.btnBuscar.TabIndex = 50;
            this.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // cboFiltro
            // 
            this.cboFiltro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFiltro.FormattingEnabled = true;
            this.cboFiltro.Items.AddRange(new object[] {
            "Apellido",
            "Nombre",
            "Nro. de Documento",
            "Fecha de registracion"});
            this.cboFiltro.Location = new System.Drawing.Point(999, 42);
            this.cboFiltro.Name = "cboFiltro";
            this.cboFiltro.Size = new System.Drawing.Size(264, 24);
            this.cboFiltro.TabIndex = 49;
            this.cboFiltro.SelectedIndexChanged += new System.EventHandler(this.cboFiltro_SelectedIndexChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(1164, 14);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(99, 24);
            this.dtpHasta.TabIndex = 48;
            this.dtpHasta.Visible = false;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(999, 14);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(99, 24);
            this.dtpDesde.TabIndex = 46;
            this.dtpDesde.Visible = false;
            // 
            // lbHasta
            // 
            this.lbHasta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbHasta.AutoSize = true;
            this.lbHasta.Location = new System.Drawing.Point(1104, 17);
            this.lbHasta.Name = "lbHasta";
            this.lbHasta.Size = new System.Drawing.Size(54, 17);
            this.lbHasta.TabIndex = 47;
            this.lbHasta.Text = "Hasta:";
            this.lbHasta.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(938, 14);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(325, 24);
            this.txtBuscar.TabIndex = 44;
            // 
            // dgvProfesoresInactivos
            // 
            this.dgvProfesoresInactivos.AllowUserToAddRows = false;
            this.dgvProfesoresInactivos.AllowUserToDeleteRows = false;
            this.dgvProfesoresInactivos.AllowUserToOrderColumns = true;
            this.dgvProfesoresInactivos.AllowUserToResizeRows = false;
            this.dgvProfesoresInactivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvProfesoresInactivos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProfesoresInactivos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvProfesoresInactivos.BackgroundColor = System.Drawing.Color.White;
            this.dgvProfesoresInactivos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvProfesoresInactivos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dgvProfesoresInactivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProfesoresInactivos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProfesoresInactivos.Location = new System.Drawing.Point(12, 73);
            this.dgvProfesoresInactivos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProfesoresInactivos.MultiSelect = false;
            this.dgvProfesoresInactivos.Name = "dgvProfesoresInactivos";
            this.dgvProfesoresInactivos.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvProfesoresInactivos.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProfesoresInactivos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvProfesoresInactivos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProfesoresInactivos.Size = new System.Drawing.Size(1324, 382);
            this.dgvProfesoresInactivos.TabIndex = 45;
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
            this.statusBar.TabIndex = 55;
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
            // frmProfesoresInactivos
            // 
            this.AcceptButton = this.btnBuscar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1348, 481);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnActivarProfesor);
            this.Controls.Add(this.lbDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cboFiltro);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.lbHasta);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvProfesoresInactivos);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmProfesoresInactivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Profesores inactivos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmProfesoresInactivos_FormClosing);
            this.Load += new System.EventHandler(this.frmProfesoresInactivos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProfesoresInactivos)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnActivarProfesor;
        private System.Windows.Forms.Label lbDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cboFiltro;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lbHasta;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvProfesoresInactivos;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel lbCantidad;
    }
}