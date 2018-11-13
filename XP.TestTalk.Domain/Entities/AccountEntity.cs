using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XP.TestTalk.Domain.Entities
{
    public class AccountEntity
    {
        public int CustomerCode { get; set; }
        public decimal AccountBalance { get; set; }
        public IEnumerable<StockPositionEntity> Positions { get; set; }
    }
}
