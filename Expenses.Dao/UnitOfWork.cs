using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;

namespace Expenses.Repository
{
    public class UnitOfWork : IUnitOfWorkRepository
    {

        public UnitOfWork(
            ICategoryRepository categoryRepository,
            IPeriodRepository periodRepository,
            IEntryRepositoy entryRepositoy,
            IExpenseRepository expenseRepository
        )
        {
            Category = categoryRepository;
            Period = periodRepository;
            Entry = entryRepositoy;
            Expense = expenseRepository;
        }

        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }       

        public IExpenseRepository Expense { get; }
    }
}