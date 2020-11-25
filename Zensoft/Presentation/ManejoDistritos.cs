using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class ManejoDistritos
    {
        private List<string> listaDistritos;

        public List<string> obtenerDistritos(int indexP, int indexC)
        {
            try
            {

                //Provincia de SJ
                if (indexP == 0)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() {"Carmen", "Merced", "Hospital", "Catedral", "Zapote",
                        "San Francisco", "Uruca", "Mata Redonda", "Pavas", "Hatillo", "San Sebastián"};
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "San Miguel", "San Antonio", "San Rafael" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() {"Desamparados", "San Miguel", "San Juan de Dios",
                        "San Rafael Arriba", "San Antonio", "Frailes", "Patarrá", "San Cristóbal", "El Rosario",
                        "Damas", "San Rafael Abajo", "Las Gravilias", "Los Guido"};
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "Santiago", "Mercedes Sur", "Barbacoas", "Grifo Alto",
                        "San Rafael", "Candelaria", "Desemparaditos", "San Antonio", "Chires"};
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "San Marcos", "San Lorenzo", "San Carlos" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() {"Aserrí", "Tarbaca", "Vuelta de Jorco", "San Gabriel",
                        "Legua", "Monterrey", "Salitrillos"};
                    }
                    else if (indexC == 6)
                    {
                        listaDistritos = new List<string>() { "Ciudad Colón", "Guayabo", "Jaris", "Picagres", "Piedras Negras", "Tabarcia" };
                    }
                    else if (indexC == 7)
                    {
                        listaDistritos = new List<string>() { "Calle Blancos", "Guadalupe", "Ipís", "Mata de Plátano", "Purral", "Rancho Redondo", "San Francisco" };
                    }
                    else if (indexC == 8)
                    {
                        listaDistritos = new List<string>() { "Brasil", "Piedades", "Pozos", "Salitral", "Santa Ana", "Uruca" };
                    }
                    else if (indexC == 9)
                    {
                        listaDistritos = new List<string>() { "Alajuelita", "Concepción", "San Antonio", "San Felipe", "San Josecito" };
                    }
                    else if (indexC == 10)
                    {
                        listaDistritos = new List<string>() { "Cascajal", "Dulce Nombre de Jesús", "Patalillo", "San Isidro", "San Rafael" };
                    }
                    else if (indexC == 11)
                    {
                        listaDistritos = new List<string>() { "Cangrejal", "Guaitil", "Palmichal", "Sabanillas", "San Ignacio" };
                    }
                    else if (indexC == 12)
                    {
                        listaDistritos = new List<string>() { "Anselmo Llorente", "Cinco Esquinas", "Colima", "León XIII", "San Juan" };
                    }
                    else if (indexC == 13)
                    {
                        listaDistritos = new List<string>() { "San Jerónimo", "San Vicente", "Trinidad" };
                    }
                    else if (indexC == 14)
                    {
                        listaDistritos = new List<string>() { "Mercedes", "Sabanilla", "San Pedro", "San Rafael" };
                    }
                    else if (indexC == 15)
                    {
                        listaDistritos = new List<string>() { "Carara", "San Juan de Mata", "San Luis", "San Pablo", "San Pedro" };
                    }
                    else if (indexC == 16)
                    {
                        listaDistritos = new List<string>() { "Copey", "Jardín", "Santa María" };
                    }
                    else if (indexC == 17)
                    {
                        listaDistritos = new List<string>() { "Curridabat", "Granadilla", "Sánchez", "Tirrases" };
                    }
                    else if (indexC == 18)
                    {
                        listaDistritos = new List<string>() { "San Isidro de El General", "Barú", "Cajón", "Daniel Flores",
                            "El General", "La Amistad", "Páramo", "Pejibaye", "Platanares", "Río Nuevo", "Rivas", "San Pedro" };
                    }
                    else if (indexC == 19)
                    {
                        listaDistritos = new List<string>() { "San Pablo", "San Andrés", "Llano Bonito", "San Isidro", "Santa Cruz", "San Antonio" };
                    }
                }
                //provincia de Alajuela
                else if (indexP == 1)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() {"Alajuela", "San José", "Carrizal", "San Antonio",
                            "Guácima", "San Isidro", "Sabanilla", "San Rafael", "Río Segundo", "Desamparados", "Turrúcares", "Tambor", "La Garita", "Sarapiquí" };
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "San Ramón", "Santiago", "San Juan", "Piedades Norte", "Piedades Sur", "San Rafael", "San Isidro",
                            "Ángeles", "Alfaro", "Volio", "Concepción", "Zapotal", "Peñas Blancas", "San Lorenzo" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() { "Grecia", "San Isidro", "San José", "San Roque", "Tacares", "Puente de Piedra", "Bolívar" };
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "San Mateo", "Desmonte", "Jesús María", "Labrador" };
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "Atenas", "Jesús", "Mercedes", "San Isidro", "Concepción", "San José", "Santa Eulalia", "Escobal" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() { "Naranjo", "San Miguel", "San José", "Cirrí", "San Jerónimo", "San Juan", "Rosario", "Palmitos" };
                    }
                    else if (indexC == 6)
                    {
                        listaDistritos = new List<string>() { "Palmares", "Zaragoza", "Buenos Aires", "Santiago", "Candelaria", "Esquipulas", "La Granja" };
                    }
                    else if (indexC == 7)
                    {
                        listaDistritos = new List<string>() { "San Pedro", "San Juan", "San Rafael", "Carrillos", "Sabana Redonda" };
                    }
                    else if (indexC == 8)
                    {
                        listaDistritos = new List<string>() { "Orotina", "El Mastate", "Hacienda Vieja", "Coyolar", "La Ceiba" };
                    }
                    else if (indexC == 9)
                    {
                        listaDistritos = new List<string>() { "Quesada", "Florencia", "Buenavista", "Aguas Zarcas", "Venecia", "Portal", "La Fortuna", "La Tigra",
                            "La Palmera", "Venado", "Cutris", "Monterrey", "Pocosol" };
                    }
                    else if (indexC == 10)
                    {
                        listaDistritos = new List<string>() { "Zarcero", "Laguna", "Tapezco", "Palmira", "Guadalupe", "Zapote", "Brisas" };
                    }
                    else if (indexC == 11)
                    {
                        listaDistritos = new List<string>() { "Sarchí Norte", "Sarchí Sur", "Toro Amarillo", "San Pedro", "Rodríguez" };
                    }
                    else if (indexC == 12)
                    {
                        listaDistritos = new List<string>() { "Upala", "Aguas Claras", "San José(Pizote)", "Bijagua", "Delicias", "Dos Ríos", "Yolillal", "Canalete" };
                    }
                    else if (indexC == 13)
                    {
                        listaDistritos = new List<string>() { "Los Chiles", "Caño Negro", "Amparo", "San Jorge" };
                    }
                    else if (indexC == 14)
                    {
                        listaDistritos = new List<string>() { "San Rafael", "Buenavista", "Cote", "Katira" };
                    }
                    else if (indexC == 15)
                    {
                        listaDistritos = new List<string>() { "Río Cuarto", "Santa Isabel", "Santa Rita" };
                    }
                }
                //provincia de Cartago
                else if (indexP == 2)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() { "Agua Caliente", "Carmen", "Corralillo", "Dulce Nombre", "Guadalupe", "Llano Grande", "Occidental",
                            "Oriental", "Quebradilla", "San Nicolás", "Tierra Blanca" };
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "Capellades", "Cervantes", "Pacayas" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() { "Patio de Agua", "San Isidro", "Tejar", "Tobosi" };
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "Juan Viñas", "Pejibaye", "Tucurrique" };
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "Concepción", "Dulce Nombre", "Río Azul", "San Diego",
                            "San Juan", "San Rafael", "San Ramón", "Tres Ríos" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() { "Cipreses", "Cot", "Potrero Cerrado", "San Rafael", "Santa Rosa" };
                    }
                    else if (indexC == 6)
                    {
                        listaDistritos = new List<string>() { "Cachí", "Llanos de Santa Lucía", "Orosí", "Paraíso", "Santiago de Paraíso" };
                    }
                    else if (indexC == 7)
                    {
                        listaDistritos = new List<string>() { "Chirripó", "La Isabel", "La Suiza", "Pavones", "Peralta", "Santa Cruz",
                            "Santa Rosa", "Santa Teresita", "Tayutic", "Tres Equis", "Tuis", "Turrialba" };
                    }
                }
                //provincia de Heredia
                else if (indexP == 3)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() { "Heredia", "Mercedes", "San Francisco", "Ulloa", "Varablanca" };
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "Barva", "San José de la Montaña", "San Pablo", "San Pedro", "San Roque", "Santa Lucía" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() { "Pará", "Paracito", "San Miguel", "San Vicente", "Santa Rosa", "Santo Domingo", "Santo Tomás", "Tures" };
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "Jesús", "Purabá", "San Juan", "San Pedro", "Santa Bárbara", "Santo Domingo" };
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "Ángeles", "Concepción", "San Josecito", "San Rafael", "Santiago" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() { "Concepción", "San Francisco", "San Isidro", "San José" };
                    }
                    else if (indexC == 6)
                    {
                        listaDistritos = new List<string>() { "La Asunción", "La Ribera", "San Antonio" };
                    }
                    else if (indexC == 7)
                    {
                        listaDistritos = new List<string>() { "Barrantes", "Llorente", "San Joaquín" };
                    }
                    else if (indexC == 8)
                    {
                        listaDistritos = new List<string>() { "Rincón de Sabanilla", "San Pablo" };
                    }
                    else if (indexC == 9)
                    {
                        listaDistritos = new List<string>() { "Cureña", "La Virgen", "Las Horquetas", "Llanuras del Gaspar", "Puerto Viejo" };
                    }
                }
                //provincia de Guanacaste
                else if (indexP == 4)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() { "Liberia", "Cañas Dulces", "Mayorga", "Nacascolo", "Curubandé" };
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "Nicoya", "Mansión", "San Antonio", "Quebrada Honda", "Sámara", "Nosara", "Belén de Nosarita" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() { "Santa Cruz", "Bolsón", "Veintisiete de Abril", "Tempate", "Cartagena", "Cuajiniquil", "Diriá", "Cabo Velas",
                            "Tamarindo" };
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "Bagaces", "La Fortuna", "Mogote", "Río Naranjo" };
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "Filadelfia", "Belén", "Palmira", "Sardinal" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() { "Cañas", "Palmira", "San Miguel", "Bebedero", "Porozal" };
                    }
                    else if (indexC == 6)
                    {
                        listaDistritos = new List<string>() { "Las Juntas", "Sierra", "San Juan", "Colorado" };
                    }
                    else if (indexC == 7)
                    {
                        listaDistritos = new List<string>() { "Tilarán", "Quebrada Grande", "Tronadora", "Santa Rosa", "Líbano", "Tierras Morenas", "Arenal" };
                    }
                    else if (indexC == 8)
                    {
                        listaDistritos = new List<string>() { "Carmona", "Santa Rita", "Zapotal", "San Pablo", "Porvenir", "Bejuco" };
                    }
                    else if (indexC == 9)
                    {
                        listaDistritos = new List<string>() { "La Cruz", "Santa Cecilia", "La Garita", "Santa Elena" };
                    }
                    else if (indexC == 10)
                    {
                        listaDistritos = new List<string>() { "Hojancha", "Monte Romo", "Puerto Carrillo", "Huacas", "Matambú" };
                    }
                }
                //provincia de Puntarenas
                else if (indexP == 5)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() { "Puntarenas", "Pitahaya", "Chomes", "Lepanto", "Paquera", "Manzanillo", "Guacimal", "Barranca", "Monteverde",
                            "Isla del Coco", "Cóbano", "Chacarita", "Chira", "Acapulco", "El Roble", "Arancibia" };
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "Espíritu Santo", "San Juan", "Macacona", "San Rafael", "San Jerónimo", "Caldera" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() { "Buenos Aires", "Volcán", "Potrero Grande", "Boruca", "Pilas", "Colinas", "Chánguena", "Biolley", "Brunka" };
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "Miramar", "La Unión", "San Isidro" };
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "Ciudad Cortés", "Palmar", "Sierpe", "Piedras Blancas", "Bahía Ballena", "Bahía Drake" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() { "Quepos", "Savegre", "Naranjito" };
                    }
                    else if (indexC == 6)
                    {
                        listaDistritos = new List<string>() { "Golfito", "Puerto Jiménez", "Guaycará", "Pavón" };
                    }
                    else if (indexC == 7)
                    {
                        listaDistritos = new List<string>() { "San Vito", "Sabalito", "Agua Buena", "Limoncito", "Pittier", "Gutiérrez Brown" };
                    }
                    else if (indexC == 8)
                    {
                        listaDistritos = new List<string>() { "Parrita" };
                    }
                    else if (indexC == 9)
                    {
                        listaDistritos = new List<string>() { "Corredor", "La Cuesta", "Paso Canoas", "Laurel" };
                    }
                    else if (indexC == 10)
                    {
                        listaDistritos = new List<string>() { "Jacó", "Tárcoles" };
                    }
                }
                //provincia de Limón
                else if (indexP == 6)
                {
                    if (indexC == 0)
                    {
                        listaDistritos = new List<string>() { "Limón", "Matama", "Río Blanco", "Valle La Estrella" };
                    }
                    else if (indexC == 1)
                    {
                        listaDistritos = new List<string>() { "Duacarí", "Guácimo", "Mercedes", "Pocora", "Río Jiménez" };
                    }
                    else if (indexC == 2)
                    {
                        listaDistritos = new List<string>() { "Batán", "Carrandi", "Matina" };
                    }
                    else if (indexC == 3)
                    {
                        listaDistritos = new List<string>() { "Cariari", "Colorado", "Guápiles", "Jiménez", "Rita", "Roxana" };
                    }
                    else if (indexC == 4)
                    {
                        listaDistritos = new List<string>() { "Alegría", "Cairo", "Florida", "Germania", "Pacuarito", "Siquirres" };
                    }
                    else if (indexC == 5)
                    {
                        listaDistritos = new List<string>() { "Bratsi", "Cahuita", "Sixaola", "Telire" };
                    }
                }

                    return listaDistritos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
