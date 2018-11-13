using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;

namespace XP.TestTalk.Domain.Infra
{
    public interface IStocksRepository
    {
        Task<StockEntity> FindByTickerAsync(string ticker);
        Task<IEnumerable<StockEntity>> ListAllAsync();
    }
}
