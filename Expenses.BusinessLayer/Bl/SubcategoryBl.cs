using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class SubcategoryBl : ISubcategoryBl
    {
        private IUnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;

        public SubcategoryBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(SubategoryDtoIn item)
        {
            SubcategoryEntity entity;

            entity = _mapper.Map<SubcategoryEntity>(item);
            entity.Id = await _unitOfWork.Subcategory.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Subcategory.DeleteAsync(id);
        }

        public async Task<SubcategoryDtoOut> GetAsync(int id)
        {
            SubcategoryDtoOut item;
            SubcategoryEntity entity;

            entity= await _unitOfWork.Subcategory.GetAsync(id);
            item =_mapper.Map<SubcategoryDtoOut>(entity);

            return item;
        }

        public async Task<IReadOnlyList<SubcategoryDtoOut>> GetAsync()
        {
            IReadOnlyList<SubcategoryDtoOut> list;
            IReadOnlyList<SubcategoryEntity> entities;

            entities = await _unitOfWork.Subcategory.GetAsync();
            list = _mapper.Map<List<SubcategoryDtoOut>>(entities);

            return list;
        }

        public async Task UpdateAsync(SubategoryDtoIn item, int id)
        {
            SubcategoryEntity entity;

            entity = await _unitOfWork.Subcategory.GetAsync(id);
            entity.Amount = item.Amount;
            entity.CategoryId = item.CategoryId;
            entity.IsBudget = item.IsBudget;
            entity.Name = item.Name;
            await _unitOfWork.Subcategory.UpdateAsync(entity);
        }

    }//end class
}
