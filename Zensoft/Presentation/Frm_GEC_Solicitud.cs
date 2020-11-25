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
    public partial class Frm_GEC_Solicitud : Form
    {
        Frm_GEC_Realizar frmrealizar;
        public Frm_GEC_Solicitud(Frm_GEC_Realizar frmrealizar)
        {
            this.frmrealizar = frmrealizar;
            InitializeComponent();
            limpiarEmp();
            cargarGrid();
        }

        private void cargarGrid()
        {
            LNConsumible lnConsumibles = new LNConsumible();
            this.dgvConsumibles.AllowUserToAddRows = false;
            this.dgvConsumibles.DataSource = lnConsumibles.CargarTabla();
            this.dgvConsumibles.AutoResizeColumns();
            this.dgvConsumibles.ReadOnly = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tb_cedula.Text.Trim()))
            {
                if (LNEmpleado.verificarEmpleado(tb_cedula.Text.Trim()))
                {
                    if (tb_cedula.Enabled == true)
                    {
                        tb_nombre.Text = LNEmpleado.getNombre(tb_cedula.Text.Trim());
                        this.tb_cedula.Enabled = false;
                    }
                    else
                        MessageBox.Show("¡Ya hay un empleado!" , "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("No se encontró al empleado con cédula "+ tb_cedula.Text.Trim(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Algunos espacios se encuentran en blanco: Cédula", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarEmp();
        }

        private void btnHecho_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tb_nombre.Text.Trim()) && !string.IsNullOrWhiteSpace(tb_cedula.Text.Trim()))
            {
                if (!string.IsNullOrWhiteSpace(tb_Observacion.Text.Trim()) )
                {
                    TblMovimiento movimiento = new TblMovimiento();
                    movimiento.nombreUsuario = Frm_MenuPrincipal.nombreU;
                    movimiento.cedEmpleado = tb_cedula.Text.Trim();
                    movimiento.observacion = tb_Observacion.Text.Trim();
                    movimiento.fecha = DateTime.Now;
                    movimiento.accion = "E";
                    LNMovimientos.realizarEntrega(movimiento);
                    MessageBox.Show("¡Se realizó la entrega existosamente!", "Generado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Frm_Reporte_GEC frm_Reporte_GEC = new Frm_Reporte_GEC();
                    frm_Reporte_GEC.ShowDialog();
                    frm_Reporte_GEC.Dispose();
                    this.frmrealizar.vaciarGrid();
                    this.frmrealizar.autocompletar();
                    this.Close();
                }
                else
                    MessageBox.Show("Algunos espacios se encuentran en blanco: Observación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Algunos espacios se encuentran en blanco", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void limpiarEmp()
        {
            this.tb_cedula.Clear();
            this.tb_cedula.Enabled = true;
            this.tb_nombre.Clear();
        }

        private void Frm_GEC_Solicitud_Load(object sender, EventArgs e)
        {

        }
    }
}
