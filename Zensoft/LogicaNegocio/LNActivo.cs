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
    public class LNActivo
    {
        private ADActivos aDActivos;

        public List<string> getPatrimonios()
        {
            try
            {
                //Instancia de Acceso a datos
                this.aDActivos = new ADActivos();
                //Se ejecuta la consulta
                return this.aDActivos.getPatrimonios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SP_CNS_ACTIVO_Result getActivoSolicitado(string patrimonio)
        {
            try
            {
                //Instancia de Acceso a Datos
                this.aDActivos = new ADActivos();
                return this.aDActivos.getActivoSolicitado(patrimonio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool registrarSolicitud(string patrimonio)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //Se instancia el acceso a datos
                    this.aDActivos = new ADActivos();
                    this.aDActivos.registrarSolicitud(patrimonio);
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool elimiarSolicitudes()
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    //Instancia al acceso a datos
                    this.aDActivos = new ADActivos();
                    this.aDActivos.elimiarSolicitudes();
                    scope.Complete();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool eliminarActivoSolicitado(string patrimonio)
        {
            try
            {
                bool eliminado = false;
                using (TransactionScope scope = new TransactionScope())
                {
                    //Instancia del acceso a datos
                    this.aDActivos = new ADActivos();
                    if (this.aDActivos.eliminarActivoSolicitado(patrimonio))
                    {
                        eliminado = true;
                    }
                    scope.Complete();
                }
                return eliminado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void agregarActivo(TblActivos activo)
        {
            ADActivos ADActivos = new ADActivos();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ADActivos.agregarActivo(activo);
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception (e.Message);
            }
        }

        public DataTable consultarActivos(string patrimonio)
        {
            try
            {
                ADActivos adActivos = new ADActivos();
                DataTable datos = new DataTable();

                datos.Columns.Add("Patrimonio", typeof(string));
                datos.Columns.Add("Nombre", typeof(string));
                datos.Columns.Add("Marca", typeof(string));
                datos.Columns.Add("Modelo", typeof(string));
                datos.Columns.Add("Serie", typeof(string));
                datos.Columns.Add("Estado", typeof(string));
                datos.Columns.Add("Disponibilidad", typeof(string));

                var listaActivos = adActivos.obtenerListaActivos(patrimonio);

                foreach (var la in listaActivos)
                {
                    DataRow fila = datos.NewRow();
                    fila.SetField<string>("Patrimonio", la.Patrimonio);
                    fila.SetField<string>("Nombre", la.Nombre);
                    fila.SetField<string>("Marca", la.Marca);
                    fila.SetField<string>("Modelo", la.Modelo);
                    fila.SetField<string>("Serie", la.Serie);
                    fila.SetField<string>("Estado", la.Estado);
                    fila.SetField<string>("Disponibilidad", la.Disponibilidad);
                    datos.Rows.Add(fila);
                }
                return datos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool consultar(string patrimonio)
        {
            ADActivos ADActivos = new ADActivos();
            try
            {
                return ADActivos.consultarActivo(patrimonio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static TblActivos consultarActivoPat(string patrimonio)
        {
            ADActivos ADActivos = new ADActivos();
            try
            {
                return ADActivos.consultarActivoPat(patrimonio);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void modificarActivo(TblActivos activos)
        {
            ADActivos ADActivos = new ADActivos();
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ADActivos.modificar(activos);
                    scope.Complete();
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
