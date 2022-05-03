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
    public class DepositPlansController : Controller
    {
        private readonly AppDbContext _context;

        public DepositPlansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DepositPlans
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.DepositPlan
                .Include(x => x.ListExpenses.Where(x => x.IsActive))
                .Include(d => d.Subcategory)
                .OrderBy(x=> x.Name);
            return View(await appDbContext.ToListAsync());
        }

        // GET: DepositPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depositPlan = await _context.DepositPlan
                .Include(x => x.ListExpenses.Where(x => x.IsActive))
                .Include(d => d.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (depositPlan == null)
            {
                return NotFound();
            }
            ViewBag.SubcategoryId = depositPlan.SubcategoryId;

            return View(depositPlan);
        }

        // GET: DepositPlans/Create
        public IActionResult Create()
        {
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name");
            return View();
        }

        // POST: DepositPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,Goal,SubcategoryId,DateRegister,IsActive")] DepositPlan depositPlan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(depositPlan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", depositPlan.SubcategoryId);
            return View(depositPlan);
        }

        // GET: DepositPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depositPlan = await _context.DepositPlan.FindAsync(id);
            if (depositPlan == null)
            {
                return NotFound();
            }
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", depositPlan.SubcategoryId);
            return View(depositPlan);
        }

        // POST: DepositPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,Goal,SubcategoryId,DateRegister,IsActive")] DepositPlan depositPlan)
        {
            if (id != depositPlan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(depositPlan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositPlanExists(depositPlan.Id))
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
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", depositPlan.SubcategoryId);
            return View(depositPlan);
        }

        // GET: DepositPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depositPlan = await _context.DepositPlan
                .Include(d => d.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (depositPlan == null)
            {
                return NotFound();
            }

            return View(depositPlan);
        }

        // POST: DepositPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depositPlan = await _context.DepositPlan.FindAsync(id);
            _context.DepositPlan.Remove(depositPlan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositPlanExists(int id)
        {
            return _context.DepositPlan.Any(e => e.Id == id);
        }
    }
}
