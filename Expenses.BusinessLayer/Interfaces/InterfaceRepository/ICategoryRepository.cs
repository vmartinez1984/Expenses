using Expenses.BusinessLayer.Entities;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface ICategoryRepository
    {
        int Add(CategoryEntity entity);
        void Delete(int id);
        void Update(CategoryEntity entity);
        List<CategoryEntity> Get();
        CategoryEntity Get(int id);
    }
}
