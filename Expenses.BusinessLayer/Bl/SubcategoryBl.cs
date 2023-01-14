using AutoMapper;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class SubcategoryBl : BaseBl, ISubcategoryBl
    {
        public SubcategoryBl(IMapper mapper, IRepository unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<int> AddAsync(SubcategoryDtoIn item)
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

        public async Task<SubcategoryDto> GetAsync(int id)
        {
            SubcategoryDto item;
            SubcategoryEntity entity;

            entity = await _unitOfWork.Subcategory.GetAsync(id);
            item = _mapper.Map<SubcategoryDto>(entity);

            return item;
        }

        public async Task<List<SubcategoryDto>> GetAsync()
        {
            List<SubcategoryDto> list;
            IReadOnlyList<SubcategoryEntity> entities;

            entities = await _unitOfWork.Subcategory.GetAsync();
            list = _mapper.Map<List<SubcategoryDto>>(entities);
            SetCategoryName(list);

            return list;
        }

        private async void SetCategoryName(List<SubcategoryDto> list)
        {
            List<CategoryEntity> categories;

            categories = await _unitOfWork.Category.GetAsync();
            list.ForEach(subcategory =>
            {
                CategoryEntity category;

                category = categories.Where(x => x.Id == subcategory.CategoryId).FirstOrDefault();

                subcategory.CategoryName = category.Name;
            });
        }

        public async Task UpdateAsync(SubcategoryDtoIn item, int id)
        {
            SubcategoryEntity entity;

            entity = await _unitOfWork.Subcategory.GetAsync(id);
            entity.Amount = item.Amount;
            entity.CategoryId = item.CategoryId;
            entity.Name = item.Name;

            await _unitOfWork.Subcategory.UpdateAsync(entity);
        }

    }//end class
}
