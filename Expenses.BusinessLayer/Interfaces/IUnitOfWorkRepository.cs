using Expenses.BusinessLayer.Interfaces.InterfaceRepository;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }

        public IExpenseRepository Expense { get; }
        
        public ISubcategoryRepository Subcategory { get; }
    }
}
