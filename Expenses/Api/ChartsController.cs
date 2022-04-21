using Expenses.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expenses.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ChartsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("CategorySummary/Period/{periodId}")]
        public async Task<IActionResult> GetCategorySummary(int periodId)
        {
            List<CategorySummary> list;
            List<Category> categories;

            list = new List<CategorySummary>();
            categories = await _context.Category.Where(x => x.IsActive).ToListAsync();
            categories.ForEach(category =>
            {
                list.Add(new CategorySummary
                {
                    Name = category.Name,
                    Total = GetTotal(category.Id, periodId)
                });
            });

            return Ok(list);
        }

        private int GetTotal(int categoryId, int periodId)
        {
            int total;
            Period period;

            period = _context.Period.Include(x => x.ListExpenses)
                .ThenInclude(x=> x.Subcategory)
                .Where(x => x.Id == periodId).FirstOrDefault();
            total = period.ListExpenses.Where(x=> x.Subcategory.CategoryId == categoryId).Sum(x=> x.Amount);

            return total;
        }
    }
}
