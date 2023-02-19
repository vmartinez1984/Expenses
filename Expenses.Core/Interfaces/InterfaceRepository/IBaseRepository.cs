using Expenses.Core.Entities;

namespace Expenses.Core.InterfaceRepository
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<int> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    //Como es una linea sera m�s f�cil manipular desde aqui

    public interface IInvesmentRepository: IBaseRepository<InvestmentEntity> {
        Task<List<InvestmentEntity>> GetAllAsync(PagerEntity pagerEntity);
    }

    public interface ISubcategoryRepository : IBaseRepository<SubcategoryEntity>
    {
        Task<List<SubcategoryEntity>> GetAsync();
    }

    public interface IPeriodRepository : IBaseRepository<PeriodEntity>
    {
        Task<PeriodEntity> GetActiveAsync();
        Task<List<PeriodEntity>> GetAsync();
        int GetBalance(int id);
    }

    public interface IEntryRepositoy : IBaseRepository<EntryEntity>
    {
        Task<List<EntryEntity>> GetAllAsync(int id);        
    }

    public interface IExpenseRepository : IBaseRepository<ExpenseEntity>
    {
        Task<List<ExpenseEntity>> GetAllAsync(int periodId);

        Task<List<ExpenseEntity>> GetAllOfDepositPlanAsync(int depositPlanId);
    }

    public interface IDepositPlanRepository : IBaseRepository<DepositPlanEntity>
    {
        Task<List<DepositPlanEntity>> GetAsync();
        Task<int> GetTotalAsync(int id);
    }

    public interface ITermAccountRepository : IBaseRepository<TermAccountEntity>
    {
        Task<IReadOnlyList<TermAccountEntity>> GetAllAsync();
    }

    public interface IExpenseTdcRepository : IBaseRepository<ExpenseTdcEntity>
    {
        Task<IReadOnlyList<ExpenseTdcEntity>> GetAsync();
    }

    public interface ICategoryRepository : IBaseRepository<CategoryEntity>
    {
        Task<List<CategoryEntity>> GetAsync();
    }

    public interface IApartRepository : IBaseRepository<ApartEntity>
    {
        Task<List<ApartEntity>> GetAsync(int? subcategoryId);
    }
}