using System.Collections.Generic;
using Expenses.Dtos.Inputs;
using Expenses.Dtos.Outputs;

namespace Expenses.Interfaces.InterfaceBl{
    public interface ICategoryBl{
        int Add(CategoryDtoIn item);

        List<CategoryDtoOut> Get();
    }
}