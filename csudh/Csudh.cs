using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csudh
{
    class Csudh
    {
        public string DomainNev;
        public string IpCim;

        public Csudh(string sor)
        {
            DomainNev = sor.Split(';')[0];
            IpCim = sor.Split(';')[1];
        }

    }
}
