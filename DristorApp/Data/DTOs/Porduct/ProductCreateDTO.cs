using System;
namespace DristorApp.Data.DTOs.Porduct
{
	public class ProductCreateDTO
	{
		public string Name { set; get; }
		public List<int> Ingredients { set; get; }
		public List<int> ProductVariants { set; get; }
	}
}

