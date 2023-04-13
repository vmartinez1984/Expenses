using Expenses.Core.InterfaceRepository;

namespace Expenses.Core.Interfaces
{
    public interface IRepository
    {
        IApartRepository Apart { get; }

        ICategoryRepository Category { get; }

        IPeriodRepository Period { get; }

        IEntryRepositoy Entry { get; }

        IExpenseRepository Expense { get; }

        ISubcategoryRepository Subcategory { get; }

        IDepositPlanRepository DepositPlan { get; }

        ITermAccountRepository TermAccount { get; }

        IExpenseTdcRepository ExpenseTdc { get; }

        IInvesmentRepository Invesment { get; }

        IBuyRepository Buy { get; }

        IPayRepository Pay { get; }

        ITdcRepository Tdc { get; }
    }
}
