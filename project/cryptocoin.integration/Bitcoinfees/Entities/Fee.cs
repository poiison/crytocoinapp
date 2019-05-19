using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Bitcoinfees.Entities
{
    public class Fees
    {
        public List<Fee> fees { get; set; }
    }

    public class Fee
    {
        public int minFee { get; set; }
        public int maxFee { get; set; }
        public int dayCount { get; set; }
        public int memCount { get; set; }
        public int minDelay { get; set; }
        public int maxDelay { get; set; }
        public int minMinutes { get; set; }
        public int maxMinutes { get; set; }
    }
}
