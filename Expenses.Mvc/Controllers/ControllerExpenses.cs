using Expenses.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Expenses.Mvc.Controllers
{
    public class ControllerExpenses: Controller
    {
        protected readonly IUnitOfWorkBl _unitOfWork;

        public ControllerExpenses(IUnitOfWorkBl unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}