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
    public class InvesmentBl : BaseBl, IInvesmentBl
    {
        public InvesmentBl(IMapper mapper, IRepository unitOfWork) : base(mapper, unitOfWork)
        {
        }

        public async Task<int> AddAsync(InvesmentDtoIn item)
        {
            InvestmentEntity entity;

            entity = _mapper.Map<InvestmentEntity>(item);
            await _unitOfWork.Invesment.AddAsync(entity);

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvestmentDto>> GetAllAsync()
        {
            List<InvestmentEntity> entities;
            List<InvestmentDto> list;

            entities = await _unitOfWork.Invesment.GetAllAsync();
            list = _mapper.Map<List<InvestmentDto>>(entities);

            return list;
        }

        public Task<InvestmentDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvesmentDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}