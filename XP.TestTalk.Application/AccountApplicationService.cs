using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Application;
using XP.TestTalk.Domain.Entities;
using XP.TestTalk.Domain.Infra;

namespace XP.TestTalk.Application
{
    public class AccountApplicationService : IAccountApplicationService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountApplicationService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<int> CreateAccountAsync(decimal initialFunds)
        {
            if (initialFunds < 100)
                return 0;

            var customerCode = await _accountRepository.CreateAccountAsync(initialFunds);
            return customerCode;
        }

        public async Task DepositAsync(int customerCode, decimal value)
        {
            var accountEntity = await _accountRepository.FindAsync(customerCode);
            accountEntity.AccountBalance += value;
            await _accountRepository.UpdateAsync(accountEntity);            
        }

        public async Task<AccountEntity> Find(int customerCode)
        {
            return await _accountRepository.FindAsync(customerCode);
        }

        public async Task<IEnumerable<AccountEntity>> ListAll()
        {
            return await _accountRepository.ListAllAsync();
        }
    }
}
