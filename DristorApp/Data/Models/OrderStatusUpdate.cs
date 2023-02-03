using System;
namespace DristorApp.Data.Models
{
    public class OrderStatusUpdate
    {
        public int Id { set; get; }
        public string Status { set; get; }
        public DateTime TimesTamp { set; get; }

        public int OrderId { set; get; }
        public Order Order { set; get; }
    }
}

