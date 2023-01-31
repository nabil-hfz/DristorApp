using System;
namespace DristorApp.Data.DTOs.ProductVariant
{
    public class ProductVariantUpdateDTO
    {
        public string Name { set; get; }
        public int Quantity { set; get; }
        public string Unit { set; get; }
        public float Price { set; get; }

        public int Product { set; get; }
    }
}

