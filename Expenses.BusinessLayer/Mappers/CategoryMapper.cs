using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;

namespace Expenses.BusinessLayer.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryEntity, CategoryDtoOut>().ReverseMap();

            CreateMap<CategoryEntity, CategoryDtoIn>().ReverseMap();

            CreateMap<CategoryEntity, CategoryUpdDtoIn>().ReverseMap();
        }
    }
}