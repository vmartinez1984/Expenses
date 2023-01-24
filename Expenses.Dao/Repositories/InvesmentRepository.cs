using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Expenses.Repository.Repositories
{
    public class InvesmentRepository : BaseRepository, IInvesmentRepository
    {
        public InvesmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(InvestmentEntity entity)
        {
            string query;

            query = $@"INSERT INTO investment 
                   (Name, DateStart, DateStop, Interest, Amount, InstructionId, Term, AmountFinal, IsActive) 
            VALUES (@Name, @DateStart, @DateStop, @Interest, @Amount, @InstructionId, @Term, @AmountFinal, 1); {LastId}";
            entity.Id = await _dbConnection.QueryFirstOrDefaultAsync<int>(query,entity);

            return entity.Id;
        }

        public async Task DeleteAsync(int id)
        {
            string query;

            query = $@"UPDATE investment 
            SET IsActive = 0
            WHERE Id = {id}
            ";

            await _dbConnection.QueryAsync(query);
        }

        public async Task<List<InvestmentEntity>> GetAllAsync()
        {
            string query;
            IEnumerable<InvestmentEntity> entities;

            query = "SELECT * FROM investment WHERE IsActive = 1 ORDER BY Id DESC";
            entities = await _dbConnection.QueryAsync<InvestmentEntity>(query);

            return entities.ToList();
        }

        public async Task<InvestmentEntity> GetAsync(int id)
        {
            string query;
            InvestmentEntity entity;

            query = $"SELECT * FROM investment WHERE Id = {id}";
            entity = await _dbConnection.QueryFirstOrDefaultAsync<InvestmentEntity>(query);

            return entity;
        }

        public async Task UpdateAsync(InvestmentEntity entity)
        {
            string query;

            query = $@"UPDATE investment 
            SET Name = @Name, DateStart=@DateStart, DateStop=@DateStop, Amount=@Amount, InstructionId=@InstructionId, Term=@Term, AmountFinal=@AmountFinal, Interest=@Interest
            WHERE Id = @Id";

            await _dbConnection.QueryAsync(query, entity);
        }
    }
}