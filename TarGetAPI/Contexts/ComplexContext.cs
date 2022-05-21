using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;


namespace TarGetAPI.Contexts
{
    public class ComplexContext :DbContext
    {
        public ComplexContext(DbContextOptions<ComplexContext> options) : base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetails> CartDetails { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<District> Districts{ get; set; }
        public DbSet<Producers> Producers{ get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<UserAccount> UserAccount{ get; set; }


    }
}
