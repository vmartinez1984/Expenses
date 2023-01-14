using AutoMapper;
using Expenses.BusinessLayer.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Expenses.Core.Mappers
{
    public static class ExpensesMapperExtensor
    {
        public static void AddMappers(this IServiceCollection services)
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
    }
}
