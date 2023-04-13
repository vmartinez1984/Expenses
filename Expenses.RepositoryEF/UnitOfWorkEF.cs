using Expenses.Core.InterfaceRepository;
using Expenses.Core.Interfaces;
using Expenses.RepositoryEF.Repositories;

namespace Expenses.RepositoryEF
{
    public class UnitOfWorkEF : IRepository
    {
        public UnitOfWorkEF(
           ICategoryRepository categoryRepository
           , ISubcategoryRepository subcategory
           , IPeriodRepository periodRepository
           , IEntryRepositoy entryRepositoy
           , IExpenseRepository expenseRepository
           , IDepositPlanRepository depositPlanRepository
           , ITermAccountRepository termAccountRepository
           , IExpenseTdcRepository expenseTdcRepository
           , TdcRepository tdcRepository
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
            Tdc = tdcRepository;
        }

        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }

        public IExpenseRepository Expense { get; }

        public ISubcategoryRepository Subcategory { get; }

        public IDepositPlanRepository DepositPlan { get; }

        public ITermAccountRepository TermAccount { get; }

        public IExpenseTdcRepository ExpenseTdc { get; }

        public IApartRepository Apart => throw new System.NotImplementedException();

        public IInvesmentRepository Invesment => throw new System.NotImplementedException();

        public IBuyRepository Buy { get; }

        public IPayRepository Pay { get; }

        public ITdcRepository Tdc { get; }
    }
}
