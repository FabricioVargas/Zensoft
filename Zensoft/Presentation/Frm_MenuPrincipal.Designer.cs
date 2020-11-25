namespace Presentation
{
    partial class Frm_MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MenuPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.perfilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.empleadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unidadOrganizativaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consumibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trámiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.préstamoDeActivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.préstamoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trasladosEntreUnidadOrganizativaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entregaConsumibleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_hora = new System.Windows.Forms.Label();
            this.lb_fecha = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.horafecha = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUsuarioLog = new System.Windows.Forms.Label();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.perfilesToolStripMenuItem,
            this.inventarioToolStripMenuItem,
            this.trámiteToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1089, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // perfilesToolStripMenuItem
            // 
            this.perfilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empleadoToolStripMenuItem,
            this.usuarioToolStripMenuItem,
            this.unidadOrganizativaToolStripMenuItem});
            this.perfilesToolStripMenuItem.Name = "perfilesToolStripMenuItem";
            this.perfilesToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.perfilesToolStripMenuItem.Text = "Perfiles";
            // 
            // empleadoToolStripMenuItem
            // 
            this.empleadoToolStripMenuItem.Name = "empleadoToolStripMenuItem";
            this.empleadoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.empleadoToolStripMenuItem.Tag = "";
            this.empleadoToolStripMenuItem.Text = "Empleado";
            this.empleadoToolStripMenuItem.Click += new System.EventHandler(this.empleadoToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuarioToolStripMenuItem,
            this.modificarUsuarioToolStripMenuItem,
            this.listaDeUsuariosToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // modificarUsuarioToolStripMenuItem
            // 
            this.modificarUsuarioToolStripMenuItem.Name = "modificarUsuarioToolStripMenuItem";
            this.modificarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.modificarUsuarioToolStripMenuItem.Text = "Modificar Usuario";
            this.modificarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.modificarUsuarioToolStripMenuItem_Click);
            // 
            // listaDeUsuariosToolStripMenuItem
            // 
            this.listaDeUsuariosToolStripMenuItem.Name = "listaDeUsuariosToolStripMenuItem";
            this.listaDeUsuariosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.listaDeUsuariosToolStripMenuItem.Text = "Lista de Usuarios";
            this.listaDeUsuariosToolStripMenuItem.Click += new System.EventHandler(this.listaDeUsuariosToolStripMenuItem_Click);
            // 
            // unidadOrganizativaToolStripMenuItem
            // 
            this.unidadOrganizativaToolStripMenuItem.Name = "unidadOrganizativaToolStripMenuItem";
            this.unidadOrganizativaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.unidadOrganizativaToolStripMenuItem.Text = "Unidad Organizativa";
            this.unidadOrganizativaToolStripMenuItem.Click += new System.EventHandler(this.unidadOrganizativaToolStripMenuItem_Click);
            // 
            // inventarioToolStripMenuItem
            // 
            this.inventarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.activoToolStripMenuItem,
            this.consumibleToolStripMenuItem});
            this.inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            this.inventarioToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // activoToolStripMenuItem
            // 
            this.activoToolStripMenuItem.Name = "activoToolStripMenuItem";
            this.activoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.activoToolStripMenuItem.Text = "Activo";
            this.activoToolStripMenuItem.Click += new System.EventHandler(this.activoToolStripMenuItem_Click);
            // 
            // consumibleToolStripMenuItem
            // 
            this.consumibleToolStripMenuItem.Name = "consumibleToolStripMenuItem";
            this.consumibleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.consumibleToolStripMenuItem.Text = "Consumible";
            this.consumibleToolStripMenuItem.Click += new System.EventHandler(this.consumibleToolStripMenuItem_Click);
            // 
            // trámiteToolStripMenuItem
            // 
            this.trámiteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.préstamoDeActivoToolStripMenuItem,
            this.entregaConsumibleToolStripMenuItem});
            this.trámiteToolStripMenuItem.Name = "trámiteToolStripMenuItem";
            this.trámiteToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.trámiteToolStripMenuItem.Text = "Trámite";
            // 
            // préstamoDeActivoToolStripMenuItem
            // 
            this.préstamoDeActivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.préstamoToolStripMenuItem,
            this.devoluciónToolStripMenuItem,
            this.trasladosEntreUnidadOrganizativaToolStripMenuItem});
            this.préstamoDeActivoToolStripMenuItem.Name = "préstamoDeActivoToolStripMenuItem";
            this.préstamoDeActivoToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.préstamoDeActivoToolStripMenuItem.Text = "Activo";
            // 
            // préstamoToolStripMenuItem
            // 
            this.préstamoToolStripMenuItem.Name = "préstamoToolStripMenuItem";
            this.préstamoToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.préstamoToolStripMenuItem.Text = "Préstamo";
            this.préstamoToolStripMenuItem.Click += new System.EventHandler(this.préstamoToolStripMenuItem_Click);
            // 
            // devoluciónToolStripMenuItem
            // 
            this.devoluciónToolStripMenuItem.Name = "devoluciónToolStripMenuItem";
            this.devoluciónToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.devoluciónToolStripMenuItem.Text = "Devolución";
            this.devoluciónToolStripMenuItem.Click += new System.EventHandler(this.devoluciónToolStripMenuItem_Click);
            // 
            // trasladosEntreUnidadOrganizativaToolStripMenuItem
            // 
            this.trasladosEntreUnidadOrganizativaToolStripMenuItem.Name = "trasladosEntreUnidadOrganizativaToolStripMenuItem";
            this.trasladosEntreUnidadOrganizativaToolStripMenuItem.Size = new System.Drawing.Size(273, 22);
            this.trasladosEntreUnidadOrganizativaToolStripMenuItem.Text = "Traslados entre Unidad Organizativa";
            this.trasladosEntreUnidadOrganizativaToolStripMenuItem.Click += new System.EventHandler(this.trasladosEntreUnidadOrganizativaToolStripMenuItem_Click);
            // 
            // entregaConsumibleToolStripMenuItem
            // 
            this.entregaConsumibleToolStripMenuItem.Name = "entregaConsumibleToolStripMenuItem";
            this.entregaConsumibleToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.entregaConsumibleToolStripMenuItem.Text = "Entrega Consumible";
            this.entregaConsumibleToolStripMenuItem.Click += new System.EventHandler(this.entregaConsumibleToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(481, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Menú Principal";
            // 
            // lb_hora
            // 
            this.lb_hora.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_hora.AutoSize = true;
            this.lb_hora.BackColor = System.Drawing.Color.Transparent;
            this.lb_hora.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hora.Location = new System.Drawing.Point(134, 205);
            this.lb_hora.Name = "lb_hora";
            this.lb_hora.Size = new System.Drawing.Size(138, 59);
            this.lb_hora.TabIndex = 3;
            this.lb_hora.Text = "Hora";
            // 
            // lb_fecha
            // 
            this.lb_fecha.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lb_fecha.AutoSize = true;
            this.lb_fecha.BackColor = System.Drawing.Color.Transparent;
            this.lb_fecha.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_fecha.Location = new System.Drawing.Point(139, 264);
            this.lb_fecha.Name = "lb_fecha";
            this.lb_fecha.Size = new System.Drawing.Size(82, 29);
            this.lb_fecha.TabIndex = 4;
            this.lb_fecha.Text = "Fecha";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1378, 356);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Usuario";
            // 
            // horafecha
            // 
            this.horafecha.Enabled = true;
            this.horafecha.Tick += new System.EventHandler(this.horafecha_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1347, 388);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 31);
            this.label1.TabIndex = 6;
            this.label1.Text = "Menú Principal";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(519, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Bienvenido";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(802, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Usuario:";
            // 
            // lblUsuarioLog
            // 
            this.lblUsuarioLog.AutoSize = true;
            this.lblUsuarioLog.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuarioLog.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioLog.Location = new System.Drawing.Point(1041, 179);
            this.lblUsuarioLog.Name = "lblUsuarioLog";
            this.lblUsuarioLog.Size = new System.Drawing.Size(0, 23);
            this.lblUsuarioLog.TabIndex = 9;
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // Frm_MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Presentation.Properties.Resources.Fondo_P2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1089, 450);
            this.Controls.Add(this.lblUsuarioLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lb_fecha);
            this.Controls.Add(this.lb_hora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Frm_MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZenSoft";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Frm_MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem empleadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unidadOrganizativaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consumibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem préstamoDeActivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem préstamoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devoluciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trasladosEntreUnidadOrganizativaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entregaConsumibleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perfilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trámiteToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_hora;
        private System.Windows.Forms.Label lb_fecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer horafecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblUsuarioLog;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
    }
}