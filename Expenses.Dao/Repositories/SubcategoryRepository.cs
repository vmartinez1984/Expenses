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
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly IConfiguration _configuration;
        const string DefaultConnection = "DefaultConnection";

        public SubcategoryRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(SubcategoryEntity entity)
        {
            try
            {
                 string query;

                query = @"INSERT INTO Subcategory VALUES(@Name, @CategoryId, @Amount, @IsBudget, 1) 
                SELECT SCOPE_IDENTITY();
                ";
                await Task.Run(()=>{
                    using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                    {
                        entity.Id = db.Query<int>(query,entity).FirstOrDefault();
                    }
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
            try
            {                
                string query;

                query = $@"UPDATE Subcategory SET IsActive = 0 WHERE Id = {id}";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    await db.QueryAsync(query);                    
                }              
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<SubcategoryEntity> GetAsync(int id)
        {
           try
            {
                SubcategoryEntity entity;
                string query;

                query = $@"SELECT Subcategory.*
                        FROM Subcategory                         
                        WHERE Subcategory.Id = {id}";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    var response = await db.QueryAsync<SubcategoryEntity>(query);
                    entity = response.FirstOrDefault();
                }
                SetCategory(entity);

                return entity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IReadOnlyList<SubcategoryEntity>> GetAsync()
        {
            try
            {
                List<SubcategoryEntity> entities;
                string query;

                query = @"SELECT Subcategory.*
                        FROM Subcategory                         
                        WHERE Subcategory.IsActive = 1";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    var response = await db.QueryAsync<SubcategoryEntity>(query);
                    entities = response.ToList();
                }
                SetCategory(entities);

                return entities;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void SetCategory(List<SubcategoryEntity> entities)
        {
            List<CategoryEntity> categories;
            CategoryRepository categoryRepository;

            categoryRepository = new CategoryRepository(_configuration);
            categories =  categoryRepository.Get();
            entities.ForEach(item => {
                item.Category =categories.Where(x=> x.Id == item.CategoryId).FirstOrDefault();
            });
        }

        private void SetCategory(SubcategoryEntity entity)
        {            
            CategoryRepository categoryRepository;

            categoryRepository = new CategoryRepository(_configuration);
            
            entity.Category = categoryRepository.Get(entity.CategoryId);
        }
        
        public async Task UpdateAsync(SubcategoryEntity entity)
        {
            try
            {                
                string query;

                query = $@"UPDATE Subcategory SET Nombre = @Nombre, CategoryId = @CategoryId, IsBudget = @IsBudget  WHERE Id = @Id";
                using (var db = new SqlConnection(_configuration.GetConnectionString(DefaultConnection)))
                {
                    await db.QueryAsync(query);                    
                }              
            }
            catch (Exception)
            {

                throw;
            }
        }       

    }//end class
}