using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Dtos;
using System.Collections;

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
        Task UpdateAsync(T item, int id);
    }

    public interface IInvesmentBl: IBaseBl<InvesmentDtoIn, InvestmentDto>
    {
        Task<List<InvestmentDto>> GetAllAsync();
    }
    public interface IApartBl : IBaseBl<ApartDtoIn, ApartDto>
    {
        Task<List<ApartDto>> GetAsync(int? subcategoryId);

    }

    public interface IGenericBlAAsync<T, U> where T : class
    {
        Task<int> AddAsync(U item);
        Task DeleteAsync(int id);
        Task<List<T>> GetAsync(int periodId);
        Task UpdateAsync(U item, int id);
    }

    //Como solo es una linea se agregara las interfaces aqui
    public interface IPeriodBl : IBaseBl<PeriodDtoIn, PeriodDto>
    {
        Task<List<PeriodDto>> GetAsync();
        Task<PeriodFullDto> GetFullAsync(int id);
    }

    public interface IEntryBl : IBaseBl<EntryDtoOut, EntryDtoIn>
    {
        Task<List<EntryDtoOut>> GetAllAsync(int id);
    }

    public interface IExpenseBl : IBaseBl<ExpenseDtoIn, ExpenseDto>
    {
        Task<List<ExpenseDto>> GetAllAsync(int id);
    }

    public interface IExpenseTdcBl : IBaseBl<ExpenseTdcDtoIn, ExpenseTdcDtoOut> { }

    public interface ICategoryBl : IBaseBl<CategoryDtoIn, CategoryDto>
    {
        Task<List<CategoryDto>> GetAsync();
    }

    public interface ISubcategoryBl : IBaseBl<SubcategoryDtoIn, SubcategoryDto>
    {
        Task<List<SubcategoryDto>> GetAsync();
        Task<List<SubcategoryDto>> GetByApartsAsync();
    }

    public interface IDepositPlanBl : IBaseBl<DepositPlanDtoIn, DepositPlanDtoOut>
    {
        Task<DepositPlanFullDtoOut> GetFullAsync(int id);
    }

    public interface ITermAccountBl : IBaseBl<TermAccountDtoIn, TermAccountDtoOut> { }
}