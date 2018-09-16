using ShoppingCartDemo.Models;
using System.Collections.Generic;

namespace ShoppingCartDemo.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        //Address

        public decimal TotalPrice { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
