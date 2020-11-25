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
    public class LNMovimientos
    {
        private ADMovimientos adMovmiento;

        public bool registrarMovimientoAct(TblMovimiento mov, List<SP_CNS_ACTIVO_Result> listaAct)
        {
            try
            {
                bool registrado = false;
                using (TransactionScope scope = new TransactionScope())
                {
                    this.adMovmiento = new ADMovimientos();
                    this.adMovmiento.registrarMovimientoAct(mov, listaAct);
                    registrado = true;
                    scope.Complete();
                }
                return registrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_CNS_PRESTAMOSxEMPLEADO_Result> obtenerPrestamosEmpleado(string cedula)
        {
            try
            {
                this.adMovmiento = new ADMovimientos();
                return this.adMovmiento.obtenerPrestamosEmpleado(cedula);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TblMovimiento getMovimiento(int idMov)
        {
            try
            {
                this.adMovmiento = new ADMovimientos();
                return this.adMovmiento.getMovimiento(idMov);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_CNS_ACTIVOSPRESTAMO_Result> getPrestamo(int idMov)
        {
            try
            {
                this.adMovmiento = new ADMovimientos();
                return this.adMovmiento.getPrestamo(idMov);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable generarGVconFechas(DateTime desde, DateTime hasta)
        {
            try
            {
                ADMovimientos adMovimientos = new ADMovimientos();
                DataTable datos = new DataTable();

                datos.Columns.Add("Código", typeof(string));
                datos.Columns.Add("Nombre", typeof(string));
                datos.Columns.Add("Marca", typeof(string));
                //datos.Columns.Add("Modelo", typeof(string));
                datos.Columns.Add("Fecha", typeof(string));
                datos.Columns.Add("Nombre empleado asignado", typeof(string));
                datos.Columns.Add("Cantidad", typeof(string));
                datos.Columns.Add("Observación", typeof(string));

                var listaConsumibles = adMovimientos.obtenerListaPorFechas(desde, hasta);

                foreach (var lc in listaConsumibles)
                {
                    DataRow fila = datos.NewRow();
                    fila.SetField<string>("Código", lc.Código);
                    fila.SetField<string>("Nombre", lc.NombreC);
                    fila.SetField<string>("Marca", lc.Marca);
                    fila.SetField<string>("Fecha", lc.Fecha.ToString());
                    fila.SetField<string>("Nombre empleado asignado", lc.NombreE);
                    fila.SetField<string>("Cantidad", lc.Cantidad.ToString());
                    fila.SetField<string>("Observación", lc.Observacíón);

                    datos.Rows.Add(fila);
                }
                return datos;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void realizarEntrega(TblMovimiento movimiento)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                ADMovimientos adMo = new ADMovimientos();
                adMo.realizarEntrega(movimiento);
                scope.Complete();
            }
        }
    }
}
