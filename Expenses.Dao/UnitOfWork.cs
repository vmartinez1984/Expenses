using Expenses.BusinessLayer.Interfaces;

namespace Expenses.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(ICategoryRepository categoryEntity)
        {
            Category = categoryEntity;
        }

        public ICategoryRepository Category
        {
            get;
        }
    }
}