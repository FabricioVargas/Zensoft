using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LogicaNegocio;
using System.Linq;
using Entidades;
using System.Text.RegularExpressions;
using System.Drawing;

namespace Zensoft
{
    public partial class FRMIMEmpleado : Form
    {
        private List<string> listaCantones;
        private List<string> listaDistritos;
        private ManejoCantones manejoCantones;
        private ManejoDistritos manejoDistritos;
        private LNEmpleado procesosEmpleado;
        private LNUnidadOrganizativa lnUnidadOrg;
        public int funcion;
        public string cedula;
        private FrmEmpleados frmEmpleados;
        private Validations mailValidation;

        public FRMIMEmpleado(FrmEmpleados frmEmpleados)
        {
            InitializeComponent();
            this.frmEmpleados = frmEmpleados;
        }

        private void FRMIMEmpleado_Load(object sender, EventArgs e)
        {
            this.llenarSedes();
            this.llenarDepartamentos();
            if (this.funcion == 1)
            {
                this.btnAcciones.Text = "&Modificar";
                this.llenarDatos();
                this.habilitarModificar();
                this.Text = "Modificar Empleado";
            }
        }

        private void llenarDepartamentos()
        {
            try
            {
                //Se instancias la logica de negocio
                this.procesosEmpleado = new LNEmpleado();

                List<TblDepartamento> departamentos = this.procesosEmpleado.getDepartamentos();

                this.cboxDepartamento.DisplayMember = "nombre";
                this.cboxDepartamento.ValueMember = "idDepartamento";
                this.cboxDepartamento.DataSource = departamentos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void llenarSedes()
        {
            try
            {
                //se instancia la logica de negocios del empleado
                this.lnUnidadOrg = new LNUnidadOrganizativa();

                //Se obtiene la lista de sedes y recintos
                List<TblUnidadOrganizativa> unidadesOrg = this.lnUnidadOrg.getUnidadesOrg();

                this.cboxSede.DisplayMember = "nombre";
                this.cboxSede.ValueMember = "codigo";
                this.cboxSede.DataSource = unidadesOrg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void habilitarModificar()
        {
            this.btnAcciones.Enabled = true;
            this.btnConsultar.Visible = false;
            this.txtCedula.Enabled = false;
            this.txtNombre.Enabled = false;
            this.txtCorreo.Enabled = true;
            this.txtTelefono.Enabled = true;
            this.cboxProvincia.Enabled = true;
            this.cboxCanton.Enabled = true;
            this.cboxDistrito.Enabled = true;
            this.txtDireccion.Enabled = true;
            this.cboxSede.Enabled = true;
        }

        //Metodo para llenar los cantones según la provincia seleccionada
        private void cboxProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Se limpian las listas en caso de contener datos
                this.cboxCanton.Items.Clear();
                this.cboxDistrito.Items.Clear();
                this.cboxDistrito.Enabled = false;

                //Se llena el como box con los cantones de la provincia seleccionada
                this.llenarCantones();

                //Se habilita el combobox de cantones
                this.cboxCanton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llenarCantones()
        {
            //Se instancia la clase que gestiona los cantones
            this.manejoCantones = new ManejoCantones();
            //Se llena la listaCantones con el metodo para obtener los cantones con relacion a la provincia de SJ
            this.listaCantones = this.manejoCantones.obtenerCantones(this.cboxProvincia.SelectedIndex);

            //Se procede a llenar el combo box de cantones de la provincia de SJ
            for (int i = 0; i < listaCantones.Count; i++)
            {
                this.cboxCanton.Items.Add(listaCantones[i]);
            }
            //Se libera memoria
            this.listaCantones = null;
            this.manejoCantones = null;
        }

        //Metodo para llenar los distritos según la provincia y canton seleccionados
        private void cboxCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Se limpia la lista de distritos en caso de contener datos
                this.cboxDistrito.Items.Clear();

                //Se llena el combobox con los distritos del cantón seleccionado
                this.llenarDistritos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void llenarDistritos()
        {
            //Se habilita el combobox de distritos
            this.cboxDistrito.Enabled = true;
            //Se instancia la clase para el manejo de los distritos
            this.manejoDistritos = new ManejoDistritos();
            //Acciones para la seleccion de la provincia de SJ         
            listaDistritos = this.manejoDistritos.obtenerDistritos(this.cboxProvincia.SelectedIndex, this.cboxCanton.SelectedIndex);

            //Se llena el combobox de distritos
            for (int i = 0; i < listaDistritos.Count; i++)
            {
                this.cboxDistrito.Items.Add(this.listaDistritos[i]);
            }
            //Se libera memoria
            this.listaDistritos = null;
            this.manejoDistritos = null;
        }

        private void cboxSede_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboxDepartamento.Enabled = true;
            this.cboxCondicion.Enabled = true;
        }

        //Corregir acá
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                int result;
                if(!string.IsNullOrWhiteSpace(this.txtCedula.Text) && int.TryParse(this.txtCedula.Text, out result))
                {
                    procesosEmpleado = new LNEmpleado();
                    if (procesosEmpleado.consultarEmpleado(this.txtCedula.Text.Trim()))
                    {
                        MessageBox.Show("Este empleado ya se encuentra registrado", "Proceso Aplicado",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        this.txtNombre.Enabled = true;
                        this.txtTelefono.Enabled = true;
                        this.txtCorreo.Enabled = true;
                        this.cboxProvincia.Enabled = true;
                        this.cboxSede.Enabled = true;
                        this.btnAcciones.Enabled = true;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void cboxCondicion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cboxCondicion.SelectedIndex == 0)
            {
                this.lblPlaza.Visible = true;
                this.txtPlaza.Visible = true;
            }
            else
            {
                this.lblPlaza.Visible = false;
                this.txtPlaza.Visible = false;
                this.txtPlaza.Text = "";
            }
        }

        private void cboxDistrito_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se habilita el campo de direccion
            this.txtDireccion.Enabled = true;
        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ComprobarDatos())
                {
                    TblEmpleado empleado = new TblEmpleado
                    {
                        cedula = this.txtCedula.Text.Trim(),
                        nombre = this.txtNombre.Text.Trim(),
                        telefono = this.txtTelefono.Text.Trim(),
                        correo = this.txtCorreo.Text.Trim(),
                        condicion = this.cboxCondicion.Text.Substring(0, 1),
                        estado = "A",
                        codigoSede = this.cboxSede.SelectedValue.ToString(),
                        idDepartamento = this.cboxDepartamento.SelectedValue.ToString()
                    };

                    TblUbicacion ubicacion = new TblUbicacion
                    {
                        cedula = this.txtCedula.Text,
                        provincia = this.cboxProvincia.SelectedItem.ToString(),
                        canton = this.cboxCanton.SelectedItem.ToString(),
                        distrito = this.cboxDistrito.SelectedItem.ToString(),
                        direccion = this.txtDireccion.Text.Trim()
                    };

                    TblPlaza plaza = null;
                    if (this.cboxCondicion.SelectedIndex == 0 && !string.IsNullOrEmpty(this.txtPlaza.Text))
                    {
                        plaza = new TblPlaza()
                        {
                            cedula = this.txtCedula.Text.Trim(),
                            numPlaza = this.txtPlaza.Text.Trim()
                        };
                    }
                    if (funcion == 0)
                    {
                        if (this.procesosEmpleado.registrarEmpleado(empleado, ubicacion, plaza))
                        {
                            MessageBox.Show("Empleado registrado correctamente", "Proceso Aplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.frmEmpleados.recargarTabla();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (this.procesosEmpleado.modificarEmpleado(empleado, ubicacion, plaza))
                        {
                            MessageBox.Show("Empleado modificado correctamente", "Proceso Aplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.frmEmpleados.recargarTabla();
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proceso Aplicado",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ComprobarDatos()
        {
            bool correcto = false;
            mailValidation = new Validations();
            int result;

            if (!string.IsNullOrWhiteSpace(this.txtCedula.Text.Trim()) && int.TryParse(this.txtCedula.Text.Trim(), out result))
            {
                if (!string.IsNullOrWhiteSpace(this.txtNombre.Text.Trim()))
                {
                    if (!string.IsNullOrWhiteSpace(this.txtTelefono.Text.Trim()) && int.TryParse(this.txtTelefono.Text.Trim(), out result))
                    {
                        if (this.mailValidation.IsValidEmail(txtCorreo.Text.Trim()))
                        {
                            if (!string.IsNullOrWhiteSpace(this.txtDireccion.Text.Trim()))
                            {
                                if (!string.IsNullOrEmpty(this.cboxCanton.Text.Trim()))
                                {
                                    if (!string.IsNullOrEmpty(this.cboxDistrito.Text.Trim()))
                                    {
                                        if (!string.IsNullOrEmpty(this.cboxSede.Text.Trim()))
                                        {
                                            if (!string.IsNullOrEmpty(this.cboxDepartamento.Text.Trim()))
                                            {
                                                if (!string.IsNullOrEmpty(this.cboxCondicion.Text.Trim()))
                                                {
                                                    correcto = true;
                                                    if (this.cboxCondicion.Text.Equals("Propiedad") && string.IsNullOrEmpty(this.txtPlaza.Text.Trim()) && int.TryParse(this.txtPlaza.Text.Trim(), out result))
                                                    {
                                                        MessageBox.Show("El número de plaza está en el formato incorrecto", "Proceso Aplicado",
                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                        correcto = false;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Por favor seleccionar condición laboral", "Proceso Aplicado",
                                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Por favor seleccionar un departamento", "Proceso Aplicado",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Por favor seleccionar una sede o recinto", "Proceso Aplicado",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Por favor seleccionar un distrito", "Proceso Aplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Por favor seleccionar un cantón", "Proceso Aplicado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La dirección está en el formato incorrecto", "Proceso Aplicado",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El correo electrónico está en el formato incorrecto", "Proceso Aplicado",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El teléfono está en el formato incorrecto. Ejemplo de uso: ########", "Proceso Aplicado",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("El nombre está en el formato incorrecto", "Proceso Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("La cédula está en el formato incorrecto. Ejemplo de uso: #########", "Proceso Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return correcto;
        }

        public void llenarDatos()
        {
            this.procesosEmpleado = new LNEmpleado(); ;
            //Se obtienen los datos del empleado
            TblEmpleado empleado = this.procesosEmpleado.getEmpleado(this.cedula);
            TblUbicacion ubicacion = this.procesosEmpleado.getUbicacion(this.cedula);
            TblPlaza plaza = this.procesosEmpleado.getPlaza(this.cedula);

            //Se procede a llenar los datos del empleado
            this.txtCedula.Text = empleado.cedula;
            this.txtNombre.Text = empleado.nombre;
            this.txtTelefono.Text = empleado.telefono;
            this.txtCorreo.Text = empleado.correo;
            for (int i = 0; i < this.cboxSede.Items.Count; i++)
            {
                if (this.cboxSede.ValueMember.Equals(this.cboxDepartamento.SelectedValue = this.procesosEmpleado.getDepartamento(this.cedula).idDepartamento))
                {
                    cboxSede.SelectedIndex = i;
                }
            }
            //this.cboxSede.SelectedIndex = this.cboxSede.FindStringExact(empleado.sede);

            //Datos de ubicacion
            this.cboxProvincia.SelectedIndex = this.cboxProvincia.FindString(ubicacion.provincia);
            this.llenarCantones();
            this.cboxCanton.SelectedIndex = this.cboxCanton.FindString(ubicacion.canton);
            this.llenarDistritos();
            this.cboxDistrito.SelectedIndex = this.cboxDistrito.FindString(ubicacion.distrito);
            this.txtDireccion.Text = ubicacion.direccion;

            //Datos de condición y plaza en caso de tener propiedad como condición
            this.cboxCondicion.SelectedIndex = this.cboxCondicion.FindString(empleado.condicion);
            if (plaza != null)
            {
                this.lblPlaza.Visible = true;
                this.txtPlaza.Text = plaza.numPlaza;
                this.txtPlaza.Visible = true;
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.frmEmpleados.recargarTabla();
            this.Dispose();
            this.Close();
        }
    }
}