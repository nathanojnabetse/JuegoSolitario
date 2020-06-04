using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JuegoSolitario.ServicioSolitario;

namespace JuegoSolitario
{
    public class Carta
    {
        int id;
        int numero;
        string palo;
        string color;
        bool vuelta;
        string path;

        List<Carta> lsCartasJuego = new List<Carta>(); //Lista de cartas ordenadas

        /// <summary>
        /// Constructor de la carta
        /// </summary>
        /// <param name="id"></param>
        /// <param name="numero"></param>
        /// <param name="palo"></param>
        /// <param name="color"></param>
        /// <param name="vuelta"></param>
        /// <param name="path"></param>
        public Carta(int id, int numero, string palo, string color, bool vuelta, string path)
        {
            this.id = id;
            this.numero = numero;
            this.palo = palo;
            this.color = color;
            this.vuelta = vuelta;
            this.path = path;
        }
        
        /// <summary>
        /// Constructor Vacio
        /// </summary>
        public Carta()
        {
            this.id = 0;
            this.numero = 0;
            this.palo = "";
            this.color = "";
            this.vuelta = false;
            this.path = "";
        }

        #region Propiedades
        public int Id { get => id; set => id = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Palo { get => palo; set => palo = value; }
        public string Color { get => color; set => color = value; }
        public bool Vuelta { get => vuelta; set => vuelta = value; }
        public string Path { get => path; set => path = value; }
        #endregion

        /// <summary>
        /// Sobre escritura del metodo ToString()
        /// para las cartas A, J, Q, K se usa otro formato y para las cartas dadas la vuelta un caracter especial 
        /// </summary>
        /// <returns>Un string con el numero y palo de la carta</returns>
        public override string ToString()
        {
            if(vuelta == true)
            {
                return "   █  ";
            }
            else
            {
                if(numero == 1)
                {
                    return palo + " A " + palo;
                }
                else if(numero == 11)
                {
                    return palo + " J " + palo;
                }
                else if(numero == 12)
                {
                    return palo + " Q " + palo;
                }
                else if (numero == 13)
                {
                    return palo + " K " + palo;
                }
                else
                {
                    return palo + " " + numero + " " + palo;
                }
                
            }
            
        }

        /// <summary>
        /// Se agregan todas las cartas del mazo a la lista lsCartasJuego
        /// </summary>
        /// <returns>lsCartasJuego que es una lista con las barajas en orden</returns>
        public List<Carta> AgregarCartas()
        {
            

            lsCartasJuego.Add(new Carta(0, 0, "reverso", "blanco", true, "B1.png"));

            lsCartasJuego.Add(new Carta(1, 1, "♥", "rojo", true, "C1.png"));
            lsCartasJuego.Add(new Carta(2, 2, "♥", "rojo", true, "C2.png"));
            lsCartasJuego.Add(new Carta(3, 3, "♥", "rojo", true, "C3.png"));
            lsCartasJuego.Add(new Carta(4, 4, "♥", "rojo", true, "C4.png"));
            lsCartasJuego.Add(new Carta(5, 5, "♥", "rojo", true, "C5.png"));
            lsCartasJuego.Add(new Carta(6, 6, "♥", "rojo", true, "C6.png"));
            lsCartasJuego.Add(new Carta(7, 7, "♥", "rojo", true, "C7.png"));
            lsCartasJuego.Add(new Carta(8, 8, "♥", "rojo", true, "C8.png"));
            lsCartasJuego.Add(new Carta(9, 9, "♥", "rojo", true, "C9.png"));
            lsCartasJuego.Add(new Carta(10, 10, "♥", "rojo", true, "C10.png"));
            lsCartasJuego.Add(new Carta(11, 11, "♥", "rojo", true, "C11.png"));
            lsCartasJuego.Add(new Carta(12, 12, "♥", "rojo", true, "C12.png"));
            lsCartasJuego.Add(new Carta(13, 13, "♥", "rojo", true, "C13.png"));

            lsCartasJuego.Add(new Carta(14, 1, "♦", "rojo", true, "D1.png"));
            lsCartasJuego.Add(new Carta(15, 2, "♦", "rojo", true, "D2.png"));
            lsCartasJuego.Add(new Carta(16, 3, "♦", "rojo", true, "D3.png"));
            lsCartasJuego.Add(new Carta(17, 4, "♦", "rojo", true, "D4.png"));
            lsCartasJuego.Add(new Carta(18, 5, "♦", "rojo", true, "D5.png"));
            lsCartasJuego.Add(new Carta(19, 6, "♦", "rojo", true, "D6.png"));
            lsCartasJuego.Add(new Carta(20, 7, "♦", "rojo", true, "D7.png"));
            lsCartasJuego.Add(new Carta(21, 8, "♦", "rojo", true, "D8.png"));
            lsCartasJuego.Add(new Carta(22, 9, "♦", "rojo", true, "D9.png"));
            lsCartasJuego.Add(new Carta(23, 10, "♦", "rojo", true, "D10.png"));
            lsCartasJuego.Add(new Carta(24, 11, "♦", "rojo", true, "D11.png"));
            lsCartasJuego.Add(new Carta(25, 12, "♦", "rojo", true, "D12.png"));
            lsCartasJuego.Add(new Carta(26, 13, "♦", "rojo", true, "D13.png"));

            lsCartasJuego.Add(new Carta(27, 1, "♠", "negro", true, "E1.png"));
            lsCartasJuego.Add(new Carta(28, 2, "♠", "negro", true, "E2.png"));
            lsCartasJuego.Add(new Carta(29, 3, "♠", "negro", true, "E3.png"));
            lsCartasJuego.Add(new Carta(30, 4, "♠", "negro", true, "E4.png"));
            lsCartasJuego.Add(new Carta(31, 5, "♠", "negro", true, "E5.png"));
            lsCartasJuego.Add(new Carta(32, 6, "♠", "negro", true, "E6.png"));
            lsCartasJuego.Add(new Carta(33, 7, "♠", "negro", true, "E7.png"));
            lsCartasJuego.Add(new Carta(34, 8, "♠", "negro", true, "E8.png"));
            lsCartasJuego.Add(new Carta(35, 9, "♠", "negro", true, "E9.png"));
            lsCartasJuego.Add(new Carta(36, 10, "♠", "negro", true, "E10.png"));
            lsCartasJuego.Add(new Carta(37, 11, "♠", "negro", true, "E11.png"));
            lsCartasJuego.Add(new Carta(38, 12, "♠", "negro", true, "E12.png"));
            lsCartasJuego.Add(new Carta(39, 13, "♠", "negro", true, "E13.png"));

            lsCartasJuego.Add(new Carta(40, 1, "♣", "negro", true, "T1.png"));
            lsCartasJuego.Add(new Carta(41, 2, "♣", "negro", true, "T2.png"));
            lsCartasJuego.Add(new Carta(42, 3, "♣", "negro", true, "T3.png"));
            lsCartasJuego.Add(new Carta(43, 4, "♣", "negro", true, "T4.png"));
            lsCartasJuego.Add(new Carta(44, 5, "♣", "negro", true, "T5.png"));
            lsCartasJuego.Add(new Carta(45, 6, "♣", "negro", true, "T6.png"));
            lsCartasJuego.Add(new Carta(46, 7, "♣", "negro", true, "T7.png"));
            lsCartasJuego.Add(new Carta(47, 8, "♣", "negro", true, "T8.png"));
            lsCartasJuego.Add(new Carta(48, 9, "♣", "negro", true, "T9.png"));
            lsCartasJuego.Add(new Carta(49, 10, "♣", "negro", true, "T10.png"));
            lsCartasJuego.Add(new Carta(50, 11, "♣", "negro", true, "T11.png"));
            lsCartasJuego.Add(new Carta(51, 12, "♣", "negro", true, "T12.png"));
            lsCartasJuego.Add(new Carta(52, 13, "♣", "negro", true, "T13.png"));


            return lsCartasJuego;
        }

        /// <summary>
        /// La funcion hace uso del proxy para obtener los indices de la baraja desordenados
        /// </summary>
        /// <returns>Una lista de enteros desordenados</returns>
        public int[] NumRand()
        {
            //La ista de cartas se llena
            AgregarCartas();
            //Se inicia el proxy para la comunicacion y obtencion de la lista de numeros aleatorios
            ServicioSolitarioClient proxy = new ServicioSolitarioClient();

            int[] sorteo = proxy.RepartirCartas();//numeros aleatorios del 1 al 52 desordenados
            //es usado para los indices de los objetos del tipo carta.
            
            proxy.Close();

            return sorteo;
        }
        
        /// <summary>
        /// La funcion recibe la lista de numeros aleatorios y reparte esto en los montones de las 7 columnas y el mazo
        /// </summary>
        /// <param name="v1">El primer valor de la lista desde el cual se repartiran los montones para las columnas</param>
        /// <param name="v2">Ultimo valor de la lista desde el cual se repartiran los montones para las columnas</param>
        /// <param name="sorteo">Lista de numeros aleatorios</param>
        /// <returns></returns>
        public List<Carta> DevolverColumnas(int v1, int v2, int[] sorteo)
        {
            List<Carta> lsAux = new List<Carta>();
            for (int i = 0; i < v1; i++)
            {
                lsAux.Add(lsCartasJuego[sorteo[i + v2]]);
               
            }
            if(lsAux.Count==24)
            {

            }
            else
            {
                lsAux[lsAux.Count - 1].vuelta = false;
            }
            //Se devuelve una lista que corresponde a una columna del juego
            return lsAux;
        }




    }
}
