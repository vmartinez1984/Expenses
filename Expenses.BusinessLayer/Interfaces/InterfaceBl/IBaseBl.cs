using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;

namespace Expenses.BusinessLayer.Interfaces.InterfaceBl
{
    /// <summary>
    /// Donde T es la entrada y U la salida
    /// </summary>
    /// <typeparam name="T">Entrada</typeparam>
    /// <typeparam name="U">Salida</typeparam>
    public interface IBaseBl<T, U> where T : class
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task<IReadOnlyList<U>> GetAsync();
        Task UpdateAsync(T item, int id);
    }

    public interface IGenericBlAAsync<T, U> where T : class
    {
        Task<int> AddAsync(U item);
        Task DeleteAsync(int id);
        Task<List<T>> GetAsync(int periodId);
        Task UpdateAsync(U item, int id);
    }

    //Como solo es una linea se agregara las interfaces aqui
    public interface IPeriodBl : IBaseBl<PeriodDtoIn, PeriodDtoOut>
    {
        Task<PeriodFullDtoOut> GetFullActiveAsync();
        Task<PeriodFullDtoOut> GetFullAsync(int id);
    }

    public interface IEntryBl : IGenericBlAAsync<EntryDtoOut, EntryDtoIn>
    {
        Task<EntryDtoOut> GetByIdAsync(int id);
    }

    public interface IExpensesBl : IGenericBlAAsync<ExpenseDtoOut, ExpenseDtoIn>
    {
        Task<ExpenseDtoOut> GetByIdAsync(int id);
    }

    public interface IExpenseTdcBl : IBaseBl<ExpenseTdcDtoIn, ExpenseTdcDtoOut> { }

    public interface ICategoryBl : IBaseBl<CategoryDtoIn, CategoryDtoOut> { }

    public interface ISubcategoryBl : IBaseBl<SubcategoryDtoIn, SubcategoryDtoOut> { }

    public interface IDepositPlanBl : IBaseBl<DepositPlanDtoIn, DepositPlanDtoOut>
    {
        Task<DepositPlanFullDtoOut> GetFullAsync(int id);
    }

    public interface ITermAccountBl : IBaseBl<TermAccountDtoIn, TermAccountDtoOut> { }
}