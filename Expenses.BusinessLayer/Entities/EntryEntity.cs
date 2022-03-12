using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Entities
{
    public class EntryEntity : BaseBEntity
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int PeriodId { get; set; }
    }
}