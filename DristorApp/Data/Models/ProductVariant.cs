namespace DristorApp.Data.Models
{
    public class ProductVariant
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public string Unit { set; get; }
        public float Price { set; get; }

        public Product Product { set; get; }
        public ICollection<CartItem> CartItems { set; get; }
        public ICollection<OrderItem> OrderItems { set; get; }
    }
}