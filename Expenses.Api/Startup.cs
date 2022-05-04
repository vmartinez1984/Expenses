using AutoMapper;
using Expenses.BusinessLayer.Bl;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Expenses.BusinessLayer.Mappers;
using Expenses.Repository;
using Expenses.Repository.Repositories;
using Expenses.RepositoryEF;
using Expenses.RepositoryEF.Contexts;
using Expenses.RepositoryEF.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Expenses.Api
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
            services.AddControllers();
            services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
            services.AddScoped<ICategoryBl, CategoryBl>();
            services.AddScoped<IPeriodBl, PeriodBl>();
            services.AddScoped<IExpensesBl, ExpenseBl>();
            services.AddScoped<IEntryBl, EntryBl>();
            services.AddScoped<ISubcategoryBl, SubcategoryBl>();
            services.AddScoped<IUnitOfWorkRepository, UnitOfWork>();
            services.AddTransient<IUnitOfWorkRepository, UnitOfWorkEF>();           
            AddRepository(services);
            //AddRepositoryEF(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Expenses.Api", Version = "v1" });
            });
            services.AddCors(options => options.AddPolicy("AllowWebApp", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
        }

        private void AddRepository(IServiceCollection services){                        
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IEntryRepositoy, EntryRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();          
        }

        private void AddRepositoryEF(IServiceCollection services){
            services.AddScoped<AppDbContext>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();            
            services.AddScoped<IPeriodRepository, PeriodRepository>();
            services.AddScoped<IEntryRepositoy, EntryRepository>();
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();            
        }

        private void AddMappers(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mapperConfig =>
            {
                mapperConfig.AddProfile<CategoryMapper>();
                mapperConfig.AddProfile<PeriodMapper>();
                mapperConfig.AddProfile<EntryMapper>();
                mapperConfig.AddProfile<ExpenseMapper>();
                mapperConfig.AddProfile<SubcategoryMapper>();
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expenses.Api v1"));
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Expenses.Api v1"));
            }

            app.UseCors("AllowWebApp");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
