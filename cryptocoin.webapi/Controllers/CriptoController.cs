using cryptocoin.business.Service.Interface;
using cryptocoin.contract.Request;
using cryptocoin.contract.Response;
using cryptocoin.contract.Response.Bitcoinfee;
using cryptocoin.contract.Response.Cryptonator.Entities;
using cryptocoin.contract.Response.Shrimpy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace cryptocoin.webapi.Controllers
{
    [RoutePrefix("cripto")]
    public class CriptoController : BaseApiController
    {
        private readonly ICryptocoinService _cryptoCurrencyService;

        public CriptoController(ICryptocoinService cryptoCurrencyService) : base()
        {
            _cryptoCurrencyService = cryptoCurrencyService;
        }

        /// <summary>
        /// Obter lista de criptomedas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(RetornoDTO<CriptomoedaDTO>))]
        public async Task<IHttpActionResult> ObterListaCriptomoedas()
        {
            try
            {
                var resultado = await _cryptoCurrencyService.ObterListaCriptomoedas();

                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao consultar lista de criptomoedas");
            }
        }

        /// <summary>
        /// Obter taxa de conversão entre criptomoedas
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(RetornoDTO<MessageDTO>))]
        public async Task<IHttpActionResult> ObterTaxaConversaoCriptomoedas(FiltroExchangeDTO filtro)
        {
            try
            {
                var resultado = await _cryptoCurrencyService.ConverterCompleto(filtro);

                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao consultar lista de exchanges");
            }
        }

        [HttpGet]
        [ResponseType(typeof(RetornoDTO<RecommendedFeeDTO>))]
        public async Task<IHttpActionResult> ObterTaxaRecomendadaBTC()
        {
            try
            {
                var resultado = await _cryptoCurrencyService.ObterTaxaRecomendadaBTC();

                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao consultar taxa recomendada para BTC");
            }
        }

        [HttpGet]
        [ResponseType(typeof(RetornoDTO<FeesDTO>))]
        public async Task<IHttpActionResult> ObterTaxasBTC()
        {
            try
            {
                var resultado = await _cryptoCurrencyService.ObterTaxasBTC();

                return Ok(resultado);
            }
            catch (Exception)
            {
                return BadRequest("Erro ao consultar taxas para BTC");
            }
        }
    }
}
