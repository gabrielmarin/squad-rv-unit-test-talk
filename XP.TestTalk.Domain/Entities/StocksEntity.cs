using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XP.TestTalk.Domain.Entities
{
    public class StockEntity
    {
        public string Ticker { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
