namespace Expenses.BusinessLayer.Entities{
    public class SubcategoryEntity: BaseAEntity{
        public string Name { get; set; }
        
        public int CategoryId { get; set; }

        public virtual CategoryEntity Category {get; set;}

        public bool IsBudget { get; set; }
        
        public int? Amount { get; set; }
    }
}