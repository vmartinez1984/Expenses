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
        public IActionResult Get([FromQuery] LevelDto levelDto)
        {
            try
            {
                IActionResult actionResult;

                actionResult = null;
                switch(levelDto.Level){
                    case EnumLevel.Simple:
                        List<PeriodDtoOut> list;

                        list = _unitOfWorkBl.Period.Get();

                        actionResult = Ok(list);
                    break;
                  
                    case EnumLevel.Full:
                        List<PeriodFullDtoOut> listFull;

                        listFull = _unitOfWorkBl.Period.GetFull();

                        actionResult = Ok(listFull);
                    break;
                }

                return actionResult;
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

                item = await _unitOfWorkBl.Period.GetActiveAsync();  
                
                return Ok(item);
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

                PeriodDtoOut item;

                item = await _unitOfWorkBl.Period.GetFullAsync(id);  

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
