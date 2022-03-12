using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class ExpenseMapper: Profile
    {
        public ExpenseMapper()
        {
            CreateMap<ExpenseEntity, ExpenseDtoOut>().ReverseMap();
            CreateMap<ExpenseEntity, ExpenseDtoIn>().ReverseMap();
        }
    }
}
