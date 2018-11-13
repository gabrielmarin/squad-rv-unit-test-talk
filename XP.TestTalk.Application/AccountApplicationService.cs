using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Application;
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
            return await _accountRepository.CreateAccountAsync(initialFunds);
        }

        public async Task DepositAsync(int customerCode, decimal value)
        {
            await _accountRepository.DepositAsync(customerCode, value);
        }
    }
}
