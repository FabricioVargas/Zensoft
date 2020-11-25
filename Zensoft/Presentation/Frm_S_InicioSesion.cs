using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Frm_S : Form
    {
        bool inicioSesion=false;
        public string permiso, nombreUsuario;
        public Frm_S()
        {
            InitializeComponent();
        }

        private void LbRecuperarContrasena_Click(object sender, EventArgs e)
        {
            Frm_U_Modificar frm_U_Modificar = new Frm_U_Modificar();
            frm_U_Modificar.funcion = 1;
            frm_U_Modificar.ShowDialog();
            frm_U_Modificar.Dispose();
        }

        private void btnInicioSesion_Click(object sender, EventArgs e)
        {
            string hash = "";
            Frm_U_Modificar frm_U_Modificar = new Frm_U_Modificar();

            if (!string.IsNullOrWhiteSpace(tbNombreUsuario.Text)&&!string.IsNullOrWhiteSpace(tbContraseña.Text))
            {
                if (frm_U_Modificar.ConsultarUsuarioBloqueado(tbNombreUsuario.Text)==0)
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        hash = frm_U_Modificar.GetMd5Hash(md5Hash, tbContraseña.Text);

                        if (frm_U_Modificar.VerifyMd5Hash(frm_U_Modificar.DevolverContraseñaUsuario(tbNombreUsuario.Text), hash) == true)
                        {
                            inicioSesion = true;
                            this.permiso = frm_U_Modificar.tipoUsuario(tbNombreUsuario.Text);
                            this.nombreUsuario = tbNombreUsuario.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nombre de usuario y contraseña no coinciden", "Proceso Aplicado",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            tbContraseña.Text = "";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El usuario se encuentra bloqueado", "Proceso Aplicado",
                                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbContraseña.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Llenar todos los espacios con la información solicitada", "Proceso Aplicado",
                                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbContraseña.Text = "";
                tbNombreUsuario.Text = "";
            }
        }

        private void Frm_S_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!inicioSesion)
            {
                Application.Exit();
            }
           
        }
    }
}
