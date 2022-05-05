using Dapper;
using Expenses.BusinessLayer.Entities;
using Expenses.BusinessLayer.Interfaces.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly IConfiguration _configuration;

        public ExpenseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<int> AddAsync(ExpenseEntity entity)
        {
            try
            {
                string query;

                query = @"INSERT INTO Expense (Name, Amount, PeriodId, CategoryId, DateRegister, IsActive) 
                          VALUES(@Name,@Amount,@PeriodId, @CategoryId,@DateRegister,@IsActive)
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

            query = $"UPDATE Expense SET IsActive = 0 WHERE Id  = {id}";
            await Task.Run(() =>
            {
                using (var db = new SqlConnection(_configuration.GetConnectionString(StringConnection.DefaultConnection)))
                {
                    db.Query(query);
                }
            });
        }

        public async Task<List<ExpenseEntity>> GetAsync(int periodId)
        {
            try
            {
                List<ExpenseEntity> entities;
                string query;

                query = $@"SELECT Expense.*, Category.Name CategoryName 
                FROM Expense 
                INNER JOIN Subcategory on Expense.SubcategoryId = Subcategory.Id 
                INNER JOIN Category on Subcategory.CategoryId = Category.Id                 
                WHERE Expense.IsActive = 1 AND PeriodId = {periodId}";
                entities = await Task.Run(() =>
                {
                    using (var db = new SqlConnection(_configuration.GetConnectionString(StringConnection.DefaultConnection)))
                    {
                        entities = db.Query<ExpenseEntity>(query).ToList();
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

        public async Task UpdateAsync(ExpenseEntity entity)
        {
            try
            {
                string query;

                query = "UPDATE Expense SET Name = @Name, Amount = @Amount, PeriodId = @PeriodId, CategoryId = @CategoryId WHERE Id  = @Id";
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
