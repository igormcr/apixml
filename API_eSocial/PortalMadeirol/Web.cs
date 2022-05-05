using System;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Xml.Linq;

namespace PortalMadeirol
{
    public class Web
    {
        public class ServiceEsocial
        {

            internal class ServicoEnviarLoteEventosClient
            {
                public class ClientCredentials
                {
                    public struct ClientCertificate
                    {
                        //public static X509Certificate2 Certificate { get; internal set; }

                        internal static void Certificate(X509Certificate2 x509Cert)
                        {
                            throw new NotImplementedException();
                        }
                    }

                    public string Certificate { get;set; }
                    
                }
                private BasicHttpsBinding binding;
                private EndpointAddress address;

                public ServicoEnviarLoteEventosClient(BasicHttpsBinding binding, EndpointAddress address)
                {
                    this.binding = binding;
                    this.address = address;
                }

            

                public object EnviarLoteEventos(XElement root)
                {
                    throw new NotImplementedException();
                }

                internal void Close()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
