using System.Collections.Generic;
using XP.TestTalk.Domain.Entities;

namespace XP.TestTalk.Infra.Data
{
    public static class DbMock
    {
        public static Dictionary<int, AccountEntity> CustomerAccounts = new Dictionary<int, AccountEntity>();

        public static Dictionary<string, StockEntity> Stocks = new Dictionary<string, StockEntity>
        {
            { "PETR4", new StockEntity { Ticker = "PETR4", CurrentPrice = 10m} },
            { "VALE3", new StockEntity { Ticker = "VALE3", CurrentPrice = 15m } },
            { "ITUB4", new StockEntity { Ticker = "ITUB4", CurrentPrice = 7m } },
            { "ELET3", new StockEntity { Ticker = "ELET3", CurrentPrice = 5m } },
            { "UGPA3", new StockEntity { Ticker = "UGPA3", CurrentPrice = 5m } }
        };
    }
}