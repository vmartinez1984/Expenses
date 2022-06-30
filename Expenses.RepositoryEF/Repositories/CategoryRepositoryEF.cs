using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF.Repositories
{
    public class CategoryRepositoryEF : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryEntity> GetAsync(int id)
        {
            CategoryEntity item;

            item = await _context.Category.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();

            return item;
        }

        public async Task<IReadOnlyList<CategoryEntity>> GetAsync()
        {
            IReadOnlyList<CategoryEntity> list;

            list = await _context.Category.Where(x => x.IsActive).ToListAsync();

            return list;
        }

        public async Task<int> AddAsync(CategoryEntity entity)
        {
            await _context.Category.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(CategoryEntity entity)
        {
            CategoryEntity item;

            item = await _context.Category.Where(x => x.Id == entity.Id && x.IsActive).FirstOrDefaultAsync();
            item.Name = entity.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CategoryEntity item;

            item = await _context.Category.Where(x => x.Id == id).FirstOrDefaultAsync();
            item.IsActive = false;

            await _context.SaveChangesAsync();
        }
    }
}
