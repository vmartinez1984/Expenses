namespace Expenses.BusinessLayer.Entities{
    public class SubcategoryEntity: BaseBEntity{
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        public bool IsBudget { get; set; }
        
        public int Amount { get; set; }
    }
}