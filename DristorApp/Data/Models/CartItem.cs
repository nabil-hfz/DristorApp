using System;
namespace DristorApp.Data.Models
{
    public class CartItem
    {
        public int Id { set; get; }
        public int Quantity { set; get; }

        public virtual ProductVariant ProductVariant { set; get; }
        public virtual  User User { set; get; }

    }
}

