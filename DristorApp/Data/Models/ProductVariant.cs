namespace DristorApp.Data.Models
{
    public class ProductVariant
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
        public string Unit { set; get; }
        public float Price { set; get; }

        public virtual Product Product { set; get; }
        public virtual ICollection<CartItem> CartItems { set; get; }
        public virtual ICollection<OrderItem> OrderItems { set; get; }
    }
}