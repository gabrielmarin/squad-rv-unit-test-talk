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
            var customerCode = new Random().Next(1, 101);
            DbMock.CustomerAccounts.Add(customerCode, new AccountEntity { CustomerCode = customerCode, AccountBalance = initialFunds });
            return customerCode;
        }

        public async Task UpdateAsync(AccountEntity entity)
        {
            await Task.Delay(new Random().Next(100, 1001));
            if (DbMock.CustomerAccounts.TryGetValue(entity.CustomerCode, out var account))
                account = entity;
        }

        public async Task<AccountEntity> FindAsync(int customerCode)
        {
            await Task.Delay(new Random().Next(100, 1001));
            if (DbMock.CustomerAccounts.TryGetValue(customerCode, out var account))
            {
                return account;
            }

            return null;
        }

        public async Task<IEnumerable<AccountEntity>> ListAllAsync()
        {
            await Task.Delay(new Random().Next(100, 1001));
            return DbMock.CustomerAccounts.Select(x => x.Value).ToList();
        }
    }
}
