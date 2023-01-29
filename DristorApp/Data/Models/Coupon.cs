using System;
using System.ComponentModel.DataAnnotations;

namespace DristorApp.Data.Models
{
	public class Coupon
	{

		public int Id {set; get;}

		[Range(0, 100)]
		public int Discount { set; get; }

		public User User { set; get; }
		public OrderItem OrderItem { set; get; }
    }
}

