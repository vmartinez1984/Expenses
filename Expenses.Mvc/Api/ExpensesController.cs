using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public ExpensesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseDto = await _unitOfWorkBl.Expense.GetAsync((int)id);
            if (expenseDto == null)
            {
                return NotFound();
            }

            return Ok(expenseDto);
        }
    }
}
