using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Expenses.RepositoryEF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public CategoryRepositoryEF()
        {

        }

        public int Add(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CategoryEntity> Get()
        {
            List<CategoryEntity> list;

            list = _context.Category.Where(x => x.IsActive).ToList();

            return list;
        }

        public CategoryEntity Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
