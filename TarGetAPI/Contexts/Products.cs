using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;


namespace TarGetAPI.Contexts
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
        {

        }

        public DbSet<Products> Products{ get; set; }
    }
}
