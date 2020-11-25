using System;
using System.Windows.Forms;
using Zensoft;

namespace Presentation
{
    public partial class Frm_MenuPrincipal : Form
    {
        public static string nombreU;
        public Frm_MenuPrincipal()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEmpleados empleados = new FrmEmpleados();
            empleados.ShowDialog();
            empleados.Dispose();
        }

        private void unidadOrganizativaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_UO_Consultar2 un = new Frm_UO_Consultar2();
            un.ShowDialog();
            un.Dispose();
        }

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_A_Lista lista = new Frm_A_Lista();
            lista.ShowDialog();
            lista.Dispose();
        }

        private void consumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_C_Lista lista = new Frm_C_Lista();
            lista.ShowDialog();
            lista.Dispose();
        }

        private void préstamoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSolicitudActivos frmSolicitudActivos = new FrmSolicitudActivos();
            frmSolicitudActivos.ShowDialog();
            frmSolicitudActivos.Dispose();
        }

        private void devoluciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrestamosEmpleado frmPrestamosEmpleado = new FrmPrestamosEmpleado();
            frmPrestamosEmpleado.ShowDialog();
            frmPrestamosEmpleado.Dispose();
        }

        private void trasladosEntreUnidadOrganizativaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_TACU_Agregar frmTacu = new Frm_TACU_Agregar();
            frmTacu.ShowDialog();
            frmTacu.Dispose();
        }

        private void entregaConsumibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_GEC_Lista lista = new Frm_GEC_Lista();
            lista.ShowDialog();
            lista.Dispose();
        }

        private void agregarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuario frm_U_Agregar = new Usuario(this);
            frm_U_Agregar.ShowDialog();
            frm_U_Agregar.Dispose();
        }

        private void modificarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_U_Modificar frm_U_Modificar = new Frm_U_Modificar();
            frm_U_Modificar.ShowDialog();
            frm_U_Modificar.Dispose();
        }

        private void listaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_U_Consultar2 frm_U_Consultar2 = new Frm_U_Consultar2();
            frm_U_Consultar2.ShowDialog();
            frm_U_Consultar2.Dispose();
        }

        private void Frm_MenuPrincipal_Load(object sender, EventArgs e)
        {
            Frm_S frm_S = new Frm_S();
            Frm_U_Modificar frm_U_Modificar = new Frm_U_Modificar();
            frm_S.ShowDialog();
            frm_S.Dispose();
            nombreU = frm_S.nombreUsuario;
            lblUsuarioLog.Text = frm_S.nombreUsuario;
            this.BloquearEspacios(frm_S.permiso);
        }

        public void BloquearEspacios(string tipo)
        {
            if (tipo == "2")
            {
                perfilesToolStripMenuItem.Visible = false;
                inventarioToolStripMenuItem.Visible = false;
            }
            else if (tipo == "3")
            { 
                //Geovanon
            }
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lb_hora.Text = DateTime.Now.ToLongTimeString();
            lb_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblUsuarioLog.Text = "";
            Frm_S frm_S = new Frm_S();
            Frm_U_Modificar frm_U_Modificar = new Frm_U_Modificar();
            frm_S.ShowDialog();
            frm_S.Dispose();
            nombreU = frm_S.nombreUsuario;
            lblUsuarioLog.Text = frm_S.nombreUsuario;
            this.BloquearEspacios(frm_S.permiso);
        }
    }
}
