using System;
using System.Windows.Forms;
using LogicaNegocio;

namespace Zensoft
{
    public partial class FrmEmpleados : Form
    {
        private LNEmpleado lnEmpleado;
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            this.recargarTabla();
        }

        public void recargarTabla()
        {
            //Se instancia la LN de empleado
            this.lnEmpleado = new LNEmpleado();

            //Se llama el metodo que devuelve lista de empleados que coincidan con la cedula digitada
            this.dgtEmpleados.AllowUserToAddRows = false;
            this.dgtEmpleados.DataSource = this.lnEmpleado.consultarEmpledos(this.txtCedula.Text.Trim());

            this.dgtEmpleados.AutoResizeColumns();
            this.dgtEmpleados.ReadOnly = true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FRMIMEmpleado empleado = new FRMIMEmpleado(this);
            empleado.funcion = 0;
            empleado.ShowDialog();
            empleado.Dispose();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMIMEmpleado empleado = new FRMIMEmpleado(this);
            empleado.funcion = 1;

            //Validacion
            if (this.dgtEmpleados.Rows.Count <= 0)
                MessageBox.Show("No hay datos de empleados consultados", "Proceso Aplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

            //Se valida que exista una fila seleccionada
            else if (this.dgtEmpleados.SelectedRows.Count <= 0)
                MessageBox.Show("Seleccione la fila del empleado que desea modificar", "Proceso Aplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            else {
                empleado.cedula = this.dgtEmpleados.SelectedRows[0].Cells["Cédula"].Value.ToString();
                empleado.ShowDialog();
                empleado.Dispose();
            }
            
        }
    }
}
