namespace Presentation
{
    partial class Frm_U_Modificar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_U_Modificar));
            this.btnVolverAlMenu = new System.Windows.Forms.Button();
            this.btnDeshabilitar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.tbNombreUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNuevaContraseña = new System.Windows.Forms.TextBox();
            this.tbConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.cbMostrarContraseña = new System.Windows.Forms.CheckBox();
            this.groupmMBox1 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupmMBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnVolverAlMenu
            // 
            this.btnVolverAlMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnVolverAlMenu.BackColor = System.Drawing.Color.Indigo;
            this.btnVolverAlMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnVolverAlMenu.ForeColor = System.Drawing.Color.White;
            this.btnVolverAlMenu.Location = new System.Drawing.Point(506, 367);
            this.btnVolverAlMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolverAlMenu.Name = "btnVolverAlMenu";
            this.btnVolverAlMenu.Size = new System.Drawing.Size(122, 36);
            this.btnVolverAlMenu.TabIndex = 95;
            this.btnVolverAlMenu.Text = "Regresar";
            this.btnVolverAlMenu.UseVisualStyleBackColor = false;
            this.btnVolverAlMenu.Click += new System.EventHandler(this.btnVolverAlMenu_Click);
            // 
            // btnDeshabilitar
            // 
            this.btnDeshabilitar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeshabilitar.BackColor = System.Drawing.Color.Indigo;
            this.btnDeshabilitar.Enabled = false;
            this.btnDeshabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnDeshabilitar.ForeColor = System.Drawing.Color.White;
            this.btnDeshabilitar.Location = new System.Drawing.Point(339, 367);
            this.btnDeshabilitar.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeshabilitar.Name = "btnDeshabilitar";
            this.btnDeshabilitar.Size = new System.Drawing.Size(122, 36);
            this.btnDeshabilitar.TabIndex = 93;
            this.btnDeshabilitar.Text = "Deshabilitar";
            this.btnDeshabilitar.UseVisualStyleBackColor = false;
            this.btnDeshabilitar.Click += new System.EventHandler(this.btnDeshabilitar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnModificar.BackColor = System.Drawing.Color.Indigo;
            this.btnModificar.Enabled = false;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(177, 367);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(96, 36);
            this.btnModificar.TabIndex = 92;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(28, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(194, 24);
            this.label3.TabIndex = 87;
            this.label3.Text = "Confirmar contraseña:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(28, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 24);
            this.label2.TabIndex = 85;
            this.label2.Text = "Nueva contraseña:";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsultar.BackColor = System.Drawing.Color.Indigo;
            this.btnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(492, 72);
            this.btnConsultar.Margin = new System.Windows.Forms.Padding(2);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(105, 31);
            this.btnConsultar.TabIndex = 84;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // tbNombreUsuario
            // 
            this.tbNombreUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNombreUsuario.Location = new System.Drawing.Point(222, 72);
            this.tbNombreUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.tbNombreUsuario.Name = "tbNombreUsuario";
            this.tbNombreUsuario.Size = new System.Drawing.Size(244, 29);
            this.tbNombreUsuario.TabIndex = 82;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(28, 68);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 24);
            this.label6.TabIndex = 81;
            this.label6.Text = "Nombre de usuario:";
            // 
            // tbNuevaContraseña
            // 
            this.tbNuevaContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbNuevaContraseña.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbNuevaContraseña.Enabled = false;
            this.tbNuevaContraseña.Location = new System.Drawing.Point(222, 116);
            this.tbNuevaContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.tbNuevaContraseña.Name = "tbNuevaContraseña";
            this.tbNuevaContraseña.PasswordChar = '*';
            this.tbNuevaContraseña.Size = new System.Drawing.Size(244, 29);
            this.tbNuevaContraseña.TabIndex = 96;
            // 
            // tbConfirmarContraseña
            // 
            this.tbConfirmarContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tbConfirmarContraseña.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbConfirmarContraseña.Enabled = false;
            this.tbConfirmarContraseña.Location = new System.Drawing.Point(222, 160);
            this.tbConfirmarContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.tbConfirmarContraseña.Name = "tbConfirmarContraseña";
            this.tbConfirmarContraseña.PasswordChar = '*';
            this.tbConfirmarContraseña.Size = new System.Drawing.Size(244, 29);
            this.tbConfirmarContraseña.TabIndex = 97;
            // 
            // cbMostrarContraseña
            // 
            this.cbMostrarContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbMostrarContraseña.AutoSize = true;
            this.cbMostrarContraseña.BackColor = System.Drawing.Color.Transparent;
            this.cbMostrarContraseña.Enabled = false;
            this.cbMostrarContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.cbMostrarContraseña.Location = new System.Drawing.Point(254, 205);
            this.cbMostrarContraseña.Name = "cbMostrarContraseña";
            this.cbMostrarContraseña.Size = new System.Drawing.Size(201, 28);
            this.cbMostrarContraseña.TabIndex = 102;
            this.cbMostrarContraseña.Text = "Mostrar Contraseñas";
            this.cbMostrarContraseña.UseVisualStyleBackColor = false;
            this.cbMostrarContraseña.CheckedChanged += new System.EventHandler(this.cbMostrarContraseña_CheckedChanged);
            // 
            // groupmMBox1
            // 
            this.groupmMBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupmMBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupmMBox1.Controls.Add(this.label6);
            this.groupmMBox1.Controls.Add(this.cbMostrarContraseña);
            this.groupmMBox1.Controls.Add(this.tbNombreUsuario);
            this.groupmMBox1.Controls.Add(this.tbConfirmarContraseña);
            this.groupmMBox1.Controls.Add(this.btnConsultar);
            this.groupmMBox1.Controls.Add(this.label2);
            this.groupmMBox1.Controls.Add(this.tbNuevaContraseña);
            this.groupmMBox1.Controls.Add(this.label3);
            this.groupmMBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupmMBox1.Location = new System.Drawing.Point(145, 67);
            this.groupmMBox1.Name = "groupmMBox1";
            this.groupmMBox1.Size = new System.Drawing.Size(614, 251);
            this.groupmMBox1.TabIndex = 103;
            this.groupmMBox1.TabStop = false;
            this.groupmMBox1.Text = "Modificar Usuario";
            // 
            // Frm_U_Modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.BackgroundImage = global::Presentation.Properties.Resources.Fondo_M2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(890, 494);
            this.Controls.Add(this.groupmMBox1);
            this.Controls.Add(this.btnVolverAlMenu);
            this.Controls.Add(this.btnDeshabilitar);
            this.Controls.Add(this.btnModificar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_U_Modificar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificar Usuario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_U_Modificar_Load);
            this.groupmMBox1.ResumeLayout(false);
            this.groupmMBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVolverAlMenu;
        private System.Windows.Forms.Button btnDeshabilitar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.TextBox tbNombreUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNuevaContraseña;
        private System.Windows.Forms.TextBox tbConfirmarContraseña;
        private System.Windows.Forms.CheckBox cbMostrarContraseña;
        private System.Windows.Forms.GroupBox groupmMBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}