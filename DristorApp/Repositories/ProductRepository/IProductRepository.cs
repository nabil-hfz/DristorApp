using System;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;

namespace DristorApp.Repositories.ProductRepository
{
	public interface IProductRepository:IRepository<Product , int>
	{
		public Task<List<Product>> GetAllProductsAsync();
        public Task<Product?> GetProductByIdAsync(int id);

    }
}

