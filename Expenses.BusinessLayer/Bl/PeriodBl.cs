using AutoMapper;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using Expenses.Core.Entities;
using Expenses.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    public class PeriodBl : BaseBl, IPeriodBl
    {
        private readonly IExpenseBl _expenseBl;

        public PeriodBl(
            IMapper mapper
            , IRepository unitOfWork
            , IExpenseBl expensesBl
        ) : base(mapper, unitOfWork) { _expenseBl = expensesBl; }

        public async Task<int> AddAsync(PeriodDtoIn item)
        {
            try
            {
                PeriodEntity entity;

                entity = _mapper.Map<PeriodEntity>(item);
                entity.Id = await _unitOfWork.Period.AddAsync(entity);

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

            await _unitOfWork.Period.UpdateAsync(entity);
        }

        public async Task<List<PeriodDto>> GetAsync()
        {
            List<PeriodDto> list;
            IReadOnlyList<PeriodEntity> entities;

            entities = await _unitOfWork.Period.GetAsync();
            list = _mapper.Map<List<PeriodDto>>(entities);

            return list;
        }

        public async Task<PeriodDto> GetAsync(int id)
        {
            PeriodDto item;
            PeriodEntity entity;

            entity = await _unitOfWork.Period.GetAsync(id);
            item = _mapper.Map<PeriodDto>(entity);

            return item;
        }

        public async Task<PeriodFullDto> GetFullAsync(int periodId)
        {
            PeriodFullDto item;
            PeriodEntity entity;

            entity = await _unitOfWork.Period.GetAsync(periodId);
            item = _mapper.Map<PeriodFullDto>(entity);
            item.ListExpenses = await GetListExpensesAsync(item.Id);

            return item;
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Period.DeleteAsync(id);
        }

        private async Task<List<ExpenseDto>> GetListExpensesAsync(int periodId)
        {
            List<SubcategoryEntity> subcategories;
            List<ExpenseDto> expenses;
            List<ExpenseDto> list;

            subcategories = await _unitOfWork.Subcategory.GetAsync();
            expenses = await _expenseBl.GetAsync(periodId);
            list = new List<ExpenseDto>();
            subcategories.ForEach(subcategory =>
            {
                List<ExpenseDto> expensesByCategory;

                expensesByCategory = expenses.Where(x => x.SubcategoryId == subcategory.Id).ToList();
                if (expensesByCategory.Count == 0)
                {
                    list.Add(new ExpenseDto
                    {
                        Amount = 0,
                        Budget = (int)subcategory.Amount,
                        CategoryId = subcategory.CategoryId,
                        Id = 0,                        
                        DateRegister = null,
                        Name = string.Empty,
                        PeriodId = periodId,
                        SubcategoryId = subcategory.Id,
                        SubcategoryName = subcategory.Name
                    });
                }
                else
                {
                    expensesByCategory.ForEach(expense =>
                    {
                        list.Add(new ExpenseDto
                        {
                            Amount = expense.Amount,
                            Budget = (int)subcategory.Amount,
                            CategoryId = subcategory.CategoryId,
                            Id = expense.Id,
                            CategoryName = expense.CategoryName,
                            DateRegister = expense.DateRegister,
                            Name = expense.Name,
                            PeriodId = expense.PeriodId,
                            SubcategoryId = subcategory.Id,
                            SubcategoryName = subcategory.Name
                        });
                    });
                }
            });
            await SetCategoryNameAsync(list);

            return list.OrderBy(x => x.SubcategoryName).ToList();
        }

        private async Task SetCategoryNameAsync(List<ExpenseDto> list)
        {
            List<CategoryEntity> categories;

            categories = await _unitOfWork.Category.GetAsync();
            list.ForEach(expense =>
            {
                CategoryEntity category;

                category = categories.Where(x => x.Id == expense.CategoryId).FirstOrDefault();
                if (category != null)
                {
                    expense.CategoryName = category.Name;
                }
            });
        }
    }
}