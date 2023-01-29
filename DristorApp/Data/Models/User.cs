using System;
using Microsoft.AspNetCore.Identity;

namespace DristorApp.Data.Models
{
	public class User : IdentityUser<int>
    {
		public string FirstName { set; get; }
		public string LastName { set; get; }

		public ICollection<Role> Roles { set; get; }
        public ICollection<Token> Tokens { set; get; }
        public ICollection<Address> Addresses { set; get; }
        public ICollection<CartItem> CartItems { set; get; }
        public ICollection<Coupon> Coupons { set; get; }

    }
}

