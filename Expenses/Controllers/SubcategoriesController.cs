using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Expenses.BusinessLayer.Interfaces;
using Expenses.BusinessLayer.Dtos.Inputs;
using Expenses.BusinessLayer.Dtos.Outputs;
using System.Collections.Generic;

namespace Expenses.Controllers
{
    public class SubcategoriesController : Controller
    {
        
        private readonly IUnitOfWorkBl _unitOfWorkBl;

        public SubcategoriesController(IUnitOfWorkBl unitOfWorkBl)
        {         
            _unitOfWorkBl = unitOfWorkBl;
        }

        // GET: Subcategories
        public async Task<IActionResult> Index(
            string orderBy,
            string orderByName,
            string OrderByAmount,
            string OrderbyCategory,
            string category
        )
        {
            // IQueryable<Subcategory> appDbContext;

            // appDbContext = _context.Subcategory.Include(s => s.Category).Where(x => x.IsActive);
            // switch (orderByName)
            // {
            //     case "Asc":
            //         appDbContext = appDbContext.OrderBy(x => x.Name);
            //         ViewBag.OrderByName = "Desc";
            //         break;
            //     case "Desc":
            //         appDbContext = appDbContext.OrderByDescending(x => x.Name);
            //         ViewBag.OrderByName = string.Empty;
            //         break;
            //     default:
            //         ViewBag.OrderByName = "Asc";
            //         break;
            // }

            // OrderByCategory(ref appDbContext, OrderbyCategory);
            // FilterCategory(ref appDbContext, category);

            // if (string.IsNullOrEmpty(OrderByAmount))
            // {
            //     ViewBag.OrderByAmount = true;
            // }
            // else
            // {
            //     ViewBag.OrderByAmount = string.Empty;
            //     appDbContext = appDbContext.OrderBy(x => x.Amount);
            // }
            // ViewBag.ListCategories = _context.Category.Where(Category => Category.IsActive).OrderBy(x => x.Name).ToList();
            IReadOnlyList<SubcategoryDtoOut> list;

            list = await _unitOfWorkBl.Subcategory.GetAsync();

            return View(list);
        }

        // private void FilterCategory(ref IQueryable<Subcategory> appDbContext, string category)
        // {
        //     if (string.IsNullOrEmpty(category))
        //     {

        //     }
        //     else
        //     {
        //         appDbContext = appDbContext.Where(x => x.Category.Name == category);
        //     }
        // }

        // private void OrderByCategory(ref IQueryable<Subcategory> appDbContext, string OrderbyCategory)
        // {
        //     switch (OrderbyCategory)
        //     {
        //         case "Asc":
        //             appDbContext = appDbContext.OrderBy(x => x.Category.Name);
        //             break;
        //         case "Desc":
        //             appDbContext = appDbContext.OrderByDescending(x => x.Category.Name);
        //             break;
        //         default:
        //             break;
        //     }
        // }

        public async Task<IActionResult> Get(int id)
        {
            var list = await _unitOfWorkBl.Subcategory.GetAsync();
            list = list.Where(x=> x.CategoryId == id).ToList();

            return Json(list);
        }

        // GET: Subcategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _unitOfWorkBl.Subcategory.GetAsync((int)id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // GET: Subcategories/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoryId"] = new SelectList(await _unitOfWorkBl.Category.GetAsync(), "Id", "Name");
            return View();
        }

        // POST: Subcategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,Amount,IsBudget")] SubcategoryDtoIn subcategory)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Subcategory.AddAsync(subcategory);

                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWorkBl.Category.GetAsync(), "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _unitOfWorkBl.Subcategory.GetAsync((int)id);
            if (subcategory == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWorkBl.Category.GetAsync(), "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // POST: Subcategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Amount,IsBudget,IsActive")] SubcategoryDtoIn subcategory)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWorkBl.Subcategory.UpdateAsync(subcategory, id);

                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(await _unitOfWorkBl.Category.GetAsync(), "Id", "Name", subcategory.CategoryId);
            return View(subcategory);
        }

        // GET: Subcategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subcategory = await _unitOfWorkBl.Subcategory.GetAsync((int)id);
            if (subcategory == null)
            {
                return NotFound();
            }

            return View(subcategory);
        }

        // POST: Subcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWorkBl.Subcategory.DeleteAsync(id);
             
            return RedirectToAction(nameof(Index));
        }
    }
}
