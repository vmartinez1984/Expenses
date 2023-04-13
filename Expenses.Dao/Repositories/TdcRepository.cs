using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Repository.Repositories
{
    internal class TdcRepository : BaseRepository, ITdcRepository
    {
        public TdcRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public Task<int> AddAsync(TdcEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TdcEntity> GetAsync(int id)
        {
            TdcEntity entity;

            entity = new TdcEntity
            {
                Id = id,
                Name = "Bbva Platinum",
                DayCut = 3,
                Interest = 39.27M
            };

            return Task.FromResult(entity);
        }

        public Task UpdateAsync(TdcEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
