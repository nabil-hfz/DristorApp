using System;
using DristorApp.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DristorApp.Data.db;

namespace DristorApp.Repositories.BaseRepository
{
    public class ImplRepository<Entity, Id> :
        IRepository<Entity, Id> where Entity : class
    {
        protected readonly AppDbContext _DbContext;

        public ImplRepository(AppDbContext dbContext)
        {

            _DbContext = dbContext;
        }
        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _DbContext.Set<Entity>().ToListAsync();
        }


        public virtual async Task<Entity?> GetByIdAsync(Id id)
        {
            return await _DbContext.Set<Entity>().FindAsync(id);
        }

        public virtual async Task CreateAsync(Entity entity)
        {
            _DbContext.Set<Entity>().Add(entity);
            await _DbContext.SaveChangesAsync();
        }
        public virtual async Task UpdateAsync(Entity entity)
        {
            _DbContext.Set<Entity>().Update(entity);
            await _DbContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Entity entity)
        {
            _DbContext.Set<Entity>().Remove(entity);
            await _DbContext.SaveChangesAsync();
        }
    }
}

