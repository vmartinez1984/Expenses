using Expenses.BusinessLayer.Entities;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface ICategoryRepository
    {
        List<CategoryEntity> Get();
    }
}
