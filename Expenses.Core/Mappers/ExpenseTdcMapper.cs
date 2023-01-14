using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class ExpenseTdcMapper: Profile
    {
        public ExpenseTdcMapper()
        {
            CreateMap<ExpenseTdcEntity, ExpenseTdcDtoOut>().ReverseMap();
            CreateMap<ExpenseTdcEntity, ExpenseTdcDtoIn>().ReverseMap();
        }
    }
}
