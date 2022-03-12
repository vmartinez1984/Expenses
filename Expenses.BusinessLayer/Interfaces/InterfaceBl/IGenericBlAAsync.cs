using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IGenericBlAAsync<T,U> where T : class
    {       
        Task<int> AddAsync(U item);
        Task DeleteAsync(int id);
        Task<List<T>> GetAsync(int periodId);
        Task UpdateAsync(U item, int id);
    }
}