namespace Expenses.BusinessLayer.Entities
{
    public class ExpenseEntity : BaseBEntity
    {
        public string Name { get; set; }

        public int Amount { get; set; }

        public int SubcategoryId { get; set; }
        
        public int Goal { get; set; }

        public int PeriodId { get; set; }
    }
}