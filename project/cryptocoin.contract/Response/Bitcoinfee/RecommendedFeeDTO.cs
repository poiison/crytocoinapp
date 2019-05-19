using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.contract.Response.Bitcoinfee
{
    public class RecommendedFeeDTO
    {
        public int fastestFee { get; set; }
        public int halfHourFee { get; set; }
        public int hourFee { get; set; }
    }
}
