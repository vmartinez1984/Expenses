using System.Collections.Generic;

namespace Expenses.BusinessLayer.Dtos.Outputs
{
    public class PeriodFullDtoOut: PeriodDtoOut
    {
       public List<ExpenseDtoOut> ListExpenses { get; set;}

       public List<EntryDtoOut> ListEntries { get; set;}
    }
}
