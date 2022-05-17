using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class SubcategoryMapper: Profile
    {
        public SubcategoryMapper()
        {
            CreateMap<SubcategoryEntity, SubcategoryDtoOut>().ReverseMap();
            CreateMap<SubcategoryEntity, SubcategoryDtoIn>().ReverseMap();
        }
    }
}
