using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Cryptonator.Entities
{
    public class FiltroExchange
    {
        public string Base { get; set; }
        public string Target { get; set; }


        public string GetFiltro()
        {
            return this.Base + "-" + this.Target;
        }
    }
}
