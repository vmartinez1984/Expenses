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
    public class EntriesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public EntriesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: api/<EntriesController>
        [HttpGet]
        public async Task<IActionResult> Get(int periodId)
        {
            try
            {
                List<EntryDtoOut> list;

                list = await _unitOfWorkBl.Entry.GetAsync(periodId);

                return Ok(list);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //// GET api/<EntriesController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<EntriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EntryDtoIn item)
        {
            try
            {
                int id;

                id = await _unitOfWorkBl.Entry.AddAsync(item);

                return Created($"Entries/{id}", new { Id = id });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<EntriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EntryDtoIn item)
        {
            try
            {
                await _unitOfWorkBl.Entry.UpdateAsync(item, id);

                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<EntriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _unitOfWorkBl.Entry.DeleteAsync(id);

            return NoContent();
        }
    }
}