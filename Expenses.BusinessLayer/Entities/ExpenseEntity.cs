namespace Expenses.BusinessLayer.Entities
{
    public class ExpenseEntity : BaseBEntity
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int PeriodId { get; set; }

    }
}