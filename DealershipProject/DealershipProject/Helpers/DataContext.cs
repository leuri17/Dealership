using Microsoft.EntityFrameworkCore;

namespace DealershipProject.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("dealershipDatabase"));
        }

        //public DbSet<Owners> Users { get; set; }
        //public DbSet<Vehicles> Users { get; set; }
        //public DbSet<Claims> Users { get; set; }
    }
}
