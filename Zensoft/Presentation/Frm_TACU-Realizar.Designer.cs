namespace Presentation
{
    partial class Frm_TACU_Agregar
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
            this.dateTimeBox = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIdentificador = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtn_Consumible = new System.Windows.Forms.RadioButton();
            this.rbtn_Activo = new System.Windows.Forms.RadioButton();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this.lblCantidadDis = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbUSalida = new System.Windows.Forms.ComboBox();
            this.cbUDestino = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRealizar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.spCantidad = new System.Windows.Forms.NumericUpDown();
            this.lblCantidadDisponible = new System.Windows.Forms.Label();
            this.lblCantReq = new System.Windows.Forms.Label();
            this.btnAgregarD = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimeBox
            // 
            this.dateTimeBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimeBox.Font = new System.Drawing.Font("Noto Sans", 9.749999F);
            this.dateTimeBox.Location = new System.Drawing.Point(535, 56);
            this.dateTimeBox.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimeBox.Name = "dateTimeBox";
            this.dateTimeBox.Size = new System.Drawing.Size(261, 25);
            this.dateTimeBox.TabIndex = 101;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Noto Sans", 9.749999F);
            this.label8.Location = new System.Drawing.Point(454, 56);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 18);
            this.label8.TabIndex = 100;
            this.label8.Text = "Fecha:";
            // 
            // lblIdentificador
            // 
            this.lblIdentificador.AutoSize = true;
            this.lblIdentificador.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.lblIdentificador.Location = new System.Drawing.Point(28, 211);
            this.lblIdentificador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentificador.Name = "lblIdentificador";
            this.lblIdentificador.Size = new System.Drawing.Size(119, 26);
            this.lblIdentificador.TabIndex = 94;
            this.lblIdentificador.Text = "Patrimonio:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.label9.Location = new System.Drawing.Point(28, 98);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(305, 26);
            this.label9.TabIndex = 114;
            this.label9.Text = "Unidad Organizativa de destino:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.txtNombre.Location = new System.Drawing.Point(230, 252);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(156, 33);
            this.txtNombre.TabIndex = 117;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.label2.Location = new System.Drawing.Point(28, 255);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 116;
            this.label2.Text = "Nombre:";
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.AllowUserToOrderColumns = true;
            this.dgvDetalle.AllowUserToResizeColumns = false;
            this.dgvDetalle.AllowUserToResizeRows = false;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Location = new System.Drawing.Point(113, 389);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.Size = new System.Drawing.Size(568, 174);
            this.dgvDetalle.TabIndex = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.rbtn_Consumible);
            this.groupBox1.Controls.Add(this.rbtn_Activo);
            this.groupBox1.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.groupBox1.Location = new System.Drawing.Point(30, 135);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(662, 63);
            this.groupBox1.TabIndex = 122;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condición";
            // 
            // rbtn_Consumible
            // 
            this.rbtn_Consumible.AutoSize = true;
            this.rbtn_Consumible.Location = new System.Drawing.Point(382, 24);
            this.rbtn_Consumible.Name = "rbtn_Consumible";
            this.rbtn_Consumible.Size = new System.Drawing.Size(138, 30);
            this.rbtn_Consumible.TabIndex = 1;
            this.rbtn_Consumible.Text = "Consumible";
            this.rbtn_Consumible.UseVisualStyleBackColor = true;
            // 
            // rbtn_Activo
            // 
            this.rbtn_Activo.AutoSize = true;
            this.rbtn_Activo.Checked = true;
            this.rbtn_Activo.Location = new System.Drawing.Point(161, 24);
            this.rbtn_Activo.Name = "rbtn_Activo";
            this.rbtn_Activo.Size = new System.Drawing.Size(85, 30);
            this.rbtn_Activo.TabIndex = 0;
            this.rbtn_Activo.TabStop = true;
            this.rbtn_Activo.Text = "Activo";
            this.rbtn_Activo.UseVisualStyleBackColor = true;
            this.rbtn_Activo.CheckedChanged += new System.EventHandler(this.rbtn_Activo_CheckedChanged);
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.txtIdentificador.Location = new System.Drawing.Point(230, 208);
            this.txtIdentificador.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.Size = new System.Drawing.Size(274, 33);
            this.txtIdentificador.TabIndex = 112;
            // 
            // lblCantidadDis
            // 
            this.lblCantidadDis.AutoSize = true;
            this.lblCantidadDis.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.lblCantidadDis.Location = new System.Drawing.Point(28, 304);
            this.lblCantidadDis.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidadDis.Name = "lblCantidadDis";
            this.lblCantidadDis.Size = new System.Drawing.Size(199, 26);
            this.lblCantidadDis.TabIndex = 118;
            this.lblCantidadDis.Text = "Cantidad disponible:";
            this.lblCantidadDis.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.label5.Location = new System.Drawing.Point(28, 389);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 26);
            this.label5.TabIndex = 123;
            this.label5.Text = "Detalle:";
            // 
            // cbUSalida
            // 
            this.cbUSalida.FormattingEnabled = true;
            this.cbUSalida.Location = new System.Drawing.Point(339, 46);
            this.cbUSalida.Margin = new System.Windows.Forms.Padding(2);
            this.cbUSalida.Name = "cbUSalida";
            this.cbUSalida.Size = new System.Drawing.Size(353, 36);
            this.cbUSalida.TabIndex = 124;
            this.cbUSalida.SelectedIndexChanged += new System.EventHandler(this.cbUSalida_SelectedIndexChanged);
            this.cbUSalida.Click += new System.EventHandler(this.cbUSalida_Click);
            // 
            // cbUDestino
            // 
            this.cbUDestino.FormattingEnabled = true;
            this.cbUDestino.Location = new System.Drawing.Point(339, 95);
            this.cbUDestino.Margin = new System.Windows.Forms.Padding(2);
            this.cbUDestino.Name = "cbUDestino";
            this.cbUDestino.Size = new System.Drawing.Size(353, 36);
            this.cbUDestino.TabIndex = 126;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.label6.Location = new System.Drawing.Point(28, 49);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(290, 26);
            this.label6.TabIndex = 125;
            this.label6.Text = "Unidad Organizativa de salida:";
            // 
            // btnRealizar
            // 
            this.btnRealizar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRealizar.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnRealizar.Enabled = false;
            this.btnRealizar.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.btnRealizar.ForeColor = System.Drawing.Color.White;
            this.btnRealizar.Location = new System.Drawing.Point(182, 673);
            this.btnRealizar.Name = "btnRealizar";
            this.btnRealizar.Size = new System.Drawing.Size(118, 46);
            this.btnRealizar.TabIndex = 129;
            this.btnRealizar.Text = "Realizar";
            this.btnRealizar.UseVisualStyleBackColor = false;
            this.btnRealizar.Click += new System.EventHandler(this.btnRealizar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRegresar.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnRegresar.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(443, 673);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(116, 46);
            this.btnRegresar.TabIndex = 128;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLimpiar.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnLimpiar.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(315, 673);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(118, 46);
            this.btnLimpiar.TabIndex = 127;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.spCantidad);
            this.groupBox2.Controls.Add(this.lblCantidadDisponible);
            this.groupBox2.Controls.Add(this.lblCantReq);
            this.groupBox2.Controls.Add(this.btnAgregarD);
            this.groupBox2.Controls.Add(this.btnConsultar);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.lblIdentificador);
            this.groupBox2.Controls.Add(this.txtIdentificador);
            this.groupBox2.Controls.Add(this.cbUDestino);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbUSalida);
            this.groupBox2.Controls.Add(this.txtNombre);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.lblCantidadDis);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.dgvDetalle);
            this.groupBox2.Font = new System.Drawing.Font("Noto Sans", 15.75F, System.Drawing.FontStyle.Italic);
            this.groupBox2.Location = new System.Drawing.Point(69, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 568);
            this.groupBox2.TabIndex = 130;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Traslado de Activos y Consumibles";
            // 
            // spCantidad
            // 
            this.spCantidad.Enabled = false;
            this.spCantidad.Location = new System.Drawing.Point(568, 302);
            this.spCantidad.Margin = new System.Windows.Forms.Padding(2);
            this.spCantidad.Name = "spCantidad";
            this.spCantidad.ReadOnly = true;
            this.spCantidad.Size = new System.Drawing.Size(90, 36);
            this.spCantidad.TabIndex = 131;
            this.spCantidad.Visible = false;
            this.spCantidad.ValueChanged += new System.EventHandler(this.spCantidad_ValueChanged);
            this.spCantidad.Click += new System.EventHandler(this.spCantidad_Click);
            // 
            // lblCantidadDisponible
            // 
            this.lblCantidadDisponible.AutoSize = true;
            this.lblCantidadDisponible.Location = new System.Drawing.Point(241, 302);
            this.lblCantidadDisponible.Name = "lblCantidadDisponible";
            this.lblCantidadDisponible.Size = new System.Drawing.Size(0, 28);
            this.lblCantidadDisponible.TabIndex = 130;
            this.lblCantidadDisponible.Visible = false;
            // 
            // lblCantReq
            // 
            this.lblCantReq.AutoSize = true;
            this.lblCantReq.Location = new System.Drawing.Point(369, 302);
            this.lblCantReq.Name = "lblCantReq";
            this.lblCantReq.Size = new System.Drawing.Size(195, 28);
            this.lblCantReq.TabIndex = 129;
            this.lblCantReq.Text = "Cantidad requerida:";
            this.lblCantReq.Visible = false;
            // 
            // btnAgregarD
            // 
            this.btnAgregarD.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarD.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnAgregarD.Enabled = false;
            this.btnAgregarD.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.btnAgregarD.ForeColor = System.Drawing.Color.White;
            this.btnAgregarD.Location = new System.Drawing.Point(113, 344);
            this.btnAgregarD.Name = "btnAgregarD";
            this.btnAgregarD.Size = new System.Drawing.Size(195, 40);
            this.btnAgregarD.TabIndex = 128;
            this.btnAgregarD.Text = "Agregar a detalle";
            this.btnAgregarD.UseVisualStyleBackColor = false;
            this.btnAgregarD.Click += new System.EventHandler(this.btnAgregarD_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConsultar.BackColor = System.Drawing.Color.DarkKhaki;
            this.btnConsultar.Font = new System.Drawing.Font("Noto Sans", 14.25F);
            this.btnConsultar.ForeColor = System.Drawing.Color.White;
            this.btnConsultar.Location = new System.Drawing.Point(554, 200);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(112, 39);
            this.btnConsultar.TabIndex = 127;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = false;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // Frm_TACU_Agregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentation.Properties.Resources.Fondo_A1;
            this.ClientSize = new System.Drawing.Size(872, 749);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.dateTimeBox);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRealizar);
            this.Controls.Add(this.label8);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_TACU_Agregar";
            this.Text = "Frm_TACU";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_TACU_Agregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimeBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIdentificador;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdentificador;
        private System.Windows.Forms.Label lblCantidadDis;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbUSalida;
        private System.Windows.Forms.ComboBox cbUDestino;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRealizar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtn_Consumible;
        private System.Windows.Forms.RadioButton rbtn_Activo;
        private System.Windows.Forms.Button btnAgregarD;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Label lblCantReq;
        private System.Windows.Forms.Label lblCantidadDisponible;
        private System.Windows.Forms.NumericUpDown spCantidad;
    }
}