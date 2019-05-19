using cryptocoin.contract.Request;
using cryptocoin.contract.Response;
using cryptocoin.contract.Response.Bitcoinfee;
using cryptocoin.contract.Response.Cryptonator.Entities;
using cryptocoin.contract.Response.Shrimpy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.business.Service.Interface
{
    public interface ICryptocoinService
    {
        Task<RetornoDTO<List<CriptomoedaDTO>>> ObterListaCriptomoedas();
        Task<RetornoDTO<MessageDTO>> ConverterCompleto(FiltroExchangeDTO filtro);
        Task<RetornoDTO<RecommendedFeeDTO>> ObterTaxaRecomendadaBTC();
        Task<RetornoDTO<FeesDTO>> ObterTaxasBTC();
    }
}
