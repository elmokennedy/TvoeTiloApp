using Microsoft.EntityFrameworkCore;
using TvoeTiloApp.Domain.Entities;

namespace TvoeTiloApp.Infrastructure.DataAccess.DbContexts
{
    public class TvoeTiloAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public TvoeTiloAppDbContext(DbContextOptions<TvoeTiloAppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-VTKRU1B\\SQLEXPRESS;Database=TvoeTiloAppDb;Integrated Security=SSPI;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(x => x.CoachProfile)
                .WithOne(x => x.User)
                .HasForeignKey<CoachProfile>(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasOne(x => x.ClientProfile)
                .WithOne(x => x.User)
                .HasForeignKey<ClientProfile>(x => x.UserId);

            modelBuilder.Entity<CoachProfile>()
                .HasMany(x => x.TrainingTypes)
                .WithMany(x => x.CoachProfiles);

            modelBuilder.Entity<ScheduledTraining>()
                .HasOne(x => x.TrainingType)
                .WithMany(x => x.ScheduledTrainings);

            modelBuilder.Entity<ScheduledTraining>()
                .HasMany(x => x.ClientProfiles)
                .WithMany(x => x.ScheduledTrainings);
        }
    }
}
