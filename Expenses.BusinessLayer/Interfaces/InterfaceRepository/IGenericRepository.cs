using System.Collections.Generic;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T Get(int id);
        List<T> Get(bool? isActive);
        int Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
