using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        T Get(int id);
        List<T> Get();
        int Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
