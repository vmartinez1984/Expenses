using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    internal class PayRepository : BaseRepository, IPayRepository
    {
        public PayRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(PayEntity entity)
        {
            string query;

            query = $@"INSERT INTO buy 
                   (Amount,   DateRegistration, BuyId, IsActive) 
            VALUES (@Amount, @DateRegistration,@BuyId, @IsActive); {LastId}";
            entity.Id = await _dbConnection.QueryFirstOrDefaultAsync<int>(query, entity);

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<PayEntity> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(PayEntity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<PayEntity>> GetAsync(int? buyId)
        {
            IEnumerable<PayEntity> entities;
            string query;

            if (buyId == null)
                query = $"SELECT * FROM Pay WHERE IsActive = 1";
            else
                query = $"SELECT * FROM Pay WHERE IsActive = 1 AND BuyId = {buyId}";
            entities = await _dbConnection.QueryAsync<PayEntity>(query);

            return entities.ToList();
        }
    }
}
