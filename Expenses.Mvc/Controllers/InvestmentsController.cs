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

        public async Task<IActionResult> Index(PagerDto pager)
        {
            //List<InvestmentDto> list;
            PagerDto pagerDto;

            pagerDto = await _context.Investment.GetAllAsync(pager);
            ViewBag.Pager = pagerDto;
            //if (investmentId is null)
            //{
                ViewBag.Investment = new InvestmentDto();            
            //}
            //else
            //{
            //    ViewBag.Investment = await _context.Investment.GetAsync((int)investmentId);
            //}

            return View(pagerDto.List);
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

        [HttpPost]
        public async Task<IActionResult> Delete(int investmentIdForDelete)
        {
            await _context.Investment.DeleteAsync(investmentIdForDelete);
             
            return RedirectToAction("Index");
        }
    }
}
