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
    public class TermAccountBl : ITermAccountBl
    {
        private IUnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;

        public TermAccountBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TermAccountDtoOut> GetAsync(int id)
        {
            TermAccountEntity entity;
            TermAccountDtoOut item;

            entity = await _unitOfWork.TermAccount.GetAsync(id);
            item = _mapper.Map<TermAccountDtoOut>(entity);
            AddTerm(item);

            return item;
        }

        private void AddTerm(TermAccountDtoOut item)
        {
            bool isDone;

            isDone = false;
            while (!isDone)
            {
                item.DateExpiration = item.DateRegistration.AddDays(item.Term);
                if (item.DateExpiration >= DateTime.Now)
                { }
                else { isDone = true; }
            }
        }

        public async Task<IReadOnlyList<TermAccountDtoOut>> GetAsync()
        {
            IReadOnlyList<TermAccountEntity> entities;
            List<TermAccountDtoOut> list;

            entities = await _unitOfWork.TermAccount.GetAsync();
            list = _mapper.Map<List<TermAccountDtoOut>>(entities);
            list.ForEach(item=>{
                AddTerm(item);
            });

            return list;
        }

        public async Task<int> AddAsync(TermAccountDtoIn item)
        {
            TermAccountEntity entity;

            entity = _mapper.Map<TermAccountEntity>(item);
            entity.Id = await _unitOfWork.TermAccount.AddAsync(entity);

            return entity.Id;
        }

        public async Task UpdateAsync(TermAccountDtoIn item, int id)
        {
            TermAccountEntity entity;

            entity = _mapper.Map<TermAccountEntity>(item);
            entity.Id = id;

            await _unitOfWork.TermAccount.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.TermAccount.DeleteAsync(id);
        }
    }
}
