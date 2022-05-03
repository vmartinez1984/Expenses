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
    public class SubcategoryBl : ISubcategoryBl
    {
        private IUnitOfWorkRepository _unitOfWork;
        private IMapper _mapper;

        public SubcategoryBl(IMapper mapper, IUnitOfWorkRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> AddAsync(SubategoryDtoIn entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SubategoryDtoIn> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<SubcategoryDtoOut>> GetAsync()
        {
            IReadOnlyList<SubcategoryDtoOut> list;
            IReadOnlyList<SubcategoryEntity> entities;

            entities = await _unitOfWork.Subcategory.GetAsync();
            list = _mapper.Map<List<SubcategoryDtoOut>>(entities);

            return list;
        }

        public Task UpdateAsync(SubategoryDtoIn entity)
        {
            throw new NotImplementedException();
        }
    }
}
