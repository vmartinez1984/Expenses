using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expenses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public ExpensesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }
        // GET: api/<ExpensesController>
        [HttpGet]
        public async Task<IActionResult> Get(int periodId)
        {
            try
            {
                List<ExpenseDtoOut> list;

                list = await _unitOfWorkBl.Expense.GetAsync(periodId);

                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// GET api/<ExpensesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ExpensesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ExpenseDtoIn item)
        {
            try
            {
                int id;

                id = await _unitOfWorkBl.Expense.AddAsync(item);

                return Created($"/Expenses/{id}", new { Id = id });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ExpensesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ExpenseDtoIn item)
        {
            await _unitOfWorkBl.Expense.UpdateAsync(item, id);

            return NoContent();
        }

        // DELETE api/<ExpensesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWorkBl.Expense.DeleteAsync(id);

            return NoContent();
        }
    }
}
