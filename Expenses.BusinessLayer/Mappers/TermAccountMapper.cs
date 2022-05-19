using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class TermAccountMapper : Profile
    {
        public TermAccountMapper()
        {
            CreateMap<TermAccountEntity, TermAccountDtoOut>().ReverseMap();

            CreateMap<TermAccountEntity, TermAccountDtoIn>().ReverseMap();            
        }
    }
}