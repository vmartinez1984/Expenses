using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF
{
    public class UnitOfWorkEF : IUnitOfWorkRepository
    {
        public UnitOfWorkEF(
           ICategoryRepository categoryRepository
           //IPeriodRepository periodRepository,
           //IEntryRepositoy entryRepositoy,
           //IExpenseRepository expenseRepository
        )
        {
            Category = categoryRepository;
            //Period = periodRepository;
            //Entry = entryRepositoy;
            //Expense = expenseRepository;
        }

        public ICategoryRepository Category { get; }

        public IPeriodRepository Period { get; }

        public IEntryRepositoy Entry { get; }

        public IExpenseRepository Expense { get; }
    }
}
