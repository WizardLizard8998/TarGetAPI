using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;

namespace TarGetAPI.Contexts
{
    public class CartDetailsContext : DbContext
    {
        public CartDetailsContext(DbContextOptions<CartDetailsContext> options) : base(options)
        {

        }

        public DbSet<CartDetails> CartDetails { get; set; }

    }
}
