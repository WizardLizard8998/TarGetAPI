using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;

namespace TarGetAPI.Contexts
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }

        public DbSet<Cart>Carts { get; set; }   

    }
}
