using Dapper;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class PeriodRepository : IPeriodRepository
    {
        private readonly IConfiguration _configuration;
        const string DefaultConnection = "DefaultConnection";

        public PeriodRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<PeriodEntity> Get()
        {
            try
            {
                List<PeriodEntity> entities;
                string query;

                query = $"SELECT * FROM Period";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    entities = db.Query<PeriodEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public PeriodEntity Get(int id)
        {
            try
            {
                PeriodEntity entity;
                string query;

                query = $"SELECT * FROM Period WHERE IsActive = 1 AND  Id = {id}";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    entity = db.Query<PeriodEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(PeriodEntity entity)
        {
            try
            {
                string query;

                query = "INSERT INTO Period (Name,DateStart, DateStop,IsActive) VALUES(@Name, @DateStart, @DateStop, 1)  SELECT SCOPE_IDENTITY()";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    entity.Id = db.Query<int>(query, entity).FirstOrDefault();
                }

                return entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(PeriodEntity entity)
        {
            try
            {
                string query;

                query = "UPDATE Period SET Name = @Name, DateStart = @DateStart, DateStop = @DateStop WHERE Id  = @Id";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    db.Query(query, entity);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                string query;

                query = $"UPDATE Period SET IsActive = 0 WHERE Id  = {id}";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    db.Query(query);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PeriodEntity> GetActiveAsync()
        {
            try
            {
                PeriodEntity entity;
                string query;

                query = $"SELECT TOP(1) * FROM Period WHERE IsActive = 1 ORDER BY Id DESC";

                entity = await Task.Run(() =>
                {
                    using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
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
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
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
    }
}
