using System;
namespace DristorApp.Data.DTOs.Orderitem
{
    public class OrderItemCreateDTO
    {
        public int ProductVariant { set; get; }
        public int Order { set; get; }

        public int Quantity { set; get; }
    }


}

