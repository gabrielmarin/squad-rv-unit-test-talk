using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XP.TestTalk.Domain.Entities
{
    public class StockPositionEntity
    {
        public int Amount { get; set; }
        public StockEntity Stock { get; set; }
    }
}
