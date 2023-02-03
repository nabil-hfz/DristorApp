using System;
namespace DristorApp.Data.Models
{
	public class OrderItem
	{
		public int Id { set; get; }
		public int Quantity { set; get; }

		public int? CouponId { set; get; }
		public Coupon Coupon { set; get; }
		public ProductVariant ProductVariant { set; get; }
		public Order Order { set; get; }
	}
}

