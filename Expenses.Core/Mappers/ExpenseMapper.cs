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

            CreateMap<InvesmentDtoIn, InvestmentEntity>();

            CreateMap<InvestmentEntity, InvestmentDto>();

            CreateMap<PagerDto, PagerEntity>().ReverseMap();

            CreateMap<BuyEntity, BuyDto>();

            CreateMap<BuyDtoIn, BuyEntity>();            
        }
    }
}
