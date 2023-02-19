using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expenses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodsController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public PeriodsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: api/<PeriodsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                IReadOnlyList<PeriodDto> list;

                list = await _unitOfWorkBl.Period.GetAsync();

                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<PeriodsController>/5
        [HttpGet("/api/Periods/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                PeriodFullDto period;                

                period = await _unitOfWorkBl.Period.GetFullAsync(id);

                return Ok(period);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<PeriodsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PeriodDtoIn item)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    int id;

                    id = await _unitOfWorkBl.Period.AddAsync(item);

                    return Created($"/Periods/{id}", new { Id = id });
                }

                return BadRequest();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // PUT api/<PeriodsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PeriodDtoIn item)
        {
            try
            {
                await _unitOfWorkBl.Period.UpdateAsync(item, id);

                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE api/<PeriodsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
               await _unitOfWorkBl.Period.DeleteAsync(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
