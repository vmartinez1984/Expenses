using Expenses.Core.InterfaceRepository;
using Expenses.Core.Interfaces;

namespace Expenses.Repository
{
    public class UnitOfWork : IRepository
    {

        public UnitOfWork(
            ICategoryRepository categoryRepository,
            IPeriodRepository periodRepository,
            IEntryRepositoy entryRepositoy,
            IExpenseRepository expenseRepository,
            ISubcategoryRepository subcategory
            //IDepositPlanRepository depositPlanRepository,
            //IExpenseTdcRepository expenseTdcRepository,
            //ITermAccountRepository termAccountRepository
        )
        {
            Category = categoryRepository;
            Period = periodRepository;
            Entry = entryRepositoy;
            Expense = expenseRepository;
            Subcategory = subcategory;
            //DepositPlan = depositPlanRepository;
            //ExpenseTdc = expenseTdcRepository;
            //TermAccount = termAccountRepository;
        }

        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }       

        public IExpenseRepository Expense { get; }

        public ISubcategoryRepository Subcategory { get; }
        public IDepositPlanRepository DepositPlan { get; }
        public IExpenseTdcRepository ExpenseTdc { get; }
        public ITermAccountRepository TermAccount { get; }
    }
}