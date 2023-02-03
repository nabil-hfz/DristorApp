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
        public override string ToString()
        {
            string roles = "No roles";
            foreach (var rol in Roles) {
                roles += rol.ToString();
                roles += ' ';
            }
            return string.Format("FirstName: {0}, LastName: {1},Addresses: {2}, CartItems: {3}, Coupons: {4}, Roles: [{5}]",
                FirstName, LastName, Tokens, Addresses, CartItems, Coupons, roles);
        }
    }
}

