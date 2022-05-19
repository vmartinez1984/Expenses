using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IUnitOfWorkBl
    {
        ICategoryBl Category { get; }

        IPeriodBl Period { get; }

        IEntryBl Entry { get; }

        IExpensesBl Expense { get; }

        ISubcategoryBl Subcategory { get; }

        IDepositPlanBl DepositPlanBl { get; }

        ITermAccountBl TermAccount {get;}

        IExpenseTdcBl ExpenseTdc { get; }
    }
}