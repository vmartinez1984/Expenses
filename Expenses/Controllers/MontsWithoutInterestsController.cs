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
    public class MontsWithoutInterestsController : Controller
    {
        private readonly AppDbContext _context;

        public MontsWithoutInterestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MontsWithoutInterests
        public async Task<IActionResult> Index()
        {
            List<MontsWithoutInterest> list;

            list = await _context.MontsWithoutInterest        
                .Where(x=>x.IsActive)
                .ToListAsync();
            list.ForEach(item =>
            {
                item.ListPays = _context.MontsWithoutInterestDetails
                .Where(x => x.MontsWithoutInterestId == item.Id && x.IsActive)
                .ToList();
            });

            return View(list);
        }

        // GET: MontsWithoutInterests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montsWithoutInterest = await _context.MontsWithoutInterest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montsWithoutInterest == null)
            {
                return NotFound();
            }
            montsWithoutInterest.ListPays = _context.MontsWithoutInterestDetails
                .Where(x => x.MontsWithoutInterestId == montsWithoutInterest.Id && x.IsActive)
                .ToList();
            return View(montsWithoutInterest);
        }

        // GET: MontsWithoutInterests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MontsWithoutInterests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ExpensesTotal,Amount,DateStart,IsActive")] MontsWithoutInterest montsWithoutInterest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montsWithoutInterest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(montsWithoutInterest);
        }
                
        // GET: MontsWithoutInterests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montsWithoutInterest = await _context.MontsWithoutInterest.FindAsync(id);
            if (montsWithoutInterest == null)
            {
                return NotFound();
            }
            return View(montsWithoutInterest);
        }

        // POST: MontsWithoutInterestDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _AddPay([Bind("Id,Amount,ExpenseNumber,MontsWithoutInterestId,DateStart,IsActive")] MontsWithoutInterestDetails montsWithoutInterestDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montsWithoutInterestDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "MontsWithoutInterests", new { Id = montsWithoutInterestDetails.MontsWithoutInterestId });
            }

            return RedirectToAction("Details", "MontsWithoutInterests", new { Id = montsWithoutInterestDetails.MontsWithoutInterestId });
        }

        // POST: MontsWithoutInterests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ExpensesTotal,Amount,DateStart,IsActive")] MontsWithoutInterest montsWithoutInterest)
        {
            if (id != montsWithoutInterest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(montsWithoutInterest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MontsWithoutInterestExists(montsWithoutInterest.Id))
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
            return View(montsWithoutInterest);
        }

        // GET: MontsWithoutInterests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montsWithoutInterest = await _context.MontsWithoutInterest
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montsWithoutInterest == null)
            {
                return NotFound();
            }

            return View(montsWithoutInterest);
        }

        // POST: MontsWithoutInterests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var montsWithoutInterest = await _context.MontsWithoutInterest.FindAsync(id);
            _context.MontsWithoutInterest.Remove(montsWithoutInterest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontsWithoutInterestExists(int id)
        {
            return _context.MontsWithoutInterest.Any(e => e.Id == id);
        }
    }
}
