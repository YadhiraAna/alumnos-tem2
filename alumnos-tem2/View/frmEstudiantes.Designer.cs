namespace alumnos_tem2.View
{
    partial class frmEstudiantes
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstudiantes));
            lbl_control_estudiante = new Label();
            scEstudiantes = new SplitContainer();
            gb_alta = new GroupBox();
            cbox_estatus = new ComboBox();
            txt_nombre = new TextBox();
            btn_guardar = new Button();
            lbl_nombre_completo = new Label();
            dtp_fecha_baja = new DateTimePicker();
            lbl_dt_obligatorios = new Label();
            txt_telefono = new TextBox();
            lbl_fecha_baja = new Label();
            lbls_correo = new Label();
            lbl_estatus = new Label();
            lbl_telefono = new Label();
            dtp_fecha_alta = new DateTimePicker();
            lbl_CURP = new Label();
            txt_curp = new TextBox();
            lbl_fecha_alta = new Label();
            txt_correo = new TextBox();
            pictore_question = new PictureBox();
            lbl_fecha_nac = new Label();
            txt_num_control = new TextBox();
            lbl_no_control = new Label();
            lbl_semestre = new Label();
            npd_semestre = new NumericUpDown();
            dtp_fecha_nacimiento = new DateTimePicker();
            dgvEstudiantes = new DataGridView();
            cmsEstudiantes = new ContextMenuStrip(components);
            editarEstuidanteToolStripMenuItem = new ToolStripMenuItem();
            bg_filtros = new GroupBox();
            lbl_totalReg = new Label();
            cbox_tipoFecha = new ComboBox();
            dtp_fin = new DateTimePicker();
            dtp_inicio = new DateTimePicker();
            txt_busqueda = new TextBox();
            lbl_fecha_fin = new Label();
            lbl_fecha_inic = new Label();
            lbl_busqueda = new Label();
            lbl_tipo_fecha = new Label();
            btn_actualizar = new Button();
            gb_herramientas = new GroupBox();
            btn_exc = new Button();
            chSoloActivos = new CheckBox();
            lbl_ruta = new Label();
            btn_carga = new Button();
            btn_mostrarCap = new Button();
            toolTip_nu_control = new ToolTip(components);
            ofdArchivo = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).BeginInit();
            scEstudiantes.Panel1.SuspendLayout();
            scEstudiantes.Panel2.SuspendLayout();
            scEstudiantes.SuspendLayout();
            gb_alta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictore_question).BeginInit();
            ((System.ComponentModel.ISupportInitialize)npd_semestre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).BeginInit();
            cmsEstudiantes.SuspendLayout();
            bg_filtros.SuspendLayout();
            gb_herramientas.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_control_estudiante
            // 
            lbl_control_estudiante.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lbl_control_estudiante.BackColor = Color.Thistle;
            lbl_control_estudiante.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_control_estudiante.Location = new Point(3, 9);
            lbl_control_estudiante.Name = "lbl_control_estudiante";
            lbl_control_estudiante.Size = new Size(1265, 40);
            lbl_control_estudiante.TabIndex = 0;
            lbl_control_estudiante.Text = "Control Estudiantes";
            lbl_control_estudiante.TextAlign = ContentAlignment.TopCenter;
            lbl_control_estudiante.Click += label1_Click;
            // 
            // scEstudiantes
            // 
            scEstudiantes.Location = new Point(0, 52);
            scEstudiantes.Name = "scEstudiantes";
            // 
            // scEstudiantes.Panel1
            // 
            scEstudiantes.Panel1.Controls.Add(gb_alta);
            scEstudiantes.Panel1.Paint += splitContainer1_Panel1_Paint;
            // 
            // scEstudiantes.Panel2
            // 
            scEstudiantes.Panel2.Controls.Add(dgvEstudiantes);
            scEstudiantes.Panel2.Controls.Add(bg_filtros);
            scEstudiantes.Panel2.Controls.Add(gb_herramientas);
            scEstudiantes.Panel2.Paint += scEstudiantes_Panel2_Paint;
            scEstudiantes.Size = new Size(1268, 712);
            scEstudiantes.SplitterDistance = 359;
            scEstudiantes.TabIndex = 1;
            scEstudiantes.SplitterMoved += scEstudiantes_SplitterMoved;
            // 
            // gb_alta
            // 
            gb_alta.Controls.Add(cbox_estatus);
            gb_alta.Controls.Add(txt_nombre);
            gb_alta.Controls.Add(btn_guardar);
            gb_alta.Controls.Add(lbl_nombre_completo);
            gb_alta.Controls.Add(dtp_fecha_baja);
            gb_alta.Controls.Add(lbl_dt_obligatorios);
            gb_alta.Controls.Add(txt_telefono);
            gb_alta.Controls.Add(lbl_fecha_baja);
            gb_alta.Controls.Add(lbls_correo);
            gb_alta.Controls.Add(lbl_estatus);
            gb_alta.Controls.Add(lbl_telefono);
            gb_alta.Controls.Add(dtp_fecha_alta);
            gb_alta.Controls.Add(lbl_CURP);
            gb_alta.Controls.Add(txt_curp);
            gb_alta.Controls.Add(lbl_fecha_alta);
            gb_alta.Controls.Add(txt_correo);
            gb_alta.Controls.Add(pictore_question);
            gb_alta.Controls.Add(lbl_fecha_nac);
            gb_alta.Controls.Add(txt_num_control);
            gb_alta.Controls.Add(lbl_no_control);
            gb_alta.Controls.Add(lbl_semestre);
            gb_alta.Controls.Add(npd_semestre);
            gb_alta.Controls.Add(dtp_fecha_nacimiento);
            gb_alta.Location = new Point(3, 3);
            gb_alta.Name = "gb_alta";
            gb_alta.Size = new Size(353, 696);
            gb_alta.TabIndex = 24;
            gb_alta.TabStop = false;
            gb_alta.Text = "Alta o edicion";
            gb_alta.Enter += groupBox2_Enter;
            // 
            // cbox_estatus
            // 
            cbox_estatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_estatus.FormattingEnabled = true;
            cbox_estatus.Location = new Point(10, 546);
            cbox_estatus.Name = "cbox_estatus";
            cbox_estatus.Size = new Size(329, 33);
            cbox_estatus.TabIndex = 23;
            cbox_estatus.SelectedIndexChanged += cbox_estatus_SelectedIndexChanged;
            // 
            // txt_nombre
            // 
            txt_nombre.Location = new Point(6, 72);
            txt_nombre.MaxLength = 255;
            txt_nombre.Name = "txt_nombre";
            txt_nombre.Size = new Size(334, 31);
            txt_nombre.TabIndex = 5;
            // 
            // btn_guardar
            // 
            btn_guardar.Image = (Image)resources.GetObject("btn_guardar.Image");
            btn_guardar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_guardar.Location = new Point(225, 649);
            btn_guardar.Name = "btn_guardar";
            btn_guardar.Size = new Size(112, 34);
            btn_guardar.TabIndex = 22;
            btn_guardar.Text = "guardar";
            btn_guardar.UseVisualStyleBackColor = true;
            btn_guardar.Click += btn_guardar_Click;
            // 
            // lbl_nombre_completo
            // 
            lbl_nombre_completo.AutoSize = true;
            lbl_nombre_completo.Location = new Point(6, 44);
            lbl_nombre_completo.Name = "lbl_nombre_completo";
            lbl_nombre_completo.Size = new Size(164, 25);
            lbl_nombre_completo.TabIndex = 1;
            lbl_nombre_completo.Text = "nombre completo*";
            // 
            // dtp_fecha_baja
            // 
            dtp_fecha_baja.Format = DateTimePickerFormat.Short;
            dtp_fecha_baja.Location = new Point(5, 610);
            dtp_fecha_baja.Name = "dtp_fecha_baja";
            dtp_fecha_baja.Size = new Size(334, 31);
            dtp_fecha_baja.TabIndex = 21;
            // 
            // lbl_dt_obligatorios
            // 
            lbl_dt_obligatorios.AutoSize = true;
            lbl_dt_obligatorios.Location = new Point(17, 644);
            lbl_dt_obligatorios.Name = "lbl_dt_obligatorios";
            lbl_dt_obligatorios.Size = new Size(166, 25);
            lbl_dt_obligatorios.TabIndex = 20;
            lbl_dt_obligatorios.Text = "*datos obligatorios";
            // 
            // txt_telefono
            // 
            txt_telefono.Location = new Point(6, 202);
            txt_telefono.MaxLength = 15;
            txt_telefono.Name = "txt_telefono";
            txt_telefono.Size = new Size(335, 31);
            txt_telefono.TabIndex = 7;
            // 
            // lbl_fecha_baja
            // 
            lbl_fecha_baja.AutoSize = true;
            lbl_fecha_baja.Location = new Point(3, 582);
            lbl_fecha_baja.Name = "lbl_fecha_baja";
            lbl_fecha_baja.Size = new Size(92, 25);
            lbl_fecha_baja.TabIndex = 19;
            lbl_fecha_baja.Text = "fecha baja";
            // 
            // lbls_correo
            // 
            lbls_correo.AutoSize = true;
            lbls_correo.Location = new Point(6, 112);
            lbls_correo.Name = "lbls_correo";
            lbls_correo.Size = new Size(71, 25);
            lbls_correo.TabIndex = 2;
            lbls_correo.Text = "correo*";
            // 
            // lbl_estatus
            // 
            lbl_estatus.AutoSize = true;
            lbl_estatus.Location = new Point(5, 520);
            lbl_estatus.Name = "lbl_estatus";
            lbl_estatus.Size = new Size(76, 25);
            lbl_estatus.TabIndex = 18;
            lbl_estatus.Text = "estatus*";
            // 
            // lbl_telefono
            // 
            lbl_telefono.AutoSize = true;
            lbl_telefono.Location = new Point(5, 174);
            lbl_telefono.Name = "lbl_telefono";
            lbl_telefono.Size = new Size(86, 25);
            lbl_telefono.TabIndex = 3;
            lbl_telefono.Text = "telefono*";
            // 
            // dtp_fecha_alta
            // 
            dtp_fecha_alta.Format = DateTimePickerFormat.Short;
            dtp_fecha_alta.Location = new Point(5, 477);
            dtp_fecha_alta.Name = "dtp_fecha_alta";
            dtp_fecha_alta.Size = new Size(332, 31);
            dtp_fecha_alta.TabIndex = 17;
            // 
            // lbl_CURP
            // 
            lbl_CURP.AutoSize = true;
            lbl_CURP.Location = new Point(6, 236);
            lbl_CURP.Name = "lbl_CURP";
            lbl_CURP.Size = new Size(64, 25);
            lbl_CURP.TabIndex = 4;
            lbl_CURP.Text = "CURP*";
            // 
            // txt_curp
            // 
            txt_curp.Location = new Point(5, 264);
            txt_curp.MaxLength = 20;
            txt_curp.Name = "txt_curp";
            txt_curp.Size = new Size(334, 31);
            txt_curp.TabIndex = 6;
            // 
            // lbl_fecha_alta
            // 
            lbl_fecha_alta.AutoSize = true;
            lbl_fecha_alta.Location = new Point(6, 454);
            lbl_fecha_alta.Name = "lbl_fecha_alta";
            lbl_fecha_alta.Size = new Size(95, 25);
            lbl_fecha_alta.TabIndex = 16;
            lbl_fecha_alta.Text = "fecha alta*";
            // 
            // txt_correo
            // 
            txt_correo.Location = new Point(6, 140);
            txt_correo.MaxLength = 100;
            txt_correo.Name = "txt_correo";
            txt_correo.Size = new Size(334, 31);
            txt_correo.TabIndex = 8;
            // 
            // pictore_question
            // 
            pictore_question.Image = (Image)resources.GetObject("pictore_question.Image");
            pictore_question.Location = new Point(283, 406);
            pictore_question.Name = "pictore_question";
            pictore_question.Size = new Size(43, 34);
            pictore_question.SizeMode = PictureBoxSizeMode.StretchImage;
            pictore_question.TabIndex = 15;
            pictore_question.TabStop = false;
            toolTip_nu_control.SetToolTip(pictore_question, "T/M-Año de ingreso-Numero de alumno");
            // 
            // lbl_fecha_nac
            // 
            lbl_fecha_nac.AutoSize = true;
            lbl_fecha_nac.Location = new Point(6, 301);
            lbl_fecha_nac.Name = "lbl_fecha_nac";
            lbl_fecha_nac.Size = new Size(154, 25);
            lbl_fecha_nac.TabIndex = 10;
            lbl_fecha_nac.Text = "fecha nacimiento*";
            // 
            // txt_num_control
            // 
            txt_num_control.Location = new Point(6, 409);
            txt_num_control.MaxLength = 15;
            txt_num_control.Name = "txt_num_control";
            txt_num_control.Size = new Size(250, 31);
            txt_num_control.TabIndex = 14;
            txt_num_control.Text = "T-2024-123";
            txt_num_control.TextChanged += txt_num_control_TextChanged;
            // 
            // lbl_no_control
            // 
            lbl_no_control.AutoSize = true;
            lbl_no_control.Location = new Point(6, 381);
            lbl_no_control.Name = "lbl_no_control";
            lbl_no_control.Size = new Size(168, 25);
            lbl_no_control.TabIndex = 13;
            lbl_no_control.Text = "numero de control*";
            // 
            // lbl_semestre
            // 
            lbl_semestre.AutoSize = true;
            lbl_semestre.Location = new Point(192, 301);
            lbl_semestre.Name = "lbl_semestre";
            lbl_semestre.Size = new Size(91, 25);
            lbl_semestre.TabIndex = 12;
            lbl_semestre.Text = "semestre*";
            // 
            // npd_semestre
            // 
            npd_semestre.Location = new Point(192, 335);
            npd_semestre.Maximum = new decimal(new int[] { 13, 0, 0, 0 });
            npd_semestre.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            npd_semestre.Name = "npd_semestre";
            npd_semestre.Size = new Size(108, 31);
            npd_semestre.TabIndex = 11;
            npd_semestre.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // dtp_fecha_nacimiento
            // 
            dtp_fecha_nacimiento.Format = DateTimePickerFormat.Short;
            dtp_fecha_nacimiento.Location = new Point(6, 335);
            dtp_fecha_nacimiento.Name = "dtp_fecha_nacimiento";
            dtp_fecha_nacimiento.Size = new Size(154, 31);
            dtp_fecha_nacimiento.TabIndex = 9;
            // 
            // dgvEstudiantes
            // 
            dgvEstudiantes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEstudiantes.ContextMenuStrip = cmsEstudiantes;
            dgvEstudiantes.Location = new Point(15, 239);
            dgvEstudiantes.Name = "dgvEstudiantes";
            dgvEstudiantes.RowHeadersWidth = 62;
            dgvEstudiantes.Size = new Size(876, 433);
            dgvEstudiantes.TabIndex = 3;
            dgvEstudiantes.CellContentClick += dgvEstudiantes_CellContentClick;
            dgvEstudiantes.CellMouseClick += dgvEstudiantes_CellMouseClick;
            // 
            // cmsEstudiantes
            // 
            cmsEstudiantes.ImageScalingSize = new Size(24, 24);
            cmsEstudiantes.Items.AddRange(new ToolStripItem[] { editarEstuidanteToolStripMenuItem });
            cmsEstudiantes.Name = "contextMenuStrip1";
            cmsEstudiantes.Size = new Size(217, 36);
            cmsEstudiantes.Opening += cmsEstudiantes_Opening;
            // 
            // editarEstuidanteToolStripMenuItem
            // 
            editarEstuidanteToolStripMenuItem.Name = "editarEstuidanteToolStripMenuItem";
            editarEstuidanteToolStripMenuItem.Size = new Size(216, 32);
            editarEstuidanteToolStripMenuItem.Text = "editar estuidante";
            editarEstuidanteToolStripMenuItem.Click += editarEstuidanteToolStripMenuItem_Click;
            // 
            // bg_filtros
            // 
            bg_filtros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            bg_filtros.Controls.Add(lbl_totalReg);
            bg_filtros.Controls.Add(chSoloActivos);
            bg_filtros.Controls.Add(cbox_tipoFecha);
            bg_filtros.Controls.Add(dtp_fin);
            bg_filtros.Controls.Add(dtp_inicio);
            bg_filtros.Controls.Add(txt_busqueda);
            bg_filtros.Controls.Add(lbl_fecha_fin);
            bg_filtros.Controls.Add(lbl_fecha_inic);
            bg_filtros.Controls.Add(lbl_busqueda);
            bg_filtros.Controls.Add(lbl_tipo_fecha);
            bg_filtros.Controls.Add(btn_actualizar);
            bg_filtros.Location = new Point(9, 78);
            bg_filtros.Name = "bg_filtros";
            bg_filtros.Size = new Size(893, 136);
            bg_filtros.TabIndex = 1;
            bg_filtros.TabStop = false;
            bg_filtros.Text = "filtros";
            // 
            // lbl_totalReg
            // 
            lbl_totalReg.AutoSize = true;
            lbl_totalReg.Location = new Point(26, 99);
            lbl_totalReg.Name = "lbl_totalReg";
            lbl_totalReg.Size = new Size(22, 25);
            lbl_totalReg.TabIndex = 10;
            lbl_totalReg.Text = "0";
            // 
            // cbox_tipoFecha
            // 
            cbox_tipoFecha.DropDownStyle = ComboBoxStyle.DropDownList;
            cbox_tipoFecha.FormattingEnabled = true;
            cbox_tipoFecha.Location = new Point(103, 16);
            cbox_tipoFecha.Name = "cbox_tipoFecha";
            cbox_tipoFecha.Size = new Size(182, 33);
            cbox_tipoFecha.TabIndex = 9;
            cbox_tipoFecha.SelectedIndexChanged += cbox_tipoFecha_SelectedIndexChanged;
            // 
            // dtp_fin
            // 
            dtp_fin.Format = DateTimePickerFormat.Short;
            dtp_fin.Location = new Point(672, 21);
            dtp_fin.Name = "dtp_fin";
            dtp_fin.Size = new Size(156, 31);
            dtp_fin.TabIndex = 7;
            // 
            // dtp_inicio
            // 
            dtp_inicio.Format = DateTimePickerFormat.Short;
            dtp_inicio.Location = new Point(420, 22);
            dtp_inicio.Name = "dtp_inicio";
            dtp_inicio.Size = new Size(153, 31);
            dtp_inicio.TabIndex = 6;
            // 
            // txt_busqueda
            // 
            txt_busqueda.Location = new Point(181, 59);
            txt_busqueda.Name = "txt_busqueda";
            txt_busqueda.Size = new Size(349, 31);
            txt_busqueda.TabIndex = 5;
            // 
            // lbl_fecha_fin
            // 
            lbl_fecha_fin.AutoSize = true;
            lbl_fecha_fin.Location = new Point(575, 22);
            lbl_fecha_fin.Name = "lbl_fecha_fin";
            lbl_fecha_fin.Size = new Size(82, 25);
            lbl_fecha_fin.TabIndex = 4;
            lbl_fecha_fin.Text = "Fecha fin";
            // 
            // lbl_fecha_inic
            // 
            lbl_fecha_inic.AutoSize = true;
            lbl_fecha_inic.Location = new Point(314, 24);
            lbl_fecha_inic.Name = "lbl_fecha_inic";
            lbl_fecha_inic.Size = new Size(100, 25);
            lbl_fecha_inic.TabIndex = 3;
            lbl_fecha_inic.Text = "fecha inicio";
            // 
            // lbl_busqueda
            // 
            lbl_busqueda.AutoSize = true;
            lbl_busqueda.Location = new Point(6, 55);
            lbl_busqueda.Name = "lbl_busqueda";
            lbl_busqueda.Size = new Size(169, 25);
            lbl_busqueda.TabIndex = 2;
            lbl_busqueda.Text = "busqueda por texto";
            // 
            // lbl_tipo_fecha
            // 
            lbl_tipo_fecha.AutoSize = true;
            lbl_tipo_fecha.Location = new Point(6, 28);
            lbl_tipo_fecha.Name = "lbl_tipo_fecha";
            lbl_tipo_fecha.Size = new Size(91, 25);
            lbl_tipo_fecha.TabIndex = 1;
            lbl_tipo_fecha.Text = "tipo fecha";
            // 
            // btn_actualizar
            // 
            btn_actualizar.Image = (Image)resources.GetObject("btn_actualizar.Image");
            btn_actualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_actualizar.Location = new Point(575, 56);
            btn_actualizar.Name = "btn_actualizar";
            btn_actualizar.Size = new Size(140, 34);
            btn_actualizar.TabIndex = 0;
            btn_actualizar.Text = "Actualizar";
            btn_actualizar.UseVisualStyleBackColor = true;
            btn_actualizar.Click += btn_actualizar_Click_1;
            // 
            // gb_herramientas
            // 
            gb_herramientas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gb_herramientas.Controls.Add(btn_exc);
            gb_herramientas.Controls.Add(lbl_ruta);
            gb_herramientas.Controls.Add(btn_carga);
            gb_herramientas.Controls.Add(btn_mostrarCap);
            gb_herramientas.Location = new Point(9, 3);
            gb_herramientas.Name = "gb_herramientas";
            gb_herramientas.Size = new Size(893, 69);
            gb_herramientas.TabIndex = 0;
            gb_herramientas.TabStop = false;
            gb_herramientas.Text = "herramientas";
            // 
            // btn_exc
            // 
            btn_exc.Location = new Point(653, 24);
            btn_exc.Name = "btn_exc";
            btn_exc.Size = new Size(157, 30);
            btn_exc.TabIndex = 12;
            btn_exc.Text = "Guardar Excel";
            btn_exc.UseVisualStyleBackColor = true;
            btn_exc.Click += btn_exc_Click;
            // 
            // chSoloActivos
            // 
            chSoloActivos.AutoSize = true;
            chSoloActivos.Location = new Point(734, 85);
            chSoloActivos.Name = "chSoloActivos";
            chSoloActivos.Size = new Size(132, 29);
            chSoloActivos.TabIndex = 11;
            chSoloActivos.Text = "solo activos";
            chSoloActivos.UseVisualStyleBackColor = true;
            // 
            // lbl_ruta
            // 
            lbl_ruta.AutoSize = true;
            lbl_ruta.Location = new Point(350, 27);
            lbl_ruta.Name = "lbl_ruta";
            lbl_ruta.Size = new Size(223, 25);
            lbl_ruta.TabIndex = 2;
            lbl_ruta.Text = "Ruta de archivo a importar";
            // 
            // btn_carga
            // 
            btn_carga.Location = new Point(191, 26);
            btn_carga.Name = "btn_carga";
            btn_carga.Size = new Size(153, 34);
            btn_carga.TabIndex = 1;
            btn_carga.Text = "Carga masiva";
            btn_carga.UseVisualStyleBackColor = true;
            btn_carga.Click += btn_carga_Click;
            // 
            // btn_mostrarCap
            // 
            btn_mostrarCap.Location = new Point(6, 26);
            btn_mostrarCap.Name = "btn_mostrarCap";
            btn_mostrarCap.Size = new Size(168, 34);
            btn_mostrarCap.TabIndex = 0;
            btn_mostrarCap.Text = "Mostrar captura";
            btn_mostrarCap.UseVisualStyleBackColor = true;
            btn_mostrarCap.Click += btn_mostrarCap_Click;
            // 
            // toolTip_nu_control
            // 
            toolTip_nu_control.Popup += toolTip_nu_control_Popup;
            // 
            // ofdArchivo
            // 
            ofdArchivo.FileName = "Carga masiva de estudiantes";
            // 
            // frmEstudiantes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 763);
            Controls.Add(scEstudiantes);
            Controls.Add(lbl_control_estudiante);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmEstudiantes";
            Text = "frmEstudiantes";
            Load += frmEstudiantes_Load;
            scEstudiantes.Panel1.ResumeLayout(false);
            scEstudiantes.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)scEstudiantes).EndInit();
            scEstudiantes.ResumeLayout(false);
            gb_alta.ResumeLayout(false);
            gb_alta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictore_question).EndInit();
            ((System.ComponentModel.ISupportInitialize)npd_semestre).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvEstudiantes).EndInit();
            cmsEstudiantes.ResumeLayout(false);
            bg_filtros.ResumeLayout(false);
            bg_filtros.PerformLayout();
            gb_herramientas.ResumeLayout(false);
            gb_herramientas.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lbl_control_estudiante;
        private SplitContainer scEstudiantes;
        private TextBox txt_nombre;
        private Label lbl_CURP;
        private Label lbl_telefono;
        private Label lbls_correo;
        private Label lbl_nombre_completo;
        private TextBox txt_correo;
        private TextBox txt_telefono;
        private TextBox txt_curp;
        private Label lbl_fecha_nac;
        private DateTimePicker dtp_fecha_nacimiento;
        private Label lbl_semestre;
        private NumericUpDown npd_semestre;
        private PictureBox pictore_question;
        private TextBox txt_num_control;
        private Label lbl_no_control;
        private DateTimePicker dtp_fecha_alta;
        private Label lbl_fecha_alta;
        private ToolTip toolTip_nu_control;
        private Label lbl_fecha_baja;
        private Label lbl_estatus;
        private ComboBox cbox_estatus;
        private Button btn_guardar;
        private DateTimePicker dtp_fecha_baja;
        private Label lbl_dt_obligatorios;
        private GroupBox gb_alta;
        private GroupBox gb_herramientas;
        private GroupBox bg_filtros;
        private Label lbl_fecha_fin;
        private Label lbl_fecha_inic;
        private Label lbl_busqueda;
        private Label lbl_tipo_fecha;
        private Button btn_actualizar;
        private Label lbl_ruta;
        private Button btn_carga;
        private Button btn_mostrarCap;
        private DateTimePicker dtp_inicio;
        private TextBox txt_busqueda;
        private DateTimePicker dtp_fin;
        private ComboBox cbox_tipoFecha;
        private OpenFileDialog ofdArchivo;
        private DataGridView dgvEstudiantes;
        private Label lbl_totalReg;
        private ContextMenuStrip cmsEstudiantes;
        private ToolStripMenuItem editarEstuidanteToolStripMenuItem;
        private CheckBox chSoloActivos;
        private Button btn_exc;
    }
}