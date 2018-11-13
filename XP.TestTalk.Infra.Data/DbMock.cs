using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XP.TestTalk.Domain.Entities;

namespace XP.TestTalk.Infra.Data
{
    public static class DbMock
    {
        public static Dictionary<int, AccountEntity> CustomerAccounts = new Dictionary<int, AccountEntity>();
        public static List<StockEntity> Stocks = new List<StockEntity>
        {
            new StockEntity { Ticker = "PETR4", CurrentPrice = 10m},
            new StockEntity { Ticker = "VALE3", CurrentPrice = 15m },
            new StockEntity { Ticker = "ITUB4", CurrentPrice = 7m },
            new StockEntity { Ticker = "ELET3", CurrentPrice = 5m },
            new StockEntity { Ticker = "UGPA3", CurrentPrice = 5m }
        };
    }
}
