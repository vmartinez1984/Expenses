namespace Expenses.Core.Entities
{
    public class BuyEntity
    {        
        public int Id { get; set; }

        public string Name { get; set; }

        public int MonthsWhithoutInterest { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateRegistration { get; set; } = DateTime.Now;

        public DateTime DatePay { get; set; }

        public bool IsActive { get; set; } = true;

        public int TdcId { get; set; }

    }
}