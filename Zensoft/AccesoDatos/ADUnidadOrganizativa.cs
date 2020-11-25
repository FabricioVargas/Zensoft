using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADUnidadOrganizativa
    {
        //Se referencian las entidades de la BD
        private zensoftEntities entidades;


        public bool registrarUnidadOrganizativa(TblUnidadOrganizativa unidadOrganizativa)
        {
            bool registro = false;
            try
            {
                if (this.consultarUO(unidadOrganizativa.codigo) == false)
                {
                    using (this.entidades = new zensoftEntities())
                    {
                        entidades.TblUnidadOrganizativa.Add(unidadOrganizativa);
                        entidades.SaveChanges();

                        registro = true;
                    }
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
            return registro;
        }


        public bool registrarDependenciasOrganizativas(TblDependenciaOrganizativa dependencias)
        {
            bool registro = false;
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    entidades.TblDependenciaOrganizativa.Add(dependencias);
                    entidades.SaveChanges();

                    registro = true;
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
            return registro;
        }



        public bool consultarUO(string idUnidadO)
        {
            bool existe = false;
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    TblUnidadOrganizativa unidadO = entidades.TblUnidadOrganizativa.FirstOrDefault(e => e.codigo == idUnidadO);

                    if (unidadO != null)
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

        public List<TblUnidadOrganizativa> GetAllUnidadesS()
        {
            List<TblUnidadOrganizativa> unidades = new List<TblUnidadOrganizativa>();
            using (this.entidades = new zensoftEntities())
            {
                try
                {
                    unidades = entidades.TblUnidadOrganizativa.OrderBy(uo => uo.nombre).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return unidades;
            }
        }

        public bool existenUnidades()//Si existe una sola unidad organizativa, se carga EN dependencias
        {
            try
            {
                bool existe = false;
                int cont;
                using (this.entidades = new zensoftEntities())
                {
                    cont = this.entidades.TblUnidadOrganizativa.ToList().Count;
                }
                if (cont > 0)
                {
                    existe = true;
                }
                return existe;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool removeUnOr(string codigo)
        {
            bool exito = false;
            try
            {
                using (entidades = new zensoftEntities())
                {
                    entidades.TblUnidadOrganizativa.Remove(this.getUnidadO(codigo));
                    exito = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public List<TblUnidadOrganizativa> cargarDependecias()
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblUnidadOrganizativa.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static void modificarUnidad(TblUnidadOrganizativa unidad)
        {
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblUnidadOrganizativa unidadOEncontrada = db.TblUnidadOrganizativa.Where(uo => uo.codigo == unidad.codigo).FirstOrDefault();
                    unidadOEncontrada.codigo = unidad.codigo;
                    unidadOEncontrada.nombre = unidad.nombre;
                    unidadOEncontrada.telefono = unidad.telefono;
                    unidadOEncontrada.latitud = unidad.latitud;
                    unidadOEncontrada.logitud = unidad.logitud;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public TblUnidadOrganizativa getUnidadO(string idUnidad)
        {
            try
            {
                using (entidades = new zensoftEntities())
                {
                    return this.entidades.TblUnidadOrganizativa.FirstOrDefault(e => e.codigo == idUnidad);
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

        public TblDependenciaOrganizativa getDependiente(string idDependiente)
        {
            try
            {
                using (entidades = new zensoftEntities())
                {
                    return this.entidades.TblDependenciaOrganizativa.FirstOrDefault(e => e.unidadDependiente == idDependiente);
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

        public bool verificarDependencia(string codigoDependiente)//busca si existe la unidad como unidad dependiente
        {
            bool verificar = false;
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblDependenciaOrganizativa dependencia = this.entidades.TblDependenciaOrganizativa.FirstOrDefault(e => e.unidadDependiente == codigoDependiente);
                    if (dependencia != null)
                    {
                        verificar = true;
                    }
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
            return verificar;
        }

        public void modificarDependencia(TblDependenciaOrganizativa dependencia)
        {
            using (zensoftEntities db = new zensoftEntities())
            {
                try
                {
                    TblDependenciaOrganizativa dependenciaEncontrda = db.TblDependenciaOrganizativa.Where(d => d.unidadDependiente == dependencia.unidadDependiente).FirstOrDefault();
                    dependenciaEncontrda.unidadCabecilla = dependencia.unidadCabecilla;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<SP_UO_List_Result> obtenerUnidadesOrgCod(string codigo)
        {
            try
            {
                //Se instancian las entidades de la BD
                using (this.entidades = new zensoftEntities())
                {
                    List<SP_UO_List_Result> consumibles = this.entidades.SP_UO_List(codigo).ToList();
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
        public List<TblUnidadOrganizativa> getUnidadesOrg()
        {
            try
            {
                //Se instancian las entidades
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblUnidadOrganizativa.ToList();
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
