using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenses.Core.Dtos;
using Expenses.BusinessLayer.Interfaces;

namespace Expenses.Mvc.Controllers
{
    public class CategoriesController : BaseMvcController
    {
        public CategoriesController(IUnitOfWorkBl context) : base(context)
        {
        }


        // GET: CategoryDtoes
        public async Task<IActionResult> Index()
        {
            List<CategoryDto> list;

            list = await _context.Category.GetAsync();

            return View(list);
        }

        // GET: CategoryDtoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _context.Category.GetAsync((int)id);
            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }

        // GET: CategoryDtoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryDtoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _context.Category.AddAsync(categoryDto);

                return RedirectToAction(nameof(Index));
            }
            return View(categoryDto);
        }

        // GET: CategoryDtoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _context.Category.GetAsync((int)id);
            if (categoryDto == null)
            {
                return NotFound();
            }
            return View(categoryDto);
        }

        // POST: CategoryDtoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CategoryDtoIn categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Category.UpdateAsync(categoryDto, id);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryDtoExists(id))
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
            return View(categoryDto);
        }

        // GET: CategoryDtoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryDto = await _context.Category.GetAsync((int)id);
            if (categoryDto == null)
            {
                return NotFound();
            }

            return View(categoryDto);
        }

        // POST: CategoryDtoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {           
            var categoryDto = await _context.Category.GetAsync((int)id);
            if (categoryDto != null)
            {
                await _context.Category.DeleteAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryDtoExists(int id)
        {
            return _context.Category.GetAsync(id) != null;
        }
    }
}
