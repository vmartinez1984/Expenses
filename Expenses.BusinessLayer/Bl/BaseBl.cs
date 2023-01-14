using AutoMapper;
using Expenses.Core.Interfaces;

namespace Expenses.BusinessLayer.Bl
{
    public class BaseBl
    {
        protected readonly IRepository _unitOfWork;
        protected readonly IMapper _mapper;

        public BaseBl(IMapper mapper, IRepository unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
