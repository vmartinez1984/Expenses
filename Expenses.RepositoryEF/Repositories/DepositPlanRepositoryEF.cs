using System.Threading.Tasks;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;

namespace Expenses.RepositoryEF.Repositories
{
    public class DepositPlanRepositoryEF : BaseRepository,  IDepositPlanRepository
    {
        public DepositPlanRepositoryEF(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(DepositPlanEntity entity)
        {
            await _appDbContext.DepositPlan.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            DepositPlanEntity entity;

            entity= await _appDbContext.DepositPlan.Where(x=> x.Id == id).FirstOrDefaultAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<DepositPlanEntity> GetAsync(int id)
        {
            DepositPlanEntity entity;

            entity= await _appDbContext.DepositPlan.Where(x=> x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<DepositPlanEntity>> GetAsync()
        {
            List<DepositPlanEntity> entities;

            entities = await _appDbContext.DepositPlan.Where(x=> x.IsActive).ToListAsync();

            return entities;
        }

        public async Task<int> GetTotalAsync(int id)
        {
            int total;

            //total = await _appDbContext.Expense.Where(x=> x.DepositPlanId == id).SumAsync(x=> x.Amount);
            total = 0;

            return total;
        }

        public async Task UpdateAsync(DepositPlanEntity entity)
        {
            _appDbContext.DepositPlan.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}