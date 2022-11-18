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

        //public DbSet<Owners> Owners { get; set; }
        //public DbSet<Vehicles> Vehicles { get; set; }
        //public DbSet<Claims> Claims { get; set; }
    }
}
