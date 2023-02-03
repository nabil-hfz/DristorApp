using System;
namespace DristorApp.Data.Models
{
    public class Ingredient
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public bool Allergen { set; get; }
        public bool Spicy { set; get; }

        public ICollection<Product> Products { set; get; }
    }
}

