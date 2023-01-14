using AutoMapper;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class CategoryBl : ICategoryBl
    {
        private IRepository _unitOfWork;
        private IMapper _mapper;

        public CategoryBl(IMapper mapper, IRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            CategoryEntity entity;
            CategoryDto item;

            entity = await _unitOfWork.Category.GetAsync(id);
            item = _mapper.Map<CategoryDto>(entity);

            return item;
        }

        public async Task<List<CategoryDto>> GetAsync()
        {
            List<CategoryEntity> entities;
            List<CategoryDto> list;

            entities = await _unitOfWork.Category.GetAsync();
            list = _mapper.Map<List<CategoryDto>>(entities);
            
            return list;
        }

        public async Task<int> AddAsync(CategoryDtoIn item)
        {
            CategoryEntity entity;

            entity = _mapper.Map<CategoryEntity>(item);
            entity.Id = await _unitOfWork.Category.AddAsync(entity);

            return entity.Id;
        }

        public async Task UpdateAsync(CategoryDtoIn item, int id)
        {
            CategoryEntity entity;

            entity = _mapper.Map<CategoryEntity>(item);
            entity.Id = id;

            await _unitOfWork.Category.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Category.DeleteAsync(id);
        }
    }
}
