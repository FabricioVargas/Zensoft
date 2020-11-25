using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogicaNegocio;
using Entidades;

namespace Zensoft
{
    public partial class FrmPrestamosEmpleado : Form
    {
        LNEmpleado lnEmpleado;
        LNMovimientos lnMovimientos;
        public FrmPrestamosEmpleado()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int result;
            if (!string.IsNullOrWhiteSpace(this.txtCedula.Text.Trim()) && int.TryParse(this.txtCedula.Text.Trim(), out result))
            {
                this.lnEmpleado = new LNEmpleado();
                if (this.lnEmpleado.consultarEmpleado(this.txtCedula.Text.Trim()))
                {
                    this.lnMovimientos = new LNMovimientos();
                    this.txtNombre.Text = this.lnEmpleado.getEmpleado(this.txtCedula.Text.Trim()).nombre;
                    this.llenarGrid(this.lnMovimientos.obtenerPrestamosEmpleado(this.txtCedula.Text.Trim()));
                }
                else
                {
                    MessageBox.Show("No existe un empleado con esa cédula asociada.", "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.limpiarVentana();
                }
            }
            else
            {
                MessageBox.Show("Formato incorrecto en el campo de cédula. Ejemplo de uso: ##########", "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void limpiarVentana()
        {
            this.txtCedula.Text = "";
            this.txtNombre.Text = "";
            this.dgtPrestamos.Columns.Clear();
            this.dgtPrestamos.Rows.Clear();
        }

        private void llenarGrid(List<SP_CNS_PRESTAMOSxEMPLEADO_Result> listaPrestamos)
        {
            this.dgtPrestamos.AllowUserToAddRows = false;
            //Se asignan los activos solicitados al grid
            this.cargarDatosGrid(listaPrestamos);
            this.dgtPrestamos.AutoResizeColumns();
            this.dgtPrestamos.ReadOnly = true;
        }

        private void cargarDatosGrid(List<SP_CNS_PRESTAMOSxEMPLEADO_Result> listaPrestamos)
        {
            this.dgtPrestamos.Columns.Clear();
            this.dgtPrestamos.Rows.Clear();
            this.dgtPrestamos.Columns.Add("idMovimiento", "IDMovimiento");
            this.dgtPrestamos.Columns.Add("nombreEmpleado", "Nombre Empleado");
            this.dgtPrestamos.Columns.Add("fecha", "Fecha del Préstamo");
            this.dgtPrestamos.Columns.Add("cantidadActivos", "Cantidad de Activos");
            this.dgtPrestamos.Columns[0].Visible = false;

            for (int i = 0; i < listaPrestamos.Count; i++)
            {
                dgtPrestamos.Rows.Add(listaPrestamos[i].IDMovimiento, listaPrestamos[i].Nombre_Empleado,
                    listaPrestamos[i].Fecha, listaPrestamos[i].Cantidad_Activos);
            }

            DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            colBotones.Name = "colBotones";
            colBotones.HeaderText = "Detalle";
            this.dgtPrestamos.Columns.Add(colBotones);
        }

        private void dgtPrestamos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                if (this.dgtPrestamos.Columns[e.ColumnIndex].Name == "colBotones")
                {
                    FrmDevolucionActivos frmDevolucion = new FrmDevolucionActivos(this);
                    this.lnMovimientos = new LNMovimientos();
                    frmDevolucion.setPrestamo(this.lnMovimientos.getMovimiento(Int32.Parse(this.dgtPrestamos.Rows[e.RowIndex].Cells[0].Value.ToString())));
                    frmDevolucion.ShowDialog();
                    frmDevolucion.Dispose();
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
