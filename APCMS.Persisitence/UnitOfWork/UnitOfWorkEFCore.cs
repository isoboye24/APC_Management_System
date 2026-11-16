using APCMS.Application.Contracts.Persistence;

namespace APCMS.Persistence.UnitOfWork
{
    public class UnitOfWorkEFCore : IUnitOfWork 
    {
        private readonly APCMSDBContext _db;
        public UnitOfWorkEFCore(APCMSDBContext db)
        {
            _db = db;
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }

        public Task Rollback()
        {
            return Task.CompletedTask;
        }
    }
}
