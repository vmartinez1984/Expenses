namespace Expenses.BusinessLayer.Dtos.Inputs{
    public class SubategoryDtoIn{
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        public bool IsBudget { get; set; } = true;
        
        public int Amount { get; set; }       
    }
}