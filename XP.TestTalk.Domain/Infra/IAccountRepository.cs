using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;

namespace XP.TestTalk.Domain.Infra
{
    public interface IAccountRepository
    {
        Task<int> CreateAccountAsync(decimal initialFunds);
        Task DepositAsync(int customerCode, decimal value);
        Task<IEnumerable<AccountEntity>> ListAll();
        Task<AccountEntity> Find(int customerCode);
    }
}
