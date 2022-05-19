using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Interfaces.InterfaceRepository
{
    public interface IBaseARepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync(int id);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAsync();
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    //Como es una linea sera m�s f�cil manipular desde aqui

    public interface ISubcategoryRepository : IBaseRepository<SubcategoryEntity> { }

    public interface IPeriodRepository : IBaseRepository<PeriodEntity>
    {
        Task<PeriodEntity> GetActiveAsync();
        int GetBalance(int id);
    }

    public interface IEntryRepositoy : IBaseARepository<EntryEntity> { }

    public interface IExpenseRepository : IBaseARepository<ExpenseEntity>
    {
        Task<IList<ExpenseEntity>> GetAllOfDepositPlanAsync(int depositPlanId);
    }

    public interface IDepositPlanRepository : IBaseRepository<DepositPlanEntity>
    {
        Task<int> GetTotalAsync(int id);
    }

    public interface ITermAccountRepository : IBaseRepository<TermAccountEntity> { }

    public interface IExpenseTdcRepository : IBaseRepository<ExpenseTdcEntity> { }
}