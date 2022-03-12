using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class EntryBl : IEntryBl
    {
        private IUnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;

        public EntryBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(EntryDtoIn item)
        {
            try
            {
                EntryEntity entity;

                entity = _mapper.Map<EntryEntity>(item);
                entity.Id = await _unitOfWork.Entry.AddAsync(entity);

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Entry.DeleteAsync(id);
        }

        public async Task<List<EntryDtoOut>> GetAsync(int periodId)
        {
            try
            {
                List<EntryEntity> entities;
                List<EntryDtoOut> list;

                entities = await _unitOfWork.Entry.GetAsync(periodId);
                list = _mapper.Map<List<EntryDtoOut>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(EntryDtoIn item, int id)
        {
            try
            {
                EntryEntity entity;

                entity = _mapper.Map<EntryEntity>(item);
                entity.Id = id;
                await _unitOfWork.Entry.UpdateAsync(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
