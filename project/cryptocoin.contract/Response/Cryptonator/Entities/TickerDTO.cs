using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.contract.Response.Cryptonator.Entities
{
    public class TickerDTO
    {
        public string Base { get; set; }
        public string Target { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        public string Change { get; set; }
        public List<MarketDTO> Markets { get; set; }
    }
}
