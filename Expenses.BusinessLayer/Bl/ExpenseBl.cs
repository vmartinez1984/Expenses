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
                SetDeposit(entity);
                SetBudget(entity);
                entity.Id = await _unitOfWork.Expense.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetBudget(ExpenseEntity entity)
        {
            throw new NotImplementedException();
        }

        private void SetDeposit(ExpenseEntity entity)
        {
            // DepositPlan depostiPlanId;

            // depostiPlanId = _context.DepositPlan.Where(x => x.SubcategoryId == expense.SubcategoryId).FirstOrDefault();
            // if (depostiPlanId is null)
            //     expense.DepositPlanId = null;
            // else
            //     expense.DepositPlanId = depostiPlanId.Id;
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
                List<ExpenseEntity> entities;

                entities = await _unitOfWork.Expense.GetAsync(periodId);
                list = _mapper.Map<List<ExpenseDtoOut>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
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
