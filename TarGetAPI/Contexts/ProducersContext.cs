using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;

namespace TarGetAPI.Contexts
{
    public class ProducersContext : DbContext
    {
        public ProducersContext(DbContextOptions<ProducersContext> options) : base(options)
        {

        }

        public DbSet<Producers> Producers{ get; set; }

        public DbSet<UserAccount> UserAccount { get; set; }

    }
}
