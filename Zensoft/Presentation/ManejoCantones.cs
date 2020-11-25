using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejoCantones
    {
        private List<string> listaCantones;
        
        public List<string> obtenerCantones(int index)
        {
            try
            {

                if(index == 0)
                {
                    this.listaCantones = new List<string>() {"San José", "Escazú", "Desamparados", "Puriscal", "Tarrazú",
                    "Aserrí", "Mora", "Goicoechea", "Santa Ana", "Alajuelita", "Vázquez De Coronado", "Acosta",
                    "Tibás", "Moravia", "Montes De Oca", "Turrubares", "Dota", "Curridabat", "Pérez Zeledón", "León Cortés Castro"};
                }
                else if (index == 1)
                {
                    this.listaCantones = new List<string>() { "Alajuela", "San Ramon", "Grecia", "San Mateo", "Atenas", "Naranjo",
                    "Palmares", "Poás", "Orotina", "San Carlos", "Zarcero", "Sarchí", "Upala", "Los Chiles",
                    "Guatuso", "Río Cuarto"};
                }
                else if (index == 2)
                {
                    this.listaCantones = new List<string>() { "Cartago", "Alvarado", "El Guarco", "Jiménez",
                    "La Unión", "Oreamuno", "Paraíso", "Turrialba"};
                    }
                else if (index == 3)
                {
                    this.listaCantones = new List<string>() { "Heredia", "Barva", "Santo Domingo", "Santa Barbara", "San Rafael",
                        "San Isidro", "Belén", "Flores", "San Pablo", "Sarapiquí" };
                }
                else if (index == 4)
                {
                    this.listaCantones = new List<string>() { "Liberia", "Nicoya", "Santa Cruz", "Bagaces", "Carrillo", "Cañas", "Abangares", "Tilarán",
                        "Nandayure", "La Cruz", "Hojancha" };
                }
                else if (index == 5)
                {
                    this.listaCantones = new List<string>() { "Puntarenas", "Esparza", "Buenos Aires", "Montes de Oro", "Osa", "Quepos", "Golfito", "Coto Brus",
                    "Parrita", "Corredores", "Garabito" };
                }
                else if (index == 6)
                {
                    this.listaCantones = new List<string>() { "Limón", "Guácimo", "Matina", "Pococí", "Siquirres", "Talamanca" };
                }

                return listaCantones;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
