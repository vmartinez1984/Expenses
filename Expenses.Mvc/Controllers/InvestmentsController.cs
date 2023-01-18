using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Controllers
{
    public class InvestmentsController : BaseMvcController
    {
        public InvestmentsController(IUnitOfWorkBl context) : base(context)
        {
        }

        public async Task<IActionResult> Index(int? investmentId)
        {
            List<InvestmentDto> list;

            list = await _context.Investment.GetAllAsync();
            if (investmentId is null)
            {
                ViewBag.Investment = new InvestmentDto();
            }
            else
            {
                ViewBag.Investment = await _context.Investment.GetAsync((int)investmentId);
            }

            return View(list);
        }

        [HttpPost]
        public async Task<IActionResult> Save(InvestmentDto investmentDto)
        {
            if (investmentDto.Id == 0)
                await _context.Investment.AddAsync(investmentDto);
            else
                await _context.Investment.UpdateAsync(investmentDto, investmentDto.Id);

            return RedirectToAction("Index");
        }
    }
}
