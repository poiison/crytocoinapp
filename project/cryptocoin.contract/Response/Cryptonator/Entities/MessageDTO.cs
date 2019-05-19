using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.contract.Response.Cryptonator.Entities
{
    public class MessageDTO
    {
        public TickerDTO ticker { get; set; }
        public double timestamp { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        public string data { get; set; }
    }
}
