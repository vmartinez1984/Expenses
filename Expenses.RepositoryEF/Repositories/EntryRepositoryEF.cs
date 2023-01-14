using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Expenses.RepositoryEF.Repositories
{
    public class EntryRepositoryEF : BaseRepository, IEntryRepositoy
    {
        public EntryRepositoryEF(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(EntryEntity entity)
        {
            await _appDbContext.Entry.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            EntryEntity entity;

            entity = await _appDbContext.Entry.Where(x => x.Id == id).FirstOrDefaultAsync();
            entity.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<EntryEntity> GetAsync(int id)
        {
            EntryEntity entity;

            entity = await _appDbContext.Entry.Where(x => x.Id == id).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<EntryEntity>> GetAllAsync(int periodId)
        {
            List<EntryEntity> entities;

            entities = await _appDbContext.Entry.Where(x => x.PeriodId == periodId && x.IsActive).ToListAsync();

            return entities;
        }

        public async Task UpdateAsync(EntryEntity entity)
        {
            _appDbContext.Entry.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}