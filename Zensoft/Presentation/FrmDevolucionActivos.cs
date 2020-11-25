using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using LogicaNegocio;

namespace Zensoft
{
    public partial class FrmDevolucionActivos : Form
    {
        private TblMovimiento prestamo;
        private LNEmpleado lnEmpleado;
        private LNMovimientos lnMovimiento;
        private List<SP_CNS_ACTIVOSPRESTAMO_Result> listaPrestados;
        private List<SP_CNS_ACTIVOSPRESTAMO_Result> listaDevueltos;
        private FrmPrestamosEmpleado frmPrestamosEmpleado;
        public FrmDevolucionActivos(FrmPrestamosEmpleado frmPrestamosEmpleado)
        {
            InitializeComponent();
            this.frmPrestamosEmpleado = frmPrestamosEmpleado;
        }

        private void FrmDevolucionActivos_Load(object sender, EventArgs e)
        {
            this.cargarEncabezado();
        }

        private void cargarEncabezado()
        {
            this.lnEmpleado = new LNEmpleado();
            this.lnMovimiento = new LNMovimientos();
            this.txtNombre.Text = this.lnEmpleado.getEmpleado(this.prestamo.cedEmpleado).nombre;
            this.txtFecha.Text = DateTime.Parse(this.prestamo.fecha.ToString()).ToString();
            this.listaDevueltos = new List<SP_CNS_ACTIVOSPRESTAMO_Result>();
            this.listaPrestados = this.lnMovimiento.getPrestamo(prestamo.idMovimiento);
            this.llenarGridPrestados(this.listaPrestados);
        }

        public void setPrestamo(TblMovimiento prestamo)
        {
            this.prestamo = prestamo;
        }

        private void llenarGridPrestados(List<SP_CNS_ACTIVOSPRESTAMO_Result> activosPrestados)
        {
            this.dgtActivosPrestados.AllowUserToAddRows = false;
            //Se asignan los activos solicitados al grid
            this.cargarDatosGridPrestados(activosPrestados);
            this.dgtActivosPrestados.AutoResizeColumns();
            this.dgtActivosPrestados.ReadOnly = true;
        }

        private void cargarDatosGridPrestados(List<SP_CNS_ACTIVOSPRESTAMO_Result> activosPrestados)
        {
            this.dgtActivosPrestados.Columns.Clear();
            this.dgtActivosPrestados.Rows.Clear();
            this.dgtActivosPrestados.Columns.Add("patrimonio", "Patrimonio");
            this.dgtActivosPrestados.Columns.Add("nombre", "Nombre Activo");
            this.dgtActivosPrestados.Columns.Add("marca", "Marca");

            for (int i = 0; i < activosPrestados.Count; i++)
            {
                dgtActivosPrestados.Rows.Add(activosPrestados[i].patrimonio, activosPrestados[i].nombre,
                    activosPrestados[i].marca);
            }

            DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            colBotones.Name = "colBotones";
            colBotones.HeaderText = "Devolver";
            this.dgtActivosPrestados.Columns.Add(colBotones);
        }

        private void dgtActivosPrestados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if (this.dgtActivosPrestados.Columns[e.ColumnIndex].Name == "colBotones")
                {
                    this.transferirDatosPrestamo(e.RowIndex);
                    this.llenarGridDevueltos(this.listaDevueltos);
                    this.llenarGridPrestados(this.listaPrestados);
                }
            }
        }

        private void transferirDatosPrestamo(int index)
        {
            for (int i = 0; i < listaPrestados.Count; i++)
            {
                if (this.listaPrestados[i].patrimonio.Equals(this.dgtActivosPrestados.Rows[index].Cells["patrimonio"].Value.ToString()))
                {
                    this.listaDevueltos.Add(this.listaPrestados[i]);
                    this.listaPrestados.Remove(this.listaPrestados[i]);
                    break;
                }
            }
        }
        private void llenarGridDevueltos(List<SP_CNS_ACTIVOSPRESTAMO_Result> activosDevueltos)
        {
            this.dgtActivosDevueltos.AllowUserToAddRows = false;
            //Se asignan los activos solicitados al grid
            this.cargarDatosGridDevueltos(activosDevueltos);
            this.dgtActivosDevueltos.AutoResizeColumns();
            this.dgtActivosDevueltos.ReadOnly = true;
        }

        private void cargarDatosGridDevueltos(List<SP_CNS_ACTIVOSPRESTAMO_Result> activosDevueltos)
        {
            this.dgtActivosDevueltos.Columns.Clear();
            this.dgtActivosDevueltos.Rows.Clear();
            this.dgtActivosDevueltos.Columns.Add("patrimonio", "Patrimonio");
            this.dgtActivosDevueltos.Columns.Add("nombre", "Nombre Activo");
            this.dgtActivosDevueltos.Columns.Add("marca", "Marca");

            for (int i = 0; i < activosDevueltos.Count; i++)
            {
                dgtActivosDevueltos.Rows.Add(activosDevueltos[i].patrimonio, activosDevueltos[i].nombre,
                    activosDevueltos[i].marca);
            }

            DataGridViewButtonColumn colBotones = new DataGridViewButtonColumn();
            colBotones.Name = "colBotones";
            colBotones.HeaderText = "Deshacer";
            colBotones.Text = "  ❌  ";
            this.dgtActivosDevueltos.Columns.Add(colBotones);
        }

        private void dgtActivosDevueltos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                if (this.dgtActivosDevueltos.Columns[e.ColumnIndex].Name == "colBotones")
                {
                    this.transferirDatosDevolucion(e.RowIndex);
                    this.llenarGridDevueltos(this.listaDevueltos);
                    this.llenarGridPrestados(this.listaPrestados);
                }
            }
        }

        private void transferirDatosDevolucion(int index)
        {
            for (int i = 0; i < listaDevueltos.Count; i++)
            {
                if (this.listaDevueltos[i].patrimonio.Equals(this.dgtActivosDevueltos.Rows[index].Cells["patrimonio"].Value.ToString()))
                {
                    this.listaPrestados.Add(this.listaDevueltos[i]);
                    this.listaDevueltos.Remove(this.listaDevueltos[i]);
                    break;
                }
            }
        }

        private void btnHecho_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(this.txtObservacion.Text.Trim()))
                {
                    if(this.dgtActivosDevueltos.Rows.Count > 0)
                    {
                        this.lnMovimiento = new LNMovimientos();
                        this.prestamo.accion = "D";
                        this.lnMovimiento.registrarMovimientoAct(this.prestamo, this.getDevovuciones());
                        MessageBox.Show("Devoluvión realizada correctamente!", "Proceso Aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.frmPrestamosEmpleado.limpiarVentana();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Por favor seleccionar activos a devolver.", "Proceso Aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor no dejar en blanco la observación.", "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<SP_CNS_ACTIVO_Result> getDevovuciones()
        {
            List<SP_CNS_ACTIVO_Result> lista = new List<SP_CNS_ACTIVO_Result>();
            SP_CNS_ACTIVO_Result activo;

            for (int i = 0; i < this.dgtActivosDevueltos.Rows.Count; i++)
            {
                activo = new SP_CNS_ACTIVO_Result();
                activo.Patrimonio = this.dgtActivosDevueltos.Rows[i].Cells["patrimonio"].Value.ToString();
                lista.Add(activo);
            }
            return lista;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
