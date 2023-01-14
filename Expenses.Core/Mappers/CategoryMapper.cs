using AutoMapper;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Entities;
using Expenses.Core.Dtos;

namespace Expenses.BusinessLayer.Mappers
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();

            CreateMap<CategoryEntity, CategoryDtoIn>().ReverseMap();            
        }
    }
}