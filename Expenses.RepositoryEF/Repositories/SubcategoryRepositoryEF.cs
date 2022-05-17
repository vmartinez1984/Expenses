using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF
{
    public class SubcategoryRepositoryEF : ISubcategoryRepository
    {

        private readonly AppDbContext _context;

        public SubcategoryRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(SubcategoryEntity entity)
        {
            entity.IsActive = true;            
            await _context.Subcategory.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            SubcategoryEntity item;

            item = await _context.Subcategory.FindAsync(id);
            item.IsActive = false;

            await _context.SaveChangesAsync();
        }

        public async Task<SubcategoryEntity> GetAsync(int id)
        {
            SubcategoryEntity entity;

            entity = await _context.Subcategory
                .Where(x => x.Id == id && x.IsActive)
                .FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IReadOnlyList<SubcategoryEntity>> GetAsync()
        {

            IReadOnlyList<SubcategoryEntity> list;

            list = await _context.Subcategory
                .Include(x=> x.Category)
                .Where(x => x.IsActive)
                .ToListAsync();

            return list;
        }

        public async Task UpdateAsync(SubcategoryEntity entity)
        {
            _context.Subcategory.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}