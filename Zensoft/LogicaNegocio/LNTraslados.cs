using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class LNTraslados
    {
        ADTraslados DaTraslados;
        DataTable tblTraslado;
        ADActivos adActivos;
        ADConsumible adConsumibles;
        public static int GenerarID()
        {
            return ADTraslados.GenerarID();
        }

        public static void RealizarTraslado(TblTraslado traslado)
        {
            ADTraslados.RealizarTraslado(traslado);
        }

        public static bool RealizarTrasladoC(TblTrasladoConsumibles trasladoConsumible)
        {
           return ADTraslados.RealizarTrasladoC(trasladoConsumible);
        }

        public static bool RealizarTrasladoA(TblTrasladoActivo trasladoActivo)
        {
            return ADTraslados.RealizarTrasladoA(trasladoActivo);
        }



        /*public DataTable consultarDatos(string identificador, int condicion)
        {
            try
            {
                //Se el acceso a datos
                this.DaTraslados = new ADTraslados();
                this.adActivos = new ADActivos();
                this.adConsumibles = new ADConsumibles();

                //Se instancian los datos para cargar el grid en la ventana
                this.tblTraslado = new DataTable();
                //Se crean las columnas de la tabla
                this.tblTraslado.Columns.Add("Identificador", typeof(string));
                this.tblTraslado.Columns.Add("Marca", typeof(string));
                this.tblTraslado.Columns.Add("Cantidad", typeof(string));

                //Se ejecuta consulta por la lista de tras
                if(condicion == 1)//Activo
                {
                    TblActivo activo = adActivos.consultarActivoPat(identificador);

                    DataRow fila = tblTraslado.NewRow();
                    fila.SetField<string>("Identificador", activo.patrimonio);
                    fila.SetField<string>("Marca", activo.marca);
                    fila.SetField<string>("Cantidad", "1");
                    this.tblTraslado.Rows.Add(fila);

                    return this.tblTraslado;
                }
                else//Consumibles
                {
                    TblConsumible cons = adConsumibles.getConsumible(identificador);

                    DataRow fila = tblTraslado.NewRow();
                    fila.SetField<string>("Identificador", cons.codigo);
                    fila.SetField<string>("Marca", cons.marca);
                    fila.SetField<string>("Cantidad", );
                    this.tblTraslado.Rows.Add(fila);

                    return this.tblTraslado;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }*/

    }
}
