namespace Expenses.Core.Entities
{
    public class ApartEntity
    {
        public int Id { get; set; }

        public int ExpenseId { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateRegistration { get; set; }

        public bool IsActive { get; set; }

        public bool IsApartN { get; set; }

        public string Name { get; set; }

        public int SubcategoryId { get; set; }
    }
}