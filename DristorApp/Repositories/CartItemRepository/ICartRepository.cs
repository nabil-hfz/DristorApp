using System;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;

namespace DristorApp.Repositories.CartRepository
{
    public interface ICartItemRepository : IRepository<CartItem, int>
    {
        public Task<List<CartItem>> GetByUserId(int userId);
    }
}

