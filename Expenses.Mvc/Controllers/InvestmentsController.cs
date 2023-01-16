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

        public async Task<IActionResult> Index()
        {
            List<InvestmentDto> list;

            list = await _context.Investment.GetAllAsync();

            return View(list);
        }
    }
}
