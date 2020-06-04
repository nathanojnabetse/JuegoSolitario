using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using ServicioSolitario;

namespace Anfitrion
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost anfitrion = new ServiceHost(typeof(Solitario), new Uri("http://localhost:8080/Juego/Solitario")))
            {
                anfitrion.Open();
                Console.WriteLine("\n ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦");
                Console.WriteLine("         __       _ _ _             _               ");
                Console.WriteLine("        / _\\ ___ | (_) |_ __ _ _ __(_) ___          ");
                Console.WriteLine(" _____  \\ \\ / _ \\| | | __/ _` | '__| |/ _ \\   _____ ");
                Console.WriteLine("|_____| _\\ \\ (_) | | | || (_| | |  | | (_) | |_____|");
                Console.WriteLine("        \\__/\\___/|_|_|\\__\\__,_|_|  |_|\\___/         ");
                Console.WriteLine("\n ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦ ♣ ♠ ♥ ♦\n");
                Console.WriteLine("Julio 2019\n");
                Console.WriteLine("El servicio para el juego está corriendo");
                Console.WriteLine("Presione una tecla para terminar");

                

                Console.ReadKey();
            }
        }
    }
}

