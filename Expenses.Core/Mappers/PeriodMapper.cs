using AutoMapper;
using Expenses.Core.Entities;
using Expenses.Core.Dtos;

namespace Expenses.BusinessLayer.Mappers
{
    public class PeriodMapper : Profile
    {
        public PeriodMapper()
        {
            CreateMap<PeriodEntity, PeriodDto>().ReverseMap();

            CreateMap<PeriodEntity, PeriodDtoIn>().ReverseMap();

            CreateMap<PeriodDto, PeriodFullDto>().ReverseMap();

            CreateMap<PeriodFullDto, PeriodEntity>().ReverseMap();
        }
    }
}