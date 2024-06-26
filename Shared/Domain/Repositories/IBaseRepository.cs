﻿namespace ez_park_platform.Shared.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity?> FindByIdAsync(int id);
        void Update(TEntity entity);
        void RemoveById(int id);
        Task<IEnumerable<TEntity>> ListAsync();
    }
}
