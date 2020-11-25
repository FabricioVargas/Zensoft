
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
    public partial class Frm_UO_Consultar2 : Form
    {
        LNUnidadOrganizativa dlUnidad;

        public Frm_UO_Consultar2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CargarUnidad();
        }

        public void CargarUnidad()
        {
            this.dlUnidad = new LNUnidadOrganizativa();

            dgUnidadesOrganizativas.DataSource = dlUnidad.consultarUnidadesOrganizacionales(txtCodigo.Text.Trim());

        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_UO_Agregar unidad = new Frm_UO_Agregar();
            unidad.funcion = 0;
            unidad.ShowDialog();
            unidad.Dispose();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.txtCodigo.Text.Equals(""))
            {
                //Valida que se haya hecho una consulta antes para poder modificar "Se indica que no se ha consultado nada"
                if (this.dgUnidadesOrganizativas.Rows.Count <= 0)
                    MessageBox.Show("No hay datos de Unidades Organizativas consultadas", "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else if (this.dgUnidadesOrganizativas.SelectedRows.Count <= 0)
                    MessageBox.Show("Seleccione la fila de la Unidad Organizativa que desea modificar",
                        "Proceso Aplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    Frm_UO_Agregar unidad = new Frm_UO_Agregar();
                    unidad.funcion = 1;
                    unidad.codigo = this.dgUnidadesOrganizativas.SelectedRows[0].Cells["Código"].Value.ToString();
                    unidad.ShowDialog();
                    unidad.Dispose();
                }
            }
        }



    }
}
