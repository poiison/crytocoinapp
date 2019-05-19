using cryptocoin.integration.Shrimpy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Shrimpy.Interface
{
    public interface IIntegrationShrimpyService
    {
        Task<List<Currency>> ConsultarConversaoCompleta();
    }
}
