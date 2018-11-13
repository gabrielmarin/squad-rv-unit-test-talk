using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using XP.TestTalk.Domain.Application;

namespace XP.TestTalk.Controllers
{
    [RoutePrefix("api/v1/stocks")]
    public class StocksController : ApiController
    {
        private readonly IStocksApplicationService _stocksApplicationService;

        public StocksController(IStocksApplicationService stocksApplicationService)
        {
            _stocksApplicationService = stocksApplicationService;
        }



        [Route(""), HttpGet]
        public async Task<IHttpActionResult> Get(string ticker = null)
        {
            if (string.IsNullOrWhiteSpace(ticker))
                return Ok((await _stocksApplicationService.ListAllAsync()));

            return Ok((await _stocksApplicationService.FindByTickerAsync(ticker)));
        }
    }
}
