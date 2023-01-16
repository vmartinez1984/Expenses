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
    public class EntryBl : BaseBl, IEntryBl
    {
        public EntryBl(IMapper mapper, IRepository unitOfWork) : base(mapper, unitOfWork)
        {
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

        public Task<int> AddAsync(EntryDtoOut item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Entry.DeleteAsync(id);
        }

        public async Task<List<EntryDtoOut>> GetAllAsync(int periodId)
        {
            try
            {
                IReadOnlyList<EntryEntity> entities;
                List<EntryDtoOut> list;

                entities = await _unitOfWork.Entry.GetAllAsync(periodId);
                list = _mapper.Map<List<EntryDtoOut>>(entities);

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<EntryDtoIn> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EntryDtoOut> GetIdAsync(int periodId)
        {
            try
            {
                EntryEntity entity;
                EntryDtoOut item;

                entity = await _unitOfWork.Entry.GetAsync(periodId);
                item = _mapper.Map<EntryDtoOut>(entity);

                return item;
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

        public Task UpdateAsync(EntryDtoOut item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
