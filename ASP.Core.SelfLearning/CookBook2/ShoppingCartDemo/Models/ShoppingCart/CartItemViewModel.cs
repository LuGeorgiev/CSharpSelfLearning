using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCartDemo.Models.ShoppingCart
{
    public class CartItemViewModel
    {
        public int ProductId { get; set; }

        public string Title { get; set; }

        public decimal  Price { get; set; }

        public int Quantity { get; set; }
    }
}
