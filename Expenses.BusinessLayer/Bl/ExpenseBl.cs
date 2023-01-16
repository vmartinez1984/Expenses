using AutoMapper;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class ExpenseBl : IExpenseBl
    {
        private IMapper _mapper;
        private IRepository _unitOfWork;

        public ExpenseBl(IMapper mapper, IRepository unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(ExpenseDtoIn item)
        {
            try
            {
                ExpenseEntity entity;

                entity = _mapper.Map<ExpenseEntity>(item);
                entity.Id = await _unitOfWork.Expense.AddAsync(entity);
                if (item.IsSaveInApartN)
                    await AddApartAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task AddApartAsync(ExpenseEntity expense)
        {
            ApartEntity apartEntity;

            apartEntity = new ApartEntity
            {
                Amount = expense.Amount,
                DateRegistration = DateTime.Now,
                ExpenseId = expense.Id,
                IsActive = true,
                IsApartN = true,
                Name = expense.Name,
                SubcategoryId = expense.SubcategoryId
            };

            await _unitOfWork.Apart.AddAsync(apartEntity);
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Expense.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ExpenseDto>> GetAllAsync(int periodId)
        {
            List<ExpenseDto> list;
            IReadOnlyList<ExpenseEntity> entities;

            entities = await _unitOfWork.Expense.GetAllAsync(periodId);
            list = _mapper.Map<List<ExpenseDto>>(entities);

            return list;
        }

        public async Task<ExpenseDto> GetAsync(int expenseId)
        {
            try
            {
                ExpenseDto item;
                ExpenseEntity entity;

                entity = await _unitOfWork.Expense.GetAsync(expenseId);
                item = _mapper.Map<ExpenseDto>(entity);
                item.CategoryId = await GetCategoryId(item.SubcategoryId);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task<int> GetCategoryId(int subcategoryId)
        {
            int categoryId;

            categoryId = (await _unitOfWork.Subcategory.GetAsync(subcategoryId)).CategoryId;

            return categoryId;
        }

        public async Task UpdateAsync(ExpenseDtoIn item, int id)
        {
            try
            {
                ExpenseEntity entity;

                entity = _mapper.Map<ExpenseEntity>(item);
                entity.Id = id;

                await _unitOfWork.Expense.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
