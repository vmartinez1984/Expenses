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

        public SubcategoryRepositoryEF()
        {

        }

        public Task<int> AddAsync(SubcategoryEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
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
                .Where(x => x.IsActive)
                .ToListAsync();

            return list;
        }

        public Task UpdateAsync(SubcategoryEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}