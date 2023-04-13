using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;

namespace Expenses.BusinessLayer.Bl
{
    public class UnitOfWorkBl : IUnitOfWorkBl
    {
        public UnitOfWorkBl(
            ICategoryBl category
            , ISubcategoryBl subcategoryBl
            , IPeriodBl period
            , IEntryBl entry
            , IExpenseBl expensesBl
            , IDepositPlanBl depositPlanBl
            , ITermAccountBl termAccountBl
            , IExpenseTdcBl expenseTdcBl
            , IApartBl apartBl
            , IInvesmentBl invesmentBl
            , IBuyBl buyBl
            , IPayBl payBl
        )
        {
            Apart = apartBl;
            Category = category;
            Subcategory = subcategoryBl;
            Period = period;
            Entry = entry;
            Expense = expensesBl;
            DepositPlanBl = depositPlanBl;
            TermAccount = termAccountBl;
            ExpenseTdc = expenseTdcBl;
            Investment = invesmentBl;
            Pay = payBl;
            Buy = buyBl;
        }

        public IApartBl Apart { get; }

        public ICategoryBl Category { get; }

        public IPeriodBl Period { get; }

        public IEntryBl Entry { get; }
        public IExpenseBl Expense { get; }

        public ISubcategoryBl Subcategory { get; }

        public IDepositPlanBl DepositPlanBl { get; set; }

        public ITermAccountBl TermAccount { get; }

        public IExpenseTdcBl ExpenseTdc { get; }

        public IInvesmentBl Investment { get; }

        public IBuyBl Buy { get; }

        public IPayBl Pay { get; }
    }
}