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
    public partial class Frm_GEC_Realizar : Form
    {
        LNConsumible lnConsumibles;
        
        public Frm_GEC_Realizar()
        {
            InitializeComponent();
                vaciarGrid();
        }


        private void btnPrestar_Click(object sender, EventArgs e)
        {
            if (dgbConsumibles.Rows.Count == 0)
            {
                MessageBox.Show("No tiene consumibles seleccionados para prestar", "Falta Datos",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Frm_GEC_Solicitud frmSolicitud = new Frm_GEC_Solicitud(this);
                frmSolicitud.ShowDialog();
                frmSolicitud.Dispose();
            }
        }


        public void autocompletar()
        {
            LNConsumible lnConsumibles = new LNConsumible();
            List<string> codigos = lnConsumibles.getCodigos();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(codigos.ToArray());
            this.tb_codigo.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.tb_codigo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.tb_codigo.AutoCompleteCustomSource = source;
        }

        private void Frm_GEC_Realizar_Load(object sender, EventArgs e)
        {
            autocompletar();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            string codigo = tb_codigo.Text.Trim();

            if (!String.IsNullOrWhiteSpace(tb_codigo.Text))
            {
                if (!String.IsNullOrWhiteSpace(tb_Cantidad.Text))
                {
                    LNConsumible LNConsumible = new LNConsumible();
                    int cantidad = int.Parse(tb_Cantidad.Text.Trim());
                    if (LNConsumible.VerificarCod(codigo))
                    {
                        if (LNConsumible.verificarCantidad(codigo, cantidad))
                        {
                            if (!LNConsumible.verificarGrid(codigo))
                            {
                                //no esta en el grid
                                TblConsumibleSolicitado consumibleSolicitado = new TblConsumibleSolicitado()
                                {
                                    codigo = tb_codigo.Text,
                                    cantidad = Convert.ToInt32(tb_Cantidad.Text)
                                };
                                LNConsumible.InsertarCodigos(consumibleSolicitado);
                                cargarTabla();
                                tb_codigo.Clear();
                                tb_Cantidad.Clear();
                                this.autocompletar();
                            }
                            else
                            {
                                // esta en el grid: sumarle
                                //Agarrar la cantidad de la columna
                                TblConsumibleSolicitado consumibleSolicitado = new TblConsumibleSolicitado()
                                {
                                    codigo = tb_codigo.Text,
                                    cantidad = Convert.ToInt32(tb_Cantidad.Text)
                                };
                                bool verificarCantidad = LNConsumible.ModificarConsumibleCantidad(consumibleSolicitado);
                                if (verificarCantidad)
                                { 
                                    //si no se pasa de stock
                                    cargarTabla();
                                    tb_codigo.Clear();
                                    tb_Cantidad.Clear();
                                    this.autocompletar();
                                }
                                else
                                {
                                    //cantidad se pasa de stock
                                    MessageBox.Show("¡Esa cantidad sobrepasa la cantidad del consumible en stock disponible!", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("¡Esa cantidad sobrepasa la cantidad del consumible en stock!", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tb_Cantidad.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("¡El codigo ingresado no existe!", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("¡Sin cantidad! \n\nPor favor ingrese una cantidad.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("¡Sin código! \n\nPor favor ingrese un código.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargarTabla()
        {
            this.lnConsumibles = new LNConsumible();
            this.dgbConsumibles.AllowUserToAddRows = false;
            this.dgbConsumibles.DataSource = this.lnConsumibles.CargarTabla();
            this.dgbConsumibles.AutoResizeColumns();
            this.dgbConsumibles.ReadOnly = true;
        }

        public void vaciarGrid()
        {
            LNConsumible LNConsumible = new LNConsumible();
            LNConsumible.vaciar();
            cargarTabla();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            vaciarGrid();
            this.autocompletar();
        }

        private void tb_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void tb_codigo_TextChanged(object sender, EventArgs e)
        {
            LNConsumible LNConsumible = new LNConsumible();
            tb_stock.Text = LNConsumible.cargarStock(tb_codigo.Text);
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LNConsumible.eliminarConsumibleSolicitado(tb_codigo.Text))
            {
                MessageBox.Show("Se eliminó un elemento de la tabla", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.autocompletar();
            }
            else
            {
                MessageBox.Show("Seleccione la fila", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Frm_GEC_Realizar_FormClosed(object sender, FormClosedEventArgs e)
        {
            vaciarGrid();
        }
    }
}
