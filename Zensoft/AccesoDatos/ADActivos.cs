using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccesoDatos
{
    public class ADActivos
    {

        private zensoftEntities entidades;
        public void agregarActivo(TblActivos activo)
        {
            zensoftEntities db = new zensoftEntities();
            TblActivos encontrar = db.TblActivos.Where(a => a.patrimonio == activo.patrimonio).FirstOrDefault();
            if (encontrar == null)
            {
                db.TblActivos.Add(activo);
                db.SaveChanges();
            }
        }

        public List<SP_CNS_ACTIVOS_Result> obtenerListaActivos(string patrimomio)
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    List<SP_CNS_ACTIVOS_Result> activos = db.SP_CNS_ACTIVOS(patrimomio).ToList();
                    return activos;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TblActivos consultarActivoPat(string patrimonio)
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblActivos activo = db.TblActivos.FirstOrDefault(a => a.patrimonio == patrimonio);

                    return activo;
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void modificar(TblActivos activo)
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblActivos act = db.TblActivos.First(a => a.patrimonio == activo.patrimonio);
                    act.patrimonio = activo.patrimonio;
                    act.nombre = activo.nombre;
                    act.marca = activo.marca;
                    act.modelo = activo.modelo;
                    act.descripcion = activo.descripcion;
                    act.serie = activo.serie;
                    act.estado = activo.estado;
                    act.disponibilidad = activo.disponibilidad;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Eliminado(string cod)
        {
            try
            {
                using (zensoftEntities db = new zensoftEntities())
                {
                    TblConsumibleSolicitado consumibleSolicitado = db.TblConsumibleSolicitado.FirstOrDefault(c => c.codigo.Equals(cod));
                    db.TblConsumibleSolicitado.Remove(consumibleSolicitado);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (EntityException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<string> getPatrimonios()
        {
            try
            {
                //Lista para los nombres de los activos disponibles
                List<string> patrimonios = new List<string>();
                //Instancia de las entidades de la BD
                using (this.entidades = new zensoftEntities())
                {
                    var patAct = this.entidades.SP_CNS_ACTIVOSDISPONIBLES();

                    foreach (var pA in patAct)
                    {
                        patrimonios.Add(pA.Patrimonio);
                    }

                    return patrimonios;
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

        public SP_CNS_ACTIVO_Result getActivoSolicitado(string patrimonio)
        {
            try
            {
                //Se instancias las entidade de la BD
                using (this.entidades = new zensoftEntities())
                {
                    //Se consulta el patrimonio recibido
                    List<SP_CNS_ACTIVO_Result> activo = this.entidades.SP_CNS_ACTIVO(patrimonio).ToList();

                    return activo[0];
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

        public bool consultarActivo(string patrimonio)
        {
            try
            {
                bool existe = false;
                using (this.entidades = new zensoftEntities())
                {
                    TblActivos activo = this.entidades.TblActivos.FirstOrDefault(a => a.patrimonio.Equals(patrimonio));
                    if (activo != null)
                        existe = true;

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

        public bool registrarSolicitud(string patrimonio)
        {
            try
            {
                bool registro = false;
                using (this.entidades = new zensoftEntities())
                {
                    TblActivoSolicitado activo = new TblActivoSolicitado();
                    activo.patrimonio = patrimonio;
                    this.entidades.TblActivoSolicitado.Add(activo);
                    this.entidades.SaveChanges();
                    registro = true;
                }
                return registro;
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

        public bool elimiarSolicitudes()
        {
            try
            {
                //Instancia de las entidades de la BD
                using (this.entidades = new zensoftEntities())
                {
                    List<TblActivoSolicitado> lista = this.entidades.TblActivoSolicitado.ToList();

                    for (int i = 0; i < lista.Count; i++)
                    {
                        this.entidades.TblActivoSolicitado.Remove(lista[i]);
                    }
                    this.entidades.SaveChanges();
                    return true;
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

        public bool eliminarActivoSolicitado(string patrimonio)
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    TblActivoSolicitado activoSolicitado = this.entidades.TblActivoSolicitado.FirstOrDefault(a => a.patrimonio.Equals(patrimonio));
                    this.entidades.TblActivoSolicitado.Remove(activoSolicitado);
                    this.entidades.SaveChanges();
                    return true;
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
    }
}
