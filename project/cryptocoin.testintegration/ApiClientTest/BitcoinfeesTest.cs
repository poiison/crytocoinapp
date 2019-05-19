using cryptocoin.integration.Bitcoinfees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.testintegration.ApiClientTest
{
    [TestClass]
    public class BitcoinfeesTest
    {
        [TestMethod]
        public async Task ApiClient_Bitcoinfees_ObterTaxaRecomendadaBTCTest()
        {
            IntegrationBitcoinfeesService integrationBitcoinfeesService = new IntegrationBitcoinfeesService();

            var res = await integrationBitcoinfeesService.ObterTaxaRecomendadaBTC();

            Assert.IsNotNull(res);
        }
    }
}
