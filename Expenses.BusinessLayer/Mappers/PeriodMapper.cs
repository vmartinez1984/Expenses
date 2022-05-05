using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class PeriodMapper : Profile
    {
        public PeriodMapper()
        {
            CreateMap<PeriodEntity, PeriodDtoOut>().ReverseMap();

            CreateMap<PeriodEntity, PeriodDtoIn>().ReverseMap();

            CreateMap<PeriodDtoOut, PeriodFullDtoOut>().ReverseMap();
        }
    }
}