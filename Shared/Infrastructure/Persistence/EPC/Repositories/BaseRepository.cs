using ez_park_platform.Shared.Domain.Repositories;
using ez_park_platform.Shared.Infrastructure.Persistence.EPC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ez_park_platform.Shared.Infrastructure.Persistence.EPC.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext Context;

        protected BaseRepository(AppDbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<TEntity?> FindByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);
        }

        public void RemoveById(int id)
        {
            TEntity? entity = Context.Set<TEntity>()
                .Find(id);

            if (entity is not null){
                Context.Set<TEntity>().Remove(entity);
            }
        }

        public async Task<IEnumerable<TEntity>> ListAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }
    }
}
