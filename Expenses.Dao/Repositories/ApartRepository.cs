using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class ApartRepository : BaseRepository, IApartRepository
    {
        public ApartRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(ApartEntity entity)
        {
            string query;

            query = $@"INSERT INTO Apart (ExpenseId, Amount, DateRegistration, IsActive, IsApartN) VALUES(@ExpenseId, @Amount, NOW(), 1, @IsApartN); {LastId}";
            entity.Id = await _dbConnection.ExecuteAsync(query, entity);

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApartEntity>> GetAsync(int? subcategoryId)
        {
            string query;
            IEnumerable<ApartEntity> entities;

            if (subcategoryId is null)
            {
                query = $@"SELECT apart.*, expense.Name, expense.SubcategoryId FROM apart 
                INNER JOIN expense ON apart.ExpenseId = expense.Id                
                WHERE	apart.IsActive = 1";
            }
            else
            {
                query = $@"SELECT apart.*, expense.Name, expense.SubcategoryId FROM apart 
                INNER JOIN expense ON apart.ExpenseId = expense.Id                
                WHERE	apart.IsActive = 1 AND expense.SubcategoryId = {subcategoryId}";
            }
            entities = await _dbConnection.QueryAsync<ApartEntity>(query);

            return entities.ToList();
        }

        public Task<ApartEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApartEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
