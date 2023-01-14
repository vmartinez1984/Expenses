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
                await SetDeposit(entity);
                await SetBudget(entity);
                entity.Id = await _unitOfWork.Expense.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private async Task SetBudget(ExpenseEntity expense)
        {
            //SubcategoryEntity subcategory;

            //subcategory = await _unitOfWork.Subcategory.GetAsync(expense.SubcategoryId);
            //if (subcategory != null && subcategory.IsBudget)
            //    expense.BudgetAmount = subcategory.Amount;
            //else
            //    expense.BudgetAmount = null;            
        }

        private async Task SetDeposit(ExpenseEntity expense)
        {
            //DepositPlanEntity depostiPlanId;

            //depostiPlanId = await _unitOfWork.DepositPlan.GetAsync(expense.SubcategoryId);
            //if (depostiPlanId is null)
            //    expense.DepositPlanId = null;
            //else
            //    expense.DepositPlanId = depostiPlanId.Id;
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

        public async Task<List<ExpenseDto>> GetAsync(int periodId)
        {
            List<ExpenseDto> list;
            IReadOnlyList<ExpenseEntity> entities;

            entities = await _unitOfWork.Expense.GetAllAsync(periodId);
            list = _mapper.Map<List<ExpenseDto>>(entities);

            return list;
        }

        public async Task<ExpenseDto> GetByIdAsync(int expenseId)
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
                await SetBudget(entity);
                await SetDeposit(entity);

                await _unitOfWork.Expense.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
