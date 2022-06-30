using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Dtos.Inputs;

namespace Expenses.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public CategoriesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            IReadOnlyList<CategoryDtoOut> list;

            list = await _unitOfWorkBl.Category.GetAsync();

            return View(list);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] CategoryDtoIn category)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Category.AddAsync(category);

                return RedirectToAction(nameof(Index));
            }            
                
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _unitOfWorkBl.Category.GetAsync((int)id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name")] CategoryDtoIn category)
        {
            var item = await _unitOfWorkBl.Category.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Category.UpdateAsync(category, id);

                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _unitOfWorkBl.Category.GetAsync((int)id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWorkBl.Category.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
