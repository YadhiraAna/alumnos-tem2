namespace alumnos_tem2.View
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            btn_inicio = new Button();
            btn_cerrar = new Button();
            lbl_usuario = new Label();
            lbl_password = new Label();
            txt_usuario = new TextBox();
            txt_password = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_inicio
            // 
            btn_inicio.Image = (Image)resources.GetObject("btn_inicio.Image");
            btn_inicio.ImageAlign = ContentAlignment.MiddleLeft;
            btn_inicio.Location = new Point(162, 180);
            btn_inicio.Name = "btn_inicio";
            btn_inicio.Size = new Size(215, 34);
            btn_inicio.TabIndex = 0;
            btn_inicio.Text = "iniciar sesion";
            btn_inicio.UseVisualStyleBackColor = true;
            btn_inicio.Click += btn_inicio_Click;
            // 
            // btn_cerrar
            // 
            btn_cerrar.Image = (Image)resources.GetObject("btn_cerrar.Image");
            btn_cerrar.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cerrar.Location = new Point(454, 189);
            btn_cerrar.Name = "btn_cerrar";
            btn_cerrar.Size = new Size(112, 34);
            btn_cerrar.TabIndex = 1;
            btn_cerrar.Text = "cerrar";
            btn_cerrar.UseVisualStyleBackColor = true;
            btn_cerrar.Click += btn_cerrar_Click;
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.Location = new Point(224, 59);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(70, 25);
            lbl_usuario.TabIndex = 2;
            lbl_usuario.Text = "usuario";
            // 
            // lbl_password
            // 
            lbl_password.AutoSize = true;
            lbl_password.Location = new Point(215, 102);
            lbl_password.Name = "lbl_password";
            lbl_password.Size = new Size(89, 25);
            lbl_password.TabIndex = 3;
            lbl_password.Text = "password";
            // 
            // txt_usuario
            // 
            txt_usuario.Location = new Point(324, 56);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(150, 31);
            txt_usuario.TabIndex = 4;
            txt_usuario.TextChanged += txt_usuario_TextChanged;
            // 
            // txt_password
            // 
            txt_password.Location = new Point(324, 102);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(150, 31);
            txt_password.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(59, 52);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 75);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(txt_password);
            Controls.Add(txt_usuario);
            Controls.Add(lbl_password);
            Controls.Add(lbl_usuario);
            Controls.Add(btn_cerrar);
            Controls.Add(btn_inicio);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            Text = "frmLogin";
            Load += frmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_inicio;
        private Button btn_cerrar;
        private Label lbl_usuario;
        private Label lbl_password;
        private TextBox txt_usuario;
        private TextBox txt_password;
        private PictureBox pictureBox1;
    }
}