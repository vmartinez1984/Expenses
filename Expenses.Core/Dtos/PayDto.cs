namespace Expenses.Core.Dtos
{
    public class PayDto:PayDtoIn
    {
        public int Id { get; set; }
    }
    
    public class PayDtoIn
    {
        public decimal Amount { get; set; }


        public string Name { get; set; }

        public DateTime DateRegistration { get; set; } = DateTime.Now;        

        public bool IsActive { get; set; } = true;
    }
}