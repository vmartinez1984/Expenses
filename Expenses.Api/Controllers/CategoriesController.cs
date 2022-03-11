﻿using Expenses.BusinessLayer.Dtos.Inputs;
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                CategoryDtoOut item;

                item = _unitOfWorkBl.Category.Get(id);
                if (item == null)
                    return NotFound();

                return Ok(item);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public IActionResult Post(CategoryDtoIn item)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    int id;

                    id = _unitOfWorkBl.Category.Add(item);

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

        [HttpPut]
        public IActionResult Put(CategoryUpdDtoIn item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWorkBl.Category.Update(item);

                    return Accepted($"/Categories/{item.Id}", new { IsSuccess = true });
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
        public IActionResult Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _unitOfWorkBl.Category.Delete(id);

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
