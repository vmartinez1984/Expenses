using AutoMapper;
using Expenses.BusinessLayer.Bl;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.BusinessLayer.Mappers;
using Expenses.Core.InterfaceRepository;
using Expenses.Core.Interfaces;
using Expenses.RepositoryEF;
using Expenses.RepositoryEF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace Expenses
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AddMappers(services);
            services.AddControllersWithViews();            
            //Repository
            services.AddScoped<Expenses.RepositoryEF.Contexts.AppDbContext>();            
            services.AddScoped<ICategoryRepository, CategoryRepositoryEF>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepositoryEF>();
            services.AddScoped<IPeriodRepository, PeriodRepositoryEF>();            
            services.AddScoped<IEntryRepositoy, EntryRepositoryEF>();  
            services.AddScoped<IExpenseRepository, ExpenseRepositoryEF>();  
            services.AddScoped<IExpenseTdcRepository, ExpenseTdcRepositoryEF>();  
            services.AddScoped<IDepositPlanRepository, DepositPlanRepositoryEF>();  
            services.AddScoped<ITermAccountRepository, TermAccountRepositoryEF>();
            services.AddScoped<IRepository, UnitOfWorkEF>();
            //BusinessLAyer
            services.AddScoped<IPeriodBl, PeriodBl>();
            services.AddScoped<ISubcategoryBl, SubcategoryBl>();
            services.AddScoped<ICategoryBl, CategoryBl>();
            services.AddScoped<IEntryBl, EntryBl>();  
            services.AddScoped<IExpenseBl, ExpenseBl>();
            services.AddScoped<IExpenseTdcBl, ExpenseTdcBl>();
            services.AddScoped<IDepositPlanBl, DepositPlanBl>();
            services.AddScoped<ITermAccountBl,TermAccountBl>();
            services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
        }

        private void AddMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<CategoryMapper>();
                mapperConfig.AddProfile<SubcategoryMapper>();
                mapperConfig.AddProfile<EntryMapper>();
                mapperConfig.AddProfile<ExpenseMapper>();
                mapperConfig.AddProfile<ExpenseTdcMapper>();
                mapperConfig.AddProfile<PeriodMapper>();
                mapperConfig.AddProfile<DepositPlanMapper>();
                mapperConfig.AddProfile<TermAccountMapper>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("es-MX");
            cultureInfo.NumberFormat.CurrencySymbol = "$";

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Periods}/{action=Details}/{id?}");
            });
        }
    }
}
