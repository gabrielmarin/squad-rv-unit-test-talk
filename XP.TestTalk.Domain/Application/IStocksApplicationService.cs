using System.Collections.Generic;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;

namespace XP.TestTalk.Domain.Application
{
    public interface IStocksApplicationService
    {
        Task<StockEntity> FindByTickerAsync(string ticker);

        Task<IEnumerable<StockEntity>> ListAllAsync();
    }
}