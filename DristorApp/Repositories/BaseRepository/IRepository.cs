using System;
namespace DristorApp.Repositories.BaseRepository
{
    public interface IRepository<Entity, Id> where Entity : class
    {
        public Task<List<Entity>> GetAllAsync();

        public Task<Entity?> GetByIdAsync(Id id);

        public Task CreateAsync(Entity entity);

        public Task UpdateAsync(Entity entity);

        public Task DeleteAsync(Entity entity);
    }
}

