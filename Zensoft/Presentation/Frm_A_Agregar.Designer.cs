namespace Presentation
{
    partial class Frm_A_Agregar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_A_Agregar));
            this.tb_modelo = new System.Windows.Forms.TextBox();
            this.tb_marca = new System.Windows.Forms.TextBox();
            this.gb_disponibilidad = new System.Windows.Forms.GroupBox();
            this.rbtn_libre = new System.Windows.Forms.RadioButton();
            this.rbtn_prestado = new System.Windows.Forms.RadioButton();
            this.gb_estado = new System.Windows.Forms.GroupBox();
            this.rbtn_bueno = new System.Windows.Forms.RadioButton();
            this.rbtn_dañado = new System.Windows.Forms.RadioButton();
            this.rbtn_perdido = new System.Windows.Forms.RadioButton();
            this.tb_numeroSerie = new System.Windows.Forms.TextBox();
            this.tb_patrimonio = new System.Windows.Forms.TextBox();
            this.tb_nombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_Descripcion = new System.Windows.Forms.TextBox();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.btn_Regresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.gb_disponibilidad.SuspendLayout();
            this.gb_estado.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_modelo
            // 
            this.tb_modelo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tb_modelo.Location = new System.Drawing.Point(126, 186);
            this.tb_modelo.Margin = new System.Windows.Forms.Padding(2);
            this.tb_modelo.Name = "tb_modelo";
            this.tb_modelo.Size = new System.Drawing.Size(416, 29);
            this.tb_modelo.TabIndex = 68;
            // 
            // tb_marca
            // 
            this.tb_marca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tb_marca.Location = new System.Drawing.Point(126, 138);
            this.tb_marca.Margin = new System.Windows.Forms.Padding(2);
            this.tb_marca.Name = "tb_marca";
            this.tb_marca.Size = new System.Drawing.Size(416, 29);
            this.tb_marca.TabIndex = 67;
            // 
            // gb_disponibilidad
            // 
            this.gb_disponibilidad.BackColor = System.Drawing.Color.Transparent;
            this.gb_disponibilidad.Controls.Add(this.rbtn_libre);
            this.gb_disponibilidad.Controls.Add(this.rbtn_prestado);
            this.gb_disponibilidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gb_disponibilidad.Location = new System.Drawing.Point(27, 454);
            this.gb_disponibilidad.Margin = new System.Windows.Forms.Padding(2);
            this.gb_disponibilidad.Name = "gb_disponibilidad";
            this.gb_disponibilidad.Padding = new System.Windows.Forms.Padding(2);
            this.gb_disponibilidad.Size = new System.Drawing.Size(473, 51);
            this.gb_disponibilidad.TabIndex = 66;
            this.gb_disponibilidad.TabStop = false;
            this.gb_disponibilidad.Text = "Disponibilidad";
            // 
            // rbtn_libre
            // 
            this.rbtn_libre.AutoSize = true;
            this.rbtn_libre.Checked = true;
            this.rbtn_libre.Location = new System.Drawing.Point(148, 17);
            this.rbtn_libre.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_libre.Name = "rbtn_libre";
            this.rbtn_libre.Size = new System.Drawing.Size(70, 28);
            this.rbtn_libre.TabIndex = 33;
            this.rbtn_libre.TabStop = true;
            this.rbtn_libre.Text = "Libre";
            this.rbtn_libre.UseVisualStyleBackColor = true;
            // 
            // rbtn_prestado
            // 
            this.rbtn_prestado.AutoSize = true;
            this.rbtn_prestado.Location = new System.Drawing.Point(287, 17);
            this.rbtn_prestado.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_prestado.Name = "rbtn_prestado";
            this.rbtn_prestado.Size = new System.Drawing.Size(102, 28);
            this.rbtn_prestado.TabIndex = 32;
            this.rbtn_prestado.Text = "Prestado";
            this.rbtn_prestado.UseVisualStyleBackColor = true;
            // 
            // gb_estado
            // 
            this.gb_estado.BackColor = System.Drawing.Color.Transparent;
            this.gb_estado.Controls.Add(this.rbtn_bueno);
            this.gb_estado.Controls.Add(this.rbtn_dañado);
            this.gb_estado.Controls.Add(this.rbtn_perdido);
            this.gb_estado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.gb_estado.Location = new System.Drawing.Point(27, 391);
            this.gb_estado.Margin = new System.Windows.Forms.Padding(2);
            this.gb_estado.Name = "gb_estado";
            this.gb_estado.Padding = new System.Windows.Forms.Padding(2);
            this.gb_estado.Size = new System.Drawing.Size(473, 49);
            this.gb_estado.TabIndex = 65;
            this.gb_estado.TabStop = false;
            this.gb_estado.Text = "Estado";
            // 
            // rbtn_bueno
            // 
            this.rbtn_bueno.AutoSize = true;
            this.rbtn_bueno.Checked = true;
            this.rbtn_bueno.Location = new System.Drawing.Point(91, 17);
            this.rbtn_bueno.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_bueno.Name = "rbtn_bueno";
            this.rbtn_bueno.Size = new System.Drawing.Size(84, 28);
            this.rbtn_bueno.TabIndex = 23;
            this.rbtn_bueno.TabStop = true;
            this.rbtn_bueno.Text = "Bueno";
            this.rbtn_bueno.UseVisualStyleBackColor = true;
            // 
            // rbtn_dañado
            // 
            this.rbtn_dañado.AutoSize = true;
            this.rbtn_dañado.Location = new System.Drawing.Point(188, 17);
            this.rbtn_dañado.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_dañado.Name = "rbtn_dañado";
            this.rbtn_dañado.Size = new System.Drawing.Size(94, 28);
            this.rbtn_dañado.TabIndex = 24;
            this.rbtn_dañado.Text = "Dañado";
            this.rbtn_dañado.UseVisualStyleBackColor = true;
            // 
            // rbtn_perdido
            // 
            this.rbtn_perdido.AutoSize = true;
            this.rbtn_perdido.Location = new System.Drawing.Point(308, 17);
            this.rbtn_perdido.Margin = new System.Windows.Forms.Padding(2);
            this.rbtn_perdido.Name = "rbtn_perdido";
            this.rbtn_perdido.Size = new System.Drawing.Size(94, 28);
            this.rbtn_perdido.TabIndex = 31;
            this.rbtn_perdido.Text = "Perdido";
            this.rbtn_perdido.UseVisualStyleBackColor = true;
            // 
            // tb_numeroSerie
            // 
            this.tb_numeroSerie.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tb_numeroSerie.Location = new System.Drawing.Point(197, 231);
            this.tb_numeroSerie.Margin = new System.Windows.Forms.Padding(2);
            this.tb_numeroSerie.Name = "tb_numeroSerie";
            this.tb_numeroSerie.Size = new System.Drawing.Size(345, 29);
            this.tb_numeroSerie.TabIndex = 59;
            // 
            // tb_patrimonio
            // 
            this.tb_patrimonio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tb_patrimonio.Location = new System.Drawing.Point(136, 44);
            this.tb_patrimonio.Margin = new System.Windows.Forms.Padding(2);
            this.tb_patrimonio.Name = "tb_patrimonio";
            this.tb_patrimonio.Size = new System.Drawing.Size(303, 29);
            this.tb_patrimonio.TabIndex = 58;
            // 
            // tb_nombre
            // 
            this.tb_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tb_nombre.Location = new System.Drawing.Point(126, 93);
            this.tb_nombre.Margin = new System.Windows.Forms.Padding(2);
            this.tb_nombre.Name = "tb_nombre";
            this.tb_nombre.Size = new System.Drawing.Size(416, 29);
            this.tb_nombre.TabIndex = 57;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label7.Location = new System.Drawing.Point(23, 234);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 24);
            this.label7.TabIndex = 52;
            this.label7.Text = "Número de Serie:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.Location = new System.Drawing.Point(23, 46);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 24);
            this.label6.TabIndex = 51;
            this.label6.Text = "Patrimonio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.Location = new System.Drawing.Point(23, 189);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 24);
            this.label5.TabIndex = 50;
            this.label5.Text = "Modelo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(23, 141);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 24);
            this.label4.TabIndex = 49;
            this.label4.Text = "Marca:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(23, 96);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 24);
            this.label3.TabIndex = 48;
            this.label3.Text = "Nombre:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_Descripcion);
            this.groupBox1.Controls.Add(this.btn_consultar);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tb_modelo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tb_marca);
            this.groupBox1.Controls.Add(this.tb_nombre);
            this.groupBox1.Controls.Add(this.gb_disponibilidad);
            this.groupBox1.Controls.Add(this.tb_patrimonio);
            this.groupBox1.Controls.Add(this.gb_estado);
            this.groupBox1.Controls.Add(this.tb_numeroSerie);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(78, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(617, 531);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Activo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(23, 292);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 24);
            this.label1.TabIndex = 76;
            this.label1.Text = "Descripción:";
            // 
            // tb_Descripcion
            // 
            this.tb_Descripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.tb_Descripcion.Location = new System.Drawing.Point(138, 289);
            this.tb_Descripcion.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Descripcion.Multiline = true;
            this.tb_Descripcion.Name = "tb_Descripcion";
            this.tb_Descripcion.Size = new System.Drawing.Size(404, 99);
            this.tb_Descripcion.TabIndex = 77;
            // 
            // btn_consultar
            // 
            this.btn_consultar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_consultar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_consultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_consultar.ForeColor = System.Drawing.Color.White;
            this.btn_consultar.Location = new System.Drawing.Point(445, 41);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(97, 35);
            this.btn_consultar.TabIndex = 75;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = false;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // btn_Regresar
            // 
            this.btn_Regresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Regresar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btn_Regresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btn_Regresar.ForeColor = System.Drawing.Color.White;
            this.btn_Regresar.Location = new System.Drawing.Point(440, 572);
            this.btn_Regresar.Name = "btn_Regresar";
            this.btn_Regresar.Size = new System.Drawing.Size(116, 46);
            this.btn_Regresar.TabIndex = 76;
            this.btn_Regresar.Text = "Regresar";
            this.btn_Regresar.UseVisualStyleBackColor = false;
            this.btn_Regresar.Click += new System.EventHandler(this.btn_Regresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnLimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(302, 572);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(118, 46);
            this.btnLimpiar.TabIndex = 75;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegistrar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnRegistrar.Enabled = false;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.btnRegistrar.ForeColor = System.Drawing.Color.White;
            this.btnRegistrar.Location = new System.Drawing.Point(164, 572);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(120, 46);
            this.btnRegistrar.TabIndex = 74;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // Frm_A_Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.BackgroundImage = global::Presentation.Properties.Resources.Fondo_C4;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(740, 609);
            this.Controls.Add(this.btn_Regresar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_A_Agregar";
            this.Text = "Agregar activos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gb_disponibilidad.ResumeLayout(false);
            this.gb_disponibilidad.PerformLayout();
            this.gb_estado.ResumeLayout(false);
            this.gb_estado.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tb_modelo;
        private System.Windows.Forms.TextBox tb_marca;
        private System.Windows.Forms.GroupBox gb_disponibilidad;
        private System.Windows.Forms.RadioButton rbtn_libre;
        private System.Windows.Forms.RadioButton rbtn_prestado;
        private System.Windows.Forms.GroupBox gb_estado;
        private System.Windows.Forms.RadioButton rbtn_bueno;
        private System.Windows.Forms.RadioButton rbtn_dañado;
        private System.Windows.Forms.RadioButton rbtn_perdido;
        private System.Windows.Forms.TextBox tb_numeroSerie;
        private System.Windows.Forms.TextBox tb_patrimonio;
        private System.Windows.Forms.TextBox tb_nombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Regresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_Descripcion;
    }
}