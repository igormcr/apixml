using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_eSocial.Model
{
    public class X509Certificate2
    {
        private string path;
        private string pass;

        public X509Certificate2(string path, string pass)
        {
            this.path = path;
            this.pass = pass;
        }
    }
}
