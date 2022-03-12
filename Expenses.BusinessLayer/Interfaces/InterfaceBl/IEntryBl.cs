using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    public interface IEntryBl : IGenericBlAAsync<EntryDtoOut, EntryDtoIn>
    {        
    }
}
