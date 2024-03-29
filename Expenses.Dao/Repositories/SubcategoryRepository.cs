using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class SubcategoryRepository : BaseRepository, ISubcategoryRepository
    {
        public SubcategoryRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(SubcategoryEntity entity)
        {
            string query;

            query = $@"INSERT INTO Subcategory (Name, CategoryId, Amount, IsActive) VALUES(@Name, @CategoryId, @Amount, 1); {LastId}";
            entity.Id = await _dbConnection.QueryFirstOrDefaultAsync<int>(query, entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            string query;

            query = $@"UPDATE Subcategory SET IsActive = 0 WHERE Id = {id}";

            await _dbConnection.QueryAsync(query);
        }

        public async Task<SubcategoryEntity> GetAsync(int id)
        {
            SubcategoryEntity entity;
            string query;

            query = $@"SELECT Subcategory.* FROM Subcategory WHERE Subcategory.Id = {id}";
            entity = await _dbConnection.QueryFirstOrDefaultAsync<SubcategoryEntity>(query);
            
            return entity;
        }

        public async Task<List<SubcategoryEntity>> GetAsync()
        {
            IEnumerable<SubcategoryEntity> entities;
            string query;

            query = @"SELECT Subcategory.* FROM Subcategory WHERE Subcategory.IsActive = 1 ORDER BY Name DESC";
            entities = await _dbConnection.QueryAsync<SubcategoryEntity>(query);

            return entities.ToList();
        }

        public async Task UpdateAsync(SubcategoryEntity entity)
        {
            string query;

            query = $@"UPDATE Subcategory SET Name = @Name, CategoryId = @CategoryId, Amount = @Amount   WHERE Id = @Id";

            await _dbConnection.QueryAsync(query, entity);
        }

    }//end class
}