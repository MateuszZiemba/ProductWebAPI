using Microsoft.EntityFrameworkCore;
using ProductWebAPI.Models;

namespace ProductWebAPI.Contexts
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
    }
}
