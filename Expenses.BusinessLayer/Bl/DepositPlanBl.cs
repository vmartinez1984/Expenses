using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Interfaces;
using Expenses.Core.Dtos;

namespace Expenses.BusinessLayer.Bl
{
    public class DepositPlanBl : IDepositPlanBl
    {
        private IRepository _unitOfWork;
        private IMapper _mapper;

        public DepositPlanBl(IMapper mapper, IRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(DepositPlanDtoIn item)
        {
            DepositPlanEntity entity;

            entity = _mapper.Map<DepositPlanEntity>(item);
            entity.Id = await _unitOfWork.DepositPlan.AddAsync(entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.DepositPlan.DeleteAsync(id);
        }

        public async Task<DepositPlanDtoOut> GetAsync(int id)
        {
            DepositPlanEntity entity;
            DepositPlanDtoOut item;

            entity = await _unitOfWork.DepositPlan.GetAsync(id);
            item = _mapper.Map<DepositPlanDtoOut>(entity);
            item.SubcategoryName = GetSubcategoryName(entity.SubcategoryId);
            return item;
        }

        private string GetSubcategoryName(int subcategoryId)
        {
            SubcategoryEntity entity;

            entity = _unitOfWork.Subcategory.GetAsync(subcategoryId).Result;

            return entity.Name;
        }

        public async Task<DepositPlanFullDtoOut> GetFullAsync(int id)
        {
            DepositPlanEntity entity;
            DepositPlanFullDtoOut item;

            entity = await _unitOfWork.DepositPlan.GetAsync(id);
            item = _mapper.Map<DepositPlanFullDtoOut>(entity);
            item.SubcategoryName = GetSubcategoryName(entity.SubcategoryId);
            item.ListExpenses= await GetListEntriesAsync(item.Id);

            return item;
        }

        private async Task<List<ExpenseDto>> GetListEntriesAsync(int id)
        {
            List<ExpenseDto> list;
            List<ExpenseEntity> entities;

            entities = (await _unitOfWork.Expense.GetAllOfDepositPlanAsync(id)).ToList();
            list = _mapper.Map<List<ExpenseDto>>(entities);

            return list;
        }

        public async Task<List<DepositPlanDtoOut>> GetAsync()
        {
            List<DepositPlanEntity> entities;
            List<DepositPlanDtoOut> list;

            entities = await _unitOfWork.DepositPlan.GetAsync();
            list = _mapper.Map<List<DepositPlanDtoOut>>(entities);
            await FillSubcategoriesAsync(list);
            await FillTotalsAsync(list);

            return list;
        }

        private async Task FillTotalsAsync(IReadOnlyList<DepositPlanDtoOut> list)
        {
            foreach (var item in list)
            {
                item.Total = await _unitOfWork.DepositPlan.GetTotalAsync(item.Id);
            }
        }

        private async Task FillSubcategoriesAsync(IReadOnlyList<DepositPlanDtoOut> list)
        {
            List<SubcategoryEntity> subcategories;

            subcategories = (await _unitOfWork.Subcategory.GetAsync()).ToList();

            list.ToList().ForEach(item =>
            {
                item.SubcategoryName = subcategories.Where(x => x.Id == item.SubcategoryId).FirstOrDefault().Name;
            });
        }

        public async Task UpdateAsync(DepositPlanDtoIn item, int id)
        {
            DepositPlanEntity entity;

            entity = _mapper.Map<DepositPlanEntity>(item);
            entity.Id = id;

            await _unitOfWork.DepositPlan.UpdateAsync(entity);
        }

    }
}