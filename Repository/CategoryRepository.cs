using EcommerceApi.Data;
using EcommerceApi.Model;
using EcommerceApi.Repository.IRepository;

namespace EcommerceApi.Repository
{
    public class CategoryRepository: Repository<Category> ,ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext _dbcontext) : base(_dbcontext)
        {
            
        }
    }
}
