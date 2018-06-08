using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Examen.WCF
{
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        List<Cliente> ObtenerCliente();

        [OperationContract]
        bool GuardarCliente(Cliente cliente);

        [OperationContract]
        bool EliminarCliente(int p_ClienteId);
    }
}
