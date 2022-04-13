using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Expenses.Models;

namespace Expenses.Controllers
{
    public class ExpenseTdcsController : Controller
    {
        private readonly AppDbContext _context;

        public ExpenseTdcsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ExpenseTdcs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ExpenseTdc.ToListAsync());
        }

        // GET: ExpenseTdcs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTdc = await _context.ExpenseTdc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTdc == null)
            {
                return NotFound();
            }

            return View(expenseTdc);
        }

        // GET: ExpenseTdcs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ExpenseTdcs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,DateRegistration,IsActive")] ExpenseTdc expenseTdc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(expenseTdc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(expenseTdc);
        }

        // GET: ExpenseTdcs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTdc = await _context.ExpenseTdc.FindAsync(id);
            if (expenseTdc == null)
            {
                return NotFound();
            }
            return View(expenseTdc);
        }

        // POST: ExpenseTdcs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,DateRegistration,IsActive")] ExpenseTdc expenseTdc)
        {
            if (id != expenseTdc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseTdc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseTdcExists(expenseTdc.Id))
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
            return View(expenseTdc);
        }

        // GET: ExpenseTdcs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseTdc = await _context.ExpenseTdc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseTdc == null)
            {
                return NotFound();
            }

            return View(expenseTdc);
        }

        // POST: ExpenseTdcs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseTdc = await _context.ExpenseTdc.FindAsync(id);
            _context.ExpenseTdc.Remove(expenseTdc);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseTdcExists(int id)
        {
            return _context.ExpenseTdc.Any(e => e.Id == id);
        }
    }
}
