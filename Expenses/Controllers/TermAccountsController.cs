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
    public class TermAccountsController : Controller
    {
        private readonly AppDbContext _context;

        public TermAccountsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TermAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.TermAccount.ToListAsync());
        }

        // GET: TermAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termAccount = await _context.TermAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termAccount == null)
            {
                return NotFound();
            }

            return View(termAccount);
        }

        // GET: TermAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TermAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,DateRegistration,Term,IsActive")] TermAccount termAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(termAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(termAccount);
        }

        // GET: TermAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termAccount = await _context.TermAccount.FindAsync(id);
            if (termAccount == null)
            {
                return NotFound();
            }
            return View(termAccount);
        }

        // POST: TermAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,DateRegistration,Term,IsActive")] TermAccount termAccount)
        {
            if (id != termAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(termAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TermAccountExists(termAccount.Id))
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
            return View(termAccount);
        }

        // GET: TermAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termAccount = await _context.TermAccount
                .FirstOrDefaultAsync(m => m.Id == id);
            if (termAccount == null)
            {
                return NotFound();
            }

            return View(termAccount);
        }

        // POST: TermAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var termAccount = await _context.TermAccount.FindAsync(id);
            _context.TermAccount.Remove(termAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TermAccountExists(int id)
        {
            return _context.TermAccount.Any(e => e.Id == id);
        }
    }
}
