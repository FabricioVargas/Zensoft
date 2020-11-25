using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Frm_U_Verificación : Form
    {
        Frm_U_Modificar frm_U_Modificar;
        public bool cerrar = false;
        string contrasenaGenerada = "";
        public bool compatible = false;
        public Frm_U_Verificación(string contrasena, Frm_U_Modificar modificar)
        {
            contrasenaGenerada = contrasena;
            this.frm_U_Modificar = modificar;
            InitializeComponent();
        }

        //retrocede a modificar
        private void btnRetroceder_Click(object sender, EventArgs e)
        {
            cerrar = true;
            this.Close();
        }

        private void btnMenuPrincipal_Click(object sender, EventArgs e)
        {
            cerrar = true;
            this.Close();
            this.frm_U_Modificar.Close();

        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
           
            if (!string.IsNullOrWhiteSpace(tbVerificacion.Text))
            {
                if (contrasenaGenerada.Equals(tbVerificacion.Text))
                {
                    compatible = true;
                    MessageBox.Show("Verificacion aceptada", "Proceso Aplicado",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña digitada no coincide con la enviada a su correo electrónico", "Proceso Aplicado",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                compatible = false;
            }
            else
            {
                MessageBox.Show("No dejar espacios en blanco", "Proceso Aplicado",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
