using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADConsumible
    {
        public static List<string> getCodigos()
        {
            try
            {
                List<string> codigos = new List<string>();

                using (zensoftEntities db = new zensoftEntities())
                {
                    var codCons = db.SP_CNS_CONSUMIBLESDISPONIBLES();
                     
                    foreach (var cC in codCons)
                    {
                        codigos.Add(cC.Codigo);
                    }

                    return codigos;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool VerificarCod(string codigo)
        {
            bool verificar = false;
            using(zensoftEntities db= new zensoftEntities())
            {
                try
                {
                    TblConsumibles consumibleS = db.TblConsumibles.FirstOrDefault(c => c.codigo == codigo);
                    if(consumibleS != null)
                    {
                        verificar = true;
                    }
                    return verificar;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message); 
                }
            }
        }

        public static void InsertarCodigos(TblConsumibleSolicitado consumibleSolicitado)
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    db.TblConsumibleSolicitado.Add(consumibleSolicitado);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<SP_CNS_CONSUMIBLESSOLICITUD_Result> consumiblesSolicitados()
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    List<SP_CNS_CONSUMIBLESSOLICITUD_Result> consumiblesSoli = db.SP_CNS_CONSUMIBLESSOLICITUD().ToList();
                    return consumiblesSoli;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void eliminarSolicitudes()
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    List<TblConsumibleSolicitado> lista = db.TblConsumibleSolicitado.ToList();

                    for (int i = 0; i < lista.Count; i++)
                    {
                        db.TblConsumibleSolicitado.Remove(lista[i]);
                    }
                    db.SaveChanges();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool verificarGrid(string codigo)
        {
            bool está = false;
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblConsumibleSolicitado consumible = db.TblConsumibleSolicitado.Where(c => c.codigo == codigo).FirstOrDefault();
                    if (consumible != null)
                        está = true; 
                }
                return está;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool verificarCantidad(string codigo, int cantidad)
        {
            bool valido = false;
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblConsumibles consumible = db.TblConsumibles.Where(c => c.codigo == codigo).FirstOrDefault();
                    if(consumible.stock >= cantidad)
                    {
                        valido = true;
                    }
                }
                return valido;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static bool modificarConsuValido(TblConsumibleSolicitado consumibleSolicitado)
        {
            bool valido = false;
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblConsumibleSolicitado consumibleSoli = db.TblConsumibleSolicitado.Where(c => c.codigo == consumibleSolicitado.codigo).FirstOrDefault();
                    TblConsumibles consumible = db.TblConsumibles.Where(c => c.codigo == consumibleSolicitado.codigo).FirstOrDefault();
                    if (consumible.stock >= (consumibleSoli.cantidad + consumibleSolicitado.cantidad))
                    {
                        valido = true;
                        TblConsumibleSolicitado cs = db.TblConsumibleSolicitado.First(c => c.codigo == consumibleSolicitado.codigo);
                        cs.cantidad = (consumibleSoli.cantidad + consumibleSolicitado.cantidad);
                        db.SaveChanges();
                    }
                }
                return valido;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static string cargarStock(string cod)
        {
            try
            {
                String stock = "";
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblConsumibles consumible = db.TblConsumibles.Where(c => c.codigo == cod).FirstOrDefault();
                    if (consumible != null)
                        stock += consumible.stock.ToString();
                    else
                        stock += "0";
                }
                return stock;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        zensoftEntities entidades;
        public static void AgregarConsumible(TblConsumibles consumible)
        {
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblConsumibles encontrarConsumibles = db.TblConsumibles.Where(c => c.codigo == consumible.codigo).FirstOrDefault();
                    if (encontrarConsumibles == null)
                    {
                        db.TblConsumibles.Add(consumible);
                        db.SaveChanges();
                    }
                }
                catch (Exception ex)z
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public bool ConsultarConsumible(string codigo)
        {
            bool existe = false;
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblConsumibles consumible = db.TblConsumibles.FirstOrDefault(c => c.codigo == codigo);
                    if (consumible != null)
                    {
                        existe = true;
                    }
                    return existe;
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

        public List<SP_CNS_CONSUMIBLES2_Result> obtenerConsumiblesCod(string codigo)
        {
            try
            {
                using (zensoftEntities entidades = new zensoftEntities())
                {
                    List<SP_CNS_CONSUMIBLES2_Result> consumibles = entidades.SP_CNS_CONSUMIBLES2(codigo).ToList();
                    return consumibles;
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

        public TblConsumibles getConsumible(string codigo)
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblConsumibles.FirstOrDefault(c => c.codigo.Equals(codigo));
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

        public static void ModificarConsumible(TblConsumibles consumible)
        {
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblConsumibles encontrarConsumibles = db.TblConsumibles.Where(c => c.codigo == consumible.codigo).FirstOrDefault();
                    encontrarConsumibles.codigo = consumible.codigo;
                    encontrarConsumibles.nombre = consumible.nombre;
                    encontrarConsumibles.marca = consumible.marca;
                    encontrarConsumibles.modelo = consumible.modelo;
                    encontrarConsumibles.numeroSerie = consumible.numeroSerie;
                    encontrarConsumibles.descripción = consumible.descripción;
                    encontrarConsumibles.stock = consumible.stock;
                    encontrarConsumibles.unidadMedida = consumible.unidadMedida;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
