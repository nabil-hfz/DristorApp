using System;
namespace DristorApp.Data.Models
{
	public class CartItem
	{
        public int Id { set; get; }
        public int Quantity { set; get; }

        public ProductVariant  ProductVariant{ set; get; }
        public User User { set; get; }

    }
}

