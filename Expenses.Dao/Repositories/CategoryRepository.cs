using Dapper;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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
    }
}
