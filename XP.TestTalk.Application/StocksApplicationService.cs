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
    public class StocksApplicationService : IStocksApplicationService
    {
        private readonly IStocksRepository _stocksRepository;

        public StocksApplicationService(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }
        public async Task<StockEntity> FindByTickerAsync(string ticker)
        {
            return await _stocksRepository.FindByTickerAsync(ticker);
        }

        public async Task<IEnumerable<StockEntity>> ListAllAsync()
        {
            return await _stocksRepository.ListAllAsync();
        }
    }
}
