using System.Collections.Generic;
using System.Threading.Tasks;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Controllers
{
    public class ExpenseTdcsController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public ExpenseTdcsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: ExpenseTdcs
        public async Task<IActionResult> Index()
        {
            IReadOnlyList<ExpenseTdcDtoOut> list;

            list = await _unitOfWorkBl.ExpenseTdc.GetAsync();

            return View(list);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,DateRegistration,MonthsWithoutInterest")] ExpenseTdcDtoIn expenseTdc)
        {
            if (ModelState.IsValid)
            {
               await _unitOfWorkBl.ExpenseTdc.AddAsync(expenseTdc);
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

            var expenseTdc = await _unitOfWorkBl.ExpenseTdc.GetAsync((int)id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,DateRegistration")] ExpenseTdcDtoIn expenseTdc)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.ExpenseTdc.UpdateAsync(expenseTdc, id);

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

            var expenseTdc = await _unitOfWorkBl.ExpenseTdc.GetAsync((int)id);
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
            var expenseTdc = await _unitOfWorkBl.ExpenseTdc.GetAsync((int)id);
            await _unitOfWorkBl.ExpenseTdc.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
