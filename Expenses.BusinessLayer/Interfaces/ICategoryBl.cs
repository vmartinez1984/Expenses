using Expenses.BusinessLayer.Dtos.Outputs;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface ICategoryBl
    {
        public List<CategoryDtoOut> Get();
    }
}
