using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        public CategoryRepository(IConfiguration configuration) : base(configuration) { }


        public async Task<CategoryEntity> GetAsync(int id)
        {
            CategoryEntity entity;
            string query;

            query = $"SELECT * FROM Category WHERE IsActive = 1 AND  Id = {id}";
            entity = await db.QueryFirstOrDefaultAsync<CategoryEntity>(query);

            return entity;
        }

        public async Task<List<CategoryEntity>> GetAsync()
        {
            IEnumerable<CategoryEntity> entities;
            string query;

            query = "SELECT * FROM Category WHERE IsActive = 1";
            entities = await db.QueryAsync<CategoryEntity>(query);

            return entities.ToList();
        }

        public async Task<int> AddAsync(CategoryEntity entity)
        {
            string query;

            query = $"INSERT INTO Category (Name, IsActive)  VALUES(@Name, 1); {LastId}";

            entity.Id = await db.QueryFirstOrDefaultAsync<int>(query, entity);

            return entity.Id;
        }

        public async Task UpdateAsync(CategoryEntity entity)
        {
            string query;

            query = "UPDATE Category SET Name = @Name WHERE Id  = @Id";

            await db.QueryAsync(query, entity);
        }

        public async Task DeleteAsync(int id)
        {
            string query;

            query = $"UPDATE Category SET IsActive = 0 WHERE Id  = {id}";

            await db.QueryAsync(query);
        }
    }//end class
}