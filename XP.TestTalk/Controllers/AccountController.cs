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
    [RoutePrefix("api/v1/accounts")]
    public class AccountController : ApiController
    {
        private readonly IAccountApplicationService _accountApplicationService;

        public AccountController(IAccountApplicationService accountApplicationService)
        {
            _accountApplicationService = accountApplicationService;
        }

        [Route(""), HttpPost]
        public async Task<IHttpActionResult> CreateAccount([FromBody]decimal initialFunds)
        {
            var customerCode = await _accountApplicationService.CreateAccountAsync(initialFunds);
            return Created("", customerCode);
        }

        [Route("{customerCode:int}"), HttpPatch]
        public async Task<IHttpActionResult> DepositFunds(int customerCode, [FromBody]decimal value)
        {
            await _accountApplicationService.DepositAsync(customerCode, value);
            return Ok();
        }


    }
}
