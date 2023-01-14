
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Expenses.RepositoryEF.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF
{
    public class SubcategoryRepositoryEF : BaseRepository, ISubcategoryRepository
    {
        public SubcategoryRepositoryEF(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<int> AddAsync(SubcategoryEntity entity)
        {
            entity.IsActive = true;            
            await _appDbContext.Subcategory.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            SubcategoryEntity item;

            item = await _appDbContext.Subcategory.FindAsync(id);
            item.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task<SubcategoryEntity> GetAsync(int id)
        {
            SubcategoryEntity entity;

            entity = await _appDbContext.Subcategory
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<List<SubcategoryEntity>> GetAsync()
        {

            List<SubcategoryEntity> list;

            list = await _appDbContext.Subcategory
                .Include(x=> x.Category)
                .Where(x => x.IsActive)
                .ToListAsync();

            return list;
        }

        public async Task UpdateAsync(SubcategoryEntity entity)
        {
            _appDbContext.Subcategory.Update(entity);

            await _appDbContext.SaveChangesAsync();
        }
    }
}