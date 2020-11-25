using System;
using Entidades;
using System.Transactions;
using AccesoDatos;
using System.Data.Entity.Validation;
using System.Collections.Generic;
using System.Data;

namespace LogicaNegocio
{
    public class LNUsuario
    {
        ADUsuario usuario;
        DataTable dataTable;
        //metodo para registrar empleado
        public void RegistrarEmpleado(TblUsuario tblUsuario)
        {
            usuario = new ADUsuario();
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                {
                    usuario.RegistrarUsuario(tblUsuario);
                    transactionScope.Complete();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<TblGrupo> GetGrupo()
        {
            usuario = new ADUsuario();
            return usuario.GetGrupo();
        }

        public bool ConsultarUsuario(String nombreUsuario)
        {
            try
            {
                usuario = new ADUsuario();
                return usuario.ConsultarUsuario(nombreUsuario);
            }
            catch (DbEntityValidationException ex)//Es una exepcion que me dice claramente donde esta el error
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

        public DataTable GetGrupoUsuario(string grupo)
        {
            usuario = new ADUsuario();
            this.dataTable = new DataTable();
            try
            {
                this.dataTable.Columns.Add("NombreUsuario", typeof(string));
                this.dataTable.Columns.Add("Correo", typeof(string));
                //Se  carga los datos del empleado
                var listaUsuarios = this.usuario.ObtenerUsuarios(grupo);//procedimiento almacenado

                foreach (var le in listaUsuarios)
                {
                    DataRow dataRow = dataTable.NewRow();

                    dataRow.SetField<String>("NombreUsuario", le.NombreUsuario);
                    dataRow.SetField<String>("Correo", le.Correo);
                    this.dataTable.Rows.Add(dataRow);
                }
                return dataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string DevolverContraseñaUsuario (string nombreUsuario)
        {
            try
            {
                usuario = new ADUsuario();
                return usuario.DevolverContraseñaUsuario(nombreUsuario);
            }
            catch(Exception ex)
            {
                throw ex;
            } 
        }

        public string ExtraerCorreo(string nombreUsuario)
        {
            usuario = new ADUsuario();
            return usuario.ExtraerContraseña(nombreUsuario);
        }

        public bool ModificarContraseña(string nombreUsuario,string hash)
        {
            try
            {
                    usuario = new ADUsuario();
                    return usuario.ModificarContraseña(nombreUsuario, hash);
          
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool BloquearUsuario(string nombreUsuario)
        {
            try
            {
                usuario = new ADUsuario();
                return usuario.BloquearUsuario(nombreUsuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public int ConsultarUsuarioBloqueado(string nombreUsuario)
        {
            try
            {
                usuario = new ADUsuario();
                return usuario.ConsultarUsuarioBloqueado(nombreUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TipoUsuario(string nombreUsuario)
        {
            usuario = new ADUsuario();
            return usuario.TipoUsuario(nombreUsuario);
        }
    }
    
}
