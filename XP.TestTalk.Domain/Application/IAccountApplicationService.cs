using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XP.TestTalk.Domain.Application
{
    public interface IAccountApplicationService
    {
        Task<int> CreateAccountAsync(decimal initialFunds);
        Task DepositAsync(int customerCode, decimal value);
    }
}
