using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace DristorApp.Repositories.CouponRepository
{
    public class ImplCouponRepository : ImplRepository<Coupon, int>, ICouponRepository
    {
        public ImplCouponRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<List<Coupon>> GetAllAsync()
        {
            return await _DbContext.Coupons
                .Include(c => c.User)
                .ToListAsync();
        }

        public override async Task<Coupon?> GetByIdAsync(int id)
        {
            return await _DbContext.Coupons
                .Include(c => c.User)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}

