using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADTraslados
    {
        public static int GenerarID()
        {
            zensoftEntities db = new zensoftEntities();
            List<TblTraslado> v = null;

            try
            {
                v = db.TblTraslado.OrderBy(t => t.idTraslado).ToList();
                if (v.Count != 0)
                {
                    return v.Max(t => t.idTraslado) + 1;
                }
                return v.Count + 1;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static bool RealizarTrasladoC(TblTrasladoConsumibles trasladoConsumible)
        {
            bool trasladoRealizado = false;
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblTrasladoConsumibles trasladoCns = db.TblTrasladoConsumibles.Where(c => c.idTraslado == trasladoConsumible.idTraslado).FirstOrDefault();
                    if (trasladoCns == null)
                    {
                        if (!VerificarCantidad(trasladoConsumible.codigo, trasladoConsumible.cantidad))
                        {
                            db.TblTrasladoConsumibles.Add(trasladoConsumible);
                            trasladoRealizado = true;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return trasladoRealizado;
        }

        public static bool RealizarTrasladoA(TblTrasladoActivo trasladoActivo)
        {
            bool trasladoRealizado = false;
            using(zensoftEntities db = new zensoftEntities())
            {
               try
                {
                    TblTrasladoActivo trasladoAct = db.TblTrasladoActivo.Where(ta => ta.idTraslado == trasladoActivo.idTraslado).FirstOrDefault();
                    if (trasladoAct == null)
                    {
                        if (!VerificarDisponibilidad(trasladoActivo.patrimonio))
                        {
                            db.TblTrasladoActivo.Add(trasladoActivo);
                            trasladoRealizado = true;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return trasladoRealizado;
        }

        private static bool VerificarDisponibilidad(string patrimonio)
        {
            bool disponibilidad = false;
            string d = "P";
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblActivos activo = db.TblActivos.Where(a => a.patrimonio == patrimonio).FirstOrDefault();
                    if (activo != null)
                    {
                        if (activo.disponibilidad.Equals(d))
                        {
                            disponibilidad = true;
                        }
                        else
                        {
                            activo.disponibilidad = "P";
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return disponibilidad;
            }
        }

        private static bool VerificarCantidad(string codigo, int cantidad )
        {
            bool v = false;
            int cantStock = 0;
            using(zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblConsumibles consumible = db.TblConsumibles.Where(c => c.codigo == codigo).FirstOrDefault();
                    if(consumible != null)
                    {
                        cantStock = Convert.ToInt32(consumible.stock);
                        if(cantStock < cantidad)
                        {
                            v = true;
                        }
                        else
                        {
                            consumible.stock = consumible.stock - cantidad;
                            db.SaveChanges();
                        }
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return v;
            }
        }

        public static void RealizarTraslado(TblTraslado traslado)
        {
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblTraslado encontrarTraslado = db.TblTraslado.Where(c => c.idTraslado == traslado.idTraslado).FirstOrDefault();
                    if (encontrarTraslado == null)
                    {
                        db.TblTraslado.Add(traslado);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
