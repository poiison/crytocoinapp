using cryptocoin.business.Mapping.Interface;
using cryptocoin.contract.Request;
using cryptocoin.contract.Response.Bitcoinfee;
using cryptocoin.contract.Response.Cryptonator.Entities;
using cryptocoin.contract.Response.Shrimpy;
using cryptocoin.integration.Bitcoinfees.Entities;
using cryptocoin.integration.Cryptonator.Entities;
using cryptocoin.integration.Shrimpy.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace cryptocoin.business.Mapping
{
    //TODO: COLOCAR AUTOMAPPER
    public class CryptocoinMapper : ICryptocoinMapper
    {
        public MessageDTO MessageToMessageDTO(Message o)
        {
            return new MessageDTO
            {
                error = o.error,
                success = o.success,
                ticker = this.TickerToTickerDTO(o.ticker),
                timestamp = o.timestamp,
                data = ConvertFromUnixTimestamp(o.timestamp).ToString("dd/MM/yyyy hh:mm:ss")
            };
        }

        public TickerDTO TickerToTickerDTO(Ticker o) {

            return new TickerDTO
            {
                Base = o.@base,
                Change = o.change,
                Markets = this.MarketToMarketDTO(o.markets),
                Price = o.price,
                Target = o.target,
                Volume = o.volume
            };
        }

        public MarketDTO MarketToMarketDTO(Market o)
        {
            return new MarketDTO
            {
                Market = o.market,
                Price = decimal.Parse(o.price, CultureInfo.GetCultureInfo("en-us")),
                Volume = o.volume
            };
        }

        public List<MarketDTO> MarketToMarketDTO(List<Market> o)
        {
            var l = new List<MarketDTO>();

            o.ForEach(x => l.Add(this.MarketToMarketDTO(x)));

            return l;
        }

        public FiltroExchange FiltroDTOToFiltroExchange(FiltroExchangeDTO o)
        {
            return new FiltroExchange
            {
                Base = o.Base,
                Target = o.Target
            };
        }

        public CriptomoedaDTO CurrencyToCriptomoeda(Currency o)
        {
            return new CriptomoedaDTO
            {
                Id = o.id,
                Nome = o.name,
                Simbolo = o.symbol,
                SimboloTroca = o.tradingSymbol
            };
        }

        public List<CriptomoedaDTO> CurrenciesToCriptomoedas(List<Currency> o)
        {
            var l = new List<CriptomoedaDTO>();

            o.ForEach(x => l.Add(this.CurrencyToCriptomoeda(x)));

            return l;
        }

        public RecommendedFeeDTO RecommendedFeeTORecommendedFeeDTO(RecommendedFee o)
        {
            return new RecommendedFeeDTO()
            {
                fastestFee = o.fastestFee,
                halfHourFee  = o.halfHourFee,
                hourFee = o.hourFee
            };
        }

        public FeeDTO FeeTOFeeDTO(Fee o)
        {
            return new FeeDTO()
            {
                dayCount = o.dayCount,
                maxDelay = o.maxDelay,
                maxFee = o.maxFee,
                maxMinutes = o.maxMinutes,
                memCount = o.memCount,
                minDelay = o.minDelay,
                minFee = o.minFee,
                minMinutes = o.minMinutes
            };
        }

        public FeesDTO FeesToFeesDTO(Fees o)
        {
            return new FeesDTO()
            {
                fees = FeeTOFeeDTO(o.fees)
            };
        }

        public List<FeeDTO> FeeTOFeeDTO(List<Fee> o)
        {
            var l = new List<FeeDTO>();

            o.ForEach(x => l.Add(this.FeeTOFeeDTO(x)));

            return l;
        }

        static DateTime ConvertFromUnixTimestamp(double timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(timestamp);
        }
    }
}
