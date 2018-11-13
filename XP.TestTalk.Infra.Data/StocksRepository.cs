using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;
using XP.TestTalk.Domain.Infra;

namespace XP.TestTalk.Infra.Data
{
    public class StocksRepository : IStocksRepository
    {
        public async Task<StockEntity> FindByTickerAsync(string ticker)
        {
            await Task.Delay(new Random().Next(100, 1001));
            if (DbMock.Stocks.TryGetValue(ticker, out var stockEntity))
                return stockEntity;
            return null;
        }

        public async Task<IEnumerable<StockEntity>> ListAllAsync()
        {
            await Task.Delay(new Random().Next(100, 1001));
            return DbMock.Stocks.Select(x => x.Value).ToList();
        }
    }
}
