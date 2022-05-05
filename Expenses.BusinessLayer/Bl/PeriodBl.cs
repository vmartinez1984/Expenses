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

        public PeriodBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWorkRepository = unitOfWork;
            _mapper = mapper;            
            _expenseBl = new ExpenseBl(_mapper, _unitOfWorkRepository);
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

        public Task<PeriodDtoOut> GetFullAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _unitOfWorkRepository.Period.Delete(id);
        }

        public async Task<PeriodDtoOut> GetActive()
        {
            PeriodEntity entity;
            PeriodDtoOut item;

            entity = await _unitOfWorkRepository.Period.GetActiveAsync();
            item = _mapper.Map<PeriodDtoOut>(entity);
            item.Balance = _unitOfWorkRepository.Period.GetBalance(entity.Id);

            return item;
        }

        public List<PeriodFullDtoOut> GetFull()
        {
            List<PeriodFullDtoOut> list;
            
            list = _mapper.Map<List<PeriodFullDtoOut>>(Get());
            list.ForEach(item=>{
                item.ListExpenses = GetListExpenses(item.Id);                
            });

            return list;
        }

        private List<ExpenseDtoOut> GetListExpenses(int periodId)
        {
            List<ExpenseDtoOut> list;
            
            list = new List<ExpenseDtoOut>();
            Task.Run(async ()=>{   
                //ExpenseBl expenseBl;

                //expenseBl = new ExpenseBl(_mapper, _unitOfWorkRepository);

                //list = await expenseBl.GetAsync(periodId);
                list = await _expenseBl.GetAsync(periodId);
            });

            return list;
        }
    }
}
