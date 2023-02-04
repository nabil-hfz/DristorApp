using System;
using Microsoft.AspNetCore.Identity;

namespace DristorApp.Data.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }

        public virtual ICollection<Role> Roles { set; get; }
        public virtual ICollection<Token> Tokens { set; get; }
        public virtual ICollection<Address> Addresses { set; get; }
        public virtual ICollection<CartItem> CartItems { set; get; }
        public virtual ICollection<Coupon> Coupons { set; get; }
   
    }
}

