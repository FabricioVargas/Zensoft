using System;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using LogicaNegocio;
using System.Net.Mail;
using System.Net;
namespace Presentation
{
    public partial class Frm_U_Modificar : Form
    {
        LNUsuario lnUsuario;
        Random random = new Random();
        public int funcion;
        public Frm_U_Modificar()
        {
            InitializeComponent();
        }


        //metodo de consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            lnUsuario = new LNUsuario();
            try
            {
                if (!string.IsNullOrWhiteSpace(tbNombreUsuario.Text))
                {
                    if (lnUsuario.ConsultarUsuario(tbNombreUsuario.Text))
                    {
                        if (lnUsuario.ConsultarUsuarioBloqueado(tbNombreUsuario.Text) == 1)
                        {
                            MessageBox.Show("Usuario Bloqueado", "Proceso Aplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbNombreUsuario.Text = "";
                        }
                        else
                        {
                            tbNuevaContraseña.Enabled = true;
                            tbConfirmarContraseña.Enabled = true;
                            btnConsultar.Enabled = false;
                            tbNombreUsuario.Enabled = false;
                            cbMostrarContraseña.Enabled = true;
                            btnDeshabilitar.Enabled = true;
                            btnModificar.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no registrado", "Proceso Aplicado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbNombreUsuario.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Por favor ingrese los datos correctos para la validación", "Proceso Aplicado",
                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //metodo consultar empleadoBloqueado
        public int ConsultarUsuarioBloqueado(string nombreUsuario)
        {
            lnUsuario = new LNUsuario();
            return lnUsuario.ConsultarUsuarioBloqueado(nombreUsuario);
        }

        //metodo para revelar contraseñas
        private void cbMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (cbMostrarContraseña.Checked)
            {
                if(tbNuevaContraseña.PasswordChar == '*' || tbConfirmarContraseña.PasswordChar == '*')
                {
                    tbConfirmarContraseña.PasswordChar = '\0';
                    tbNuevaContraseña.PasswordChar = '\0';
                }
            }
            else
            {
                tbConfirmarContraseña.PasswordChar = '*';
                tbNuevaContraseña.PasswordChar = '*';
            }
        }

        //Metodo que recibe las contraseñas y las compara para ver si son iguales
        private bool ValidarClaves(String clave, String claveConfirmación)
        {
            return String.IsNullOrWhiteSpace(clave) == false && clave.Equals(claveConfirmación);
        }

        //Metodos para modificar
        public void btnModificar_Click(object sender, EventArgs e)
        {
            modificarUsuario();
        }

        //metodo para modificar
        public void modificarUsuario()
        {
            string hash;
            string correoValidar;
            if (!string.IsNullOrWhiteSpace(tbNombreUsuario.Text) && !string.IsNullOrWhiteSpace(tbNuevaContraseña.Text)
                && !string.IsNullOrWhiteSpace(tbConfirmarContraseña.Text))
            {
                if (ValidarClaves(tbNuevaContraseña.Text, tbConfirmarContraseña.Text))
                {
                    using (MD5 md5Hash = MD5.Create())
                    {
                        hash = GetMd5Hash(md5Hash, tbNuevaContraseña.Text);

                        if (VerifyMd5Hash(DevolverContraseñaUsuario(tbNombreUsuario.Text), hash) == true)
                        {
                            MessageBox.Show("La contraseña utilizada ya ha sido registrada, por favor cree una nueva", "Proceso Aplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tbNuevaContraseña.Text = "";
                            tbConfirmarContraseña.Text = "";
                        }
                        else
                        {
                            correoValidar = GenerarCodigo();
                            enviarVerificacion(ExtraerCorreo(tbNombreUsuario.Text), correoValidar, tbNombreUsuario.Text);
                            Frm_U_Verificación verificacion = new Frm_U_Verificación(correoValidar, this);
                            verificacion.ShowDialog();
                            verificacion.Dispose();
                            if (verificacion.cerrar == false)
                            {
                                if (lnUsuario.ModificarContraseña(tbNombreUsuario.Text, hash))
                                {
                                    MessageBox.Show("El usuario ha sido modificado correctamente", "Proceso Aplicado",
                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LimpiaeDesbloquear();
                                }
                                correoValidar = "";
                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Proceso Aplicado",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Debe llenar todos los espacios solicitados", "Proceso Aplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Metodo que encripta las contraseñas
        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }//Cambio de static a public ver

        // Verificaión de contraseñas
        public bool VerifyMd5Hash(string input, string hash)
        {

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(input, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }//Cambio de static a public ver

        //Metodo de devolver contraseña de usuario
        public string DevolverContraseñaUsuario(string nombreUsuario)
        {
            return lnUsuario.DevolverContraseñaUsuario(nombreUsuario);
        }

        //metodo para crear el código de verificacion

        private string GenerarCodigo()
        {
            string codigo = "";
            string resultado = "";
            for (int i = 0; i < 5; i++)
            {
                codigo = Convert.ToString(random.Next(1, 9));
                resultado += codigo.ToString();
            }
            return resultado;
        }

        private void btnVolverAlMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //metodo para enviar por correo
        public void enviarVerificacion(string correoUsuario, string claveVerificación, string nombreUsuario)
        {
            try
            {
                //instancia un objeto MailMessage
                MailMessage email = new MailMessage();

                //email.To.Add es para quien va dirigido
                email.To.Add(new MailAddress(correoUsuario));
                email.From = new MailAddress("zensoft@gmail.com");//Correo de salida
                email.Subject = "Código de verificación";//asunto del correo
                email.SubjectEncoding = Encoding.UTF8;//le damos formato UTF8

                email.Body = "<b>Cambio de contraseña solicitada por el usuario: "+ nombreUsuario +" </b><br>" + " </b><br>" +
                    "<b>Código de verificación: </b> "+ claveVerificación +" </b><br>" + " </b><br>" +
                    "<b>Por favor ingrese el código de verificación en el programa Zensoft para asegurarnos que el usuario "+ nombreUsuario +" ha solicitado un cambio en la contraseña.";
                email.BodyEncoding = Encoding.UTF8;//le damos formato UTF8
                email.IsBodyHtml = true;//cuerpo del mensaje en html           
                //email.Attachments.Add();
                email.Priority = MailPriority.Normal;

                SmtpClient smtp = new SmtpClient();//Cliente correo
                smtp.Host = "smtp.gmail.com";// "smtp.office365.com"
                smtp.Port = 587;//Puerto de gmail (solo ese)
                smtp.EnableSsl = true;//Seguridad
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("zensoftpacifico@gmail.com", "zensoft2020");//Credenciales del correo que envía mensajes

                //metodo para enviar el correo
                smtp.Send(email);//envía por correo
                email.Dispose();//libera memoria
                smtp.Dispose();//libera memoria
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }//end

        //metodo de extraer el correo del usuario
        private string ExtraerCorreo(string nombreUsuario)
        {
            lnUsuario = new LNUsuario();
            return lnUsuario.ExtraerCorreo(nombreUsuario);

        }

        //metodo de limpiar y Deabloquear
        public void LimpiaeDesbloquear()
        {
            tbNombreUsuario.Enabled = true;
            btnConsultar.Enabled = true;
            tbNuevaContraseña.Enabled = false;
            tbConfirmarContraseña.Enabled = false;
            cbMostrarContraseña.Enabled = false;
            btnDeshabilitar.Enabled = false;
            btnModificar.Enabled = false;

            tbNombreUsuario.Text = String.Empty;
            tbNuevaContraseña.Text = String.Empty;
            tbConfirmarContraseña.Text = String.Empty;
            cbMostrarContraseña.Checked = false;
        }

        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {
            if(lnUsuario.BloquearUsuario(tbNombreUsuario.Text))
            {
                MessageBox.Show("Usuario bloqueado correctamente", "Proceso Aplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiaeDesbloquear();
            }
        }

        private void Frm_U_Modificar_Load(object sender, EventArgs e)
        {
            if (funcion==1)
            {
                groupmMBox1.Text = "Modificar Contraseña de Usuario";
                btnDeshabilitar.Visible = false;
                //btnModificar.Location = new System.Drawing.Point(75, 293);//(75, 293)
            }
            else
            {
                groupmMBox1.Text = "Modificar Usuario";
                btnDeshabilitar.Visible = true;
            }
            funcion = 0;
        }

        //metodo que devuelve el tipo de usuario
        public string tipoUsuario(string nombreUsuario)
        {
            return lnUsuario.TipoUsuario(nombreUsuario);
        }
    }
}
