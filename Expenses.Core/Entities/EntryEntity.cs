namespace Expenses.Core.Entities
{
    public class EntryEntity : BaseBEntity
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int PeriodId { get; set; }
    }
}