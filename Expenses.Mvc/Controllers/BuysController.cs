using Expenses.BusinessLayer.Interfaces;
using Expenses.Core.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Controllers
{
    public class BuysController : ControllerExpenses
    {
        public BuysController(IUnitOfWorkBl unitOfWork) : base(unitOfWork) { }

        // GET: BuyController
        public async Task<ActionResult> Index()
        {
            List<BuyDto> list;
            
            list = await _unitOfWork.Buy.GetAsync();

            return View(list);
        }

        // GET: BuyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BuyDtoIn buy)
        {
            try
            {
                await _unitOfWork.Buy.AddAsync(buy);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            BuyDto buyDto;

            buyDto = await _unitOfWork.Buy.GetAsync(id);

            return View(buyDto);
        }

        // POST: BuyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BuyController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            BuyDto buyDto;

            buyDto = await _unitOfWork.Buy.GetAsync(id);

            return View(buyDto);
        }

        // POST: BuyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, BuyDto buy)
        {
            try
            {
                await _unitOfWork.Buy.DeleteAsync(buy.Id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
