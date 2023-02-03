using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace DristorApp.Repositories.Roles
{
    public class ImplRoleRepository : ImplRepository<Role, int>, IRoleRepository
    {
        public ImplRoleRepository(AppDbContext dbContext) : base(dbContext)
        {


        }

        public Role? GetRoleByName(string name)
        {
            return _DbContext.Roles.FirstOrDefault(role => role.Name == name);
        }

        public async Task<Role?> GetRoleByNameAsync(string name)
        {
            return await _DbContext.Roles.FirstOrDefaultAsync(role => role.Name == name);
        }
    }
}

