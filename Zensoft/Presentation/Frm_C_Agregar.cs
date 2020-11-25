using Entidades;
using LogicaNegocio;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Frm_C_Agregar : Form
    {
        Frm_C_Lista frm_C_Lista;
        private LNConsumible procesoCon;
        public int funcion;
        public string codigo;
        public Frm_C_Agregar(Frm_C_Lista frmLista)
        {
            this.frm_C_Lista = frmLista;
            InitializeComponent();
            llenarCbUnidad();
        }



        

        private void Frm_C_Agregar_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.frm_C_Lista.Visible = true;
        }

        //Registra un consumible
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(txtCodigo.Text))
            {
               if(!String.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    if(!String.IsNullOrWhiteSpace(txtMarca.Text))
                    {
                        if(!String.IsNullOrWhiteSpace(txtModelo.Text))
                        {
                            if(!String.IsNullOrWhiteSpace(txtNumeroSerie.Text))
                            {
                                if(!String.IsNullOrWhiteSpace(txtDescripcion.Text))
                                {
                                    if(!String.IsNullOrWhiteSpace(txtStock.Text))
                                    {
                                        TblConsumibles consumible = new TblConsumibles
                                        {
                                            nombre = this.txtNombre.Text,
                                            marca = this.txtMarca.Text,
                                            modelo = this.txtModelo.Text,
                                            codigo = this.txtCodigo.Text,
                                            numeroSerie = this.txtNumeroSerie.Text,
                                            descripción = this.txtDescripcion.Text,
                                            stock = Convert.ToInt32(this.txtStock.Text),
                                            unidadMedida = this.cbUnidadMedida.Text

                                        };

                                        if (funcion == 0)
                                        {
                                            LNConsumible.AgregarConsunible(consumible);
                                            MessageBox.Show("Consumible registrado correctamente", "Proceso aplicado",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            limpiar();
                                            
                                        }
                                        else if (funcion == 1)
                                        {
                                            LNConsumible.ModificarConsumible(consumible);
                                            MessageBox.Show("Consumible modificar correctamente", "Proceso aplicado",
                                                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            limpiar();
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Ingrese una cantidad para stock ¡Por favor!", "Proceso aplicado",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ingrese una descripción ¡Por favor!", "Proceso aplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Ingrese un numero de serie ¡Por favor!", "Proceso aplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ingrese un modelo ¡Por favor!", "Proceso aplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese marca ¡Por favor!", "Proceso aplicado",
                             MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
               else
                {
                    MessageBox.Show("Ingrese un nombre ¡Por favor!", "Proceso aplicado",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un código ¡Por favor!", "Proceso aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNumeroSerie.Text = "";
            txtDescripcion.Text = "";
            txtStock.Text = "";

            txtCodigo.Enabled = true;
            txtNombre.Enabled = false;
            txtMarca.Enabled = false;
            txtModelo.Enabled = false;
            txtNumeroSerie.Enabled = false;
            txtDescripcion.Enabled = false;
            txtStock.Enabled = false;

        }

        private void llenarCbUnidad()
        {
            cbUnidadMedida.Items.Insert(0, "m");
            cbUnidadMedida.Items.Insert(1, "Kg");
            cbUnidadMedida.Items.Insert(2, "L");
        }

        //Se consulta por codigo para veificar la existencia de un consumible
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                procesoCon = new LNConsumible();
                if(procesoCon.ConsultarConsumible(this.txtCodigo.Text))
                {
                    MessageBox.Show("El consumible ya se encuentra registrado", "Proceso aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtCodigo.Text = "";
                }
                else
                {
                    txtNombre.Enabled = true;
                    txtMarca.Enabled = true;
                    txtModelo.Enabled = true;
                    txtNumeroSerie.Enabled = true;
                    txtDescripcion.Enabled = true;
                    txtStock.Enabled = true;
                    cbUnidadMedida.Enabled = true;
                    btnRegistrar.Enabled = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            frm_C_Lista.Visible = true;
            this.Close();
        }

        private void Frm_C_Agregar_Load(object sender, EventArgs e)
        {
            if(this.funcion == 1)
            {
                this.btnRegistrar.Text = "&Modificar";
                this.llenarDatos();
                this.habilitarModificar();
                this.groupBox1.Text = "Modificar consumible";
            }
        }

        private void habilitarModificar()
        {
            this.txtCodigo.Enabled = false;
            this.btnConsultar.Enabled = false;
            this.txtNombre.Enabled = true;
            this.txtMarca.Enabled = true;
            this.txtModelo.Enabled = true;
            this.txtNumeroSerie.Enabled = true;
            this.txtDescripcion.Enabled = true;
            this.txtStock.Enabled = true;
            this.cbUnidadMedida.Enabled = true;
            this.btnRegistrar.Enabled = true;
        }

        private void llenarDatos()
        {
            this.procesoCon = new LNConsumible();
            //se obtiene  los datos del consumible
            TblConsumibles consumible = this.procesoCon.getConsumible(this.codigo);

            //Se llenan los campos respectivos con la informacion del consumible
            this.txtCodigo.Text = consumible.codigo;
            this.txtNombre.Text = consumible.nombre;
            this.txtMarca.Text = consumible.marca;
            this.txtModelo.Text = consumible.modelo;
            this.txtNumeroSerie.Text = consumible.numeroSerie;
            this.txtDescripcion.Text = consumible.descripción;
            this.txtStock.Text = consumible.stock.ToString();
            this.cbUnidadMedida.Text = consumible.unidadMedida;

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
{
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && !(char.IsWhiteSpace(e.KeyChar)))
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
