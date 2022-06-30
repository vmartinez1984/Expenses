using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public CategoriesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IReadOnlyList<CategoryDtoOut> list;

            list = await _unitOfWorkBl.Category.GetAsync();

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CategoryDtoIn item)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    int id;

                    id = await _unitOfWorkBl.Category.AddAsync(item);

                    return Created($"/Categories/{id}", new { Id = id });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, CategoryDtoIn item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWorkBl.Category.UpdateAsync(item, id);

                    return Accepted();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _unitOfWorkBl.Category.DeleteAsync(id);

                    return NoContent();
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }//end class
}
