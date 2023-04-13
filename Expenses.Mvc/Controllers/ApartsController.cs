using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Controllers
{
    public class ApartsController : BaseMvcController
    {
        public ApartsController(IUnitOfWorkBl context) : base(context)
        {
        }

        //public async Task<IActionResult> Index(int? subcategoryId)
        //{
        //    List<ApartDto> list;
        //    List<SubcategoryDto> subcategories;

        //    list = await _context.Apart.GetAsync(subcategoryId);
        //    subcategories = await _context.Subcategory.GetByApartsAsync();

        //    ViewBag.Subcategories = subcategories;
        //    return View(list);
        //}

        public async Task<IActionResult> Index(PagerDto pagerDto)
        {
            //List<ApartDto> list;
            List<SubcategoryDto> subcategories;
            PagerDto pager;

            pager = await _context.Apart.GetAsync(pagerDto);
            subcategories = await _context.Subcategory.GetByApartsAsync();
            subcategories.RemoveAll(x => x.Id == 11 || x.Id == 5 || x.Id == 9);
            ViewBag.Subcategories = subcategories;
            ViewBag.Pager = pager;

            return View(pager.List);
        }
    }
}
