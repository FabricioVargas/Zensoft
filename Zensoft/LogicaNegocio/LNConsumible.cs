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
    public class LNConsumible
    {
        private ADConsumible adConsumible;
        private DataTable datos;
        public List<string> getCodigos()
        {
            try
            {
                return ADConsumible.getCodigos();
            } 
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool VerificarCod(string codigo)
        {
            try
            {
                return ADConsumible.VerificarCod(codigo);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public void InsertarCodigos(TblConsumibleSolicitado consumibleSolicitado)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ADConsumible.InsertarCodigos(consumibleSolicitado);
                    scope.Complete();
                }
            }
            catch(Exception e)
            {
                 throw new Exception(e.Message);
            }
        }

        public DataTable CargarTabla()
        {
            try
            {
                ADConsumible  adconsumible = new ADConsumible();

                this.datos = new DataTable();
                this.datos.Columns.Add("Código", typeof(string));
                this.datos.Columns.Add("Nombre", typeof(string));
                this.datos.Columns.Add("Marca", typeof(string));
                this.datos.Columns.Add("Descripción", typeof(string));
                this.datos.Columns.Add("Unidad Medida", typeof(string));
                this.datos.Columns.Add("Cantidad", typeof(string));

                var listaC = adconsumible.consumiblesSolicitados();

                foreach (var lc in listaC)
                {
                    DataRow fila = datos.NewRow();
                    fila.SetField<string>("Código", lc.Codigo);
                    fila.SetField<string>("Nombre", lc.Nombre);
                    fila.SetField<string>("Marca", lc.Marca);
                    fila.SetField<string>("Descripción", lc.Descripcion);
                    fila.SetField<string>("Unidad Medida", lc.UnidadMedida);
                    fila.SetField<string>("Cantidad", lc.Cantidad.ToString());
                    this.datos.Rows.Add(fila);
                }

                return this.datos;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool verificarGrid(string codigo)
        {
            try
            {
                return ADConsumible.verificarGrid(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool verificarCantidad(string codigo, int cantidad)
        {
            try
            {
                return ADConsumible.verificarCantidad(codigo, cantidad);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void vaciar()
        {
            try
            {
                ADConsumible ADConsumible = new ADConsumible();
                using (TransactionScope scope = new TransactionScope())
                {
                    ADConsumible.eliminarSolicitudes();
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string cargarStock(string cod)
        {
            try
            {
                return ADConsumible.cargarStock(cod);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static bool ModificarConsumibleCantidad(TblConsumibleSolicitado consumibleSolicitado)
        {
            try
            {
                return ADConsumible.modificarConsuValido(consumibleSolicitado);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public static bool eliminarConsumibleSolicitado(string cod)
        {
            try
            {
                ADActivos aDActivos = new ADActivos();
                    bool eliminado = false;
                using (TransactionScope scope = new TransactionScope())
                {
                    if(aDActivos.Eliminado(cod))
                    {
                        eliminado = true;
                    }
                    scope.Complete();
                }
                return eliminado;

            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public static void AgregarConsunible(TblConsumibles consumible)
        {

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ADConsumible.AgregarConsumible(consumible);
                    scope.Complete();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ConsultarConsumibles(string codigo)
        {
            try
            {
                ADConsumible adConsumible = new ADConsumible();

                this.datos = new DataTable();

                this.datos.Columns.Add("Código", typeof(string));
                this.datos.Columns.Add("Nombre", typeof(string));
                this.datos.Columns.Add("Marca", typeof(string));
                this.datos.Columns.Add("Modelo", typeof(string));
                this.datos.Columns.Add("Serie", typeof(string));
                this.datos.Columns.Add("Descripción", typeof(string));
                this.datos.Columns.Add("Stock", typeof(string));
                this.datos.Columns.Add("Unidad", typeof(string));

                var listaConsumibles = adConsumible.obtenerConsumiblesCod(codigo);

                foreach (var lc in listaConsumibles)
                {
                    DataRow fila = this.datos.NewRow();
                    fila.SetField<string>("Código", lc.Codigo);
                    fila.SetField<string>("Nombre", lc.Nombre);
                    fila.SetField<string>("Marca", lc.Marca);
                    fila.SetField<string>("Modelo", lc.Modelo);
                    fila.SetField<string>("Serie", lc.Serie);
                    fila.SetField<string>("Descripción", lc.Descripcion);
                    fila.SetField<int>("Stock", int.Parse(lc.Stock.ToString()));
                    fila.SetField<string>("Unidad", lc.Unidad);
                    this.datos.Rows.Add(fila);
                }
                return this.datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ConsultarConsumible(string codigo)
        {
            try
            {
                this.adConsumible = new ADConsumible();
                return adConsumible.ConsultarConsumible(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblConsumibles getConsumible(string codigo)
        {
            try
            {
                this.adConsumible = new ADConsumible();
                return this.adConsumible.getConsumible(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void ModificarConsumible(TblConsumibles consumible)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    ADConsumible.ModificarConsumible(consumible);
                    scope.Complete();
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

    }
}
