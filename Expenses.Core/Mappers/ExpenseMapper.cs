using AutoMapper;
using Expenses.Core.Entities;
using Expenses.Core.Dtos;

namespace Expenses.BusinessLayer.Mappers
{
    public class ExpenseMapper: Profile
    {
        public ExpenseMapper()
        {
            CreateMap<ApartEntity, ApartDto>();

            CreateMap<ExpenseEntity, ExpenseDto>().ReverseMap();
            CreateMap<ExpenseEntity, ExpenseDtoIn>().ReverseMap();

            CreateMap<InvestmentEntity, InvestmentDto>();
        }
    }
}
