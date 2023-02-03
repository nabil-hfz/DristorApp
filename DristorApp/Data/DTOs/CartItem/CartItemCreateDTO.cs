using System;
namespace DristorApp.Data.DTOs.CartItem
{
    public class CartItemCreateDTO
    {
        public int Quantity { set; get; }
        public int User { set; get; }

        public int ProductVariant { set; get; }

    }
}

