using Expenses.Core.InterfaceRepository;

namespace Expenses.Core.Interfaces
{
    public interface IRepository
    {
        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }

        public IExpenseRepository Expense { get; }
        
        public ISubcategoryRepository Subcategory { get; }

        public IDepositPlanRepository DepositPlan { get; }

        public ITermAccountRepository TermAccount { get;  }

        public IExpenseTdcRepository ExpenseTdc { get; }
    }
}
