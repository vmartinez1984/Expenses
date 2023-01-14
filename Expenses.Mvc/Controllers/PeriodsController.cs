using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Expenses.Mvc.Controllers
{
    public class PeriodsController : Controller
    {
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public PeriodsController(IUnitOfWorkBl unitOfWorkBl)
        {
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: PeriodsController
        public async Task<ActionResult> Index(int? periodId)
        {
            List<PeriodDto> list;
            PeriodDto periodDto;

            if (periodId is null)
            {
                DateTime now;
                DateTime date10;
                DateTime date25;

                now = DateTime.Now;
                date10 = new DateTime(now.Year, now.Month, 10);
                date25 = new DateTime(now.Year, now.Month, 25);
                var near10 = now.Date - date10.Date;

                periodDto = new PeriodDto
                {

                };
            }
            else
            {
                periodDto = await _unitOfWorkBl.Period.GetAsync((int)periodId);
            }
            ViewBag.Period = periodDto;
            list = await _unitOfWorkBl.Period.GetAsync();

            return View(list);
        }

        // GET: PeriodsController/Details/5
        public async Task<ActionResult> Details(int id, int? expenseId)
        {
            PeriodFullDto period;
            ExpenseDto expenseDto;

            period = await _unitOfWorkBl.Period.GetFullAsync(id);
            ViewBag.ListSubcategories = new SelectList(await _unitOfWorkBl.Subcategory.GetAsync(), "Id", "Name");
            if (expenseId is null)
            {
                expenseDto = new ExpenseDto { PeriodId = period.Id, Id = 0 };
            }
            else
            {
                expenseDto = await _unitOfWorkBl.Expense.GetByIdAsync((int)expenseId);
            }
            ViewBag.ExpenseDto = expenseDto;

            return View(period);
        }

        // POST: PeriodsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Save(PeriodDto period)
        {
            try
            {
                if (period.Id == 0)
                {
                    await _unitOfWorkBl.Period.AddAsync(period);
                }
                else
                {
                    await _unitOfWorkBl.Period.UpdateAsync(period, period.Id);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: PeriodsController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int periodId)
        {
            try
            {               
                await _unitOfWorkBl.Period.DeleteAsync(periodId); 

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
