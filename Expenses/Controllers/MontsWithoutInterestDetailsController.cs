using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expenses.Models;

namespace Expenses.Controllers
{
    public class MontsWithoutInterestDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public MontsWithoutInterestDetailsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MontsWithoutInterestDetails
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.MontsWithoutInterestDetails.Include(m => m.MontsWithoutInterest);
            return View(await appDbContext.ToListAsync());
        }

        // GET: MontsWithoutInterestDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montsWithoutInterestDetails = await _context.MontsWithoutInterestDetails
                .Include(m => m.MontsWithoutInterest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montsWithoutInterestDetails == null)
            {
                return NotFound();
            }

            return View(montsWithoutInterestDetails);
        }

        // GET: MontsWithoutInterestDetails/Create
        public IActionResult Create()
        {
            ViewData["MontsWithoutInterestId"] = new SelectList(_context.MontsWithoutInterest, "Id", "Name");
            return View();
        }

        // POST: MontsWithoutInterestDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,ExpenseNumber,MontsWithoutInterestId,DateStart,IsActive")] MontsWithoutInterestDetails montsWithoutInterestDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(montsWithoutInterestDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MontsWithoutInterestId"] = new SelectList(_context.MontsWithoutInterest, "Id", "Name", montsWithoutInterestDetails.MontsWithoutInterestId);
            return View(montsWithoutInterestDetails);
        }        

        // GET: MontsWithoutInterestDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montsWithoutInterestDetails = await _context.MontsWithoutInterestDetails.FindAsync(id);
            if (montsWithoutInterestDetails == null)
            {
                return NotFound();
            }
            ViewData["MontsWithoutInterestId"] = new SelectList(_context.MontsWithoutInterest, "Id", "Name", montsWithoutInterestDetails.MontsWithoutInterestId);
            return View(montsWithoutInterestDetails);
        }

        // POST: MontsWithoutInterestDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount,ExpenseNumber,MontsWithoutInterestId,DateStart,IsActive")] MontsWithoutInterestDetails montsWithoutInterestDetails)
        {
            if (id != montsWithoutInterestDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(montsWithoutInterestDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MontsWithoutInterestDetailsExists(montsWithoutInterestDetails.Id))
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
            ViewData["MontsWithoutInterestId"] = new SelectList(_context.MontsWithoutInterest, "Id", "Name", montsWithoutInterestDetails.MontsWithoutInterestId);
            return View(montsWithoutInterestDetails);
        }

        // GET: MontsWithoutInterestDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montsWithoutInterestDetails = await _context.MontsWithoutInterestDetails
                .Include(m => m.MontsWithoutInterest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montsWithoutInterestDetails == null)
            {
                return NotFound();
            }

            return View(montsWithoutInterestDetails);
        }

        // POST: MontsWithoutInterestDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var montsWithoutInterestDetails = await _context.MontsWithoutInterestDetails.FindAsync(id);
            montsWithoutInterestDetails.IsActive = false;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontsWithoutInterestDetailsExists(int id)
        {
            return _context.MontsWithoutInterestDetails.Any(e => e.Id == id);
        }
    }
}
