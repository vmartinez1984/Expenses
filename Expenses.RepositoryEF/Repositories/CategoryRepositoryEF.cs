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
            _context.Category.Add(entity);

            return entity.Id;
        }

        public void Delete(int id)
        {
            CategoryEntity item;

            item = _context.Category.Where(x=> x.Id == id).FirstOrDefault();
            item.IsActive = false;

            _context.SaveChanges();
        }

        public List<CategoryEntity> Get()
        {
            List<CategoryEntity> list;

            list = _context.Category.Where(x => x.IsActive).ToList();

            return list;
        }

        public CategoryEntity Get(int id)
        {
           CategoryEntity item;

           item = _context.Category.Where(x=> x.Id == id && x.IsActive).FirstOrDefault();

           return item;
        }

        public void Update(CategoryEntity entity)
        {
            CategoryEntity item;

            item = _context.Category.Where(x=> x.Id == entity.Id && x.IsActive).FirstOrDefault();            
            item.Name = entity.Name;

            _context.SaveChanges();
        }
    }
}
