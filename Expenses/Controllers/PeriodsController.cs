using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expenses.Models;
using System.Collections.Generic;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces;

namespace Expenses.Controllers
{
    public class PeriodsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public PeriodsController(AppDbContext context, IUnitOfWorkBl unitOfWorkBl)
        {
            _context = context;
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: Periods
        public async Task<IActionResult> Index()
        {           
            IReadOnlyList<PeriodDtoOut> list;
            
            list = await _unitOfWorkBl.Period.GetAsync();

            return View(list);
        }

        // GET: Periods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Period period;

            if (id == null)
            {
                period = await _context.Period
                     .Include(x => x.ListExpenses.Where(x => x.IsActive))
                         .ThenInclude(x => x.Subcategory)
                     .Include(x => x.ListEntries.Where(x => x.IsActive))
                     .Where(x => x.IsActive)
                     .OrderBy(x => x.Id)
                     .FirstOrDefaultAsync();
            }
            else
            {
                period = await _context.Period
                    .Include(x => x.ListExpenses.Where(x => x.IsActive))
                        .ThenInclude(x => x.Subcategory)
                    .Include(x => x.ListEntries.Where(x => x.IsActive))
                    .Where(x => x.Id == id)
                    .FirstOrDefaultAsync();
            }
            ViewBag.PeriodId = period == null ? 0 : period.Id;
            ViewData["ListCategories"] = new SelectList(_context.Category.Where(x => x.IsActive).OrderBy(x=> x.Name), "Id", "Name");
            if (period == null)
            {
                return RedirectToAction("Index","Home");
            }

            return View(period);
        }

        // GET: Periods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Periods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateStart,DateStop,IsActive")] Period period)
        {
            if (ModelState.IsValid)
            {
                _context.Add(period);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(period);
        }

        // GET: Periods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _unitOfWorkBl.Period.GetAsync((int)id);
            if (period == null)
            {
                return NotFound();
            }
            return View(period);
        }

        // POST: Periods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateStart,DateStop,IsActive")] Period period)
        {
            if (id != period.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(period);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PeriodExists(period.Id))
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
            return View(period);
        }

        // GET: Periods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _context.Period
                .FirstOrDefaultAsync(m => m.Id == id);
            if (period == null)
            {
                return NotFound();
            }

            return View(period);
        }

        // POST: Periods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var period = await _context.Period.FindAsync(id);
            period.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Periods/Delete/5
        public async Task<IActionResult> Activate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var period = await _context.Period
                .FirstOrDefaultAsync(m => m.Id == id);
            if (period == null)
            {
                return NotFound();
            }

            return View(period);
        }

        // POST: Periods/Delete/5
        [HttpPost, ActionName("Activate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ActivateConfirmed(int id)
        {
            var period = await _context.Period.FindAsync(id);
            period.IsActive = true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PeriodExists(int id)
        {
            return _context.Period.Any(e => e.Id == id);
        }
    }
}
