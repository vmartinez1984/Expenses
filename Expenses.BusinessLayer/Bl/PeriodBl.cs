using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public int Add(PeriodDtoIn item)
        {
            try
            {
                PeriodEntity entity;

                entity = _mapper.Map<PeriodEntity>(item);
                entity.Id = _unitOfWorkRepository.Period.Add(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(PeriodDtoIn item, int id)
        {
            PeriodEntity entity;

            entity = _mapper.Map<PeriodEntity>(item);
            entity.Id = id;

            _unitOfWorkRepository.Period.Update(entity);
        }

        public List<PeriodDtoOut> Get()
        {
            List<PeriodDtoOut> list;
            List<PeriodEntity> entities;

            entities = _unitOfWorkRepository.Period.Get();
            list = _mapper.Map<List<PeriodDtoOut>>(entities);
            list.ForEach(item => {
                item.Balance = _unitOfWorkRepository.Period.GetBalance(item.Id);
            });

            return list;
        }
        
        public PeriodDtoOut Get(int id)
        {
            PeriodDtoOut item;
            PeriodEntity entity;

            entity = _unitOfWorkRepository.Period.Get(id);
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

        public void Delete(int id)
        {
            _unitOfWorkRepository.Period.Delete(id);
        }

        public async Task<PeriodFullDtoOut> GetActiveAsync()
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

        public List<PeriodFullDtoOut> GetFull()
        {
            List<PeriodFullDtoOut> list;
            
            list = _mapper.Map<List<PeriodFullDtoOut>>(Get());
            list.ForEach(item=> {
                item.ListExpenses = GetListExpensesAsync(item.Id).Result;        
                item.ListEntries =  GetListEntriesAsync(item.Id).Result;        
            });

            return list;
        }

        private async Task<List<EntryDtoOut>> GetListEntriesAsync(int periodId)
        {
            List<EntryDtoOut> list;

            list = await  _entryBl.GetAsync(periodId);

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