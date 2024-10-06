using gestionVentas.Models;
using Microsoft.EntityFrameworkCore;


namespace gestionVentas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
