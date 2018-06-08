using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Examen.WCF
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string ApellidoPaterno { get; set; }

        [DataMember]
        public string ApellidoMaterno { get; set; }

        [DataMember]
        public string Telefono { get; set; }

        [DataMember]
        public string Email { get; set; }
    }
}