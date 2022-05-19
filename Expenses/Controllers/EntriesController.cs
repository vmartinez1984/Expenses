using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;

namespace Expenses.Controllers
{
    public class EntriesController : Controller
    {
        private IUnitOfWorkBl _unitOfWorkBl;

        public EntriesController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: Entries/Create
        public async Task<IActionResult> Create(int periodId)
        {
            ViewData["ListPeriods"] = new SelectList(await _unitOfWorkBl.Period.GetAsync(), "Id", "Name");
            ViewBag.PeriodId = periodId;

            return View();
        }

        // POST: Entries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateRegister,IsActive,PeriodId,Amount")] EntryDtoIn entry)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Entry.AddAsync(entry);

                return RedirectToAction("Details", "Periods", new { Id = entry.PeriodId });
            }
            return View(entry);
        }

        // GET: Entries/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _unitOfWorkBl.Entry.GetByIdAsync((int)id);
            if (entry == null)
            {
                return NotFound();
            }
            return View(entry);
        }

        // POST: Entries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateRegister,IsActive, PeriodId, Amount")] EntryDtoIn entry)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Entry.UpdateAsync(entry, id);
                return RedirectToAction("Details", "Periods", new
                {
                    Id = entry.PeriodId,
                });
            }
            return View(entry);
        }

        // GET: Entries/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entry = await _unitOfWorkBl.Entry.GetByIdAsync((int) id);                
            if (entry == null)
            {
                return NotFound();
            }

            return View(entry);
        }

        // POST: Entries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            EntryDtoOut entry = await _unitOfWorkBl.Entry.GetByIdAsync(id);
            await _unitOfWorkBl.Entry.DeleteAsync(id);
            return RedirectToAction("Details", "Periods", new { Id = entry.PeriodId });
        }
    }
}
