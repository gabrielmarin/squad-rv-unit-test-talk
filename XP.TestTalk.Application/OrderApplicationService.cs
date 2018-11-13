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
    public class OrderApplicationService : IOrderApplicationService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IStocksApplicationService _stocksAppService;

        public OrderApplicationService(IAccountRepository accountRepository, IStocksApplicationService stocksAppService)
        {
            _accountRepository = accountRepository;
            _stocksAppService = stocksAppService;
        }

        public async Task PlaceOrder(int customerCode, string ticker, int amount)
        {
            var account = await _accountRepository.FindAsync(customerCode);
            var stockEntity = await _stocksAppService.FindByTickerAsync(ticker);

            var totalPrice = stockEntity.CurrentPrice * amount;
            if (account.AccountBalance < totalPrice)
                throw new Exception("Trump says: Wrong!");

            if (account.Positions == null)
                account.Positions = new List<StockPositionEntity>();
            var stockPosition = account.Positions.FirstOrDefault(x => x.Stock.Ticker == ticker);
            if (stockPosition == null)
                account.Positions = account.Positions.Append(new StockPositionEntity { Amount = amount, Stock = stockEntity });
            else
                stockPosition.Amount += amount;
            account.AccountBalance -= totalPrice;

            await _accountRepository.UpdateAsync(account);
        }
    }
}
