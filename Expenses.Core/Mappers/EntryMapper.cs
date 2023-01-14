using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class EntryMapper : Profile
    {
        public EntryMapper()
        {
            CreateMap<EntryEntity, EntryDtoOut>().ReverseMap();

            CreateMap<EntryEntity, EntryDtoIn>().ReverseMap();
        }
    }
}
