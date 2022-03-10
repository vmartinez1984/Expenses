using AutoMapper;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Bl
{
    public class CategoryBl: ICategoryBl
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CategoryBl(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public List<CategoryDtoOut> Get()
        {
            List<CategoryEntity> entities;
            List<CategoryDtoOut> list;

            entities = _unitOfWork.Category.Get();
            list = _mapper.Map<List<CategoryDtoOut>>(entities);

            return list;
        }
    }
}
