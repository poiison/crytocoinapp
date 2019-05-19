using cryptocoin.integration.Cryptonator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Cryptonator.Cryptonator.Interface
{
    public interface IIntegrationCryptonatorService
    {
        Task<Message> ConsultarConversaoCompleta(FiltroExchange filtro);
    }
}
