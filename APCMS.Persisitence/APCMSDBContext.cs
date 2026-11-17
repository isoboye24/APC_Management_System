using APCMS.Domain.Common;
using APCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence
{
    public class APCMSDBContext : DbContext
    {
        public APCMSDBContext(
            DbContextOptions<APCMSDBContext> options)
            : base(options)
        {
        }

        protected APCMSDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(APCMSDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(
            CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Auditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationTime = DateTime.UtcNow;
                        entry.Entity.CreatedBy = null;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastMofifiedBy = null;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Position> Positions { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<AttendanceStatus> AttendanceStatuses { get; set; }
    }
}
