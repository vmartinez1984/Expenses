using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF.Repositories
{
    public class TermAccountRepositoryEF : BaseRepository, ITermAccountRepository
    {
        public TermAccountRepositoryEF(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<TermAccountEntity> GetAsync(int id)
        {
            TermAccountEntity item;

            item = await _appDbContext.TermAccount.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();

            return item;
        }

        public async Task<List<TermAccountEntity>> GetAsync()
        {
            List<TermAccountEntity> list;

            list = await _appDbContext.TermAccount.Where(x => x.IsActive).ToListAsync();            
            return list;
        }

        public async Task<int> AddAsync(TermAccountEntity entity)
        {
            await _appDbContext.TermAccount.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(TermAccountEntity entity)
        {
             _appDbContext.TermAccount.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TermAccountEntity item;

            item = await _appDbContext.TermAccount.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
