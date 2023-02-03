using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.OrderRepository;
using Microsoft.EntityFrameworkCore;

namespace DristorApp.Repositories.OrderRepository
{
    

public class OrderRepository : ImplRepository<Order, int>, IOrderRepository
{
    public OrderRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public override Task<List<Order>> GetAllAsync()
    {
        return _DbContext.Orders
            .Include(x => x.Address)
            .ThenInclude(x => x.User)
            .Include(x => x.OrderItems)
            .ThenInclude(x => x.ProductVariant)
            .ThenInclude(x => x.Product)
            .Include(x => x.OrderStatusUpdates)
            .ToListAsync();
    }

    public override Task<Order?> GetByIdAsync(int id)
    {
        return _DbContext.Orders
            .Include(x => x.Address)
            .ThenInclude(x => x.User)
            .Include(x => x.OrderItems)
            .ThenInclude(x => x.ProductVariant)
            .ThenInclude(x => x.Product)
            .Include(x => x.OrderStatusUpdates)
            .FirstOrDefaultAsync(x => x.Id == id);
    }
}
}