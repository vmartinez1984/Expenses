using Expenses.Core.Entities;
using Expenses.Core.InterfaceRepository;
using Expenses.RepositoryEF.Contexts;
using System;
using System.Threading.Tasks;

namespace Expenses.RepositoryEF.Repositories
{
    internal class TdcRepository : BaseRepository, ITdcRepository
    {
        public TdcRepository(AppDbContext appDbContext) : base(appDbContext)
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
