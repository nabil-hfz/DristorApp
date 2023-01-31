using System;
using DristorApp.Data.db;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using Microsoft.EntityFrameworkCore;

namespace DristorApp.Repositories.ProductRepository
{
    public class ImplProductRepository : ImplRepository<Product, int>,
        IProductRepository
    {
        public ImplProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _DbContext
                    .Products
                    .Include(product => product.Ingredients)
                    .Include(product => product.ProductVariants)
                    .ToListAsync();

        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _DbContext
                .Products
                .Include(product => product.Ingredients)
                .Include(product => product.ProductVariants)
                .FirstOrDefaultAsync(product => product.Id == id);

        }

    }

}