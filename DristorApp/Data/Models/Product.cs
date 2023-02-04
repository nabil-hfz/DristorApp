using System;
namespace DristorApp.Data.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }

        public virtual ICollection<Ingredient> Ingredients { set; get; }
        public virtual ICollection<ProductVariant> ProductVariants { set; get; }

    }
}

