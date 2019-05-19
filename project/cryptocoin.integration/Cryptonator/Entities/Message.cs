using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Cryptonator.Entities
{
    public class Message
    {
        public Ticker ticker { get; set; }
        public double timestamp { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
    }
}
