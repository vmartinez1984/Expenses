using Dapper;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IConfiguration _configuration;
        const string DefaultConnection = "DefaultConnection";

        public CategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<CategoryEntity> Get()
        {
            try
            {
                List<CategoryEntity> entities;
                string query;

                query = "SELECT * FROM Category WHERE IsActive = 1";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    entities = db.Query<CategoryEntity>(query).ToList();
                }

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryEntity Get(int id)
        {
            try
            {
                CategoryEntity entity;
                string query;

                query = $"SELECT * FROM Category WHERE IsActive = 1 AND  Id = {id}";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    entity = db.Query<CategoryEntity>(query).FirstOrDefault();
                }

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(CategoryEntity entity)
        {
            try
            {
                string query;

                query = "INSERT INTO Category  VALUES(@Name, 1)  SELECT SCOPE_IDENTITY()";
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

        public void Update(CategoryEntity entity)
        {
            try
            {
                string query;

                query = "UPDATE Category SET Name = @Name WHERE Id  = @Id";
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

                query = $"UPDATE Category SET IsActive = 0 WHERE Id  = {id}";
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

        public Task<CategoryEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<CategoryEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }//end class
}