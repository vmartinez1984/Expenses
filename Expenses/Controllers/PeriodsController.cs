using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Expenses.Models;
using System.Collections.Generic;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Dtos.Inputs;

namespace Expenses.Controllers
{
    public class PeriodsController : Controller
    {        
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public PeriodsController(IUnitOfWorkBl unitOfWorkBl)
        {
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
            PeriodFullDtoOut period;

            if (id == null)
            {
                period = await _unitOfWorkBl.Period.GetFullActiveAsync();
            }
            else
            {
                period = await _unitOfWorkBl.Period.GetFullAsync((int)id);                
            }
            ViewBag.PeriodId = period == null ? 0 : period.Id;
            ViewData["ListCategories"] = new SelectList((await _unitOfWorkBl.Category.GetAsync()).OrderBy(x => x.Name), "Id", "Name");
            if (period == null)
            {
                return RedirectToAction("Index", "Home");
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
        public async Task<IActionResult> Create([Bind("Name,DateStart,DateStop")] PeriodDtoIn period)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Period.AddAsync(period);

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
        public async Task<IActionResult> Edit(int id, [Bind("Name,DateStart,DateStop")] PeriodDtoIn period)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Period.UpdateAsync(period, id);
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

            var period = await _unitOfWorkBl.Period.GetAsync((int)id);
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
            await _unitOfWorkBl.Period.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
