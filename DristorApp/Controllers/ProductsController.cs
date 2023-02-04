using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DristorApp.Data.DTOs.Porduct;
using DristorApp.Data.Models;
using DristorApp.Repositories.BaseRepository;
using DristorApp.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DristorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productsRepository;
        private readonly IRepository<Ingredient, int> _ingredientRepository;
        private readonly IRepository<ProductVariant, int> _productVariantRepository;

        public ProductsController(
            IProductRepository productsRepository,
            IRepository<Ingredient, int> ingredientRepository,
            IRepository<ProductVariant, int> productVariantRepository)
        {
            _productsRepository = productsRepository;
            _ingredientRepository = ingredientRepository;
            _productVariantRepository = productVariantRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _productsRepository.GetAllProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productsRepository.GetProductByIdAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, [FromBody] ProductUpdateDTO dto)
        {
            var product = await _productsRepository.GetProductByIdAsync(id);
            if (product is null)
            {
                return NotFound();
            }
            if(product.Ingredients is not null)
                product.Ingredients.Clear();

            if (product.ProductVariants is not null) 
                product.ProductVariants.Clear();

            foreach (var ingredientId in dto.Ingredients)
            {
                var ingredient = await _ingredientRepository.GetByIdAsync(ingredientId);
                if (ingredient is null)
                {
                    return NotFound();
                }
                if (product.Ingredients is null) product.Ingredients = new Collection<Ingredient>();
                product.Ingredients?.Add(ingredient);
            }

            foreach (var productVariantId in dto.ProductVariants)
            {
                var productVariant = await _productVariantRepository.GetByIdAsync(productVariantId);
                if (productVariant is null)
                {
                    return NotFound();
                }
                if (product.ProductVariants is null) product.ProductVariants = new Collection<ProductVariant>();
                product.ProductVariants?.Add(productVariant);
            }

            product.Name = dto.Name;

            await _productsRepository.UpdateAsync(product);

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] ProductCreateDTO dto)
        {
            var ingredients = (await _ingredientRepository.GetAllAsync())
                .Where(ingredient => dto.Ingredients.Contains(ingredient.Id))
                .ToList();
            var variants = (await _productVariantRepository.GetAllAsync())
                .Where(variant => dto.ProductVariants.Contains(variant.Id))
                .ToList();

            var product = new Product
            {
                Name = dto.Name,
                Ingredients = ingredients,
                ProductVariants = variants
            };
            await _productsRepository.UpdateAsync(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productsRepository.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await _productsRepository.DeleteAsync(product);

            return NoContent();
        }
    }
}