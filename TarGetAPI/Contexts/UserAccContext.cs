using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;


namespace TarGetAPI.Contexts
{
    public class UserAccContext: DbContext
    {
        public UserAccContext(DbContextOptions<UserAccContext> options) : base(options)
        {

        }

        public DbSet<UserAcc> UsersAcc{ get; set; }
    }
}
