using Entidades;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Frm_A_Agregar : Form
    {
        public Frm_A_Agregar()
        {
            InitializeComponent();
            Limpiar();
        }

        public void Limpiar()
        {
            tb_patrimonio.Clear();
            tb_nombre.Clear();
            tb_marca.Clear();
            tb_modelo.Clear();
            tb_numeroSerie.Clear();
            tb_Descripcion.Clear();


            tb_patrimonio.Enabled = true;
            tb_nombre.Enabled = false;
            tb_marca.Enabled = false;
            tb_marca.Enabled = false;
            tb_modelo.Enabled = false;
            tb_numeroSerie.Enabled = false;
            tb_Descripcion.Enabled = false;
            gb_estado.Enabled = false;
            gb_disponibilidad.Enabled = false;

            rbtn_bueno.Checked = true;
            rbtn_libre.Checked = true;

            btn_consultar.Enabled = true;
            btn_consultar.Visible = true;
            btnRegistrar.Enabled = false;
            btnRegistrar.Text = "Registrar";
        }

        public TblActivos activo()
        {
            TblActivos activo = new TblActivos();
            activo.patrimonio = tb_patrimonio.Text;
            activo.nombre = tb_nombre.Text;
            activo.marca = tb_marca.Text;
            activo.modelo = tb_modelo.Text;
            activo.serie = tb_numeroSerie.Text;
            activo.descripcion = tb_Descripcion.Text;
            activo.estado = obtenerEstado();
            activo.disponibilidad = obtenerDisponibilidad();
            return activo;
        }

        public String obtenerEstado()
        {
            String estado = "";

            if( rbtn_bueno.Checked )
            {
                estado = rbtn_bueno.Text.Substring(0, 1);
            }
            else if (rbtn_dañado.Checked )
            {
                estado = "M";
            }
            else
            {
                estado = "X";
            }

            return estado;
        }

        internal void ModificarActivo(string patrimonio)
        {
            modoModificar(patrimonio); 

            TblActivos activo = LNActivo.consultarActivoPat(patrimonio);

            tb_nombre.Text = activo.nombre;
            tb_marca.Text = activo.marca;
            tb_modelo.Text = activo.modelo;
            tb_numeroSerie.Text = activo.serie;
            tb_Descripcion.Text = activo.descripcion;

            if (activo.estado.Equals("B"))
                rbtn_bueno.Checked = true;
            else if (activo.estado.Equals("M"))
                rbtn_dañado.Checked = true;
            else
                rbtn_perdido.Checked = true;

            if (activo.disponibilidad.Equals("D"))
                rbtn_libre.Checked = true;
            else
                rbtn_prestado.Checked = true;

        }

        private void modoModificar(string patrimonio)
        {
            tb_patrimonio.Enabled = false;
            tb_patrimonio.Text = patrimonio;
            btn_consultar.Enabled = false;

            tb_nombre.Enabled = true;
            tb_marca.Enabled = true;
            tb_marca.Enabled = true;
            tb_modelo.Enabled = true;
            tb_numeroSerie.Enabled = true;
            tb_Descripcion.Enabled = true;
            gb_disponibilidad.Enabled = true;
            gb_estado.Enabled = true;

            btnRegistrar.Enabled = true;
            btnRegistrar.Text = "Modificar";
        }

        public String obtenerDisponibilidad()
        {
            String disponibilidad = "";

            if ( rbtn_libre.Checked )
            {
                disponibilidad = "D";
            }
            else
            {
                disponibilidad = rbtn_prestado.Text.Substring(0, 1);
            }

            return disponibilidad;
        }
        

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if(btnRegistrar.Text == "Registrar")
            {
                if (!String.IsNullOrWhiteSpace(tb_patrimonio.Text) && !String.IsNullOrWhiteSpace(tb_nombre.Text) &&
                !String.IsNullOrWhiteSpace(tb_modelo.Text) && !String.IsNullOrWhiteSpace(tb_marca.Text) &&
                !String.IsNullOrWhiteSpace(tb_numeroSerie.Text) && !String.IsNullOrWhiteSpace(tb_Descripcion.Text))
                {
                    if (tb_nombre.Enabled != false)
                    {
                        LNActivo lnActivo = new LNActivo();
                        lnActivo.agregarActivo(activo());
                    
                        MessageBox.Show("Se ha guardado exitoxamente", "Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Algunos espacios se encuentran en blanco", "Error espacios vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                if (!String.IsNullOrWhiteSpace(tb_patrimonio.Text) && !String.IsNullOrWhiteSpace(tb_nombre.Text) &&
                   !String.IsNullOrWhiteSpace(tb_modelo.Text) && !String.IsNullOrWhiteSpace(tb_marca.Text) &&
                   !String.IsNullOrWhiteSpace(tb_numeroSerie.Text) && !String.IsNullOrWhiteSpace(tb_Descripcion.Text))
                {
                    
                    LNActivo.modificarActivo(activo());
                    MessageBox.Show("Activo fue modificado exitosamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   Limpiar();
                }
                else
                {
                    MessageBox.Show("Algunos espacios se encuentran en blanco", "Error espacios vacios",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_patrimonio.Text))
            {
                if(!LNActivo.consultar(tb_patrimonio.Text))
                {
                    tb_nombre.Enabled = true;
                    tb_marca.Enabled = true;
                    tb_marca.Enabled = true;
                    tb_modelo.Enabled = true;
                    tb_numeroSerie.Enabled = true;
                    tb_Descripcion.Enabled = true;
                    gb_estado.Enabled = true;
                    gb_disponibilidad.Enabled = true;

                    btnRegistrar.Enabled = true;
                }
                else
                {
                    MessageBox.Show("El patrimonio consultado ya está registrado", "Existente",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Algunos espacios se encuentran en blanco: Patrimonio", "Error espacio vacio",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Limpiar();
            }
        }

    }
}
