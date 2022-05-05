using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace API_eSocial.Model
{
    [DataContract]
    public class WebServiceEsocialModel
    {

        [DataMember]
        private string path;
        [DataMember]
        private string pass;


        public WebServiceEsocialModel(string path, string pass)
        {
            this.path = path;
            this.pass = pass;
        }
    }

}
