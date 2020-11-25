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
    public partial class Frm_C_Lista : Form
    {
        private LNConsumible lnConsumible;
        public Frm_C_Lista()
        {
            InitializeComponent();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            //Instancia LNConsumibles
            this.lnConsumible = new LNConsumible();

            //Se llama al metodo que devuelve una lista de consumibles que coincidan con el codigo que se digita
            this.dgtConsumibles.AllowUserToAddRows = false;
            this.dgtConsumibles.DataSource = this.lnConsumible.ConsultarConsumibles(this.txtCodigo.Text.Trim());

            this.dgtConsumibles.AutoResizeColumns();
            this.dgtConsumibles.ReadOnly = true;

        }

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_C_Agregar frm_C_Agregar = new Frm_C_Agregar(this);
            frm_C_Agregar.funcion = 0;
            frm_C_Agregar.ShowDialog();
            frm_C_Agregar.Dispose();
            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_C_Agregar consumible = new Frm_C_Agregar(this);
            consumible.funcion = 1;

            //Valida que se haya hecho una consulta antes para poder modificar "Se indica que no se ha consultado nada"
            if(this.dgtConsumibles.Rows.Count <= 0)
            {
                try
                {
                    MessageBox.Show("No hay datos de consumibles consultados", "Proceso aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch(Exception)
                {
                    throw new Exception("No hay datos de consumibles consultados");
                }

            }

            else if(this.dgtConsumibles.SelectedRows.Count <= 0)
               try
                {
                    MessageBox.Show("Seleccione la fila que desea modificar ¡Por favor!", "Proceso aplicado",
                       MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception)
                {
                    throw new Exception("Seleccione la fila del consumible que desea modificar");
                }

            else
            {
                consumible.codigo = this.dgtConsumibles.SelectedRows[0].Cells["Código"].Value.ToString();
                consumible.ShowDialog();
                consumible.Dispose();
            }

           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
    }
}
