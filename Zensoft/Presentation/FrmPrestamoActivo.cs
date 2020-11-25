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

namespace Presentation
{
    public partial class FrmPrestamoActivo : Form
    {
        private LNEmpleado lnEmpleado;
        private LNActivo lnActivo;
        private LNMovimientos lnMovimiento;
        private List<SP_CNS_ACTIVO_Result> listaAct;
        private FrmSolicitudActivos frmSolicitudActivos;
        public FrmPrestamoActivo(FrmSolicitudActivos frmSolicitudActivos)
        {
            InitializeComponent();
            this.frmSolicitudActivos = frmSolicitudActivos;
        }

        public void llenarGrid(List<SP_CNS_ACTIVO_Result> activosSolicitados)
        {
            try
            {
                this.listaAct = activosSolicitados;
                this.dgtActivos.AllowUserToAddRows = false;
                //Se define la procedencia de los datos
                this.llenarTabla(activosSolicitados);
                this.dgtActivos.AutoResizeColumns();
                this.dgtActivos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void llenarTabla(List<SP_CNS_ACTIVO_Result> activosSolicitados)
        {
            this.dgtActivos.Columns.Clear();
            this.dgtActivos.Rows.Clear();
            //Se agregan las columnas correspondientes
            this.dgtActivos.Columns.Add("patrimonio", "Patrimonio");
            this.dgtActivos.Columns.Add("nombre", "Nombre");
            this.dgtActivos.Columns.Add("marca", "Marca");
            this.dgtActivos.Columns.Add("modelo", "Modelo");
            this.dgtActivos.Columns.Add("serie", "Serie");

            //Se agregan las filas correspondientes
            for (int i = 0; i < activosSolicitados.Count; i++)
            {
                dgtActivos.Rows.Add(activosSolicitados[i].Patrimonio,
                    activosSolicitados[i].Nombre, activosSolicitados[i].Marca,
                    activosSolicitados[i].Modelo, activosSolicitados[i].Serie);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                int result;
                if (!string.IsNullOrWhiteSpace(this.txtCedula.Text.Trim()))
                {
                    //Instancia de la  logica de negocios
                    this.lnEmpleado = new LNEmpleado();
                    if (this.lnEmpleado.consultarEmpleado(this.txtCedula.Text))
                    {
                        this.txtNombre.Text = this.lnEmpleado.getEmpleado(this.txtCedula.Text).nombre;
                        this.btnPrestar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("El empleado con la cédula consultada no existe", "Proceso Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("La cédula está en el formato incorrecto. Ejemplo de uso: #########", "Proceso Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrestar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.validaciones())
                {
                    //Instancia de la  logica de negocios
                    this.lnEmpleado = new LNEmpleado();
                    if (this.lnEmpleado.consultarEmpleado(this.txtCedula.Text.Trim()))
                    {
                        this.lnMovimiento = new LNMovimientos();
                        this.lnMovimiento.registrarMovimientoAct(this.ObtenerDatosMov(), this.listaAct);
                        MessageBox.Show("Préstamo realizado con éxito", "Proceso Aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.frmSolicitudActivos.eliminarSolicitudes();
                        this.frmSolicitudActivos.reHacerVentana();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validaciones()
        {
            int result;
            if (!string.IsNullOrWhiteSpace(this.txtCedula.Text.Trim()) && int.TryParse(this.txtCedula.Text, out result))
            {
                if (!string.IsNullOrWhiteSpace(this.txtObservacion.Text.Trim()))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Favor no dejar en blanco la observación.", "Proceso Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("La cédula está en el formato incorrecto. Ejemplo de uso: #########", "Proceso Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private TblMovimiento ObtenerDatosMov()
        {
            TblMovimiento mov = new TblMovimiento();
            mov.nombreUsuario = Frm_MenuPrincipal.nombreU;
            mov.cedEmpleado = this.txtCedula.Text.Trim();
            mov.observacion = this.txtObservacion.Text.Trim();
            mov.fecha =  DateTime.Now;
            mov.accion = "P";
            return mov;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
