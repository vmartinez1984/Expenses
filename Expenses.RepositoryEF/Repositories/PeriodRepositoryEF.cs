using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Expenses.RepositoryEF.Repositories
{
    public class PeriodRepositoryEF : IPeriodRepository
    {
        private readonly AppDbContext _appDbContext;

        public PeriodRepositoryEF(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<PeriodEntity> GetAsync(int id)
        {
            PeriodEntity entity;

            entity = await _appDbContext.Period.Where(item => item.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IReadOnlyList<PeriodEntity>> GetAsync()
        {
            IReadOnlyList<PeriodEntity> list;

            list = await _appDbContext.Period.ToListAsync();

            return list;
        }

        public async Task<int> AddAsync(PeriodEntity entity)
        {
            await _appDbContext.Period.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(PeriodEntity entity)
        {
            _appDbContext.Period.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            PeriodEntity entity;

            entity = await GetAsync(id);
            _appDbContext.Period.Remove(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<PeriodEntity> GetActiveAsync()
        {
            PeriodEntity entity;

            entity = await _appDbContext.Period.Where(item => item.IsActive)
            .FirstOrDefaultAsync();

            return entity;
        }

        public  int GetBalance(int id){

            int entries;
            int expenses;

            entries = _appDbContext.Entry.Where(item => item.PeriodId == id).Sum(item => item.Amount);
            expenses = _appDbContext.Expense.Where(item => item.PeriodId == id).Sum(item => item.Amount);

            return entries - expenses;
        }
    }
}