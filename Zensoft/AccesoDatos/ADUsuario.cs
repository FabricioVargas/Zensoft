using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Validation;
using System.Linq;

namespace AccesoDatos
{
    public class ADUsuario
    {
        TblUsuario tblusuario;
        zensoftEntities entidades;
 
        public void RegistrarUsuario(TblUsuario usuario)
        {
            tblusuario = new TblUsuario();
            entidades = new zensoftEntities();
            try
            {
                tblusuario = entidades.TblUsuario.Where(c => c.nombreUsuario == usuario.nombreUsuario).FirstOrDefault();
                if (tblusuario == null)
                {
                    entidades.TblUsuario.Add(usuario);
                    entidades.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ConsultarUsuario(String Usuario)
        {
            bool encontrar = false;
    
            try
            {
                using(this.entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(Usuario));
                    if (tblusuario != null)
                    {
                        encontrar = true;
                    }
                    return encontrar;
                }
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }

        
        public List<TblGrupo> GetGrupo()
        {
            List<TblGrupo> grupo = new List<TblGrupo>();
            try
            {
                using (entidades = new zensoftEntities())
                {
                    grupo = entidades.TblGrupo.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return grupo;
        }

        public List<SP_CNS_Usuarios_Result> ObtenerUsuarios(string grupo)
        {
            try
            {
                //Se instancian las entidades de la BD
                using (this.entidades = new zensoftEntities())
                {
                    List<SP_CNS_Usuarios_Result> grupoUsuarios = this.entidades.SP_CNS_Usuarios(grupo).ToList();
                    return grupoUsuarios;
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
        public string DevolverContraseñaUsuario(string nombreUsuario)
        {
            string clave ="";
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(nombreUsuario));
                    if (tblusuario != null)
                    {
                        clave = tblusuario.clave;
                    }
                    return clave;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool BloquearUsuario(string nombreUsuario)
        {
            bool modificar = false;
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(nombreUsuario));
                    if (tblusuario != null)
                    {
                        tblusuario.bloqueo = 1;
                        entidades.SaveChanges();
                        modificar = true;
                    }
                    return modificar;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TipoUsuario(string nombreUsuario)
        {
            string usuario = "";
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(nombreUsuario));
                    if (tblusuario != null)
                    {
                        usuario = tblusuario.idGrupo;
                    }
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int ConsultarUsuarioBloqueado(string nombreUsuario)
        {
            int resultado = 0;
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(nombreUsuario));
                    if (tblusuario != null)
                    {
                        resultado= Convert.ToInt32(tblusuario.bloqueo);
                    }
                    return resultado;
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ModificarContraseña(string nombreUsuario, string hash)
        {
            bool modificado = false;
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(nombreUsuario));
                    if (tblusuario != null)
                    {
                        tblusuario.clave = hash;
                        entidades.SaveChanges();
                        modificado = true;
                    }
                    return modificado;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string ExtraerContraseña(string nombreUsuario)
        {
            string correo = "";
            try
            {
                using (entidades = new zensoftEntities())
                {
                    TblUsuario tblusuario = entidades.TblUsuario.FirstOrDefault(c => c.nombreUsuario.Equals(nombreUsuario));
                    if (tblusuario != null)
                    {
                        correo = tblusuario.correoElectronico;
                    }
                    return correo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
        
    
}
