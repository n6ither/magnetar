namespace Presentation.Winforms
{
    partial class frmRegistrarEditarProfesor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarEditarProfesor));
            this.menuTop = new System.Windows.Forms.ToolStrip();
            this.btnNuevoProfesor = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnBaja = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAyuda = new System.Windows.Forms.ToolStripButton();
            this.btnInicio = new System.Windows.Forms.ToolStripButton();
            this.btnSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.cmsImagen = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsCargar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsQuitar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRedimensionar = new System.Windows.Forms.ToolStripMenuItem();
            this.txtOcupacion = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTelefonoCelular = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cboSexo = new System.Windows.Forms.ComboBox();
            this.txtTelefonoFijo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.cboLocalidad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNroDoc = new System.Windows.Forms.MaskedTextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.dlgImagen = new System.Windows.Forms.OpenFileDialog();
            this.btnRegistrarLocalidad = new System.Windows.Forms.Button();
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.menuTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.cmsImagen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).BeginInit();
            this.SuspendLayout();
            // 
            // menuTop
            // 
            this.menuTop.AutoSize = false;
            this.menuTop.BackColor = System.Drawing.Color.Green;
            this.menuTop.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoProfesor,
            this.btnGuardar,
            this.btnBaja,
            this.toolStripSeparator2,
            this.btnAyuda,
            this.btnInicio,
            this.btnSiguiente,
            this.btnAnterior});
            this.menuTop.Location = new System.Drawing.Point(0, 0);
            this.menuTop.Name = "menuTop";
            this.menuTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuTop.Size = new System.Drawing.Size(601, 44);
            this.menuTop.TabIndex = 37;
            // 
            // btnNuevoProfesor
            // 
            this.btnNuevoProfesor.AutoSize = false;
            this.btnNuevoProfesor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoProfesor.Image = global::Presentation.Properties.Resources.add;
            this.btnNuevoProfesor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevoProfesor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoProfesor.Name = "btnNuevoProfesor";
            this.btnNuevoProfesor.Size = new System.Drawing.Size(36, 41);
            this.btnNuevoProfesor.ToolTipText = "Registrar nuevo socio";
            this.btnNuevoProfesor.Click += new System.EventHandler(this.btnNuevoProfesor_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.AutoSize = false;
            this.btnGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGuardar.Image = global::Presentation.Properties.Resources.save;
            this.btnGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(36, 41);
            this.btnGuardar.ToolTipText = "Guardar socio";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.AutoSize = false;
            this.btnBaja.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBaja.Image = global::Presentation.Properties.Resources.delete;
            this.btnBaja.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBaja.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(36, 41);
            this.btnBaja.ToolTipText = "Dar de baja";
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 44);
            // 
            // btnAyuda
            // 
            this.btnAyuda.AutoSize = false;
            this.btnAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAyuda.Image = global::Presentation.Properties.Resources.help;
            this.btnAyuda.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAyuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(36, 41);
            this.btnAyuda.ToolTipText = "Ayuda";
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.AutoSize = false;
            this.btnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicio.Image = global::Presentation.Properties.Resources.close;
            this.btnInicio.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(36, 41);
            this.btnInicio.ToolTipText = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnSiguiente.AutoSize = false;
            this.btnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguiente.Image = global::Presentation.Properties.Resources.next;
            this.btnSiguiente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(36, 41);
            this.btnSiguiente.ToolTipText = "Siguiente";
            // 
            // btnAnterior
            // 
            this.btnAnterior.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAnterior.AutoSize = false;
            this.btnAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnterior.Image = global::Presentation.Properties.Resources.previous;
            this.btnAnterior.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(36, 41);
            this.btnAnterior.ToolTipText = "Anterior";
            // 
            // txtEdad
            // 
            this.txtEdad.Location = new System.Drawing.Point(552, 153);
            this.txtEdad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.ReadOnly = true;
            this.txtEdad.Size = new System.Drawing.Size(33, 24);
            this.txtEdad.TabIndex = 27;
            this.txtEdad.TabStop = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(498, 156);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(49, 17);
            this.label26.TabIndex = 26;
            this.label26.Text = "Edad:";
            // 
            // pbImagen
            // 
            this.pbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImagen.ContextMenuStrip = this.cmsImagen;
            this.pbImagen.Image = global::Presentation.Properties.Resources.sociodefault;
            this.pbImagen.Location = new System.Drawing.Point(12, 57);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(250, 250);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagen.TabIndex = 24;
            this.pbImagen.TabStop = false;
            this.pbImagen.Click += new System.EventHandler(this.pbImagenProfesor_Click);
            // 
            // cmsImagen
            // 
            this.cmsImagen.Font = new System.Drawing.Font("Verdana", 9F);
            this.cmsImagen.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsCargar,
            this.cmsQuitar,
            this.cmsRedimensionar});
            this.cmsImagen.Name = "cmsImagen";
            this.cmsImagen.Size = new System.Drawing.Size(168, 70);
            // 
            // cmsCargar
            // 
            this.cmsCargar.Name = "cmsCargar";
            this.cmsCargar.Size = new System.Drawing.Size(167, 22);
            this.cmsCargar.Text = "Cargar";
            this.cmsCargar.Click += new System.EventHandler(this.cmsCargar_Click);
            // 
            // cmsQuitar
            // 
            this.cmsQuitar.Name = "cmsQuitar";
            this.cmsQuitar.Size = new System.Drawing.Size(167, 22);
            this.cmsQuitar.Text = "Quitar";
            this.cmsQuitar.Click += new System.EventHandler(this.cmsQuitar_Click);
            // 
            // cmsRedimensionar
            // 
            this.cmsRedimensionar.Name = "cmsRedimensionar";
            this.cmsRedimensionar.Size = new System.Drawing.Size(167, 22);
            this.cmsRedimensionar.Text = "Redimensionar";
            this.cmsRedimensionar.Click += new System.EventHandler(this.cmsRedimensionar_Click);
            // 
            // txtOcupacion
            // 
            this.txtOcupacion.Location = new System.Drawing.Point(385, 279);
            this.txtOcupacion.Name = "txtOcupacion";
            this.txtOcupacion.Size = new System.Drawing.Size(200, 24);
            this.txtOcupacion.TabIndex = 8;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(274, 282);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 17);
            this.label18.TabIndex = 20;
            this.label18.Text = "Ocupacion:";
            // 
            // txtTelefonoCelular
            // 
            this.txtTelefonoCelular.Location = new System.Drawing.Point(385, 341);
            this.txtTelefonoCelular.Name = "txtTelefonoCelular";
            this.txtTelefonoCelular.Size = new System.Drawing.Size(105, 24);
            this.txtTelefonoCelular.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nro. Doc.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(275, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tel. Fijo:";
            // 
            // cboSexo
            // 
            this.cboSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSexo.FormattingEnabled = true;
            this.cboSexo.Items.AddRange(new object[] {
            "Femenino",
            "Masculino"});
            this.cboSexo.Location = new System.Drawing.Point(386, 184);
            this.cboSexo.Name = "cboSexo";
            this.cboSexo.Size = new System.Drawing.Size(121, 24);
            this.cboSexo.TabIndex = 5;
            // 
            // txtTelefonoFijo
            // 
            this.txtTelefonoFijo.Location = new System.Drawing.Point(385, 310);
            this.txtTelefonoFijo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTelefonoFijo.Name = "txtTelefonoFijo";
            this.txtTelefonoFijo.Size = new System.Drawing.Size(105, 24);
            this.txtTelefonoFijo.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(274, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Apellido(s):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(274, 251);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Localidad:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(274, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Sexo:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(385, 372);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 24);
            this.txtEmail.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha de Nac.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(274, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Direccion:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 375);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Email:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(385, 89);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 24);
            this.txtNombre.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(275, 344);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Celular:";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(386, 153);
            this.dtpFechaNac.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaNac.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.Size = new System.Drawing.Size(105, 24);
            this.dtpFechaNac.TabIndex = 4;
            this.dtpFechaNac.Value = new System.DateTime(2013, 12, 30, 21, 41, 25, 0);
            this.dtpFechaNac.ValueChanged += new System.EventHandler(this.dtpFechaNac_ValueChanged);
            // 
            // cboLocalidad
            // 
            this.cboLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocalidad.FormattingEnabled = true;
            this.cboLocalidad.Location = new System.Drawing.Point(386, 248);
            this.cboLocalidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLocalidad.Name = "cboLocalidad";
            this.cboLocalidad.Size = new System.Drawing.Size(160, 24);
            this.cboLocalidad.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre(s):";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(385, 215);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(200, 24);
            this.txtDireccion.TabIndex = 6;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(385, 121);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(200, 24);
            this.txtApellido.TabIndex = 3;
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(385, 57);
            this.txtNroDoc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNroDoc.Mask = "99999999";
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(71, 24);
            this.txtNroDoc.TabIndex = 1;
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
            this.btnCancelar.Location = new System.Drawing.Point(486, 422);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 38);
            this.btnCancelar.TabIndex = 40;
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
            this.btnAceptar.Location = new System.Drawing.Point(380, 422);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 38);
            this.btnAceptar.TabIndex = 39;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // dlgImagen
            // 
            this.dlgImagen.Filter = "Archivos de imagen (*.BMP;*.JPG;*.JPEG;*.GIF)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG";
            // 
            // btnRegistrarLocalidad
            // 
            this.btnRegistrarLocalidad.AutoSize = true;
            this.btnRegistrarLocalidad.BackColor = System.Drawing.Color.Green;
            this.btnRegistrarLocalidad.FlatAppearance.BorderSize = 0;
            this.btnRegistrarLocalidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarLocalidad.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarLocalidad.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarLocalidad.Location = new System.Drawing.Point(552, 246);
            this.btnRegistrarLocalidad.Name = "btnRegistrarLocalidad";
            this.btnRegistrarLocalidad.Size = new System.Drawing.Size(33, 27);
            this.btnRegistrarLocalidad.TabIndex = 41;
            this.btnRegistrarLocalidad.Text = "...";
            this.btnRegistrarLocalidad.UseVisualStyleBackColor = false;
            this.btnRegistrarLocalidad.Click += new System.EventHandler(this.btnRegistrarLocalidad_Click);
            // 
            // dgvActividades
            // 
            this.dgvActividades.AllowUserToAddRows = false;
            this.dgvActividades.AllowUserToDeleteRows = false;
            this.dgvActividades.AllowUserToOrderColumns = true;
            this.dgvActividades.AllowUserToResizeRows = false;
            this.dgvActividades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvActividades.BackgroundColor = System.Drawing.Color.White;
            this.dgvActividades.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvActividades.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvActividades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvActividades.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvActividades.Location = new System.Drawing.Point(11, 309);
            this.dgvActividades.MultiSelect = false;
            this.dgvActividades.Name = "dgvActividades";
            this.dgvActividades.RowHeadersVisible = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            this.dgvActividades.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvActividades.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvActividades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividades.Size = new System.Drawing.Size(251, 151);
            this.dgvActividades.TabIndex = 44;
            // 
            // frmRegistrarEditarProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(601, 476);
            this.Controls.Add(this.dgvActividades);
            this.Controls.Add(this.btnRegistrarLocalidad);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.menuTop);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.txtOcupacion);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.txtTelefonoCelular);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLocalidad);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.cboSexo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTelefonoFijo);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEmail);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegistrarEditarProfesor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Registrar profesor";
            this.Load += new System.EventHandler(this.frmRegistrarEditarProfesor_Load);
            this.menuTop.ResumeLayout(false);
            this.menuTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.cmsImagen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvActividades)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menuTop;
        private System.Windows.Forms.ToolStripButton btnNuevoProfesor;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnBaja;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAyuda;
        private System.Windows.Forms.ToolStripButton btnInicio;
        private System.Windows.Forms.ToolStripButton btnSiguiente;
        private System.Windows.Forms.ToolStripButton btnAnterior;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.TextBox txtOcupacion;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtTelefonoCelular;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboSexo;
        private System.Windows.Forms.TextBox txtTelefonoFijo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.ComboBox cboLocalidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.MaskedTextBox txtNroDoc;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.OpenFileDialog dlgImagen;
        private System.Windows.Forms.Button btnRegistrarLocalidad;
        private System.Windows.Forms.ContextMenuStrip cmsImagen;
        private System.Windows.Forms.ToolStripMenuItem cmsCargar;
        private System.Windows.Forms.ToolStripMenuItem cmsQuitar;
        private System.Windows.Forms.ToolStripMenuItem cmsRedimensionar;
        private System.Windows.Forms.DataGridView dgvActividades;
    }
}