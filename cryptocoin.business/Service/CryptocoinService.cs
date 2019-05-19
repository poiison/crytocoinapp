using cryptocoin.business.Mapping.Interface;
using cryptocoin.business.Service.Interface;
using cryptocoin.contract.Request;
using cryptocoin.contract.Response;
using cryptocoin.contract.Response.Bitcoinfee;
using cryptocoin.contract.Response.Cryptonator.Entities;
using cryptocoin.contract.Response.Shrimpy;
using cryptocoin.integration.Bitcoinfees.Interface;
using cryptocoin.integration.Cryptonator;
using cryptocoin.integration.Cryptonator.Cryptonator.Interface;
using cryptocoin.integration.Shrimpy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cryptocoin.business.Service
{
    public class CryptocoinService : ICryptocoinService
    {
        private readonly IIntegrationCryptonatorService _integrationCryptonatorService;
        private readonly IIntegrationShrimpyService _shrimpyService;
        private readonly IIntegrationBitcoinfeesService _integrationBitcoinfeeService;

        private readonly ICryptocoinMapper _cryptocoinMapper;

        private static List<CriptomoedaDTO> LISTA_CRIPTOMOEDAS;

        public CryptocoinService(IIntegrationCryptonatorService integrationCryptonatorService,
                                     IIntegrationShrimpyService shrimpyService,
                                     IIntegrationBitcoinfeesService integrationBitcoinfeeService,
                                     ICryptocoinMapper cryptocoinMapper)
        {
            _integrationCryptonatorService = integrationCryptonatorService;
            _integrationBitcoinfeeService = integrationBitcoinfeeService;
            _shrimpyService = shrimpyService;

            _cryptocoinMapper = cryptocoinMapper;
        }

        /// <summary>
        /// Obter lista de criptomedas
        /// </summary>
        /// <returns></returns>
        public async Task<RetornoDTO<List<CriptomoedaDTO>>> ObterListaCriptomoedas()
        {
            var retorno = new RetornoDTO<List<CriptomoedaDTO>>();

            if (LISTA_CRIPTOMOEDAS != null)
                retorno.Retorno = LISTA_CRIPTOMOEDAS;
            else
            {
                var resultado = await _shrimpyService.ConsultarConversaoCompleta();

                LISTA_CRIPTOMOEDAS = _cryptocoinMapper.CurrenciesToCriptomoedas(resultado);

                AdicionarUSDEmLista(ref LISTA_CRIPTOMOEDAS);

                retorno.Retorno = LISTA_CRIPTOMOEDAS;
            }

            retorno.Sucesso = true;

            return retorno;
        }

        /// <summary>
        /// Obter taxa de conversão entre moedas 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public async Task<RetornoDTO<MessageDTO>> ConverterCompleto(FiltroExchangeDTO filtro)
        {
            var retorno = new RetornoDTO<MessageDTO>();

            if (filtro.Base == filtro.Target)
            {
                retorno.Sucesso = false;
                retorno.Exception = new List<Exception>() { new Exception("Selecione moedas diferentes para a busca.") };

                return retorno;
            }


            var resultado = await _integrationCryptonatorService.ConsultarConversaoCompleta(_cryptocoinMapper.FiltroDTOToFiltroExchange(filtro));

            retorno.Retorno = _cryptocoinMapper.MessageToMessageDTO(resultado);
            retorno.Sucesso = true;

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<RetornoDTO<RecommendedFeeDTO>> ObterTaxaRecomendadaBTC()
        {
            var retorno = new RetornoDTO<RecommendedFeeDTO>();

            var resultado = await _integrationBitcoinfeeService.ObterTaxaRecomendadaBTC();

            retorno.Retorno = _cryptocoinMapper.RecommendedFeeTORecommendedFeeDTO(resultado);
            retorno.Sucesso = true;

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<RetornoDTO<FeesDTO>> ObterTaxasBTC()
        {
            var retorno = new RetornoDTO<FeesDTO>();

            var resultado = await _integrationBitcoinfeeService.ObterTaxasBTC();

            retorno.Retorno = _cryptocoinMapper.FeesToFeesDTO(resultado);
            retorno.Sucesso = true;

            return retorno;
        }


        #region AUXILIAR

        /// <summary>
        /// Adiciona o valor USD para a lista de itens de criptomoedas
        /// </summary>
        /// <param name="o"></param>
        private static void AdicionarUSDEmLista(ref List<CriptomoedaDTO> o)
        {
            if (o.Where(x => x.Nome == "USD").Count() == 0)
                o.Add(new CriptomoedaDTO()
                {
                    Id = o.Count + 1,
                    Nome = "USD",
                    Simbolo = "USD",
                    SimboloTroca = "USD"
                });
        }

        #endregion
    }
}
