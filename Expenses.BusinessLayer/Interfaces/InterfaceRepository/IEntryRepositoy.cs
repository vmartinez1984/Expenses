using Expenses.BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Interfaces.InterfaceRepository
{
    public interface IEntryRepositoy : IGenericRepositoryAAsync<EntryEntity>
    {
    }
}
