using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenses.Core.Dtos;
using Expenses.BusinessLayer.Interfaces;

namespace Expenses.Mvc.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IUnitOfWorkBl _context;

        public ExpensesController(IUnitOfWorkBl context)
        {
            _context = context;
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseDto = await _context.Expense.GetAsync((int)id);                
            if (expenseDto == null)
            {
                return NotFound();
            }

            return View(expenseDto);
        }

        // GET: Expenses/Create
        public IActionResult Create()
        {
            return View();
        }

        //// POST: Expenses/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Name,Amount,CategoryName,CategoryId,SubcategoryName,SubcategoryId,PeriodId,DateRegister")] ExpenseDto expenseDto)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(expenseDto);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(expenseDto);
        //}

        //// GET: Expenses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.ExpenseDto == null)
        //    {
        //        return NotFound();
        //    }

        //    var expenseDto = await _context.ExpenseDto.FindAsync(id);
        //    if (expenseDto == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(expenseDto);
        //}

        //// POST: Expenses/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,CategoryName,CategoryId,SubcategoryName,SubcategoryId,PeriodId,DateRegister")] ExpenseDto expenseDto)
        //{
        //    if (id != expenseDto.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(expenseDto);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ExpenseDtoExists(expenseDto.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(expenseDto);
        //}

        //// GET: Expenses/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.ExpenseDto == null)
        //    {
        //        return NotFound();
        //    }

        //    var expenseDto = await _context.ExpenseDto
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (expenseDto == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(expenseDto);
        //}

        //// POST: Expenses/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.ExpenseDto == null)
        //    {
        //        return Problem("Entity set 'IUnitofWorkBl.ExpenseDto'  is null.");
        //    }
        //    var expenseDto = await _context.ExpenseDto.FindAsync(id);
        //    if (expenseDto != null)
        //    {
        //        _context.ExpenseDto.Remove(expenseDto);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ExpenseDtoExists(int id)
        //{
        //  return _context.ExpenseDto.Any(e => e.Id == id);
        //}
    }
}
