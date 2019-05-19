using cryptocoin.contract.Request;
using cryptocoin.contract.Response.Bitcoinfee;
using cryptocoin.contract.Response.Cryptonator.Entities;
using cryptocoin.contract.Response.Shrimpy;
using cryptocoin.integration.Bitcoinfees.Entities;
using cryptocoin.integration.Cryptonator.Entities;
using cryptocoin.integration.Shrimpy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.business.Mapping.Interface
{
    public interface ICryptocoinMapper
    {
        MessageDTO MessageToMessageDTO(Message o);
        TickerDTO TickerToTickerDTO(Ticker o);
        MarketDTO MarketToMarketDTO(Market o);
        List<MarketDTO> MarketToMarketDTO(List<Market> o);
        FiltroExchange FiltroDTOToFiltroExchange(FiltroExchangeDTO o);
        CriptomoedaDTO CurrencyToCriptomoeda(Currency o);
        List<CriptomoedaDTO> CurrenciesToCriptomoedas(List<Currency> o);
        RecommendedFeeDTO RecommendedFeeTORecommendedFeeDTO(RecommendedFee o);

        FeeDTO FeeTOFeeDTO(Fee o);
        FeesDTO FeesToFeesDTO(Fees o);
        List<FeeDTO> FeeTOFeeDTO(List<Fee> o);
    }
}
