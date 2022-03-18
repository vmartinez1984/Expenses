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
    public class PeriodsController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public PeriodsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: api/<PeriodsController>
        [HttpGet]
        public IActionResult Get(bool? isActive = null)
        {
            try
            {
                List<PeriodDtoOut> list;

                list = _unitOfWorkBl.Period.Get(isActive);

                return Ok(list);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // GET api/<PeriodsController>/5
        [HttpGet("/api/Periods/Active")]
        public async Task<IActionResult> GetACtive()
        {
            try
            {

                PeriodDtoOut item;

                item = await _unitOfWorkBl.Period.GetActive();
                
                return Ok(item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<PeriodsController>
        [HttpPost]
        public IActionResult Post([FromBody] PeriodDtoIn item)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    int id;

                    id = _unitOfWorkBl.Period.Add(item);

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
        public IActionResult Put(int id, [FromBody] PeriodDtoIn item)
        {
            try
            {
                _unitOfWorkBl.Period.Update(item, id);

                return NoContent();
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        // DELETE api/<PeriodsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWorkBl.Period.Delete(id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
