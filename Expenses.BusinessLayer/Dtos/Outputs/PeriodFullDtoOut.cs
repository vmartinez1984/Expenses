using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class PeriodFullDtoOut: PeriodDtoOut
    {
       public List<ExpenseDtoOut> ListExpenses { get; set;}

       public List<EntryDtoOut> ListEntries { get; set;}
    }
}
