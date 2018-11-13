using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.App_Start;
using XP.TestTalk.Application;
using XP.TestTalk.Domain.Application;
using XP.TestTalk.Infra.Data;

namespace XP.TestTalk.Tests
{
    [TestClass]
    public class AccountApplicationServiceTest
    {
        private IAccountApplicationService _accountAppService;

        [TestInitialize]
        public void SetUp()
        {
            var repository = new AccountRepository();
            _accountAppService = new AccountApplicationService(repository);
        }
       

        [TestMethod]
        public async Task Should_Create_Account()
        {
            var customerCode = await _accountAppService.CreateAccountAsync(100);
            Assert.IsNotNull(customerCode);
        }
    }
}
