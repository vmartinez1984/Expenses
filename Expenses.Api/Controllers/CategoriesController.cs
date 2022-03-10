using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IEnumerable<CategoryDtoOut> Get()
        {
            List<CategoryDtoOut> list;

            list = _unitOfWorkBl.Category.Get();

            return list;
        }
    }
}
