using Microsoft.EntityFrameworkCore;
using TvoeTiloApp.Domain.Entities;

namespace TvoeTiloApp.Infrastructure.DataAccess.DbContexts
{
    public class TvoeTiloAppDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public TvoeTiloAppDbContext(DbContextOptions<TvoeTiloAppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-VTKRU1B\\SQLEXPRESS;Database=TvoeTiloAppDb;Integrated Security=SSPI;TrustServerCertificate=True;");
        }
    }
}
