using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface ICategoryBl
    {
        int Add(CategoryDtoIn item);
        void Delete(int id);
        List<CategoryDtoOut> Get();
        CategoryDtoOut Get(int id);
        void Update(CategoryUpdDtoIn item);

    }//end class
}