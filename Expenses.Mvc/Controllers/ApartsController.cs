using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Controllers
{
    public class ApartsController :  BaseMvcController
    {
        public ApartsController(IUnitOfWorkBl context) : base(context)
        {
        }

        public async Task<IActionResult> Index(int? subcategoryId)
        {
            List<ApartDto> list;
            List<SubcategoryDto> subcategories;

            list = await _context.Apart.GetAsync(subcategoryId);
            subcategories = await _context.Subcategory.GetByApartsAsync();

            ViewBag.Subcategories = subcategories;
            return View(list);
        }
    }
}
