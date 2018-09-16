namespace ShoppingCartDemo.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

    }
}
