using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Dtos.Inputs;

namespace Expenses.Controllers
{
    public class TermAccountsController : Controller
    {        
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public TermAccountsController(IUnitOfWorkBl unitOfWorkBl)
        {            
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: TermAccounts
        public async Task<IActionResult> Index()
        {
            IReadOnlyList<TermAccountDtoOut> list;

            list = await _unitOfWorkBl.TermAccount.GetAsync();

            return View(list);
        }

        // GET: TermAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var termAccount = await _unitOfWorkBl.TermAccount.GetAsync((int)id);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,DateRegistration,Term")] TermAccountDtoIn termAccount)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.TermAccount.AddAsync(termAccount);
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

            var termAccount = await _unitOfWorkBl.TermAccount.GetAsync((int)id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,DateRegistration,Term")] TermAccountDtoIn termAccount)
        {            
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.TermAccount.UpdateAsync(termAccount, id);

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

            var termAccount = await _unitOfWorkBl.TermAccount.GetAsync((int)id);
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
            var termAccount = await _unitOfWorkBl.TermAccount.GetAsync(id);
            await _unitOfWorkBl.TermAccount.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
