using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface ICategoryBl : IBaseBl<CategoryDtoIn, CategoryDtoOut> { }//end class
}