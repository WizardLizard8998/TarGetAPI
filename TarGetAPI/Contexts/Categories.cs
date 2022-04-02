using Microsoft.EntityFrameworkCore;
using TarGetAPI.Models;

namespace TarGetAPI.Contexts
{
    public class CategoryContext: DbContext
    {
        public CategoryContext(DbContextOptions<CategoryContext> options) : base(options)
        {

        }

        public DbSet<Categories> Categories{ get; set; }

    }
}
