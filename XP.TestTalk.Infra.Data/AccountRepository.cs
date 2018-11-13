using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;
using XP.TestTalk.Domain.Infra;

namespace XP.TestTalk.Infra.Data
{
    public class AccountRepository : IAccountRepository
    {
        public async Task<int> CreateAccountAsync(decimal initialFunds)
        {
            await Task.Delay(new Random().Next(100, 1001));
            var customerCode = new Random().Next();
            DbMock.CustomerAccounts.Add(customerCode, new AccountEntity { CustomerCode = customerCode, AccountBalance = initialFunds });
            return customerCode;
        }

        public async Task DepositAsync(int customerCode, decimal value)
        {
            await Task.Delay(new Random().Next(100, 1001));
            if (DbMock.CustomerAccounts.TryGetValue(customerCode, out var account))
                account.AccountBalance += value;
        }
    }
}
