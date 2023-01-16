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
    public class InvesmentRepository : BaseRepository, IInvesmentRepository
    {
        public InvesmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> AddAsync(InvestmentEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<InvestmentEntity>> GetAllAsync()
        {
            string query;
            IEnumerable<InvestmentEntity> entities;

            query = "SELECT * FROM investment WHERE IsActive = 1";
            entities = await _dbConnection.QueryAsync<InvestmentEntity>(query);

            return entities.ToList();
        }

        public Task<InvestmentEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(InvestmentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
