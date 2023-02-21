using AutoMapper;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
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

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Invesment.DeleteAsync(id);
        }

        public async Task<PagerDto> GetAllAsync(PagerDto pagerDto)
        {
            List<InvestmentEntity> entities;
            List<InvestmentDto> list;
            PagerEntity pagerEntity;

            pagerEntity = _mapper.Map<PagerEntity>(pagerDto);
            entities = await _unitOfWork.Invesment.GetAllAsync(pagerEntity);
            list = _mapper.Map<List<InvestmentDto>>(entities);
            pagerDto = _mapper.Map<PagerDto>(pagerEntity);
            pagerDto.List = list;            

            return pagerDto;
        }

        public async Task<InvestmentDto> GetAsync(int id)
        {
            InvestmentEntity entity;
            InvestmentDto dto;

            entity = await _unitOfWork.Invesment.GetAsync(id);
            dto = _mapper.Map<InvestmentDto>(entity);

            return dto;
        }

        public async Task UpdateAsync(InvesmentDtoIn item, int id)
        {
            InvestmentEntity entity;

            entity = await _unitOfWork.Invesment.GetAsync(id);
            entity.Amount = item.Amount;
            entity.AmountFinal= item.AmountFinal;
            entity.DateStart = item.DateStart;
            entity.DateStop= item.DateStop;
            entity.InstructionId = item.InstructionId;
            entity.Interest = item.Interest;
            entity.Name = item.Name;
            entity.Term = item.Term;
            entity.Note = item.Note;

            await _unitOfWork.Invesment.UpdateAsync(entity);
        }
    }
}