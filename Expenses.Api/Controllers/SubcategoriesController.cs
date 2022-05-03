using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using Expenses.Api.Models;

namespace Expenses.Api.Controllers
{
    public class SubcategoriesController : Controller
    {
        public SubcategoriesController()
        {
        }

        public async Task<IActionResult> Index()
        {
            // TODO: Your code here
            await Task.Yield();

            return View();
        }
    }
}