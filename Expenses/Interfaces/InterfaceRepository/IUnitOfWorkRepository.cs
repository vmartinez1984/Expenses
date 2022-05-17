using Expenses.Models;

namespace Expenses.Interfaces.InterfaceRepository
{
    public interface IUnitOfWorkRepository
    {
        public ICategoryRepository Category { get; }

        //public IPeriodRepository Period { get; }

        //public IEntryRepositoy Entry { get; }

        //public IExpenseRepository Expense { get; }

        public ISubcategoryRepository Subcategory { get; }
    }

    //Para no tener tantos archivos con un par de lineas 
    public interface ICategoryRepository : IBaseRepository<Category>    {    }

    public interface ISubcategoryRepository : IBaseRepository<Subcategory> { }
}