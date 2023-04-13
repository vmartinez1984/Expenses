using Expenses.Core.InterfaceRepository;
using Expenses.Core.Interfaces;
using Expenses.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.Repository.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IApartRepository, ApartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IEntryRepositoy, EntryRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
            services.AddScoped<IRepository, UnitOfWork>();
            services.AddScoped<IInvesmentRepository, InvesmentRepository>();
            services.AddScoped<IBuyRepository, BuyRepository>();
            services.AddScoped<IPayRepository, PayRepository>();
            services.AddScoped<ITdcRepository, TdcRepository>();
        }
    }
}
