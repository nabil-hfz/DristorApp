using System;
using System.ComponentModel.DataAnnotations;

namespace DristorApp.Data.Models
{
    public class Order
    {
        public int Id { set; get; }
        [Required]
        public virtual Address Address { set; get; }
        public virtual ICollection<OrderStatusUpdate> OrderStatusUpdates { set; get; }
        public virtual ICollection<OrderItem> OrderItems { set; get; }

    }
}

