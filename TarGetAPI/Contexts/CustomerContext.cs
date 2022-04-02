using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;

namespace TarGetAPI.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }

        public DbSet<Customers> Customers { get; set; }

    }
}
