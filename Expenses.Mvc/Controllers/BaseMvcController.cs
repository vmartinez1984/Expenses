using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Controllers
{
    public class BaseMvcController : Controller
    {
        protected readonly IUnitOfWorkBl _context;

        public BaseMvcController(IUnitOfWorkBl context)
        {
            _context = context;
        }
    }
}
