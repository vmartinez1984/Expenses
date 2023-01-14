using Expenses.RepositoryEF.Contexts;

namespace Expenses.RepositoryEF.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
