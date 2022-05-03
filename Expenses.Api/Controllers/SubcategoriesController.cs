using Expenses.BusinessLayer.Dtos.Outputs;
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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SubcategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SubcategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SubcategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
