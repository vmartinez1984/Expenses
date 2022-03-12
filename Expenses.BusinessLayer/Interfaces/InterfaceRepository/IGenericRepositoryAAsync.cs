using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IGenericRepositoryAAsync<T> where T : class
    {       
        Task<List<T>> GetAsync(int periodId);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
