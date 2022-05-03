using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    public interface IBaseBl<T,U> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<U>> GetAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}