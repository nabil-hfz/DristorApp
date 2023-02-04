using System;
using System.ComponentModel.DataAnnotations;

namespace DristorApp.Data.Models
{
    public class Coupon
    {

        public int Id { set; get; }

        [Range(0, 100)]
        public int Discount { set; get; }

        public virtual  User User { set; get; }

        public virtual OrderItem OrderItem { set; get; }
    }
}

