using cryptocoin.integration.Entities;
using cryptocoin.integration.Shrimpy.Entities;
using cryptocoin.integration.Shrimpy.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Shrimpy
{
    public class IntegrationShrimpyService : IIntegrationShrimpyService
    {
        /// <summary>
        /// Método que busca lista de criptomoeadas na api do Shrimpy
        /// </summary>
        /// <returns></returns>
        public async Task<List<Currency>> ConsultarConversaoCompleta()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Parametros.UrlApiShrimpy);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("").Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<List<Currency>>(await response.Content.ReadAsStringAsync());
                    else
                        throw new Exception("Erro ao buscar dados da API.");
                }
            }
            catch (Exception) { throw; }
        }
    }
}
