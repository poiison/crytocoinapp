using cryptocoin.business.Mapping;
using cryptocoin.business.Mapping.Interface;
using cryptocoin.business.Service;
using cryptocoin.business.Service.Interface;
using cryptocoin.integration.Bitcoinfees;
using cryptocoin.integration.Bitcoinfees.Interface;
using cryptocoin.integration.Cryptonator;
using cryptocoin.integration.Cryptonator.Cryptonator.Interface;
using cryptocoin.integration.Shrimpy;
using cryptocoin.integration.Shrimpy.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cryptocoin.webapi.Ioc
{
    public class ProjectIoc
    {
        public static void RegisterServices(IKernel kernel)
        {
            //business
            kernel.Bind<ICryptocoinService>().To<CryptocoinService>();

            //integration
            kernel.Bind<IIntegrationCryptonatorService>().To<IntegrationCryptonatorService>();
            kernel.Bind<IIntegrationBitcoinfeesService>().To<IntegrationBitcoinfeesService>();
            kernel.Bind<IIntegrationShrimpyService>().To<IntegrationShrimpyService>();
            

            //mapper
            kernel.Bind<ICryptocoinMapper>().To<CryptocoinMapper>();
        }
    }
}