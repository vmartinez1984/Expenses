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
    public class ApartRepository : BaseRepository, IApartRepository
    {
        public ApartRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<int> AddAsync(ApartEntity entity)
        {
            string query;

            query = $@"INSERT INTO Apart (ExpenseId, Amount, DateRegistration, IsActive, IsApartN) VALUES(@ExpenseId, @Amount, NOW(), 1, @IsApartN); {LastId}";
            entity.Id = await _dbConnection.ExecuteAsync(query, entity);

            return entity.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ApartEntity>> GetAsync()
        {
            IEnumerable<ApartEntity> entities;
            string query;


            query = $@"SELECT apart.*, expense.Name, expense.SubcategoryId FROM apart 
                INNER JOIN expense ON apart.ExpenseId = expense.Id                
                WHERE	apart.IsActive = 1";
            entities = await _dbConnection.QueryAsync<ApartEntity>(query);

            return entities.ToList();
        }
        public async Task<List<ApartEntity>> GetAsync(PagerEntity pagerEntity)
        {
            IEnumerable<ApartEntity> entities;
            string queryForCount;
            string queryForCountFiltered;
            string query1;
            string query2;

            queryForCount = $@"SELECT COUNT(apart.Id) FROM apart 
            INNER JOIN expense ON apart.ExpenseId = expense.Id                
            INNER JOIN subcategory ON subcategory.Id = expense.SubcategoryId 
            WHERE	apart.IsActive = 1 AND expense.SubcategoryId NOT IN (11, 5, 9) ";
            if (string.IsNullOrEmpty(pagerEntity.Search))
            {
                queryForCountFiltered = queryForCount;
            }
            else
            {
                queryForCountFiltered = $"{queryForCount} AND LOWER(CONCAT(apart.DateRegistration, expense.Name, subcategory.Name)) LIKE '%{pagerEntity.Search.ToLower()}%'";
            }
            if (!string.IsNullOrEmpty(pagerEntity.SubcategoryId))
            {
                queryForCountFiltered += $" AND expense.SubcategoryId = {pagerEntity.SubcategoryId}";
            }

            query1 = $@"SELECT apart.*, expense.Name, expense.SubcategoryId, subcategory.Name SubcategoryName
            FROM apart 
            INNER JOIN expense ON apart.ExpenseId = expense.Id              
		    INNER JOIN subcategory ON subcategory.Id = expense.SubcategoryId 
            WHERE	apart.IsActive = 1 AND expense.SubcategoryId NOT IN (11, 5, 9) ";

            if (!string.IsNullOrEmpty(pagerEntity.Search))
            {
                query1 += $" AND LOWER(CONCAT(apart.DateRegistration, expense.Name, subcategory.Name)) LIKE '%{pagerEntity.Search.ToLower()}%'";
            }
            if (!string.IsNullOrEmpty(pagerEntity.SubcategoryId))
            {
                query1 += $" AND expense.SubcategoryId = {pagerEntity.SubcategoryId}";
            }

            query2 = $@"{query1}                 
                ORDER BY {pagerEntity.SortColumn} {pagerEntity.SortColumnDir}
                LIMIT {pagerEntity.RecordsPerPage}
                OFFSET {(pagerEntity.PageCurrent - 1) * pagerEntity.RecordsPerPage}
            ";

            try
            {

                entities = await _dbConnection.QueryAsync<ApartEntity>(query2);
                pagerEntity.TotalRecords = (await _dbConnection.QueryAsync<int>(queryForCount)).FirstOrDefault();
                pagerEntity.TotalRecordsFiltered = (await _dbConnection.QueryAsync<int>(queryForCountFiltered)).FirstOrDefault();


                return entities.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            //if (subcategoryId is null)
            //{
            //    query = $@"SELECT apart.*, expense.Name, expense.SubcategoryId FROM apart 
            //    INNER JOIN expense ON apart.ExpenseId = expense.Id                
            //    WHERE	apart.IsActive = 1";
            //}
            //else
            //{
            //    query = $@"SELECT apart.*, expense.Name, expense.SubcategoryId FROM apart 
            //    INNER JOIN expense ON apart.ExpenseId = expense.Id                
            //    WHERE	apart.IsActive = 1 AND expense.SubcategoryId = {subcategoryId}";
            //}
            //entities = await _dbConnection.QueryAsync<ApartEntity>(query);

            //return entities.ToList();
        }

        public Task<ApartEntity> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApartEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
