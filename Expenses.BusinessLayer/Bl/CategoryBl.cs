using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class CategoryBl : ICategoryBl
    {
        private IUnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;

        public CategoryBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CategoryDtoOut> GetAsync(int id)
        {
            CategoryEntity entity;
            CategoryDtoOut item;

            entity = await _unitOfWork.Category.GetAsync(id);
            item = _mapper.Map<CategoryDtoOut>(entity);

            return item;
        }

        public async Task<IReadOnlyList<CategoryDtoOut>> GetAsync()
        {
            IReadOnlyList<CategoryEntity> entities;
            IReadOnlyList<CategoryDtoOut> list;

            entities = await _unitOfWork.Category.GetAsync();
            list = _mapper.Map<List<CategoryDtoOut>>(entities);

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
