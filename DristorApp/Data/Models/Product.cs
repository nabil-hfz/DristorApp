using System;
namespace DristorApp.Data.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public ICollection<Ingredient> Ingredients { set; get; }
        public ICollection<ProductVariant> ProductVariants { set; get; }

    }
}

