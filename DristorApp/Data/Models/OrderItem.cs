using System;
namespace DristorApp.Data.Models
{
    public class OrderItem
    {
        public int Id { set; get; }
        public int Quantity { set; get; }

        public int? CouponId { set; get; }
        public virtual Coupon Coupon { set; get; }
        public virtual ProductVariant ProductVariant { set; get; }
        public virtual Order Order { set; get; }
    }
}

