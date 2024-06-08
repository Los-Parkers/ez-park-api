using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;

namespace ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }


        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
