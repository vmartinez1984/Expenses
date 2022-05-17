using Expenses.Interfaces.InterfaceBl;

namespace Expenses.Interfaces.InterfaceBl
{
    public interface IUnitOfWorkBl
    {
        public ICategoryBl Category { get; }
    }
}