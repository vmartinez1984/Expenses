using Expenses.BusinessLayer.Interfaces.InterfaceBl;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IUnitOfWorkBl
    {
        IApartBl Apart { get; }

        ICategoryBl Category { get; }

        IPeriodBl Period { get; }

        IEntryBl Entry { get; }

        IExpenseBl Expense { get; }

        ISubcategoryBl Subcategory { get; }

        IDepositPlanBl DepositPlanBl { get; }

        ITermAccountBl TermAccount {get;}

        IExpenseTdcBl ExpenseTdc { get; }

        IInvesmentBl Investment { get; }
    }
}