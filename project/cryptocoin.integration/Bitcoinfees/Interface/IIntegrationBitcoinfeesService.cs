using cryptocoin.integration.Bitcoinfees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Bitcoinfees.Interface
{
    public interface IIntegrationBitcoinfeesService
    {
        Task<RecommendedFee> ObterTaxaRecomendadaBTC();
        Task<Fees> ObterTaxasBTC();
    }
}
