using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Windows.Forms;

namespace ServicioSolitario
{
    [ServiceContract]
    public interface IServicioSolitario
    {
        /// <summary>
        /// Contrato de operacion del metodo RepartirCartas()
        /// </summary>
        /// <returns>int[]</returns>
        [OperationContract]
        int[] RepartirCartas();
        [OperationContract]
        bool MovimientoColumnas(string colorCartaSalida, int numeroCartaSalida, string colorCartaLlegada, int numeroCartaLlegada);
        [OperationContract]
        bool MovimientoFinal(string paloCartaSalida, int numeroCartaSalida, string paloCartaLlegada, int numeroCartaLlegada);


    }
}
