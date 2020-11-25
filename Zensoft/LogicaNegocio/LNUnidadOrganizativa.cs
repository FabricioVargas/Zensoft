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
    public class LNUnidadOrganizativa
    {
        //Se referencia la conexion a la BD
        private ADUnidadOrganizativa adUnidadOrg;
        private ADUnidadOrganizativa dataAccessUO;
        private DataTable datos;

        public bool registrarUnidadOrganizativa(TblUnidadOrganizativa unidadO)
        {
            bool conExito = false;
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    this.dataAccessUO = new ADUnidadOrganizativa();
                    conExito = this.dataAccessUO.registrarUnidadOrganizativa(unidadO);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conExito;
        }

        public bool registrarDependencias(TblDependenciaOrganizativa dependencias)
        {
            bool conExito = false;
            try
            {
                this.dataAccessUO = new ADUnidadOrganizativa();
                conExito = this.dataAccessUO.registrarDependenciasOrganizativas(dependencias);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return conExito;
        }

        //Carga el combo box que sugiere las dependencias organizativas
        public List<TblUnidadOrganizativa> cargarUnidadesDependencia()
        {
            try
            {
                this.dataAccessUO = new ADUnidadOrganizativa();
                return this.dataAccessUO.cargarDependecias();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool verificarDependencias()
        {
            try
            {
                this.dataAccessUO = new ADUnidadOrganizativa();
                return dataAccessUO.existenUnidades();//Se carga en dependencias si existe mas de una unidad organizativa

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TblUnidadOrganizativa> GetAllUnidadesSalida()
        {
            this.dataAccessUO = new ADUnidadOrganizativa();
            return dataAccessUO.GetAllUnidadesS();
        }

        public bool verificarExistencia(string codigo)//Verifica la existencia de una unidad organizativa
        {
            try
            {
                this.dataAccessUO = new ADUnidadOrganizativa();
                return dataAccessUO.consultarUO(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool verificarDependenciaUO(string codigo)//verifica si esa UO es dependiente
        {
            try
            {
                this.dataAccessUO = new ADUnidadOrganizativa();
                return dataAccessUO.verificarDependencia(codigo);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public TblUnidadOrganizativa getUnidadO(string idUnidad)
        {
            this.dataAccessUO = new ADUnidadOrganizativa();
            return this.dataAccessUO.getUnidadO(idUnidad);
        }

        public TblDependenciaOrganizativa getDependencia(string idiDepen)
        {
            this.dataAccessUO = new ADUnidadOrganizativa();
            return this.dataAccessUO.getDependiente(idiDepen);
        }

        public bool removeUnidadOrganizativa(string codigo)
        {
            this.dataAccessUO = new ADUnidadOrganizativa();
            return this.dataAccessUO.removeUnOr(codigo);
        }

        public void modificarUnidad(TblUnidadOrganizativa unidad)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ADUnidadOrganizativa.modificarUnidad(unidad);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Va a ir flitrando la cedula de los empleados a consultar
        public DataTable consultarUnidadesOrganizacionales(string codigo)
        {
            try
            {
                this.dataAccessUO = new ADUnidadOrganizativa();

                //Se instancian los datos para cargar el grid en la ventana
                this.datos = new DataTable();
                //Se crean las columnas de la tabla
                this.datos.Columns.Add("Código", typeof(string));
                this.datos.Columns.Add("Nombre", typeof(string));
                this.datos.Columns.Add("Teléfono", typeof(string));

                //Se ejecuta consulta por la lista de empleados
                var listaUnidadesO = this.dataAccessUO.obtenerUnidadesOrgCod(codigo);

                foreach (var le in listaUnidadesO)
                {
                    DataRow fila = datos.NewRow();
                    fila.SetField<string>("Código", le.Codigo);
                    fila.SetField<string>("Nombre", le.Nombre);
                    fila.SetField<string>("Teléfono", le.Telefono);
                    this.datos.Rows.Add(fila);
                }
                return this.datos;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void modificarDependencias(TblDependenciaOrganizativa dependencia)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                this.dataAccessUO = new ADUnidadOrganizativa();
                this.dataAccessUO.modificarDependencia(dependencia); //Hacer
                scope.Complete();
            }
        }

        public List<TblUnidadOrganizativa> getUnidadesOrg()
        {
            try
            {
                //Se instancia la conexion
                this.adUnidadOrg = new ADUnidadOrganizativa();
                return this.adUnidadOrg.getUnidadesOrg();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
