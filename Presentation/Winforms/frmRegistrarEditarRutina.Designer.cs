namespace Presentation.Winforms
{
    partial class frmRegistrarEditarRutina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegistrarEditarRutina));
            this.cmEdicion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmCortar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmCopiar = new System.Windows.Forms.ToolStripMenuItem();
            this.cmPegar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmFuente = new System.Windows.Forms.ToolStripMenuItem();
            this.cmColor = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogoFuente = new System.Windows.Forms.FontDialog();
            this.dialogoImportar = new System.Windows.Forms.OpenFileDialog();
            this.dialogoColor = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.numDuracion = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContenido = new System.Windows.Forms.RichTextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolstripRegistrarEditarRutina = new System.Windows.Forms.ToolStrip();
            this.btnNuevoRutina = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAyuda = new System.Windows.Forms.ToolStripButton();
            this.btnInicio = new System.Windows.Forms.ToolStripButton();
            this.btnSiguiente = new System.Windows.Forms.ToolStripButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripButton();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnFuente = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.cmEdicion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).BeginInit();
            this.toolstripRegistrarEditarRutina.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmEdicion
            // 
            this.cmEdicion.Font = new System.Drawing.Font("Verdana", 10F);
            this.cmEdicion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmCortar,
            this.cmCopiar,
            this.cmPegar,
            this.toolStripSeparator1,
            this.cmFuente,
            this.cmColor});
            this.cmEdicion.Name = "cmEdicion";
            this.cmEdicion.Size = new System.Drawing.Size(177, 120);
            // 
            // cmCortar
            // 
            this.cmCortar.Name = "cmCortar";
            this.cmCortar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cmCortar.Size = new System.Drawing.Size(176, 22);
            this.cmCortar.Text = "Cortar";
            this.cmCortar.Click += new System.EventHandler(this.cmCortar_Click);
            // 
            // cmCopiar
            // 
            this.cmCopiar.Name = "cmCopiar";
            this.cmCopiar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.cmCopiar.Size = new System.Drawing.Size(176, 22);
            this.cmCopiar.Text = "Copiar";
            this.cmCopiar.Click += new System.EventHandler(this.cmCopiar_Click);
            // 
            // cmPegar
            // 
            this.cmPegar.Name = "cmPegar";
            this.cmPegar.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.cmPegar.Size = new System.Drawing.Size(176, 22);
            this.cmPegar.Text = "Pegar";
            this.cmPegar.Click += new System.EventHandler(this.cmPegar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(173, 6);
            // 
            // cmFuente
            // 
            this.cmFuente.Name = "cmFuente";
            this.cmFuente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.cmFuente.Size = new System.Drawing.Size(176, 22);
            this.cmFuente.Text = "Fuente";
            this.cmFuente.Click += new System.EventHandler(this.cmFuente_Click);
            // 
            // cmColor
            // 
            this.cmColor.Name = "cmColor";
            this.cmColor.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.cmColor.Size = new System.Drawing.Size(176, 22);
            this.cmColor.Text = "Color";
            this.cmColor.Click += new System.EventHandler(this.cmColor_Click);
            // 
            // dialogoImportar
            // 
            this.dialogoImportar.Filter = "Archivos de texto (*.txt)|*.txt|Archivo de Texto Enriquecido (*.rtf)|*.rtf|Todos " +
    "los archivos (*.*)|*.*";
            this.dialogoImportar.Title = "Importar plan";
            // 
            // dialogoColor
            // 
            this.dialogoColor.AllowFullOpen = false;
            this.dialogoColor.SolidColorOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "semana(s).";
            // 
            // numDuracion
            // 
            this.numDuracion.AutoSize = true;
            this.numDuracion.Location = new System.Drawing.Point(98, 88);
            this.numDuracion.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDuracion.Name = "numDuracion";
            this.numDuracion.Size = new System.Drawing.Size(51, 24);
            this.numDuracion.TabIndex = 15;
            this.numDuracion.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Duracion:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(790, 17);
            this.label2.TabIndex = 17;
            this.label2.Text = "A continuacion escriba o pegue el contenido de la rutina. Tambien puede importarl" +
    "o desde un archivo de texto.";
            // 
            // txtContenido
            // 
            this.txtContenido.AcceptsTab = true;
            this.txtContenido.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContenido.ContextMenuStrip = this.cmEdicion;
            this.txtContenido.Location = new System.Drawing.Point(14, 149);
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtContenido.Size = new System.Drawing.Size(965, 363);
            this.txtContenido.TabIndex = 18;
            this.txtContenido.Text = "";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(98, 58);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 24);
            this.txtNombre.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nombre:";
            // 
            // toolstripRegistrarEditarRutina
            // 
            this.toolstripRegistrarEditarRutina.AutoSize = false;
            this.toolstripRegistrarEditarRutina.BackColor = System.Drawing.Color.Green;
            this.toolstripRegistrarEditarRutina.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolstripRegistrarEditarRutina.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolstripRegistrarEditarRutina.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevoRutina,
            this.btnGuardar,
            this.btnEliminar,
            this.toolStripSeparator2,
            this.btnAyuda,
            this.btnInicio,
            this.btnSiguiente,
            this.btnAnterior});
            this.toolstripRegistrarEditarRutina.Location = new System.Drawing.Point(0, 0);
            this.toolstripRegistrarEditarRutina.Name = "toolstripRegistrarEditarRutina";
            this.toolstripRegistrarEditarRutina.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolstripRegistrarEditarRutina.Size = new System.Drawing.Size(991, 44);
            this.toolstripRegistrarEditarRutina.TabIndex = 38;
            // 
            // btnNuevoRutina
            // 
            this.btnNuevoRutina.AutoSize = false;
            this.btnNuevoRutina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevoRutina.Image = global::Presentation.Properties.Resources.add;
            this.btnNuevoRutina.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNuevoRutina.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoRutina.Name = "btnNuevoRutina";
            this.btnNuevoRutina.Size = new System.Drawing.Size(36, 41);
            this.btnNuevoRutina.ToolTipText = "Registrar nueva rutina";
            this.btnNuevoRutina.Click += new System.EventHandler(this.btnNuevoRutina_Click);
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
            this.btnGuardar.ToolTipText = "Guardar rutina";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AutoSize = false;
            this.btnEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminar.Image = global::Presentation.Properties.Resources.delete;
            this.btnEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(36, 41);
            this.btnEliminar.ToolTipText = "Eliminar rutina";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.AutoSize = true;
            this.btnAceptar.BackColor = System.Drawing.Color.Green;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(773, 568);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 38);
            this.btnAceptar.TabIndex = 11;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.AutoSize = true;
            this.btnCancelar.BackColor = System.Drawing.Color.Gray;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(879, 568);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 38);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnColor.AutoSize = true;
            this.btnColor.BackColor = System.Drawing.Color.Green;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.ForeColor = System.Drawing.Color.White;
            this.btnColor.Image = global::Presentation.Properties.Resources.brush;
            this.btnColor.Location = new System.Drawing.Point(120, 518);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(100, 38);
            this.btnColor.TabIndex = 22;
            this.btnColor.Text = "Color";
            this.btnColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnFuente
            // 
            this.btnFuente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFuente.AutoSize = true;
            this.btnFuente.BackColor = System.Drawing.Color.Green;
            this.btnFuente.FlatAppearance.BorderSize = 0;
            this.btnFuente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFuente.ForeColor = System.Drawing.Color.White;
            this.btnFuente.Image = global::Presentation.Properties.Resources.font;
            this.btnFuente.Location = new System.Drawing.Point(14, 518);
            this.btnFuente.Name = "btnFuente";
            this.btnFuente.Size = new System.Drawing.Size(100, 38);
            this.btnFuente.TabIndex = 21;
            this.btnFuente.Text = "Fuente";
            this.btnFuente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFuente.UseVisualStyleBackColor = false;
            this.btnFuente.Click += new System.EventHandler(this.btnFuente_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.AutoSize = true;
            this.btnImportar.BackColor = System.Drawing.Color.Green;
            this.btnImportar.FlatAppearance.BorderSize = 0;
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.ForeColor = System.Drawing.Color.White;
            this.btnImportar.Image = global::Presentation.Properties.Resources.import;
            this.btnImportar.Location = new System.Drawing.Point(866, 105);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(112, 38);
            this.btnImportar.TabIndex = 16;
            this.btnImportar.Text = "Importar";
            this.btnImportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // frmRegistrarEditarRutina
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(991, 621);
            this.Controls.Add(this.toolstripRegistrarEditarRutina);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.btnFuente);
            this.Controls.Add(this.btnImportar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numDuracion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContenido);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmRegistrarEditarRutina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magnetar Gym Management | Registrar rutina";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmRegistrarEditarRutina_Load);
            this.cmEdicion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).EndInit();
            this.toolstripRegistrarEditarRutina.ResumeLayout(false);
            this.toolstripRegistrarEditarRutina.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip cmEdicion;
        private System.Windows.Forms.ToolStripMenuItem cmCortar;
        private System.Windows.Forms.ToolStripMenuItem cmCopiar;
        private System.Windows.Forms.ToolStripMenuItem cmPegar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmFuente;
        private System.Windows.Forms.FontDialog dialogoFuente;
        private System.Windows.Forms.OpenFileDialog dialogoImportar;
        private System.Windows.Forms.ToolStripMenuItem cmColor;
        private System.Windows.Forms.ColorDialog dialogoColor;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnFuente;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDuracion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox txtContenido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolstripRegistrarEditarRutina;
        private System.Windows.Forms.ToolStripButton btnNuevoRutina;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnAyuda;
        private System.Windows.Forms.ToolStripButton btnInicio;
        private System.Windows.Forms.ToolStripButton btnSiguiente;
        private System.Windows.Forms.ToolStripButton btnAnterior;
    }
}