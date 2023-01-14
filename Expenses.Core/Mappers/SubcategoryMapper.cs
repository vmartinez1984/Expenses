using AutoMapper;
using Expenses.Core.Entities;
using Expenses.Core.Dtos;

namespace Expenses.BusinessLayer.Mappers
{
    public class SubcategoryMapper: Profile
    {
        public SubcategoryMapper()
        {
            CreateMap<SubcategoryEntity, SubcategoryDto>().ReverseMap();
            CreateMap<SubcategoryEntity, SubcategoryDtoIn>().ReverseMap();
        }
    }
}
