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
    public class DepositsController : Controller
    {
        private readonly AppDbContext _context;

        public DepositsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Deposits
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Deposit.Include(d => d.DepositPlan).Include(d => d.Subcategory);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Deposits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit
                .Include(d => d.DepositPlan)
                .Include(d => d.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // GET: Deposits/Create
        public IActionResult Create()
        {
            ViewData["DepositPlanId"] = new SelectList(_context.DepositPlan, "Id", "Name");
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name");
            return View();
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Guid,Name,Amount,SubcategoryId,DepositPlanId,DateRegister,IsActive")] Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deposit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepositPlanId"] = new SelectList(_context.DepositPlan, "Id", "Name", deposit.DepositPlanId);
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", deposit.SubcategoryId);
            return View(deposit);
        }

        // GET: Deposits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit.FindAsync(id);
            if (deposit == null)
            {
                return NotFound();
            }
            ViewData["DepositPlanId"] = new SelectList(_context.DepositPlan, "Id", "Name", deposit.DepositPlanId);
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", deposit.SubcategoryId);
            return View(deposit);
        }

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Guid,Name,Amount,SubcategoryId,DepositPlanId,DateRegister,IsActive")] Deposit deposit)
        {
            if (id != deposit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deposit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepositExists(deposit.Id))
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
            ViewData["DepositPlanId"] = new SelectList(_context.DepositPlan, "Id", "Name", deposit.DepositPlanId);
            ViewData["SubcategoryId"] = new SelectList(_context.Subcategory, "Id", "Name", deposit.SubcategoryId);
            return View(deposit);
        }

        // GET: Deposits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deposit = await _context.Deposit
                .Include(d => d.DepositPlan)
                .Include(d => d.Subcategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deposit == null)
            {
                return NotFound();
            }

            return View(deposit);
        }

        // POST: Deposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deposit = await _context.Deposit.FindAsync(id);
            _context.Deposit.Remove(deposit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DepositExists(int id)
        {
            return _context.Deposit.Any(e => e.Id == id);
        }
    }
}
