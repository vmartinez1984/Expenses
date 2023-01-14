using Dapper;
using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class PeriodRepository : BaseRepository, IPeriodRepository
    {
        public PeriodRepository(IConfiguration configuration) : base(configuration) { }

        public async Task<PeriodEntity> GetActiveAsync()
        {
            try
            {
                PeriodEntity entity;
                string query;

                query = $"SELECT TOP(1) * FROM Period WHERE IsActive = 1 ORDER BY Id DESC";

                entity = await Task.Run(() =>
                {
                    using (var db = new SqlConnection(_stringConnection))
                    {
                        entity = db.Query<PeriodEntity>(query).FirstOrDefault();
                    }

                    return entity;
                });

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PeriodEntity> GetAsync(int periodId)
        {
            try
            {
                PeriodEntity entity;
                string query;

                //query = $"SELECT TOP(1) * FROM Period WHERE Id = {periodId}";
                query = $"SELECT * FROM Period WHERE Id = {periodId} Limit 1";

                entity = await db.QueryFirstOrDefaultAsync<PeriodEntity>(query);

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetBalance(int id)
        {
            try
            {
                int balance;
                string query;

                query = $@"SELECT 
                IIF(
                 (SELECT SUM(Amount) FROM Entry Where PeriodId = {id} AND IsActive = 1) IS NULL,
                 0,
                 (SELECT SUM(Amount) FROM Entry Where PeriodId = {id} AND IsActive = 1)
                 ) 
                 - 
                 IIF(
                 (SELECT SUM(Amount) FROM Expense Where PeriodId = {id} AND IsActive = 1) IS NULL,
                 0,
                 (SELECT SUM(Amount) FROM Expense Where PeriodId = {id} AND IsActive = 1)
                 )";
                using (var db = new SqlConnection(_stringConnection))
                {
                    balance = db.Query<int>(query).FirstOrDefault();
                }

                return balance;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<PeriodEntity>> GetAsync()
        {
            List<PeriodEntity> entities;
            string query;

            query = $"SELECT * FROM Period WHERE IsActive = 1 ORDER BY Id DESC";
            entities = (await db.QueryAsync<PeriodEntity>(query)).ToList();

            return entities;
        }

        public async Task<int> AddAsync(PeriodEntity entity)
        {
            string query;

            query = $"INSERT INTO Period (Name,DateStart, DateStop,IsActive) VALUES(@Name, @DateStart, @DateStop, 1); {LastId}";
            entity.Id = await db.QueryFirstOrDefaultAsync<int>(query, entity);

            return entity.Id;
        }

        public async Task UpdateAsync(PeriodEntity entity)
        {
            string query;

            query = "UPDATE Period SET Name = @Name, DateStart = @DateStart, DateStop = @DateStop WHERE Id  = @Id";

            await db.QueryAsync(query, entity);
        }

        public async Task DeleteAsync(int id)
        {
            string query;

            query = $"UPDATE Period SET IsActive = 0 WHERE Id  = {id}";

            await db.QueryAsync(query);
        }
    }
}
