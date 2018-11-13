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
    [RoutePrefix("api/v1/accounts/{customerCode:int}/orders")]
    public class OrderController : ApiController
    {
        private readonly IOrderApplicationService _orderApplicationService;

        public OrderController(IOrderApplicationService orderApplicationService)
        {
            _orderApplicationService = orderApplicationService;
        }

        [Route(), HttpPost]
        public async Task<IHttpActionResult> FindByTicker(int customerCode, string ticker, int amount)
        {
            await _orderApplicationService.PlaceOrder(customerCode, ticker, amount);
            return Ok();
        }
    }
}
