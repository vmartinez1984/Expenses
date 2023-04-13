using Expenses.BusinessLayer.Bl;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.BusinessLayer.Extensors
{
    public static class BusinessLayerExtensions
    {
        public static void AddBl(this IServiceCollection services)
        {
            services.AddScoped<IApartBl, ApartBl>();
            services.AddScoped<ICategoryBl, CategoryBl>();
            services.AddScoped<IDepositPlanBl, DepositPlanBl>();
            services.AddScoped<IEntryBl, EntryBl>();
            services.AddScoped<IExpenseBl, ExpenseBl>();
            services.AddScoped<IExpenseTdcBl, ExpenseTdcBl>();
            services.AddScoped<IPeriodBl, PeriodBl>();
            services.AddScoped<ISubcategoryBl, SubcategoryBl>();
            services.AddScoped<ITermAccountBl, TermAccountBl>();
            services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
            services.AddScoped<IInvesmentBl, InvesmentBl>();
            services.AddScoped<IBuyBl,BuyBl>();            
            services.AddScoped<IPayBl, PayBl>();            
        }
    }
}