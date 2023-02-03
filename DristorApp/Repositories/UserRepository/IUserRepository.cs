using System;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;

namespace DristorApp.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByEmailAndRolesAsync(string email);
        Task<User> GetUserByIdAndRolesAsync(int id);
    }
}

