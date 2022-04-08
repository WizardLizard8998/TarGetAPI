using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;

namespace TarGetAPI.Contexts
{
    public class DistrictContext : DbContext
    {
        public DistrictContext(DbContextOptions<DistrictContext> options) : base(options)
        {

        }

        public DbSet<District> District{ get; set; }

    }
}
