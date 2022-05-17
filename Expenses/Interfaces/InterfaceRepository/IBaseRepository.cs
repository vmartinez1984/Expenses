using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.Interfaces.InterfaceRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
