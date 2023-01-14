using System;

namespace Expenses.Core.Entities
{
    public class ExpenseEntity : BaseBEntity
    {
        

        public Guid Guid { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public int Amount { get; set; }

        //public int? BudgetAmount { get; set; }

        public int SubcategoryId { get; set; }
          
        //public int? DepositPlanId { get; set; }
     
        public int PeriodId { get; set; }
    }
}