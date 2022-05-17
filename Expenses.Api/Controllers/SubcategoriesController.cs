using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Expenses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcategoriesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public SubcategoriesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: api/<SubcategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IReadOnlyList<SubcategoryDtoOut> list;

            list = await _unitOfWorkBl.Subcategory.GetAsync();

            return Ok(list);
        }

        // GET api/<SubcategoriesController>/5
        // [HttpGet("{id}")]
        // public string Get(int id)
        // {
        //     return "value";
        // }

        // POST api/<SubcategoriesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SubcategoryDtoIn item)
        {
            int id;

            id = await _unitOfWorkBl.Subcategory.AddAsync(item);

            return Created($"Api/Subcategories/{id}",new {Id = id});
        }

        // PUT api/<SubcategoriesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SubcategoryDtoIn item)
        {            
            await _unitOfWorkBl.Subcategory.UpdateAsync(item, id);

            return Accepted();
        }

        // DELETE api/<SubcategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
