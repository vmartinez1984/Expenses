namespace Expenses.Core.Entities
{
    public class PayEntity
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Name { get; set; }

        public DateTime DateRegistration { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
