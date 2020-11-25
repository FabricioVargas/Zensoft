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
    public partial class Frm_TACU_Agregar : Form
    {
        //Variables locales
        int varCondicion=1; //Se utiliza para cargar los datos en el frame
        LNUnidadOrganizativa dlUnidad;
        LNActivo lnActivo;
        LNConsumible lnConsumibles;
        int indice;
        List<TblActivos> listaActivos;
        List<TblConsumibles> ListaConsumible;
        List<string> arrayCodCons = new List<string>();//Se almacenan los codigos de todos los consumibles que se agrgan a la lista detalle
        List<int> arrayCantCons = new List<int>();//Se almacenan las cantidades que se toman prestadas del stock
        //Se utilizan dos arrays para guardar la cantidad y relacionarla con la posicion del codigo, para que quede almacenado como una especie 
        //de cache
        List<int> cantTabla = new List<int>();//Este list va a cumplir la funcion de almacenar los registros de las cantidades de forma secuencial
        List<TblConsumibles> listaTemp; //Se va a utilizar para llenar el grid
        

        public Frm_TACU_Agregar()
        {
            InitializeComponent();
            llenarCbUnidadSalida();
            this.listaActivos = new List<TblActivos>();
            this.ListaConsumible = new List<TblConsumibles>();
            
            
        }

        private void Frm_TACU_Agregar_Load(object sender, EventArgs e)
        {
            this.dateTimeBox.Value = DateTime.Now;
            this.dateTimeBox.Enabled = false;
        }


        private void llenarCbUnidadSalida()
        {
            cbUDestino.Items.Insert(0, "Seleccione unidad de destino");
        }

        private void llenarCbUnidadDestino()
        {
            this.dlUnidad = new LNUnidadOrganizativa();
            cbUDestino.DisplayMember = "nombre";
            cbUDestino.ValueMember = "codigo";
            List<TblUnidadOrganizativa> prueba = dlUnidad.GetAllUnidadesSalida();
            prueba.RemoveAt(indice);
            cbUDestino.DataSource = prueba;
            this.cbUSalida.Enabled = true;
        }

      


        private void btnRealizar_Click(object sender, EventArgs e) //***************************************************Terminar realizar
        {// revisar ese id porque simpre me genera una nuevo y no lo necesito
            int idTraslado = LNTraslados.GenerarID();
            MessageBox.Show("Traslado realizado correctamente"+ idTraslado, "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            int cant = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[5].Value.ToString());
            TblTraslado traslado = new TblTraslado()
            {
                idTraslado = idTraslado,
                nombreUsuario = Frm_MenuPrincipal.nombreU,
                unidadSalida = this.cbUSalida.SelectedValue.ToString(),
                unidadDestino = this.cbUDestino.SelectedValue.ToString(),
                fecha = this.dateTimeBox.Value
            };
            LNTraslados.RealizarTraslado(traslado);

            if (rbtn_Consumible.Checked == true)// Traslado consumibles
            {
                TblTrasladoConsumibles trasladoConsumible = new TblTrasladoConsumibles()
                {
                    idTraslado = idTraslado,
                    codigo = this.txtIdentificador.Text,
                    nombre = txtNombre.Text,
                    marca= dgvDetalle.CurrentRow.Cells[2].Value.ToString(),
                    modelo= dgvDetalle.CurrentRow.Cells[3].Value.ToString(),
                    serie= dgvDetalle.CurrentRow.Cells[4].Value.ToString(),
                    cantidad = cant
                };
                if(MessageBox.Show("¿Desea realizar el traslado con los datos indicados? Asegurese que los datos sean correctos antes de continuar",
                    "ConfirmarAcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (LNTraslados.RealizarTrasladoC(trasladoConsumible))
                    {
                        MessageBox.Show("Traslado realizado correctamente", "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        Frm_Reporte_TACU_Consumibles frm_Reporte_TACU_Consumibles = new Frm_Reporte_TACU_Consumibles();
                        frm_Reporte_TACU_Consumibles.ShowDialog();
                        frm_Reporte_TACU_Consumibles.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Lo sentimos, la cantidad solicitada no está disponible en stock", "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }

            if (rbtn_Activo.Checked == true) //Traslado Activos
            {
                TblTrasladoActivo trasladoActivo = new TblTrasladoActivo()
                {
                    idTraslado = idTraslado,
                    patrimonio = txtIdentificador.Text,
                    nombre = txtNombre.Text,
                    marca = dgvDetalle.CurrentRow.Cells[2].Value.ToString(),
                    modelo = dgvDetalle.CurrentRow.Cells[3].Value.ToString(),
                    serie = dgvDetalle.CurrentRow.Cells[4].Value.ToString(),
                    cantidad = 1

                };
                if(MessageBox.Show("¿Desea realizar el traslado con los datos indicados? Asegurese que los datos sean correctos antes de continuar",
                    "ConfirmarAcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    if (LNTraslados.RealizarTrasladoA(trasladoActivo))
                    {
                        MessageBox.Show("Traslado realizado correctamente", "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                        Frm_Reporte_TACU_Activo frm_Reporte_TACU_Activo = new Frm_Reporte_TACU_Activo();
                        frm_Reporte_TACU_Activo.ShowDialog();
                        frm_Reporte_TACU_Activo.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("¡Lo sentimos! El activo no se encuentra disponible en este momento", "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
        

        //Codicion
        private void rbtn_Activo_CheckedChanged(object sender, EventArgs e)
        {
            if (verificarCampos())//Si hay campos llenos, por seguridad se verifica
            {
                if (rbtn_Consumible.Checked)//Valora si se cambia de activo a Consumible
                {
                    if (this.lblIdentificador.Text.Equals("Patrimonio:"))
                    {
                        if (MessageBox.Show("Desea cambiar la condicion de los datos del traslado a Consumible? Se le recuerda que los datos agregados actualmete, se pueden perder.",
                    "ConfirmarAcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                        {//Si de sea cambiar a consumible entonces
                            this.lblIdentificador.Text = "Código:";
                            this.cambiarEstados(true);
                            this.limpiarCampos();
                            this.btnAgregarD.Enabled = false;
                            this.btnRealizar.Enabled = false;
                            this.varCondicion = 2;
                        }
                        else//Si no entonces
                        {
                            this.rbtn_Activo.Checked = true;
                            this.lblIdentificador.Text = "Patrimonio:";
                            this.cambiarEstados(false);
                            this.varCondicion = 1;
                        }
                    }
                }
                else//Debe tambien valorarse si se desea cambiar de Consumible a Activo
                {
                    if (this.rbtn_Activo.Checked && this.lblIdentificador.Text.Equals("Código:"))
                    {
                        if (MessageBox.Show("Desea cambiar la condicion de los datos del traslado a Activo? Se le recuerda que los datos agregados actualmete, se pueden perder.",
                    "ConfirmarAcción", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                        {//Si de sea cambiar a Activo entonces
                            this.lblIdentificador.Text = "Patrimonio:";
                            this.cambiarEstados(false);
                            this.limpiarCampos();
                            this.btnAgregarD.Enabled = false;
                            this.btnRealizar.Enabled = false;
                            this.varCondicion = 1;
                        }
                        else//Si no entonces
                        {
                            this.rbtn_Consumible.Checked = true;
                            this.lblIdentificador.Text = "Código:";
                            this.cambiarEstados(true);
                            this.varCondicion = 2;
                        }
                    }
                }
            }
            else//Si los campos estan vacios entonces solo cambiar el estado
            {
                if (this.rbtn_Activo.Checked)
                {
                    this.cambiarEstados(false);
                    this.lblIdentificador.Text = "Patrimonio:";
                    this.varCondicion = 1;
                }
                else
                {
                    this.cambiarEstados(true);
                    this.lblIdentificador.Text = "Código:";
                    this.varCondicion = 2;
                }
            }

        }

        public void cambiarEstados(bool estado)//true se muestra consumible  False entonces se coloca activo
        {
            this.spCantidad.Visible = estado;
            this.lblCantidadDisponible.Visible = estado;
            this.lblCantidadDis.Visible = estado;
            this.lblCantReq.Visible = estado;
        }

        public void limpiarCampos()
        {
            this.txtIdentificador.Text = "";
            this.txtNombre.Text = "";
            this.spCantidad.Text = "";
            this.dgvDetalle.Rows.Clear();
            this.lblCantidadDisponible.Text = "";
            this.dgvDetalle.Rows.Clear();
            this.arrayCantCons.Clear();
            this.arrayCodCons.Clear();
            this.cantTabla.Clear();
            if (this.listaTemp!=null)
                this.listaTemp.Clear();
        }


        public bool verificarCampos()//Devuelve true si hay algo escrito
        {
            if(!string.IsNullOrWhiteSpace(txtIdentificador.Text) || !string.IsNullOrWhiteSpace(txtNombre.Text) 
                ||  dgvDetalle.Rows.Count != 0)
            {
                return true;
            }
            return false;
        }

        private void cbUSalida_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.indice = this.cbUSalida.SelectedIndex;
            this.llenarCbUnidadDestino();
        }

        private void cbUSalida_Click(object sender, EventArgs e)
        {
            dlUnidad = new LNUnidadOrganizativa();
            List<TblUnidadOrganizativa> unidadesDependencia = dlUnidad.GetAllUnidadesSalida();
            cbUSalida.DisplayMember = "nombre";
            cbUSalida.ValueMember = "codigo";
            cbUSalida.DataSource = unidadesDependencia;
        }

        public void btnConsultar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdentificador.Text))
            {
                this.spCantidad.Enabled = false;
                if (varCondicion==1)//Activo
                {
                    //this.lnActivo = new LNActivo();
                    TblActivos activo = LNActivo.consultarActivoPat(this.txtIdentificador.Text);
                    if(activo != null)
                    {
                        txtNombre.Text = activo.nombre;
                        this.btnAgregarD.Enabled = true;
                        
                    }
                    else
                    {
                        MessageBox.Show("No existe este activo.");
                    }
                }
                else//Consumible
                {
                    LNConsumible dlConsumible = new LNConsumible();
                    TblConsumibles cons = dlConsumible.getConsumible(this.txtIdentificador.Text);
                    if (cons != null)
                    {
                        this.cargarArrayConsumible(this.txtIdentificador.Text);
                        txtNombre.Text = cons.nombre;
                        lblCantidadDisponible.Text = this.arrayCantCons[this.buscarIndexArrayCon(this.txtIdentificador.Text)].ToString();
                        this.spCantidad.Maximum = this.arrayCantCons[this.buscarIndexArrayCon(this.txtIdentificador.Text)];
                        this.btnAgregarD.Enabled = true;
                        this.spCantidad.Enabled = true;
                        this.spCantidad.Value = 0;
                    }
                    else
                    {
                        MessageBox.Show("No existe este consumible.");
                        this.spCantidad.Enabled = false;
                    }
                }
                
            }
            else
            {
                MessageBox.Show("Coloque un identificador.");
                this.btnAgregarD.Enabled = false;
            }
        }

        private void spCantidad_ValueChanged(object sender, EventArgs e)
        {
            //if(this.spCantidad.Value)
        }

        public void llenarTablaActivos()
        {
            this.dgvDetalle.Columns.Clear();
            this.dgvDetalle.Rows.Clear();
            //Se agregan las columnas correspondientes
            this.dgvDetalle.Columns.Add("patrimonio", "Patrimonio");
            this.dgvDetalle.Columns.Add("nombre", "Nombre");
            this.dgvDetalle.Columns.Add("marca", "Marca");
            this.dgvDetalle.Columns.Add("modelo", "Modelo");
            this.dgvDetalle.Columns.Add("serie", "Serie");
            this.dgvDetalle.Columns.Add("cantidad", "Cantidad");

            //Se agregan las filas correspondientes
            if (this.listaActivos != null)
            {
                for (int i = 0; i < this.listaActivos.Count; i++)
                {
                    dgvDetalle.Rows.Add(this.listaActivos[i].patrimonio, this.listaActivos[i].nombre, this.listaActivos[i].marca, this.listaActivos[i].modelo, this.listaActivos[i].serie,  "1");
                }
            }
        }


        public void llenarTablaConsumibles()
        {
            this.dgvDetalle.Columns.Clear();
            this.dgvDetalle.Rows.Clear();
            //Se agregan las columnas correspondientes
            this.dgvDetalle.Columns.Add("codigo", "Codigo");
            this.dgvDetalle.Columns.Add("nombre", "Nombre");
            this.dgvDetalle.Columns.Add("marca", "Marca");
            this.dgvDetalle.Columns.Add("modelo", "Modelo");
            this.dgvDetalle.Columns.Add("numeroSerie", "Serie");
            this.dgvDetalle.Columns.Add("cantidad", "Cantidad");
            //Se agregan las filas correspondientes
            if (this.ListaConsumible != null)
            {
                this.listaTemp = this.ListaConsumible;
                for (int i = 0; i < listaTemp.Count-1; i++)
                {
                    if(this.listaTemp[i].codigo == (listaTemp[i + 1].codigo))
                    {
                        this.cantTabla[i] = this.cantTabla[i] + this.cantTabla[i + 1];
                        this.cantTabla.RemoveAt(i + 1);
                        this.listaTemp.RemoveAt(i + 1);
                    }
                }


                for (int i = 0; i < this.listaTemp.Count; i++)//Esta lista carga el data grid view
                {
                    dgvDetalle.Rows.Add(this.listaTemp[i].codigo, this.listaTemp[i].nombre, this.listaTemp[i].marca, this.listaTemp[i].modelo, this.listaTemp[i].numeroSerie, this.cantTabla[i]);//Aqui quede 11:20 PM
                    
                }
            }
        }



        private void btnAgregarD_Click(object sender, EventArgs e)
        {
            this.lnConsumibles = new LNConsumible();
            MessageBox.Show(this.txtIdentificador.Text, "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!string.IsNullOrEmpty(this.txtIdentificador.Text))
            {
                if (varCondicion == 1)//Activos
                {
                    this.listaActivos.Add(LNActivo.consultarActivoPat(this.txtIdentificador.Text));
                    this.llenarTablaActivos();
                    this.btnRealizar.Enabled = true;
                  
                }
                else//consumibles
                {//primero debo reducir la cantidad que se muestra disponible restandola con el spinner
                    if(spCantidad.Value != 0)
                    {
                        this.cargarArrayConsumible(this.txtIdentificador.Text);
                        this.ListaConsumible.Add(this.lnConsumibles.getConsumible(this.txtIdentificador.Text));//(error)es por esto que se multiplica el mismo
                        //TblConsumible stock = this.ListaConsumible.FirstOrDefault(c => c.codigo == this.txtIdentificador.Text);
                        this.ListaConsumible[this.ListaConsumible.Count - 1].stock = Convert.ToInt32(spCantidad.Value);
                        this.cantTabla.Add(Convert.ToInt32(this.spCantidad.Value));
                        this.llenarTablaConsumibles();
                        this.lblCantidadDisponible.Text = this.arrayCantCons[this.buscarIndexArrayCon(this.txtIdentificador.Text)].ToString();
                        this.btnRealizar.Enabled = true;
                        //this.lblCantidadDisponible.Text = (this.listaActivos. - (this.spCantidad.Value)).ToString();
                        this.spCantidad.Value = 0;
                        this.spCantidad.Maximum = this.arrayCantCons[this.buscarIndexArrayCon(this.txtIdentificador.Text)];
                        
                    }
                    else
                    {
                        MessageBox.Show("Seleccione una cantidad para este consumible.");
                    }
                }
            }
            else
            {
                this.btnRealizar.Enabled = false;
            }
            
        }

        private void cargarArrayConsumible(string cod)
        {
            int temp = buscarIndexArrayCon(cod);
            if (temp == -1)//Si no existe dentro del array se guarda por primera vez
            {
                LNConsumible dlConsumible = new LNConsumible();
                this.arrayCodCons.Add(this.txtIdentificador.Text);
                this.arrayCantCons.Add(Convert.ToInt32(dlConsumible.getConsumible(this.txtIdentificador.Text).stock)-Convert.ToInt32(spCantidad.Value));
            }//si existe se sobrescribe
            else
            {
                this.arrayCodCons[temp] = this.arrayCodCons[temp];
                this.arrayCantCons[temp] = this.arrayCantCons[temp] - Convert.ToInt32(this.spCantidad.Value);
            }
        }
        
        private int buscarIndexArrayCon(string codigo)//Retorna el index en que se encuentra ese codigo
        {
            for (int i = 0; i < arrayCodCons.Count; i++)
            {
                if (arrayCodCons[i].Equals(codigo))
                {
                    return i;
                }
            }
            return -1;
        }

        private void spCantidad_Click(object sender, EventArgs e)
        {
            int cantD = Convert.ToInt32(this.lblCantidadDisponible.Text);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiarCampos();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

       
    }
}
