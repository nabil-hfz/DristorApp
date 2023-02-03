using System;
namespace DristorApp.Data.DTOs.Porduct
{
    public class ProductUpdateDTO
    {
        public string Name { set; get; }
        public List<int> Ingredients { set; get; }
        public List<int> ProductVariants { set; get; }
    }
}

