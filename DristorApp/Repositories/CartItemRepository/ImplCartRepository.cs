using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.CartRepository;
using Microsoft.EntityFrameworkCore;

namespace DristorApp.Repositories.CartRepository
{

    public class ImplCartItemRepository : ImplRepository<CartItem, int>, ICartItemRepository
    {
        public ImplCartItemRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<List<CartItem>> GetAllAsync()
        {
            return _DbContext.CartItems
                .Include(x => x.User)
                .Include(x => x.ProductVariant)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Ingredients)
                .ToListAsync();
        }

        public override Task<CartItem?> GetByIdAsync(int id)
        {
            return _DbContext.CartItems
                .Include(x => x.User)
                .Include(x => x.ProductVariant)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Ingredients)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<CartItem>> GetByUserId(int userId)
        {
            return _DbContext.CartItems
                .Include(x => x.User)
                .Include(x => x.ProductVariant)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.Ingredients)
                .Where(x => x.User.Id == userId)
                .ToListAsync();
        }
    }
}