using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;

namespace Expenses.BusinessLayer.Bl
{
    public class UnitOfWorkBl : IUnitOfWorkBl
    {
        public UnitOfWorkBl(
            ICategoryBl category
            , ISubcategoryBl subcategoryBl
            , IPeriodBl period
            , IEntryBl entry
            , IExpensesBl expensesBl
            , IDepositPlanBl depositPlanBl
        )
        {
            Category = category;
            Subcategory = subcategoryBl;
            Period = period;
            Entry = entry;
            Expense = expensesBl;
            DepositPlanBl = depositPlanBl;
        }

        public ICategoryBl Category { get; }

        public IPeriodBl Period { get; }

        public IEntryBl Entry { get; }
        public IExpensesBl Expense { get; }

        public ISubcategoryBl Subcategory { get; }

        public IDepositPlanBl DepositPlanBl { get; set; }
    }
}