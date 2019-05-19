using cryptocoin.integration.Bitcoinfees.Entities;
using cryptocoin.integration.Bitcoinfees.Interface;
using cryptocoin.integration.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.integration.Bitcoinfees
{
    public class IntegrationBitcoinfeesService : IIntegrationBitcoinfeesService
    {
        public async Task<RecommendedFee> ObterTaxaRecomendadaBTC()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Parametros.UrlApiBitcoinfee);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("recommended").Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<RecommendedFee>(await response.Content.ReadAsStringAsync());
                    else
                        throw new Exception("Erro ao buscar dados da API.");
                }
            }
            catch (Exception) { throw; }
        }

        public async Task<Fees> ObterTaxasBTC()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Parametros.UrlApiBitcoinfee);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.GetAsync("list").Result;

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<Fees>(await response.Content.ReadAsStringAsync());
                    else
                        throw new Exception("Erro ao buscar dados da API.");
                }
            }
            catch (Exception) { throw; }
        }
    }
}
