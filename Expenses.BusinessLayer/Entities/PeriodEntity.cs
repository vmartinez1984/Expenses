using System;

namespace Expenses.BusinessLayer.Entities
{
    public class PeriodEntity : BaseAEntity
    {
        public string Name { get; set; }

        public DateTime DateStart { get; set; } = DateTime.Now;

        public DateTime? DateStop { get; set; }
    }
}
