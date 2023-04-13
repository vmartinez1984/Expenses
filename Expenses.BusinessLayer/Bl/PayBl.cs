using Expenses.BusinessLayer.Interfaces.InterfaceBl;
using Expenses.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Expenses.BusinessLayer.Bl
{
    internal class PayBl : IPayBl
    {
        public Task<int> AddAsync(PayDtoIn item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PayDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PayDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PayDtoIn item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
