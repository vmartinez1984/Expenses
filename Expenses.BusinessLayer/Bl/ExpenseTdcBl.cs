using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class ExpenseTdcBl : BaseBl, IExpenseTdcBl
    {
        public ExpenseTdcBl(IMapper mapper, IRepository unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<int> AddAsync(ExpenseTdcDtoIn item)
        {
            try
            {
                ExpenseTdcEntity entity;

                entity = _mapper.Map<ExpenseTdcEntity>(item);

                entity.Id = await _unitOfWork.ExpenseTdc.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.ExpenseTdc.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ExpenseTdcDtoOut> GetAsync(int id)
        {
            try
            {
                ExpenseTdcDtoOut item;
                ExpenseTdcEntity entity;

                entity = await _unitOfWork.ExpenseTdc.GetAsync(id);
                item = _mapper.Map<ExpenseTdcDtoOut>(entity);

                return item;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<ExpenseTdcDtoOut>> GetAsync()
        {
            try
            {
                List<ExpenseTdcDtoOut> list;
                IReadOnlyList<ExpenseTdcEntity> entities;

                entities = await _unitOfWork.ExpenseTdc.GetAsync();
                list = _mapper.Map<List<ExpenseTdcDtoOut>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(ExpenseTdcDtoIn item, int id)
        {
            try
            {
                ExpenseTdcEntity entity;

                entity = _mapper.Map<ExpenseTdcEntity>(item);
                entity.Id = id;

                await _unitOfWork.ExpenseTdc.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
        
    }
}