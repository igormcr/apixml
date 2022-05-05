using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_eSocial.Models
{
    [DataContract]
    public class MachineModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string MachineName { get; set; }
        [DataMember]
        public string HorsePower { get; set; }
    }
}
