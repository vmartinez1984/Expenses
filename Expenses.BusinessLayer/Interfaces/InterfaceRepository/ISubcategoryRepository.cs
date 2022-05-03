using Expenses.BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceRepository
{
    public interface ISubcategoryRepository: IBaseRepository<SubcategoryEntity>
    {
        Task<SubcategoryEntity> GetAsync(int id);
        Task<IReadOnlyList<SubcategoryEntity>> GetAsync();
        Task<int> AddAsync(SubcategoryEntity entity);
        Task UpdateAsync(SubcategoryEntity entity);
        Task DeleteAsync(int id);
    }
}