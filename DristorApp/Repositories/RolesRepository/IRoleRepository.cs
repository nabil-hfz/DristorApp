using System;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;

namespace DristorApp.Repositories.Roles
{
    public interface IRoleRepository : IRepository<Role, int>
    {
        public Role? GetRoleByName(string name);
        public Task<Role?> GetRoleByNameAsync(string name);
    }
}

