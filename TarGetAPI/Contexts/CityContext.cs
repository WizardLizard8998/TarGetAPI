using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;


namespace TarGetAPI.Contexts
{
    public class CityContext : DbContext
    {   
        public CityContext(DbContextOptions<CityContext> options) : base(options)
        {
                
        }
        
        public DbSet<City> Cities { get; set; }
    }
}
