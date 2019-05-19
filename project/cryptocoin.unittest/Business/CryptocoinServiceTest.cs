using cryptocoin.business.Mapping.Interface;
using cryptocoin.business.Service;
using cryptocoin.contract.Request;
using cryptocoin.contract.Response.Bitcoinfee;
using cryptocoin.contract.Response.Cryptonator.Entities;
using cryptocoin.contract.Response.Shrimpy;
using cryptocoin.integration.Bitcoinfees.Entities;
using cryptocoin.integration.Bitcoinfees.Interface;
using cryptocoin.integration.Cryptonator.Cryptonator.Interface;
using cryptocoin.integration.Cryptonator.Entities;
using cryptocoin.integration.Shrimpy.Entities;
using cryptocoin.integration.Shrimpy.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cryptocoin.unittest.Business
{
    [TestClass]
    public class CryptocoinServiceTest
    {
        private Mock<IIntegrationCryptonatorService> _integrationCryptonatorService;
        private Mock<IIntegrationShrimpyService> _shrimpyServiceIShrimpyService;
        private Mock<IIntegrationBitcoinfeesService> _integrationBitcoinfeeService;
        private Mock<ICryptocoinMapper> _cryptocoinMapper;

        [TestInitialize]
        public void Init()
        {
            _integrationCryptonatorService = new Mock<IIntegrationCryptonatorService>(MockBehavior.Strict);
            _shrimpyServiceIShrimpyService = new Mock<IIntegrationShrimpyService>(MockBehavior.Strict);
            _integrationBitcoinfeeService = new Mock<IIntegrationBitcoinfeesService>(MockBehavior.Strict);
            _cryptocoinMapper = new Mock<ICryptocoinMapper>(MockBehavior.Strict);
        }

        [TestMethod]
        public async Task CryptoCurrencyService_ObterListaCriptomoedasTest()
        {
            var retornoListaCriptomoedas = new List<Currency>();

            _shrimpyServiceIShrimpyService.Setup(x => x.ConsultarConversaoCompleta()).ReturnsAsync(retornoListaCriptomoedas);
            _cryptocoinMapper.Setup(x => x.CurrenciesToCriptomoedas(It.IsAny<List<Currency>>())).Returns(new List<CriptomoedaDTO>()
            {
                new CriptomoedaDTO() { Id = 1, Nome = "BTC", Simbolo = "BTC", SimboloTroca = "BTC" }
            });

            CryptocoinService cryptoCurrencyService = new CryptocoinService(_integrationCryptonatorService.Object,
                                                                                    _shrimpyServiceIShrimpyService.Object,
                                                                                    _integrationBitcoinfeeService.Object,
                                                                                    _cryptocoinMapper.Object);

            var res = await cryptoCurrencyService.ObterListaCriptomoedas();

            Assert.IsNotNull(res.Retorno);
            Assert.IsTrue(res.Sucesso);
        }

        [TestMethod]
        public async Task CryptoCurrencyService_ConverterCompletoTest()
        {
            var retornoMessageDTO = new MessageDTO();

            _integrationCryptonatorService.Setup(x => x.ConsultarConversaoCompleta(It.IsAny<FiltroExchange>()))
                .ReturnsAsync(new Message());

            _cryptocoinMapper.Setup(x => x.MessageToMessageDTO(It.IsAny<Message>())).Returns(new MessageDTO()
            {
                error = "",
                success = true,
                ticker = new TickerDTO()
                {
                    Base = "BTC",
                    Target = "USD",
                    Price = "443.7807865468",
                    Volume = "31720.1493969300",
                    Change = "0.3766203596",
                    Markets = new List<MarketDTO>()
                    {
                        new MarketDTO(){ Market = "bitfinex", Volume = 447.5000000000, Price = Convert.ToDecimal("10559.5293639000") },
                        new MarketDTO(){ Market = "bitstamp", Volume = 448.5400000000, Price = Convert.ToDecimal("11628.2880079300") },
                        new MarketDTO(){ Market = "btce", Volume = 432.8900000000, Price = Convert.ToDecimal("8561.0563600000") }
                    },
                },
                timestamp = 1399490941
            });
            _cryptocoinMapper.Setup(x => x.FiltroDTOToFiltroExchange(It.IsAny<FiltroExchangeDTO>())).Returns(new FiltroExchange());

            CryptocoinService cryptoCurrencyService = new CryptocoinService(_integrationCryptonatorService.Object,
                                                                                    _shrimpyServiceIShrimpyService.Object,
                                                                                    _integrationBitcoinfeeService.Object,
                                                                                    _cryptocoinMapper.Object);

            var res = await cryptoCurrencyService.ConverterCompleto(new FiltroExchangeDTO() { Base ="btc", Target= "usd"});

            Assert.IsNotNull(res.Retorno);
            Assert.IsTrue(res.Sucesso);
        }

        [TestMethod]
        public async Task CryptoCurrencyService_ObterTaxaRecomendadaBTCTest()
        {
            var retornoRecommendedFee = new RecommendedFee();

            _integrationBitcoinfeeService.Setup(x => x.ObterTaxaRecomendadaBTC()).ReturnsAsync(retornoRecommendedFee);
            _cryptocoinMapper.Setup(x => x.RecommendedFeeTORecommendedFeeDTO(It.IsAny<RecommendedFee>())).Returns(new RecommendedFeeDTO()
            {
                fastestFee = 100,
                halfHourFee = 100,
                hourFee = 100
            });

            CryptocoinService cryptoCurrencyService = new CryptocoinService(_integrationCryptonatorService.Object,
                                                                                    _shrimpyServiceIShrimpyService.Object,
                                                                                    _integrationBitcoinfeeService.Object,
                                                                                    _cryptocoinMapper.Object);

            var res = await cryptoCurrencyService.ObterTaxaRecomendadaBTC();

            Assert.IsNotNull(res.Retorno);
            Assert.IsTrue(res.Sucesso);
        }


    }
}
