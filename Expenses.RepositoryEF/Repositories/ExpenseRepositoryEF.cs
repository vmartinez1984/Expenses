using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Expenses.RepositoryEF.Repositories
{
    public class ExpenseRepositoryEF: IExpenseRepository
    {
         private readonly AppDbContext _appDbContext;

        public ExpenseRepositoryEF(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(ExpenseEntity entity)
        {
            await _appDbContext.Expense.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            ExpenseEntity entity;

            entity= await _appDbContext.Expense.Where(x=> x.Id == id).FirstOrDefaultAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ExpenseEntity> GetAsync(int id)
        {
            ExpenseEntity entity;

            entity= await _appDbContext.Expense.Where(x=> x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IReadOnlyList<ExpenseEntity>> GetAllAsync(int periodId)
        {
            IReadOnlyList<ExpenseEntity> entities;

            entities = await _appDbContext.Expense.Where(x=> x.PeriodId == periodId && x.IsActive).ToListAsync();

            return entities;
        }

        public async Task<IList<ExpenseEntity>> GetAllOfDepositPlanAsync(int depositPlanId)
        {
            List<ExpenseEntity> entities;

            entities = await _appDbContext.Expense.Where(x=> x.DepositPlanId == depositPlanId && x.IsActive).ToListAsync();

            return entities;
        }

        public async Task UpdateAsync(ExpenseEntity entity)
        {
            _appDbContext.Expense.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}