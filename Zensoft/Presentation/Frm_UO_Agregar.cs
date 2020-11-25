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
    public partial class Frm_UO_Agregar : Form
    {
        LNUnidadOrganizativa dLUnidadO;

        double varLat;//Variable latitud
        double varLng;//Variable Longitud

        public int funcion;
        public string codigo;

        //Constructor
        public Frm_UO_Agregar( )
        {
            InitializeComponent();
            this.checkDep.Enabled = false;
        }

        bool varComprobarSeleccion;//para comprobar que se selecciona la ubicacion desde maps

        /*Apenas se abre el frame: Instancia DataLogic, se verifica si existen unidades organizativas
            Si existen, se cargan
            si no, se deshabilita el checkbox*/
        private void Frm_UO_Agregar_Load(object sender, EventArgs e)
        {
            this.dLUnidadO = new LNUnidadOrganizativa();
            try
            {
                if (this.funcion == 1)
                {
                    this.btnAccion.Text = "&Modificar";
                    this.llenarDatos();
                    if (this.dLUnidadO.verificarDependenciaUO(this.txtCodigo.Text))
                    {
                        this.cBoxDep.Enabled = true;

                    }
                    this.verificar();
                    this.habilitarModificar();
                    this.groupBox1.Text = "Modificar consumible";
                };
                
                if (this.dLUnidadO.verificarDependencias())//cargar las unidades organizativas
                {
                    //this.dLUnidadO = new DLUnidadOrganizativa();
                    this.cargarUnidadesOrganizativas();
                }
                else
                {
                    this.checkDep.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarDatos()
        {
            this.dLUnidadO = new LNUnidadOrganizativa();
            //se obtiene  los datos del consumible
            TblUnidadOrganizativa unidad = this.dLUnidadO.getUnidadO(this.codigo);

            //Se llenan los campos respectivos con la informacion de las unidadades
            this.txtCodigo.Text = unidad.codigo;
            this.txtNombre.Text = unidad.nombre;
            this.txtTelefono.Text = unidad.telefono;
            this.varLat = Convert.ToDouble(unidad.latitud);
            this.varLng = Convert.ToDouble(unidad.logitud);
            //if()

        }

        private void habilitarModificar()
        {
            this.txtCodigo.Enabled = false;
            this.btnBuscar.Enabled = false;
            this.txtNombre.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.btnBuscarUbicacion.Enabled = true;
            this.btnAccion.Enabled = true;
        }


        /*
         * Presionado el boton Registrar, debe:
         * Verificar que no hay espacios vacios y que se seleccionó la ubicación en el mapa
         *      En caso de ser así, se carga la Unidad Organizativa, la registra
         * */
        private void btnAccion_Click(object sender, EventArgs e)//Accion
        {
            TblUnidadOrganizativa unidadO = new TblUnidadOrganizativa()
            {
                codigo = this.txtCodigo.Text,
                nombre = this.txtNombre.Text,
                telefono = this.txtTelefono.Text,
                latitud = Convert.ToDecimal(this.varLat),
                logitud = Convert.ToDecimal(this.varLng)
            };

            if (comprobarEspacios())//comprueba espacios vacios
            {
                if(funcion == 0)//valida si agrega
                {
                    if (varComprobarSeleccion)//valida si selecciona en maps
                    {
                        this.dLUnidadO.registrarUnidadOrganizativa(unidadO);
                        MessageBox.Show("Unidad Organizativa se ha agregado correctamente", "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtCodigo.Text = "";
                        this.limpiarCampos();

                        if (this.checkDep.Checked)
                        {
                            TblDependenciaOrganizativa dependencia = new TblDependenciaOrganizativa();
                            dependencia.unidadCabecilla = this.cBoxDep.SelectedValue.ToString();
                            dependencia.unidadDependiente = this.txtCodigo.Text;
                            dLUnidadO.registrarDependencias(dependencia);
                        }
                    }
                }
                else if(funcion == 1)//Modificar
                {
                    this.dLUnidadO.modificarUnidad(unidadO);
                    MessageBox.Show("Unidad Organizativa se ha modificado correctamente", "Proceso aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.limpiarCampos();

                    if (this.checkDep.Checked)
                    {
                        Entidades.TblDependenciaOrganizativa dependencia = new TblDependenciaOrganizativa();
                        dependencia.unidadCabecilla = this.cBoxDep.SelectedValue.ToString();
                        dependencia.unidadDependiente = this.txtCodigo.Text;
                        dLUnidadO.modificarDependencias(dependencia);
                    }

                }
            }

            
        }

        public bool comprobarEspacios()
        {
            bool comprobar=false;
            if(!string.IsNullOrWhiteSpace(txtCodigo.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                comprobar = true;
            }
            return comprobar;
        }


        public void limpiarCampos() //Se le tiene que añadir el txtCodigo.Text = "", ya que el metodo no lo hace
        {
            this.txtCodigo.Text = "";
            this.cBoxDep.Enabled = false;
            this.txtNombre.Text = "";
            this.txtTelefono.Text = "";
            this.habilitarCampos(false);
            this.verificar();
        }

        public void verificar()//Busca si existen unidades organizativas y si pueden haber dependencias organizativas
        {
            this.checkDep.Enabled = false;
            if (this.dLUnidadO.verificarDependencias())//true si existe 1 o mas unidades
            {
                cargarUnidadesOrganizativas();
                this.checkDep.Enabled = true;
            }
            this.checkDep.Checked = false;
            this.cBoxDep.Enabled = false;

        }

        public void habilitarCampos(bool cond)
        {
            this.txtNombre.Enabled = cond;
            this.txtTelefono.Enabled = cond;
            this.btnBuscarUbicacion.Enabled = cond;
            this.checkDep.Enabled = false;
        }

        public void cargarUnidadesOrganizativas()//Cargar el comboBox con las unidades organizativas que existan
        {
            List<TblUnidadOrganizativa> unidades = this.dLUnidadO.cargarUnidadesDependencia();
            this.cBoxDep.DisplayMember = "nombre";
            this.cBoxDep.ValueMember = "codigo";
            this.cBoxDep.DataSource = unidades;
        }

        private void checkDep_CheckedChanged(object sender, EventArgs e)
        {
            if (checkDep.Checked)
            {
                this.cBoxDep.Enabled = true;
            }
            else
            {
                this.cBoxDep.Enabled = false;
            }
        }

        private void btnBuscarMaps_Click(object sender, EventArgs e)
        {
            MapasGoogle mapas;
            if (this.funcion == 1)
            {
                mapas = new MapasGoogle(this, this.varLat, this.varLng);
                mapas.Show();
            }
            else
            {
                mapas = new MapasGoogle(this);
                mapas.Show();
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void cargarUbicacion(double lat, double lng, bool sel)
        {
            this.varLat = lat;
            this.varLng = lng;
            this.varComprobarSeleccion = sel;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                try
                {
                    this.dLUnidadO = new LNUnidadOrganizativa();
                    if (dLUnidadO.verificarExistencia(this.txtCodigo.Text))//si existe
                    {
                        MessageBox.Show("El consumible ya se encuentra registrado", "Proceso aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtCodigo.Text = "";
                    }
                    else
                    {
                        txtNombre.Enabled = true;
                        txtTelefono.Enabled = true;
                        checkDep.Enabled = true;
                        btnBuscarUbicacion.Enabled = true;
                        btnAccion.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                }
                /*if (this.dLUnidadO.verificarExistencia(this.txtCodigo.Text))//Pregunta si existe la unidad organizativa, si existe, se carga todo y se modifica
                {
                    TblUnidadOrganizativa unidad = this.dLUnidadO.getUnidadO(this.txtCodigo.Text);
                    txtNombre.Text = unidad.nombre;
                    txtTelefono.Text = unidad.telefono;
                    this.varLat = Convert.ToDouble(unidad.latitud);
                    this.varLng = Convert.ToDouble(unidad.logitud);
                    this.habilitarCampos(true);

                    if (this.dLUnidadO.verificarDependenciaUO(this.txtCodigo.Text))//Verifica si la Unidad Cargada, tiene dependencias organizativas
                    {
                        this.checkDep.Checked = true;
                        this.checkDep.Enabled = true;
                        this.cBoxDep.Enabled = true;
                        TblDependenciaOrganizativa dep = this.dLUnidadO.getDependencia(unidad.codigo);//Se carga la dependencia(UnCabecilla, UnDependiente)
                        cBoxDep.SelectedIndex = this.cBoxDep.FindString((this.dLUnidadO.getUnidadO(dep.unidadCabecilla)).nombre);
                    }
                    else
                    {
                        this.checkDep.Checked = false;
                        this.checkDep.Enabled = true;
                        this.cBoxDep.Enabled = false;
                    }

                }*/
                /*else//si no existe, deja registrar
                {
                    this.limpiarCampos();
                    this.habilitarCampos(true);
                }*/
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtCodigo.Text = "";
            this.limpiarCampos();
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
