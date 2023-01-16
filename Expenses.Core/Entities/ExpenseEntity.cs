﻿using System;

namespace Expenses.Core.Entities
{
    public class ExpenseEntity : BaseBEntity
    {        
        //public string Guid { get; set; } = new Guid.NewGuid().ToString();

        public string Name { get; set; }

        public int Amount { get; set; }

        //public int? BudgetAmount { get; set; }

        public int SubcategoryId { get; set; }
          
        //public int? DepositPlanId { get; set; }
     
        public int PeriodId { get; set; }
    }
}