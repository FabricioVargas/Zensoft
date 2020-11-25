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
    public partial class Frm_A_Lista : Form
    {
        public Frm_A_Lista()
        {
            InitializeComponent();
            CargarGrid();
        }

        private void tb_Patrimomio_TextChanged(object sender, EventArgs e)
        {
            CargarGrid();
        }

        public void CargarGrid()
        {
            LNActivo lnActivo = new LNActivo();

            dgvListaActivos.AllowUserToAddRows = false;
            dgvListaActivos.DataSource = lnActivo.consultarActivos(tb_Patrimomio.Text.Trim());
           dgvListaActivos.AutoResizeColumns();
            dgvListaActivos.ReadOnly = true; 
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Frm_A_Agregar frm_A_Agregar = new Frm_A_Agregar();
            frm_A_Agregar.ShowDialog();
            frm_A_Agregar.Dispose();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            String patrimonio = this.dgvListaActivos.SelectedRows[0].Cells["Patrimonio"].Value.ToString();


            if (this.dgvListaActivos.Rows.Count <= 0)
                throw new Exception("No hay datos de usuario consultados");

            if (this.dgvListaActivos.SelectedRows.Count <= 0)
                throw new Exception("Seleccione la fila del usuario que desea eliminar");

            Frm_A_Agregar frm_A_Agregar = new Frm_A_Agregar();
            frm_A_Agregar.ModificarActivo(patrimonio);
            frm_A_Agregar.ShowDialog();
            frm_A_Agregar.Dispose();
        }

    }
}
