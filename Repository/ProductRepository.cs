using EcommerceApi.Data;
using EcommerceApi.Model;
using EcommerceApi.Repository.IRepository;

namespace EcommerceApi.Repository
{
    public class ProductRepository: Repository<Product> , IProductRepository
    {
        public ProductRepository(ApplicationDbContext _dbcontext) : base(_dbcontext)
        {

        }
    }
}
