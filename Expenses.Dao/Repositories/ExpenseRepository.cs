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
    public class ExpenseRepository : BaseRepository, IExpenseRepository
    {
        public ExpenseRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(ExpenseEntity entity)
        {
            try
            {
                string query;

                query = $@"INSERT INTO Expense 
                      (Guid, Name, Amount, BudgetAmount, SubcategoryId, DepositPlanId, PeriodId, DateRegister, IsActive) 
                VALUES(@Guid,@Name,@Amount,@BudgetAmount,@SubcategoryId,@DepositPlanId,@PeriodId, @DateRegister,@IsActive)
                {LastId}";
                entity.Id = await db.QueryFirstOrDefaultAsync<int>(query, entity);

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

            await db.QueryAsync(query);
        }

        public async Task<ExpenseEntity> GetAsync(int id)
        {
            ExpenseEntity entity;
            string query;

            query = $@"SELECT Expense.*, Category.Name CategoryName 
                FROM Expense 
                INNER JOIN Subcategory on Expense.SubcategoryId = Subcategory.Id 
                INNER JOIN Category on Subcategory.CategoryId = Category.Id                 
                WHERE Expense.IsActive = 1 AND Expense.Id = {id} LIMIT 1";
            //entities = (await db.QueryAsync<ExpenseEntity>(query)).ToList();
            entity = await db.QueryFirstOrDefaultAsync<ExpenseEntity>(query);

            return entity;
        }

        public Task<List<ExpenseEntity>> GetAllOfDepositPlanAsync(int depositPlanId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ExpenseEntity>> GetAllAsync(int periodId)
        {
            IEnumerable<ExpenseEntity> entities;
            string query;

            query = $@"SELECT Expense.*, Category.Name CategoryName 
                FROM Expense 
                INNER JOIN Subcategory on Expense.SubcategoryId = Subcategory.Id 
                INNER JOIN Category on Subcategory.CategoryId = Category.Id                 
                WHERE Expense.IsActive = 1 AND PeriodId = {periodId} ORDER BY Expense.Id";
            //entities = (await db.QueryAsync<ExpenseEntity>(query)).ToList();
            entities = await db.QueryAsync<ExpenseEntity>(query);

            return entities.ToList();
        }

        public async Task UpdateAsync(ExpenseEntity entity)
        {
            string query;

            query = "UPDATE Expense SET Name = @Name, Amount = @Amount, PeriodId = @PeriodId, CategoryId = @CategoryId WHERE Id  = @Id";

            await db.QueryAsync(query, entity);
        }
    }
}
