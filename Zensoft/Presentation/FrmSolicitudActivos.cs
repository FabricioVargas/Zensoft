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
namespace Presentation
{
    public partial class FrmSolicitudActivos : Form
    {
        private LNActivo lnActivos;
        //Lista Para activos solicitados
        private List<SP_CNS_ACTIVO_Result> activosSolicitados;
        public FrmSolicitudActivos()
        {
            InitializeComponent();
        }

        public void eliminarSolicitudes()
        {
            //Instancia a logica de negocios
            this.lnActivos = new LNActivo();
            //Se eliminan las solicitudes no procesadas
            this.lnActivos.elimiarSolicitudes();
            if(this.activosSolicitados != null)
                this.activosSolicitados.Clear();
        }

        private void FrmSolicitudActivos_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.eliminarSolicitudes();
        }

        private void FrmSolicitudActivos_Load(object sender, EventArgs e)
        {
            //Se pone el textbox en modo de autocompletar
            this.autocompletar();
            this.activosSolicitados = new List<SP_CNS_ACTIVO_Result>();
        }

        private void autocompletar()
        {
            //Instancia de la logica de negocios de activos
            this.lnActivos = new LNActivo();

            List<string> patrimonios = this.lnActivos.getPatrimonios();
            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            source.AddRange(patrimonios.ToArray());
            this.txtActivo.AutoCompleteMode = AutoCompleteMode.Suggest;
            this.txtActivo.AutoCompleteSource = AutoCompleteSource.CustomSource;
            this.txtActivo.AutoCompleteCustomSource = source;
        }

        public void llenarTabla()
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
            if(this.activosSolicitados != null)
            {
                for (int i = 0; i < this.activosSolicitados.Count; i++)
                {
                    dgtActivos.Rows.Add(this.activosSolicitados[i].Patrimonio,
                        this.activosSolicitados[i].Nombre, this.activosSolicitados[i].Marca,
                        this.activosSolicitados[i].Modelo, this.activosSolicitados[i].Serie);
                }
            }
        }

        private void recargarTabla()
        {
            try
            {
                this.dgtActivos.AllowUserToAddRows = false;
                //Se asignan los activos solicitados al grid
                this.llenarTabla();
                this.dgtActivos.AutoResizeColumns();
                this.dgtActivos.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            try
            {
                //Instancia de la logica de negocios
                this.lnActivos = new LNActivo();
                SP_CNS_ACTIVO_Result activo = this.lnActivos.getActivoSolicitado(this.txtActivo.Text);

                //Se comprueba que el objeto no sea nulo
                if (activo != null)
                {
                    if (this.activosSolicitados == null)
                    {
                        this.activosSolicitados = new List<SP_CNS_ACTIVO_Result>();
                        this.activosSolicitados.Add(activo);
                        this.recargarTabla();
                        this.lnActivos.registrarSolicitud(this.txtActivo.Text);
                        this.txtActivo.Text = "";
                        this.autocompletar();
                    }
                    else
                    {
                        if (!this.comprobarSolicitud(this.txtActivo.Text))
                        {
                            this.activosSolicitados.Add(activo);
                            this.recargarTabla();
                            this.lnActivos.registrarSolicitud(this.txtActivo.Text);
                            this.txtActivo.Text = "";
                            this.autocompletar();
                        }
                        else
                        {
                            MessageBox.Show("Error al solicitar acivo, ya se ha solicitado ese activo", "Proceso Aplicado",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                    MessageBox.Show("Error al solicitar acivo, no se encuentra registrado ningún activo con el patrimonio establecido", "Proceso Aplicado",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool comprobarSolicitud(string act)
        {
            bool encontrado = false;
            for (int i = 0; i < this.activosSolicitados.Count; i++)
            {
                if (act.Equals(this.activosSolicitados[i].Patrimonio))
                    encontrado = true;
            }
            return encontrado;
        }

        private void quitarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgtActivos.Rows.Count <= 0)
                    throw new Exception("No hay datos de activos consultados");

                //Se valida que exista una fila seleccionada
                if (this.dgtActivos.SelectedRows.Count <= 0)
                    throw new Exception("Seleccione la fila del activo que desea modificar");

                for (int i = 0; i < this.activosSolicitados.Count; i++)
                {
                    if (this.activosSolicitados[i].Patrimonio.Equals(this.dgtActivos.SelectedRows[0].Cells["patrimonio"].Value.ToString()))
                    {
                        this.activosSolicitados.Remove(this.activosSolicitados[i]);
                        this.lnActivos = new LNActivo();
                        if(this.lnActivos.eliminarActivoSolicitado(this.dgtActivos.SelectedRows[0].Cells["patrimonio"].Value.ToString()))
                            MessageBox.Show("Activo quitado correctamente", "Proceso Aplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.recargarTabla();
                this.autocompletar();
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
                if(this.dgtActivos.Rows.Count > 0)
                {
                    //Instancia de la interfaz para realizar el prestamo
                    FrmPrestamoActivo frmPrestamoActivo = new FrmPrestamoActivo(this);
                    frmPrestamoActivo.llenarGrid(this.activosSolicitados);
                    frmPrestamoActivo.ShowDialog();
                    frmPrestamoActivo.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void reHacerVentana()
        {
            this.activosSolicitados = null;
            this.recargarTabla();
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            this.txtActivo.Text = "";
            this.eliminarSolicitudes();
            this.recargarTabla();
            this.autocompletar();
        }
    }
}
