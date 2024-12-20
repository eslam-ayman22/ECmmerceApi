using EcommerceApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApi.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
    }
}
