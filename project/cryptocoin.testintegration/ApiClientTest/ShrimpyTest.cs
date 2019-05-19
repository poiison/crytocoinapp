using cryptocoin.integration.Shrimpy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.testintegration.ApiClientTest
{
    [TestClass]
    public class ShrimpyTest
    {
        [TestMethod]
        public async Task ApiClient_Shrimpy_ConsultarConversaoCompletaTest()
        {
            IntegrationShrimpyService shrimpyService = new IntegrationShrimpyService();

            var res = await shrimpyService.ConsultarConversaoCompleta();

            Assert.IsNotNull(res);
        }
    }
}
