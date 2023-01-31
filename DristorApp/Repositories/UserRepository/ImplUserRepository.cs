using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace DristorApp.Repositories.UserRepository
{
    public class ImplUserRepository : ImplRepository<User, int> , IUserRepository
    {
        public ImplUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

       
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _DbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByEmailAndRolesAsync(string email)
        {
            return await _DbContext.Users
                .Include(u => u.Roles)
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByIdAndRolesAsync(int id)
        {
            return await _DbContext.Users
                .Include(u => u.Roles)
                .Include(u => u.Addresses)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}

