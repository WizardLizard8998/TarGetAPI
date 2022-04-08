using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;


namespace TarGetAPI.Contexts
{
    public class UserAccountContext: DbContext
    {
        public UserAccountContext(DbContextOptions<UserAccountContext> options) : base(options)
        {

        }

        public DbSet<UserAccount> UserAccount{ get; set; }
    }
}
