using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LogicaNegocio
{
    public class LNEmpleado
    {
        private DataTable datos;
        private ADEmpleado adEmpledo;

        public ADEmpleado AdEmpledo { get => adEmpledo; set => adEmpledo = value; }

        public bool consultarEmpleado(string cedula)
        {
            try
            {
                this.AdEmpledo = new ADEmpleado();
                return this.AdEmpledo.consultarEmpleado(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblEmpleado getEmpleado(string cedula)
        {
            try
            {
                this.AdEmpledo = new ADEmpleado();
                return this.AdEmpledo.getEmpleado(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblUbicacion getUbicacion(string cedula)
        {
            try
            {
                this.AdEmpledo = new ADEmpleado();
                return this.AdEmpledo.getUbicacion(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblPlaza getPlaza(string cedula)
        {
            try
            {
                this.AdEmpledo = new ADEmpleado();
                return this.AdEmpledo.getPlaza(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblDepartamento> getDepartamentos()
        {
            try
            {
                this.AdEmpledo = new ADEmpleado();
                return this.AdEmpledo.getDepartamentos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblDepartamento getDepartamento(string cedula)
        {
            try
            {
                this.AdEmpledo = new ADEmpleado();
                return this.AdEmpledo.getDep(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool registrarEmpleado(TblEmpleado empleado, TblUbicacion ubicacion, TblPlaza plaza)
        {
            bool registro = false;
            try
            {
                //this.entidades = new zensoftEntities();
                using (TransactionScope scope = new TransactionScope())
                {
                    this.AdEmpledo = new ADEmpleado();
                    registro = this.AdEmpledo.registrarEmpleado(empleado, ubicacion, plaza);
                    scope.Complete();
                }
                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool modificarEmpleado(TblEmpleado empleado, TblUbicacion ubicacion, TblPlaza plaza)
        {
            bool registro = false;
            try
            {
                //this.entidades = new zensoftEntities();
                using (TransactionScope scope = new TransactionScope())
                {
                    this.AdEmpledo = new ADEmpleado();
                    registro = this.AdEmpledo.modificarEmpleado(empleado, ubicacion, plaza);
                    scope.Complete();
                }
                return registro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Va a ir flitrando la cedula de los empleados a consultar
        public DataTable consultarEmpledos(string cedula)
        {
            try
            {
                //Se el acceso a dato del empleado
                this.AdEmpledo = new ADEmpleado();

                //Se instancian los datos para cargar el grid en la ventana
                this.datos = new DataTable();
                //Se crean las columnas de la tabla
                this.datos.Columns.Add("Cédula", typeof(string));
                this.datos.Columns.Add("Nombre", typeof(string));
                this.datos.Columns.Add("Teléfono", typeof(string));
                this.datos.Columns.Add("Sede", typeof(string));
                this.datos.Columns.Add("Departamento", typeof(string));
                this.datos.Columns.Add("Condición", typeof(string));

                //Se ejecuta consulta por la lista de empleados
                var listaEmpleados = this.AdEmpledo.obtenerEmpleadosCed(cedula);

                foreach (var le in listaEmpleados)
                {
                    DataRow fila = datos.NewRow();
                    fila.SetField<string>("Cédula", le.Cedula);
                    fila.SetField<string>("Nombre", le.Nombre);
                    fila.SetField<string>("Teléfono", le.Telefono);
                    fila.SetField<string>("Sede", le.Sede);
                    fila.SetField<string>("Departamento", le.Departamento);
                    fila.SetField<string>("Condición", le.Condicion);
                    this.datos.Rows.Add(fila);
                }
                return this.datos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static bool verificarEmpleado(string ced)
        {
            try
            {
                bool verificar = false;
                using (TransactionScope scope = new TransactionScope())
                {
                    verificar = ADEmpleado.verificarEmpl(ced);
                    scope.Complete();
                }
                return verificar;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string getNombre(string ced)
        {
            try
            {
                string nombre;
                using (TransactionScope scope = new TransactionScope())
                {
                    nombre = ADEmpleado.getNombre(ced);
                    scope.Complete();
                }
                return nombre;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
