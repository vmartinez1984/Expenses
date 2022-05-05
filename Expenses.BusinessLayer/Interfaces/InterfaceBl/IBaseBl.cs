using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    public interface IBaseBl<T,U> where T : class
    {
        Task<U> GetAsync(int id);
        Task<IReadOnlyList<U>> GetAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity, int id);
        Task DeleteAsync(int id);
    }
}