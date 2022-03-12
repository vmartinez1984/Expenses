using Expenses.BusinessLayer.Interfaces;
using System;
using Microsoft.Extensions.Configuration;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;

namespace Expenses.BusinessLayer.Bl
{
    public class UnitOfWorkBl : IUnitOfWorkBl
    {
        private IConfiguration _configuration;

        public UnitOfWorkBl(
            IConfiguration configuration,
            ICategoryBl category,
            IPeriodBl period,
            IEntryBl entry,
            IExpensesBl expensesBl
        )
        {
            _configuration = configuration;
            Category = category;
            Period = period;
            Entry = entry;
            Expense = expensesBl;
        }

        public ICategoryBl Category { get; }

        public IPeriodBl Period { get; }

        public IEntryBl Entry { get; }
        public IExpensesBl Expense { get; }
    }
}