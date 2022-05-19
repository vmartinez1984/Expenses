using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Expenses.RepositoryEF.Repositories
{
    public class ExpenseTdcRepositoryEF: IExpenseTdcRepository
    {
         private readonly AppDbContext _appDbContext;

        public ExpenseTdcRepositoryEF(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AddAsync(ExpenseTdcEntity entity)
        {
            await _appDbContext.ExpenseTdc.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            ExpenseTdcEntity entity;

            entity= await _appDbContext.ExpenseTdc.Where(x=> x.Id == id).FirstOrDefaultAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<ExpenseTdcEntity> GetAsync(int id)
        {
            ExpenseTdcEntity entity;

            entity= await _appDbContext.ExpenseTdc.Where(x=> x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IReadOnlyList<ExpenseTdcEntity>> GetAsync()
        {
            IReadOnlyList<ExpenseTdcEntity> entities;

            entities = await _appDbContext.ExpenseTdc.Where(x=> x.IsActive).ToListAsync();

            return entities;
        }


        public async Task UpdateAsync(ExpenseTdcEntity entity)
        {
            _appDbContext.ExpenseTdc.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}