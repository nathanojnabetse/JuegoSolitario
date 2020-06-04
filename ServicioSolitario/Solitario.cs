using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;

namespace ServicioSolitario
{
    public class Solitario : IServicioSolitario
    {
        public bool MovimientoColumnas(string colorCartaSalida, int numeroCartaSalida, string colorCartaLlegada, int numeroCartaLlegada)
        {
           
            if ((colorCartaSalida != colorCartaLlegada) && (numeroCartaSalida == numeroCartaLlegada - 1))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool MovimientoFinal(string paloCartaSalida, int numeroCartaSalida, string paloCartaLlegada, int numeroCartaLlegada)
        {
            if ((paloCartaSalida == paloCartaLlegada) && (numeroCartaSalida  == numeroCartaLlegada+1))
            {
                return true;

            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// El método llena una lista de enteros con 52 numeros del 1 al 52 de manera aleatoria
        /// y sin repeticion, es usado para desordenar los indices de las cartas en la interfaz
        /// </summary>
        /// <returns>lsRepartir es la lista de int desordenada</returns>
        public int[] RepartirCartas()
        {
            int[] lsRepartir = new int[52];

            Random r = new Random();

            int auxiliar = 0;
            int contador = 0;

            for (int i = 0; i < lsRepartir.Length; i++)
            {
                auxiliar = r.Next(1, 53);
                bool continuar = false;

                while (!continuar)
                {
                    for (int j = 0; j <= contador; j++)
                    {
                        if (auxiliar == lsRepartir[j])
                        {
                            continuar = true;
                            j = contador;
                        }
                    }

                    if (continuar)
                    {
                        auxiliar = r.Next(1, 53);
                        continuar = false;
                    }
                    else
                    {
                        continuar = true;
                        lsRepartir[contador] = auxiliar;

                        contador++;
                    }
                }
            }



            return lsRepartir;
        }


    }
}
