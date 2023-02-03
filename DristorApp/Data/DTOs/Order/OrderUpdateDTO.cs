using System;
namespace DristorApp.Data.DTOs.Order
{
	public class OrderUpdateDTO
	{
        public int Address { set; get; }
        public List<int> OrderItems { set; get; }

    }
}

