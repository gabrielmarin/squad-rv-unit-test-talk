using System.Collections.Generic;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;

namespace XP.TestTalk.Domain.Infra
{
    public interface IAccountRepository
    {
        Task<int> CreateAccountAsync(decimal initialFunds);

        Task UpdateAsync(AccountEntity entity);

        Task<IEnumerable<AccountEntity>> ListAllAsync();

        Task<AccountEntity> FindAsync(int customerCode);
    }
}