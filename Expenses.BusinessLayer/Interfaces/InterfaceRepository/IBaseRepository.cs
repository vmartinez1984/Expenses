using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Interfaces.InterfaceRepository
{
    public interface IBaseRepository<T> where T :class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    //Como es una linea sera más fácil manipular desde aqui

    public interface ISubcategoryRepository : IBaseRepository<SubcategoryEntity> { }
}