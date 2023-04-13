using Microsoft.AspNetCore.Mvc;
using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expenses.Mvc.Controllers
{
    public class SubcategoriesController : Controller
    {
        private readonly IUnitOfWorkBl _context;

        public SubcategoriesController(IUnitOfWorkBl context)
        {
            _context = context;
        }

        // GET: Subcategories
        public async Task<IActionResult> Index()
        {
            List<SubcategoryDto> subcategories;

            ViewBag.SelectCategories = new SelectList(await _context.Category.GetAsync(), "Id", "Name");
            subcategories = await _context.Subcategory.GetAsync();

            return View(subcategories);
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([Bind("Id,CategoryName,Name,CategoryId,Amount")] SubcategoryDto subcategory)
        {
            if (ModelState.IsValid)
            {
                if (subcategory.Id == 0)
                {
                    await _context.Subcategory.AddAsync(subcategory);                    
                }
                else
                {
                    await _context.Subcategory.UpdateAsync(subcategory, subcategory.Id);
                }                
            }

            return RedirectToAction(nameof(Index));
        }       
        

        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.Subcategory.GetAsync(id);

            return View(entity);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subcategoryDto = await _context.Subcategory.GetAsync(id);
            if (subcategoryDto != null)
            {
                await _context.Subcategory.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
