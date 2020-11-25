using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADMovimientos
    {

        //Referencia a las  entidades de la BD
        private zensoftEntities entidades;

        public void registrarMovimientoAct(TblMovimiento mov, List<SP_CNS_ACTIVO_Result> listaAct)
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    int idMov = mov.idMovimiento;
                    this.entidades.TblMovimiento.Add(mov);
                    this.entidades.SaveChanges();
                    for (int i = 0; i < listaAct.Count; i++)
                    {
                        this.entidades.SP_INS_MOVACTIVO(listaAct[i].Patrimonio);
                        if (mov.accion.Equals("D"))
                        {
                            string pat = listaAct[i].Patrimonio;
                            //this.entidades.SP_UPD_PRESTAMORESUELTO(idMov, pat);
                        }
                    }
                    this.entidades.SaveChanges();
                }
            }
            catch (EntityException ex)
            {
                throw ex;
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
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.SP_CNS_PRESTAMOSxEMPLEADO(cedula).ToList();
                }
            }
            catch (EntityException ex)
            {
                throw ex;
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
                using (this.entidades = new zensoftEntities())
                {
                    TblMovimiento mov = this.entidades.TblMovimiento.FirstOrDefault(m => m.idMovimiento == idMov);
                    if (mov != null)
                    {
                        return mov;
                    }
                }
                return null;
            }
            catch (EntityException ex)
            {
                throw ex;
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
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.SP_CNS_ACTIVOSPRESTAMO(idMov).ToList();
                }
            }
            catch (EntityException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SP_CNS_CONSUMIBLE_FECHAS2_Result> obtenerListaPorFechas(DateTime desde, DateTime hasta)
        {
            try
            {
               using (zensoftEntities db = new zensoftEntities())
               {
                    List<SP_CNS_CONSUMIBLE_FECHAS2_Result> consumibles = db.SP_CNS_CONSUMIBLE_FECHAS2(desde,hasta).ToList();
                    return consumibles;
                }
            }
               catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void realizarEntrega(TblMovimiento movimiento)
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    db.TblMovimiento.Add(movimiento);
                    db.SaveChanges();

                    List<TblConsumibleSolicitado> lista = db.TblConsumibleSolicitado.ToList();


                    for (int i = 0; i < lista.Count; i++)
                    {
                        db.SP_INS_MOVCONSUMIBLE(lista[i].codigo, lista[i].cantidad);
                    }
                    db.SaveChanges();
                }
            }
            catch (EntityException e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
