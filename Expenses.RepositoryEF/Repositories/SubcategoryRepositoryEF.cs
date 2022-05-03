using Expenses.BusinessLayer.Interfaces.InterfaceRepository;

namespace Expenses.RepositoryEF{
    public class SubcategoryRepositoryEF: ISubcategoryRepository{

         private readonly AppDbContext _context;

        public SubcategoryRepositoryEF(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SubcategoryEntity> GetAsync(int id)
        {
            SubcategoryEntity entity;

            entity = await _context.Subcategory.Where(x => x.Id == id && x.IsActive).FirstOrDefaultAsync();

            return entity;
        }

        public async Task<IReadOnlyList<SubcategoryEntity>> GetAsync(){

            return new List<SubcategoryEntity>();
        }

        public async Task<int> AddAsync(SubcategoryEntity entity){
            return 1;
        }

        public async Task UpdateAsync(SubcategoryEntity entity){

        }

        public async Task DeleteAsync(int id){

        }
    }
}