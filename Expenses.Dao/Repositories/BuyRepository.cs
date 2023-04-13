using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    internal class BuyRepository : BaseRepository, IBuyRepository
    {
        public BuyRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(BuyEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT INTO buy 
                   (Name,   MonthsWhithoutInterest, Amount,   DateRegistration, IsActive, TdcId) 
                    VALUES (@Name, @MonthsWhithoutInterest, @Amount, @DateRegistration, 1, @TdcId); {LastId}";
                entity.TdcId = 1;
                //_dbConnection.Open();
                entity.Id = await _dbConnection.QueryFirstOrDefaultAsync<int>(query, entity);
                //_dbConnection.Close();

                return entity.Id;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {            
            string query;

            query = $"UPDATE buy SET IsActive = 0 WHERE Id = {id}";
            await _dbConnection.QueryAsync(query);            
        }

        public async Task<BuyEntity> GetAsync(int id)
        {
            BuyEntity entity;
            string query;

            query = $"SELECT * FROM Buy WHERE Id = {id}";
            entity = await _dbConnection.QueryFirstOrDefaultAsync<BuyEntity>(query);

            return entity;
        }

        public Task UpdateAsync(BuyEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<BuyEntity>> GetAsync()
        {
            IEnumerable<BuyEntity> entities;
            string query;

            query = "SELECT * FROM Buy WHERE IsActive = 1";
            entities = await _dbConnection.QueryAsync<BuyEntity>(query);

            return entities.ToList();
        }
    }
}
