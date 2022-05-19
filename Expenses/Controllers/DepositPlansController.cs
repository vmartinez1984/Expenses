using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Expenses.BusinessLayer.Interfaces;
using System.Collections.Generic;
using Expenses.BusinessLayer.Dtos.Outputs;
using Expenses.BusinessLayer.Dtos.Inputs;

namespace Expenses.Controllers
{
    public class DepositPlansController : Controller
    {        
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public DepositPlansController(IUnitOfWorkBl unitOfWorkBl)
        {            
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: DepositPlans
        public async Task<IActionResult> Index()
        {
            IReadOnlyList<DepositPlanDtoOut> list;
            
            list = await _unitOfWorkBl.DepositPlanBl.GetAsync();

            return View(list);
        }

        // GET: DepositPlans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DepositPlanFullDtoOut depositPlan = await _unitOfWorkBl.DepositPlanBl.GetFullAsync((int)id);
            
            if (depositPlan == null)
            {
                return NotFound();
            }
            ViewBag.SubcategoryId = depositPlan.SubcategoryId;

            return View(depositPlan);
        }

        // GET: DepositPlans/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SubcategoryId"] = new SelectList(await _unitOfWorkBl.Subcategory.GetAsync(), "Id", "Name");
            return View();
        }

        // POST: DepositPlans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,Goal,SubcategoryId,DateRegister,IsActive")] DepositPlanDtoIn depositPlan)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.DepositPlanBl.AddAsync(depositPlan);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubcategoryId"] = new SelectList(await _unitOfWorkBl.Subcategory.GetAsync(), "Id", "Name", depositPlan.SubcategoryId);
            return View(depositPlan);
        }

        // GET: DepositPlans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depositPlan = await _unitOfWorkBl.DepositPlanBl.GetAsync((int) id);
            if (depositPlan == null)
            {
                return NotFound();
            }
            ViewData["SubcategoryId"] = new SelectList(await _unitOfWorkBl.Subcategory.GetAsync(), "Id", "Name", depositPlan.SubcategoryId);
            return View(depositPlan);
        }

        // POST: DepositPlans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,Goal,SubcategoryId,DateRegister,IsActive")] DepositPlanDtoIn depositPlan)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.DepositPlanBl.UpdateAsync(depositPlan,id);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubcategoryId"] = new SelectList(await _unitOfWorkBl.Subcategory.GetAsync(), "Id", "Name", depositPlan.SubcategoryId);
            return View(depositPlan);
        }

        // GET: DepositPlans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var depositPlan = await _unitOfWorkBl.DepositPlanBl.GetAsync((int)id);
            if (depositPlan == null)
            {
                return NotFound();
            }

            return View(depositPlan);
        }

        // POST: DepositPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var depositPlan = await _unitOfWorkBl.DepositPlanBl.GetAsync(id);            
            await _unitOfWorkBl.DepositPlanBl.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
