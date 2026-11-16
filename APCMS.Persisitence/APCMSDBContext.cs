using APCMS.Application.Contracts.Repositories;
using APCMS.Domain.Common;
using APCMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace APCMS.Persistence
{
    public class APCMSDBContext : DbContext
    {
        private readonly IUserService? _userService;
        public APCMSDBContext(DbContextOptions<APCMSDBContext> options, IUserService? userService) : base(options)
        {
            _userService = userService;
        }

        protected APCMSDBContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(APCMSDBContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            if (_userService is not null)
            {
                foreach (var entry in ChangeTracker.Entries<Auditable>())
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entry.Entity.CreationTime = DateTime.UtcNow;
                            entry.Entity.CreatedBy = _userService.GetUserId();
                            break;
                        case EntityState.Modified:
                            entry.Entity.LastModifiedDate = DateTime.UtcNow;
                            entry.Entity.LastMofifiedBy = _userService.GetUserId();
                            break;
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Position> Positions { get; set; }
    }
}
