using Microsoft.EntityFrameworkCore;
using WebApplication1.models;


namespace WebApplication1.context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }


    }
}
