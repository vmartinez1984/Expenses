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
    public class PeriodBl : IPeriodBl
    {
        private IUnitOfWorkRepository _unitOfWorkRepository;
        private IMapper _mapper;
        private ExpenseBl _expenseBl;
        private EntryBl _entryBl;

        public PeriodBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWorkRepository = unitOfWork;
            _mapper = mapper;
            _expenseBl = new ExpenseBl(_mapper, _unitOfWorkRepository);
            _entryBl = new EntryBl(_mapper, _unitOfWorkRepository);
        }

        public async Task<int> AddAsync(PeriodDtoIn item)
        {
            try
            {
                PeriodEntity entity;

                entity = _mapper.Map<PeriodEntity>(item);
                entity.Id = await _unitOfWorkRepository.Period.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(PeriodDtoIn item, int id)
        {
            PeriodEntity entity;

            entity = _mapper.Map<PeriodEntity>(item);
            entity.Id = id;

            await _unitOfWorkRepository.Period.UpdateAsync(entity);
        }

        public async Task<IReadOnlyList<PeriodDtoOut>> GetAsync()
        {
            List<PeriodDtoOut> list;
            IReadOnlyList<PeriodEntity> entities;

            entities = await _unitOfWorkRepository.Period.GetAsync();
            list = _mapper.Map<List<PeriodDtoOut>>(entities);
            list.ForEach(item =>
            {
                item.Balance = _unitOfWorkRepository.Period.GetBalance(item.Id);
            });

            return list;
        }

        public async Task<PeriodDtoOut> GetAsync(int id)
        {
            PeriodDtoOut item;
            PeriodEntity entity;

            entity = await _unitOfWorkRepository.Period.GetAsync(id);
            item = _mapper.Map<PeriodDtoOut>(entity);

            return item;
        }

        public async Task<PeriodFullDtoOut> GetFullAsync(int id)
        {
            PeriodFullDtoOut item;
            PeriodEntity entity;

            entity = await _unitOfWorkRepository.Period.GetAsync(id);
            item = _mapper.Map<PeriodFullDtoOut>(entity);
            item.Balance = _unitOfWorkRepository.Period.GetBalance(entity.Id);
            item.ListEntries = await GetListEntriesAsync(item.Id);
            item.ListExpenses = await GetListExpensesAsync(item.Id);

            return item;
        }

        public  async Task DeleteAsync(int id)
        {
            await _unitOfWorkRepository.Period.DeleteAsync(id);
        }

        public async Task<PeriodFullDtoOut> GetFullActiveAsync()
        {
            PeriodFullDtoOut item;
            PeriodEntity entity;

            entity = await _unitOfWorkRepository.Period.GetActiveAsync();
            item = _mapper.Map<PeriodFullDtoOut>(entity);
            item.Balance = _unitOfWorkRepository.Period.GetBalance(entity.Id);
            item.ListEntries = await GetListEntriesAsync(item.Id);
            item.ListExpenses = await GetListExpensesAsync(item.Id);

            return item;
        }

        private async Task<List<EntryDtoOut>> GetListEntriesAsync(int periodId)
        {
            List<EntryDtoOut> list;

            list = await _entryBl.GetAsync(periodId);

            return list;
        }

        private async Task<List<ExpenseDtoOut>> GetListExpensesAsync(int periodId)
        {
            List<ExpenseDtoOut> list;

            list = await _expenseBl.GetAsync(periodId);

            return list;
        }
    }
}