using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF.Repositories
{
    public class TermAccountRepositoryEF : ITermAccountRepository
    {
        private readonly AppDbContext _context;

        public TermAccountRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TermAccountEntity> GetAsync(int id)
        {
            TermAccountEntity item;

            item = await _context.TermAccount.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();

            return item;
        }

        public async Task<IReadOnlyList<TermAccountEntity>> GetAsync()
        {
            IReadOnlyList<TermAccountEntity> list;

            list = await _context.TermAccount.Where(x => x.IsActive).ToListAsync();            
            return list;
        }

        public async Task<int> AddAsync(TermAccountEntity entity)
        {
            await _context.TermAccount.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(TermAccountEntity entity)
        {
             _context.TermAccount.Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TermAccountEntity item;

            item = await _context.TermAccount.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.IsActive = false;

            await _context.SaveChangesAsync();
        }
    }
}
