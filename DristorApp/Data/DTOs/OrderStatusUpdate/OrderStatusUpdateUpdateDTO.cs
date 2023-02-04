using System;
namespace DristorApp.Data.DTOs.OrderStatusUpdate

{
    public class OrderStatusUpdateUpdateDTO
    {
        public int Id { set; get; }
        public string Status { set; get; }
        public DateTime TimesTamp { set; get; }

        public int OrderId { set; get; }
    }
}


