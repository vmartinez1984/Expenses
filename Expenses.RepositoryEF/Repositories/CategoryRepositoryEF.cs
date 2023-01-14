using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF.Repositories
{
    public class CategoryRepositoryEF : BaseRepository, ICategoryRepository
    {
        public CategoryRepositoryEF(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<CategoryEntity> GetAsync(int id)
        {
            CategoryEntity item;

            item = await _appDbContext.Category.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();

            return item;
        }

        public async Task<List<CategoryEntity>> GetAsync()
        {
            List<CategoryEntity> list;

            list = await _appDbContext.Category.Where(x => x.IsActive).ToListAsync();

            return list;
        }

        public async Task<int> AddAsync(CategoryEntity entity)
        {
            await _appDbContext.Category.AddAsync(entity);
            await _appDbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(CategoryEntity entity)
        {
            CategoryEntity item;

            item = await _appDbContext.Category.Where(x => x.Id == entity.Id && x.IsActive).FirstOrDefaultAsync();
            item.Name = entity.Name;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CategoryEntity item;

            item = await _appDbContext.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.IsActive = false;

            await _appDbContext.SaveChangesAsync();
        }
    }
}
