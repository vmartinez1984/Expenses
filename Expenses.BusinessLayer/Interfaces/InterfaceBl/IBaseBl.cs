using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    /// <summary>
    /// Don T es la entrada y U la salida
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public interface IBaseBl<T,U> where T : class
    {
        Task<U> GetAsync(int id);
        Task<IReadOnlyList<U>> GetAsync();
        Task<int> AddAsync(T item);
        Task UpdateAsync(T item, int id);
        Task DeleteAsync(int id);
    }
}