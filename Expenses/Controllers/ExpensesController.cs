using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.Core.Dtos;

namespace Expenses.Controllers
{
    public class ExpensesController : Controller
    {       
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public ExpensesController(IUnitOfWorkBl unitOfWorkBl)
        {            
            _unitOfWorkBl = unitOfWorkBl;
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId, SubcategoryId,PeriodId,Amount,DateRegister,IsActive")] ExpenseDtoIn expense)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Expense.AddAsync(expense);
                return RedirectToAction("Details", "Periods", new { Id = expense.PeriodId });
            }
            ViewData["PeriodId"] = new SelectList(await _unitOfWorkBl.Period.GetAsync(), "Id", "Name", expense.PeriodId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _unitOfWorkBl.Expense.GetByIdAsync((int)id);
            if (expense == null)
            {
                return NotFound();
            }

            ViewData["ListCategories"] = new SelectList(await _unitOfWorkBl.Category.GetAsync(), "Id", "Name");
            ViewData["ListSubcategories"] = new SelectList(await _unitOfWorkBl.Subcategory.GetAsync(), "Id", "Name");
            ViewData["PeriodId"] = new SelectList(await _unitOfWorkBl.Period.GetAsync(), "Id", "Name");

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId, SubcategoryId,PeriodId,Amount")] ExpenseDtoIn expense)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Expense.UpdateAsync(expense, id);

                return RedirectToAction("Details", "Periods", new { Id = expense.PeriodId });
            }
            ViewData["PeriodId"] = new SelectList(await _unitOfWorkBl.Period.GetAsync(), "Id", "Name", expense.PeriodId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _unitOfWorkBl.Expense.GetByIdAsync((int)id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            ExpenseDto expense;

            expense = await _unitOfWorkBl.Expense.GetByIdAsync(id);
            await _unitOfWorkBl.Expense.DeleteAsync(id);

            return RedirectToAction("Details", "Periods", new { Id = expense.PeriodId });
        }
    }
}
