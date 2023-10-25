using Microsoft.EntityFrameworkCore;
using TestMetafar.Models;

namespace TestMetafar.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }
        
    }
}
