using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;

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
              return View(await _context.Subcategory.GetAsync());
        }

        // GET: Subcategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CategoryName,Name,CategoryId,Amount")] SubcategoryDto subcategoryDto)
        {
            if (ModelState.IsValid)
            {
                await _context.Subcategory.AddAsync(subcategoryDto);
                
                return RedirectToAction(nameof(Index));
            }
            return View(subcategoryDto);
        }

        // GET: Subcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoryDto = await _context.Subcategory.GetAsync((int)id);
            if (subcategoryDto == null)
            {
                return NotFound();
            }
            return View(subcategoryDto);
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,Name,CategoryId,Amount")] SubcategoryDto subcategoryDto)
        {
            if (id != subcategoryDto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Subcategory.UpdateAsync(subcategoryDto,id);                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubcategoryDtoExists(subcategoryDto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(subcategoryDto);
        }

        // GET: Subcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategoryDto = await _context.Subcategory.GetAsync((int)id);
            if (subcategoryDto == null)
            {
                return NotFound();
            }

            return View(subcategoryDto);
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

        private bool SubcategoryDtoExists(int id)
        {
          return _context.Subcategory.GetAsync(id) != null;
        }
    }
}
