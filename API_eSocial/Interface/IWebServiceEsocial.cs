using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using API_eSocial.Interface;
using API_eSocial.Models;

namespace API_eSocial.Interface
{
    [ServiceContract]
    public interface IWebServiceEsocial
    {
        [OperationContract]
        string Pass(string pass);
        [OperationContract]
        void Path(System.Xml.Linq.XElement xml);
        [OperationContract]
        MachineModel TestMachine(MachineModel machine);
    }
}
