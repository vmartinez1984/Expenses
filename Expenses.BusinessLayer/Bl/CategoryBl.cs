using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using System.Collections.Generic;

namespace Expenses.BusinessLayer.Bl
{
    public class CategoryBl : ICategoryBl
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

        public CategoryDtoOut Get(int id)
        {
            CategoryEntity entity;
            CategoryDtoOut item;

            entity = _unitOfWork.Category.Get(id);
            item = _mapper.Map<CategoryDtoOut>(entity);

            return item;
        }

        public int Add(CategoryDtoIn item)
        {
            CategoryEntity entity;

            entity = _mapper.Map<CategoryEntity>(item);
            entity.Id = _unitOfWork.Category.Add(entity);

            return entity.Id;
        }

        public void Update(CategoryUpdDtoIn item)
        {
            CategoryEntity entity;

            entity = _mapper.Map<CategoryEntity>(item);

            _unitOfWork.Category.Update(entity);            
        }

        public void Delete(int id)
        {
            _unitOfWork.Category.Delete(id);
        }
    }
}
