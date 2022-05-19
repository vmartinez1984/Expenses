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
    public class ExpenseBl : IExpensesBl
    {
        private IMapper _mapper;
        private IUnitOfWorkRepository _unitOfWork;

        public ExpenseBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
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
            SubcategoryEntity subcategory;

            subcategory = await _unitOfWork.Subcategory.GetAsync(expense.SubcategoryId);
            if (subcategory != null && subcategory.IsBudget)
                expense.BudgetAmount = subcategory.Amount;
            else
                expense.BudgetAmount = null;            
        }

        private async Task SetDeposit(ExpenseEntity expense)
        {
            DepositPlanEntity depostiPlanId;

            depostiPlanId = await _unitOfWork.DepositPlan.GetAsync(expense.SubcategoryId);
            if (depostiPlanId is null)
                expense.DepositPlanId = null;
            else
                expense.DepositPlanId = depostiPlanId.Id;
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

        public async Task<List<ExpenseDtoOut>> GetAsync(int periodId)
        {
            try
            {
                List<ExpenseDtoOut> list;
                IReadOnlyList<ExpenseEntity> entities;

                entities = await _unitOfWork.Expense.GetAllAsync(periodId);
                list = _mapper.Map<List<ExpenseDtoOut>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExpenseDtoOut> GetByIdAsync(int expenseId)
        {
            try
            {
                ExpenseDtoOut item;
                ExpenseEntity entity;

                entity = await _unitOfWork.Expense.GetAsync(expenseId);
                await SetBudget(entity);
                item = _mapper.Map<ExpenseDtoOut>(entity);
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
