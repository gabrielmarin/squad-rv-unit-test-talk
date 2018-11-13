using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.App_Start;
using XP.TestTalk.Application;
using XP.TestTalk.Domain.Application;
using XP.TestTalk.Domain.Entities;
using XP.TestTalk.Domain.Infra;
using XP.TestTalk.Infra.Data;

namespace XP.TestTalk.Tests
{
    [TestClass]
    public class AccountApplicationServiceTest
    {
        private Mock<IAccountRepository> _accountRepositoryMock;
        private IAccountApplicationService _accountAppService;

        [TestInitialize]
        public void SetUp()
        {
             _accountRepositoryMock = new Mock<IAccountRepository>();            
            _accountAppService = new AccountApplicationService(_accountRepositoryMock.Object);
        }
       

        [TestMethod]
        public async Task Should_Create_Account()
        {
            var initialFunds = 100m;
            _accountRepositoryMock.Setup(x => x.CreateAccountAsync(It.Is<decimal>(y => y == initialFunds))).ReturnsAsync(666);
            var customerCode = await _accountAppService.CreateAccountAsync(initialFunds);
            Assert.AreEqual(666, customerCode);
        }

        [TestMethod]
        public async Task Should_Not_Create_Account_If_Funds_Are_Less_Than_A_Hundred()
        {
            var initialFunds = 90m;
            var expectedResult = 666;            
            var customerCode = await _accountAppService.CreateAccountAsync(initialFunds);
            _accountRepositoryMock.Verify(x => x.CreateAccountAsync(It.IsAny<decimal>()), Times.Never());
        }

        [TestMethod]
        public async Task Should_Deposit_The_Correct_Amount_Into_Account_Balance()
        {
            var customerCode = 123;
            var value = 100m;
            var account = new AccountEntity { AccountBalance = 100m, CustomerCode = customerCode};
            _accountRepositoryMock.Setup(x => x.FindAsync(It.Is<int>(y => y == customerCode))).ReturnsAsync(account);
            await _accountAppService.DepositAsync(customerCode, value);
            _accountRepositoryMock.Verify(x => x.UpdateAsync(It.Is<AccountEntity>(y => y.AccountBalance == 200)), Times.Once());
        }
    }
}
