using Expenses.Core.InterfaceRepository;
using Expenses.Core.Interfaces;

namespace Expenses.Repository
{
    public class UnitOfWork : IRepository
    {

        public UnitOfWork(
            IApartRepository apartRepository,
            ICategoryRepository categoryRepository,
            IPeriodRepository periodRepository,
            IEntryRepositoy entryRepositoy,
            IExpenseRepository expenseRepository,
            ISubcategoryRepository subcategory,
            IInvesmentRepository invesmentRepository
        )
        {
            Apart = apartRepository;
            Category = categoryRepository;
            Period = periodRepository;
            Entry = entryRepositoy;
            Expense = expenseRepository;
            Subcategory = subcategory;
            Invesment = invesmentRepository;
        }

        public IInvesmentRepository Invesment { get; }

        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }

        public IExpenseRepository Expense { get; }

        public ISubcategoryRepository Subcategory { get; }
        public IDepositPlanRepository DepositPlan { get; }
        public IExpenseTdcRepository ExpenseTdc { get; }
        public ITermAccountRepository TermAccount { get; }

        public IApartRepository Apart { get; }
    }
}