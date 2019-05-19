using cryptocoin.integration.Cryptonator;
using cryptocoin.integration.Cryptonator.Cryptonator.Interface;
using cryptocoin.integration.Cryptonator.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.testintegration.ApiClientTest
{
    [TestClass]
    public class CryptonatorTest
    {
        [TestMethod]
        public async Task ApiClient_Cryptonator_ConsultarConversaoCompletaTest()
        {
            IntegrationCryptonatorService integrationCryptonatorService = new IntegrationCryptonatorService();

            var filtro = new FiltroExchange()
            {
                Base = "btc",
                Target = "usd"
            };

            var res = await integrationCryptonatorService.ConsultarConversaoCompleta(filtro);

            Assert.IsNotNull(res);
        }
    }
}
