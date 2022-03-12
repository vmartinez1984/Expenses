using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    public interface IExpensesBl : IGenericBlAAsync<ExpenseDtoOut, ExpenseDtoIn>
    {

    }
}
