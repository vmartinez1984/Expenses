using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces
{
    public interface IUnitOfWorkBl
    {
        ICategoryBl Category { get; }
    }
}
