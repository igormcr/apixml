using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net;
using System.Xml;
// using API_eSocial.Model;
using System.Xml.Linq;
using System.ServiceModel;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace API_eSocial.Controllers
{
    public class WebServiceEsocial {

        public static SOAPManual()
        {
            const string url = "URL";
            const string action = "METHOD_NAME";

            XmlDocument soapEnvelopeXml = CreateSoapE CreateSoapEnvelope();
            HttpWebRequest webRequest = CreateWebRequest(url, action);

            InsertSoapEnvelopeIntoWebRequest(soapEnvelopeXml, webRequest);

            string result;
            using (WebResponse response = webRequest.GetResponse())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    result = rd.ReadToEnd();
                }
            }

            return result;
        }

        private static HttpWebRequest CreateWebRequest(string url, string action)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Headers.Add("SOAPActiontion");
            webRequest.ContentType = "text/xml;charset=\"utf-8\"";
            webRequest.Accept = "text/xml";
            webRequest.Method = "POST";
            return webRequest;
        }

        private static XmlDocument CreateSoapEnvelope()
        {
            XmlDocument soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(@"<?xml version=""1.0"" encoding=""utf-8""?>
                    <soap:Envelope xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                    <soap:Body>
                    <Method xmlns=""http://www.sample.com/path/"">
                    <Parameter1>param1</Parameter1>
                    <Parameter2>param2</Parameter2>
                    </Method>
                    </soap:Body>
                    </soap:Envelope>");
            return soapEnvelopeXml;
        }

        private static void InsertSoapEnvelopeIntoWebRequest(XmlDocument soapEnvelopeXml, HttpWebRequest webRequest)
        {
            using (Stream stream = webRequest.GetRequestStream())
            {
                soapEnvelopeXml.Save(stream);
            }
        }

        /// <summary>
        /// Cria um webrequest SOAP para [Url]
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        private static string enviarRequisicao()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
                string web_service_teste = "https://webservices.producaorestrita.esocial.gov.br/servicos/empregador/enviarloteeventos/WsEnviarLoteEventos.svc";
                //              string web_service_producao = "https://webservices.envio.esocial.gov.br/servicos/empregador/enviarloteeventos/WsEnviarLoteEventos.svc";

                string urlXML = @"C:\esocial\Templates\Esocial-S1000.xml";

                X509Certificate2 x509Cert = new X509Certificate2(@"C:\esocial\certificado.pfx", "12345678");

                string url = web_service_teste;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                XDocument loteEventosXDoc = XDocument.Load(urlXML);

                var urlServicoEnvio = @"https://webservices.producaorestrita.esocial.gov.br/servicos/empregador/enviarloteeventos/WsEnviarLoteEventos.svc";
                var address = new EndpointAddress(urlServicoEnvio);
                var binding = new BasicHttpsBinding();  //Disponível desde .NET Framework 4.5
                                                        // ou:
                                                        //var binding = new BasicHttpBinding(BasicHttpsSecurityMode.Transport);
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate;

                binding.MaxReceivedMessageSize = 768000;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
                                        SecurityProtocolType.Tls11 |
                                        SecurityProtocolType.Tls12;

                var wsClient = new PortalMadeirol.Web.ServiceEsocial.ServicoEnviarLoteEventosClient(binding, address);

                // Variável 'x509Cert' é do tipo X509Certificate2.

                wsClient.ClientCredentials.ClientCertificate.Certificate = x509Cert;

                var retornoEnvioXElement = wsClient.EnviarLoteEventos(loteEventosXDoc.Root);
                wsClient.Close();
                return Response;

            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
        private static string ServicoEnviarLoteEventosClient(string binding, string address)
        {
            string Response = null;
            return Response;
    
        }
    }


}

