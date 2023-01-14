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
    public class EntryRepository : IEntryRepositoy
    {
        private readonly IConfiguration _configuration;

        public EntryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(EntryEntity entity)
        {
            try
            {
                string query;

                query = @"INSERT INTO Entry (Name, Amount, PeriodId, DateRegister, IsActive) 
                          VALUES(@Name,@Amount,@PeriodId,@DateRegister,@IsActive)
                        SELECT SCOPE_IDENTITY()
                ";
                entity.Id = await Task.Run(() =>
                {
                    using (var db = new SqlConnection(_configuration.GetConnectionString(StringConnection.DefaultConnection)))
                    {
                        entity.Id = db.Query<int>(query, entity).FirstOrDefault();
                    }

                    return entity.Id;
                });

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task DeleteAsync(int id)
        {
            string query;

            query = $"UPDATE Entry SET IsActive = 0 WHERE Id  = {id}";
            await Task.Run(() =>
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString(StringConnection.DefaultConnection)))
                {
                    db.Query(query);
                }
            });
        }

        public  Task<EntryEntity> GetAsync(int id){
            throw new NotImplementedException();
        }


        public async Task<List<EntryEntity>> GetAllAsync(int periodId)
        {
            try
            {
                List<EntryEntity> entities;
                string query;

                query = $"SELECT * FROM Entry WHERE IsActive = 1 AND PeriodId = {periodId}";
                entities = await Task.Run(() =>
                {
                    using (var db = new SqlConnection(_configuration.GetConnectionString(StringConnection.DefaultConnection)))
                    {
                        entities = db.Query<EntryEntity>(query).ToList();
                    }

                    return entities;
                });

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateAsync(EntryEntity entity)
        {
            try
            {
                string query;

                query = "UPDATE Entry SET Name = @Name, Amount = @Amount, PeriodId = @PeriodId WHERE Id  = @Id";
                await Task.Run(() =>
                {
                    using (var db = new SqlConnection(_configuration.GetConnectionString(StringConnection.DefaultConnection)))
                    {
                        db.Query(query, entity);
                    }
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
