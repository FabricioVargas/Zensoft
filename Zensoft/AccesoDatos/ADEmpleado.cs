using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class ADEmpleado
    {
        zensoftEntities entidades;
        public static bool verificarEmpl(string ced)
        {
            bool existe = false;
            try
            {
                zensoftEntities db = new zensoftEntities();
                TblEmpleado empleado = db.TblEmpleado.FirstOrDefault(e => e.cedula.Equals(ced));

                if (empleado != null)
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

        public static string getNombre(string ced)
        {
            try
            {
                zensoftEntities db = new zensoftEntities();
                TblEmpleado empleado = db.TblEmpleado.FirstOrDefault(e => e.cedula.Equals(ced));
                return empleado.nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool modificarEmpleado(TblEmpleado empleado, TblUbicacion ubicacion, TblPlaza plaza)
        {
            try
            {
                bool registro = false;
                using (this.entidades = new zensoftEntities())
                {
                    TblEmpleado emp = this.entidades.TblEmpleado.FirstOrDefault(e => e.cedula.Equals(empleado.cedula));
                    emp.telefono = empleado.telefono;
                    emp.correo = empleado.correo;
                    emp.condicion = empleado.condicion;
                    emp.estado = empleado.estado;
                    emp.codigoSede = empleado.codigoSede;
                    emp.idDepartamento = empleado.idDepartamento;

                    TblUbicacion ubic = this.entidades.TblUbicacion.FirstOrDefault
                        (u => u.cedula.Equals(empleado.cedula));
                    ubic.provincia = ubicacion.provincia;
                    ubic.canton = ubicacion.canton;
                    ubic.distrito = ubicacion.distrito;
                    ubic.direccion = ubicacion.direccion;

                    TblPlaza plaz = this.entidades.TblPlaza.FirstOrDefault
                            (p => p.cedula.Equals(empleado.cedula));
                    if (plaz != null)
                    {
                        if (empleado.condicion.Equals("P"))
                            plaz.numPlaza = plaza.numPlaza;
                        else
                            this.entidades.TblPlaza.Remove(plaz);
                    }
                    else
                    {
                        if (plaza != null)
                            this.entidades.TblPlaza.Add(plaza);
                    }
                    entidades.SaveChanges();
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
        public bool registrarEmpleado(TblEmpleado empleado, TblUbicacion ubicacion, TblPlaza plaza)
        {
            try
            {
                bool registro = false;
                if (!this.consultarEmpleado(empleado.cedula))
                {
                    using (this.entidades = new zensoftEntities())
                    {
                        entidades.TblEmpleado.Add(empleado);
                        entidades.SaveChanges();

                        entidades.TblUbicacion.Add(ubicacion);
                        entidades.SaveChanges();

                        if (plaza != null)
                        {
                            entidades.TblPlaza.Add(plaza);
                            entidades.SaveChanges();
                        }
                        registro = true;
                    }
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

        public bool consultarEmpleado(string cedula)
        {
            bool existe = false;
            try
            {
                //Se instancian las entidades de la BD
                using (this.entidades = new zensoftEntities())
                {
                    //Se consulta si existe el empleado con la cedula recibida
                    TblEmpleado empleado = entidades.TblEmpleado.FirstOrDefault(e => e.cedula == cedula);

                    if (empleado != null)
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

        public TblEmpleado getEmpleado(string cedula)
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblEmpleado.FirstOrDefault(e => e.cedula.Equals(cedula));
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

        public TblUbicacion getUbicacion(string cedula)
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblUbicacion.FirstOrDefault(u => u.cedula.Equals(cedula));
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

        public TblPlaza getPlaza(string cedula)
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblPlaza.FirstOrDefault(p => p.cedula.Equals(cedula));
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

        public TblDepartamento getDep(string cedula)
        {
            try
            {
                string dep = this.getEmpleado(cedula).idDepartamento;
                using (this.entidades = new zensoftEntities())
                {
                    return this.entidades.TblDepartamento.FirstOrDefault(d => d.idDepartamento.Equals(dep));
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

        public List<TblDepartamento> getDepartamentos()
        {
            try
            {
                using (this.entidades = new zensoftEntities())
                {
                    return entidades.TblDepartamento.ToList();
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

        public List<SP_CNS_EMPLEADOS_Result> obtenerEmpleadosCed(string cedula)
        {
            try
            {
                //Se instancian las entidades de la BD
                using (this.entidades = new zensoftEntities())
                {
                    List<SP_CNS_EMPLEADOS_Result> empleados = this.entidades.SP_CNS_EMPLEADOS(cedula).ToList();
                    return empleados;
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
