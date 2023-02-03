using System;
using System.ComponentModel.DataAnnotations;

namespace DristorApp.Data.Models
{
    public class Order
    {
        public int Id { set; get; }
        [Required]
        public Address Address { set; get; }
        public ICollection<OrderStatusUpdate> OrderStatusUpdates { set; get; }
        public ICollection<OrderItem> OrderItems { set; get; }

    }
}

