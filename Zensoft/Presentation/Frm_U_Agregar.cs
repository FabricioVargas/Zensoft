using System;
using System.Data.Entity.Validation;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;


namespace Presentation
{
    public partial class Usuario : Form
    {
        Frm_MenuPrincipal frm_MenuPrincipal;
        MailValidation mailValidation; //Llama el metodo que tiene el correo
        LNUsuario lnUsuario;


        public Usuario(Frm_MenuPrincipal MenuP)
        {
            this.frm_MenuPrincipal = MenuP;
            InitializeComponent();
        }

        //Cuando se cierra la interfaz se hace visible el frame principal
        private void Frm_U_Agregar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm_MenuPrincipal.Visible = true;
        }


        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.frm_MenuPrincipal.Visible = true;
            this.Close();
        }

        //Metodo que recibe las contraseñas y las compara para ver si son iguales
        private bool ValidarClaves(String clave, String claveConfirmación)
        {
            return String.IsNullOrWhiteSpace(clave) == false && clave.Equals(claveConfirmación);
        }
        
        //Metodo para agregar a los radioButtom a controls
        private void InicializarRb()
        {
            //instancia del groupBox y de cada radio buttom
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbJefe = new System.Windows.Forms.RadioButton();
            this.RbOperativo = new System.Windows.Forms.RadioButton();
            this.RbSuperUsuario = new System.Windows.Forms.RadioButton();

            //Añado cada radioBottom al groupBox
            this.groupBox1.Controls.Add(RbJefe);
            this.groupBox1.Controls.Add(RbOperativo);
            this.groupBox1.Controls.Add(RbSuperUsuario);
            this.Controls.Add(groupBox1);

        }
       
        //metodo de agregar usuarios
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string hash;
            mailValidation = new MailValidation();
            try
            {
                if (!string.IsNullOrWhiteSpace(TbNombreUsuario.Text) && !string.IsNullOrWhiteSpace(TbClave.Text) && !string.IsNullOrWhiteSpace(TbConfirmarClave.Text)
                    && RbJefe.Checked == true || RbOperativo.Checked == true || RbSuperUsuario.Checked == true)
                {
                    if(mailValidation.IsValidEmail(TbCorreoElectronico.Text))
                    {
                        if (ValidarClaves(TbClave.Text, TbConfirmarClave.Text))
                        {
                            mailValidation = new MailValidation();
                            using (MD5 md5Hash = MD5.Create())
                            {
                                hash = GetMd5Hash(md5Hash, TbClave.Text);
                            }
                            Entidades.TblUsuario tblUsuario = new TblUsuario
                            {
                                nombreUsuario = TbNombreUsuario.Text,
                                idGrupo = RbSeleccionado(),
                                correoElectronico = TbCorreoElectronico.Text,
                                clave = hash
                            };
                            this.lnUsuario.RegistrarEmpleado(tblUsuario);

                            MessageBox.Show("Usuario registrado correctamente", "Proceso Aplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Limpiar();
                            Bloquear();
                            TbNombreUsuario.Enabled = true;
                            btnConsultar.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden", "Proceso Aplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Formato de correo incorrecto", "Proceso Aplicado",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }//Fin if

                else
                {
                    MessageBox.Show("Verifique todos los campos sean llenados con la información solicitada", "Proceso Aplicado",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        //metodo para revalar las contraseñas de clasve y validaciónClave
        private void CbMostrarContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if(CbMostrarContraseña.Checked==true)
            {
                if (TbClave.PasswordChar == '*' || TbConfirmarClave.PasswordChar == '*')
                {
                    TbClave.PasswordChar = '\0';
                    TbConfirmarClave.PasswordChar = '\0';
                }
            }
            else
            {
                TbClave.PasswordChar = '*';
                TbConfirmarClave.PasswordChar = '*';
            }
        }

        //metodo que me devuelve el radioButton
        private string RbSeleccionado ()
        {
            if (RbJefe.Checked)
            {
                return "1";
            }
            else if (RbOperativo.Checked)
            {
                return "2";
            }
            else
            {
                return "3";
            }
        }


        //Metodos de encriptación/Validación de contraseñas
        static string GetMd5Hash(MD5 md5Hash, string input)
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
        }

       //Boton de limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarModificar();
        }

        //Limpia todos los componentes de la interfazr
        private void Limpiar()
        {
            TbClave.Text = String.Empty;
            TbConfirmarClave.Text = String.Empty;
            TbCorreoElectronico.Text = String.Empty;
            TbNombreUsuario.Text = String.Empty;
            RbJefe.Checked = false;
            RbOperativo.Checked = false;
            RbSuperUsuario.Checked = false;
            CbMostrarContraseña.Checked = false;
        }

        private void LimpiarModificar()
        {
            TbClave.Text = String.Empty;
            TbConfirmarClave.Text = String.Empty;
            TbCorreoElectronico.Text = String.Empty;
            RbJefe.Checked = false;
            RbOperativo.Checked = false;
            RbSuperUsuario.Checked = false;
            CbMostrarContraseña.Checked = false;
        }

        //Metodo para desbloquear componentes
        private void DebloquearComponentes()
        {
            TbClave.Enabled = true;
            TbConfirmarClave.Enabled = true;
            TbCorreoElectronico.Enabled = true;
            TbNombreUsuario.Enabled = true;
            RbJefe.Enabled = true;
            RbOperativo.Enabled = true;
            RbSuperUsuario.Enabled = true;
            CbMostrarContraseña.Enabled = true;
            btnLimpiar.Enabled = true;
            btnRegistrar.Enabled = true;
        }

        //Metodo de bloquear
        private void Bloquear()
        {
            TbClave.Enabled = false;
            TbConfirmarClave.Enabled = false;
            TbCorreoElectronico.Enabled = false;
            TbNombreUsuario.Enabled = false;
            RbJefe.Enabled = false;
            RbOperativo.Enabled = false;
            RbSuperUsuario.Enabled = false;
            CbMostrarContraseña.Enabled = false;
            btnLimpiar.Enabled = false;
            btnRegistrar.Enabled = false;
        }

        //Boton de consultar
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            lnUsuario = new LNUsuario();
            try
            {
                if (!String.IsNullOrWhiteSpace(TbNombreUsuario.Text))
                {
                    
                    if (lnUsuario.ConsultarUsuario(this.TbNombreUsuario.Text))
                    {
                        MessageBox.Show("Este usuario ya se encuentra registrado", "Proceso Aplicado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        DebloquearComponentes();
                        btnConsultar.Enabled = false;
                        TbNombreUsuario.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese los datos que se le solicitan", "Proceso Aplicado",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    
    }
}
