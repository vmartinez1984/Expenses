using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;


namespace Expenses.RepositoryEF
{
    public class UnitOfWorkEF : IUnitOfWorkRepository
    {
        public UnitOfWorkEF(
           ICategoryRepository categoryRepository
           ,  ISubcategoryRepository subcategory
           , IPeriodRepository periodRepository
           , IEntryRepositoy entryRepositoy
           , IExpenseRepository expenseRepository
           , IDepositPlanRepository depositPlanRepository
           , ITermAccountRepository termAccountRepository
           , IExpenseTdcRepository expenseTdcRepository
        )
        {
            Category = categoryRepository;
            Subcategory = subcategory;
            Period = periodRepository;
            Entry = entryRepositoy;
            Expense = expenseRepository;
            DepositPlan = depositPlanRepository;
            TermAccount = termAccountRepository;
            ExpenseTdc = expenseTdcRepository;
        }

        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }

        public IExpenseRepository Expense { get; }

        public ISubcategoryRepository Subcategory { get; }

        public IDepositPlanRepository DepositPlan { get; }
        
        public ITermAccountRepository TermAccount { get; }
        
        public IExpenseTdcRepository ExpenseTdc { get; }
    }
}
