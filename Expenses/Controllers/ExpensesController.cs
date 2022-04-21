using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expenses.Models;

namespace Expenses.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly AppDbContext _context;

        public ExpensesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Expenses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Expense.Include(e => e.Period);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Expenses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .Include(e => e.Period)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: Expenses/Create
        public IActionResult Create(int periodId)
        {
            ViewData["ListCategories"] = new SelectList(_context.Category.Where(x => x.IsActive), "Id", "Name");
            ViewData["ListPeriods"] = new SelectList(_context.Period.Where(x => x.IsActive), "Id", "Name");
            ViewBag.PeriodId = periodId;

            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId, SubcategoryId,PeriodId,Amount,DateRegister,IsActive")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                SetDeposit(expense);
                SetBudget(expense);
                _context.Add(expense);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details), "Periods", new { Id = expense.PeriodId });
            }
            ViewData["PeriodId"] = new SelectList(_context.Period, "Id", "Name", expense.PeriodId);
            return View(expense);
        }

        private void SetBudget(Expense expense)
        {
            Subcategory subcategory;

            subcategory = _context.Subcategory.Where(x => x.Id == expense.SubcategoryId).FirstOrDefault();
            if (subcategory.IsBudget)            
                expense.BudgetAmount = subcategory.Amount;            
            else
                expense.BudgetAmount = null;
        }

        private void SetDeposit(Expense expense)
        {
            DepositPlan depostiPlanId;

            depostiPlanId = _context.DepositPlan.Where(x => x.SubcategoryId == expense.SubcategoryId).FirstOrDefault();
            if (depostiPlanId is null)
                expense.DepositPlanId = null;
            else
                expense.DepositPlanId = depostiPlanId.Id;
        }

        // GET: Expenses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense.Include(x => x.Subcategory).Where(x => x.Id == id).FirstOrDefaultAsync();
            SetBudget(expense);
            if (expense == null)
            {
                return NotFound();
            }
            expense.CategoryId = expense.Subcategory.CategoryId;

            ViewData["ListCategories"] = new SelectList(_context.Category.Where(x => x.IsActive), "Id", "Name");
            ViewData["ListSubcategories"] = new SelectList(_context.Subcategory.Where(x => x.IsActive), "Id", "Name");
            ViewData["PeriodId"] = new SelectList(_context.Period.Where(x => x.IsActive), "Id", "Name");

            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId, SubcategoryId,PeriodId,Amount,DateRegister,IsActive")] Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    SetDeposit(expense);
                    SetBudget(expense);
                    _context.Update(expense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details), "Periods", new { Id = expense.PeriodId });
            }
            ViewData["PeriodId"] = new SelectList(_context.Period, "Id", "Name", expense.PeriodId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await _context.Expense
                .Include(e => e.Period)
                .Include(e => e.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var expense = await _context.Expense.FindAsync(id);
            expense.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), "Periods", new { Id = expense.PeriodId });
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expense.Any(e => e.Id == id);
        }
    }
}
