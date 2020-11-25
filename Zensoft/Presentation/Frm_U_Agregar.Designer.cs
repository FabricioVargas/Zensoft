namespace Presentation
{
    partial class Usuario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Usuario));
            this.label3 = new System.Windows.Forms.Label();
            this.RbSuperUsuario = new System.Windows.Forms.RadioButton();
            this.RbJefe = new System.Windows.Forms.RadioButton();
            this.RbOperativo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.TbNombreUsuario = new System.Windows.Forms.TextBox();
            this.TbCorreoElectronico = new System.Windows.Forms.TextBox();
            this.TbClave = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TbConfirmarClave = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.CbMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(23, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre de usuario";
            // 
            // RbSuperUsuario
            // 
            this.RbSuperUsuario.AutoSize = true;
            this.RbSuperUsuario.Checked = true;
            this.RbSuperUsuario.Enabled = false;
            this.RbSuperUsuario.Location = new System.Drawing.Point(76, 25);
            this.RbSuperUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.RbSuperUsuario.Name = "RbSuperUsuario";
            this.RbSuperUsuario.Size = new System.Drawing.Size(147, 28);
            this.RbSuperUsuario.TabIndex = 3;
            this.RbSuperUsuario.TabStop = true;
            this.RbSuperUsuario.Text = "Super-usuario";
            this.RbSuperUsuario.UseVisualStyleBackColor = true;
            // 
            // RbJefe
            // 
            this.RbJefe.AutoSize = true;
            this.RbJefe.Enabled = false;
            this.RbJefe.Location = new System.Drawing.Point(275, 25);
            this.RbJefe.Margin = new System.Windows.Forms.Padding(2);
            this.RbJefe.Name = "RbJefe";
            this.RbJefe.Size = new System.Drawing.Size(63, 28);
            this.RbJefe.TabIndex = 4;
            this.RbJefe.Text = "Jefe";
            this.RbJefe.UseVisualStyleBackColor = true;
            // 
            // RbOperativo
            // 
            this.RbOperativo.AutoSize = true;
            this.RbOperativo.Enabled = false;
            this.RbOperativo.Location = new System.Drawing.Point(375, 25);
            this.RbOperativo.Margin = new System.Windows.Forms.Padding(2);
            this.RbOperativo.Name = "RbOperativo";
            this.RbOperativo.Size = new System.Drawing.Size(109, 28);
            this.RbOperativo.TabIndex = 5;
            this.RbOperativo.Text = "Operativo";
            this.RbOperativo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(31, 277);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(30, 331);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Confirmar Contraseña";
            // 
            // TbNombreUsuario
            // 
            this.TbNombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TbNombreUsuario.Location = new System.Drawing.Point(200, 62);
            this.TbNombreUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.TbNombreUsuario.MaxLength = 50;
            this.TbNombreUsuario.Name = "TbNombreUsuario";
            this.TbNombreUsuario.Size = new System.Drawing.Size(244, 29);
            this.TbNombreUsuario.TabIndex = 8;
            // 
            // TbCorreoElectronico
            // 
            this.TbCorreoElectronico.Enabled = false;
            this.TbCorreoElectronico.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TbCorreoElectronico.Location = new System.Drawing.Point(307, 216);
            this.TbCorreoElectronico.Margin = new System.Windows.Forms.Padding(2);
            this.TbCorreoElectronico.Name = "TbCorreoElectronico";
            this.TbCorreoElectronico.Size = new System.Drawing.Size(241, 29);
            this.TbCorreoElectronico.TabIndex = 9;
            // 
            // TbClave
            // 
            this.TbClave.Enabled = false;
            this.TbClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TbClave.Location = new System.Drawing.Point(307, 274);
            this.TbClave.Margin = new System.Windows.Forms.Padding(2);
            this.TbClave.Name = "TbClave";
            this.TbClave.PasswordChar = '*';
            this.TbClave.Size = new System.Drawing.Size(241, 29);
            this.TbClave.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(30, 219);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(168, 24);
            this.label6.TabIndex = 15;
            this.label6.Text = "Correo Electrónico";
            // 
            // TbConfirmarClave
            // 
            this.TbConfirmarClave.Enabled = false;
            this.TbConfirmarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.TbConfirmarClave.Location = new System.Drawing.Point(307, 328);
            this.TbConfirmarClave.Margin = new System.Windows.Forms.Padding(2);
            this.TbConfirmarClave.Name = "TbConfirmarClave";
            this.TbConfirmarClave.PasswordChar = '*';
            this.TbConfirmarClave.Size = new System.Drawing.Size(241, 29);
            this.TbConfirmarClave.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbSuperUsuario);
            this.groupBox1.Controls.Add(this.RbJefe);
            this.groupBox1.Controls.Add(this.RbOperativo);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(36, 114);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(516, 61);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grupo";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.btnConsultar);
            this.groupBox2.Controls.Add(this.CbMostrarContraseña);
            this.groupBox2.Controls.Add(this.TbClave);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TbConfirmarClave);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.TbNombreUsuario);
            this.groupBox2.Controls.Add(this.TbCorreoElectronico);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic);
            this.groupBox2.Location = new System.Drawing.Point(128, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(590, 455);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agregar Usuario";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsultar.BackColor = System.Drawing.Color.Indigo;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(449, 60);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(99, 35);
            this.btnConsultar.TabIndex = 21;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // CbMostrarContraseña
            // 
            this.CbMostrarContraseña.AutoSize = true;
            this.CbMostrarContraseña.Enabled = false;
            this.CbMostrarContraseña.Location = new System.Drawing.Point(216, 389);
            this.CbMostrarContraseña.Name = "CbMostrarContraseña";
            this.CbMostrarContraseña.Size = new System.Drawing.Size(232, 29);
            this.CbMostrarContraseña.TabIndex = 18;
            this.CbMostrarContraseña.Text = "Mostrar Contraseñas";
            this.CbMostrarContraseña.UseVisualStyleBackColor = true;
            this.CbMostrarContraseña.CheckedChanged += new System.EventHandler(this.CbMostrarContraseña_CheckedChanged);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegresar.BackColor = System.Drawing.Color.Indigo;
            this.btnRegresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(511, 562);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(116, 46);
            this.btnRegresar.TabIndex = 20;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.BackColor = System.Drawing.Color.Indigo;
            this.btnLimpiar.Enabled = false;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(373, 562);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(118, 46);
            this.btnLimpiar.TabIndex = 19;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistrar.BackColor = System.Drawing.Color.Indigo;
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(223, 562);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 46);
            this.btnRegistrar.TabIndex = 18;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentation.Properties.Resources.Fondo_M2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(892, 632);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Usuario";
            this.Text = "Agregar Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_U_Agregar_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton RbSuperUsuario;
        private System.Windows.Forms.RadioButton RbJefe;
        private System.Windows.Forms.RadioButton RbOperativo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbNombreUsuario;
        private System.Windows.Forms.TextBox TbCorreoElectronico;
        private System.Windows.Forms.TextBox TbClave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbConfirmarClave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.CheckBox CbMostrarContraseña;
        private System.Windows.Forms.Button btnConsultar;
    }
}