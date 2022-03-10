using Expenses.BusinessLayer.Dtos.Outputs;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Interfaces.IntefaceDto
{
    public interface ICategoryDto
    {
        List<CategoryDtoOut> Get();
    }
}
