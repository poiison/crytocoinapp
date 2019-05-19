using cryptocoin.integration.Cryptonator.Cryptonator.Interface;
using cryptocoin.integration.Cryptonator.Entities;
using cryptocoin.integration.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace cryptocoin.integration.Cryptonator
{
    public class IntegrationCryptonatorService : IIntegrationCryptonatorService
    {
        /// <summary>
        /// Metodo de consulta a api do Cryptonator para taxas de conversao
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public async Task<Message> ConsultarConversaoCompleta(FiltroExchange filtro)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Parametros.UrlApiCryptonator);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string requestUri = string.Concat("full/" + filtro.GetFiltro());

                    var response = client.GetAsync(requestUri).Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<Message>(await response.Content.ReadAsStringAsync());
                    else
                        throw new Exception("Erro ao buscar dados da API.");
                }
            }
            catch (Exception) { throw; }
        }
    }
}
