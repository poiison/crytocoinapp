using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Shrimpy.Entities
{
    public class Currency
    {
        public int id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string tradingSymbol { get; set; }
    }
}
