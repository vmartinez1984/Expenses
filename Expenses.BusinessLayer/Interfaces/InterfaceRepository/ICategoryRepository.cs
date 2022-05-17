using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<CategoryEntity> { }
}
