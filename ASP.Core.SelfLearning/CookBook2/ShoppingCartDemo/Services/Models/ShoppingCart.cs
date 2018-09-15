namespace ShoppingCartDemo.Services.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ShoppingCart
    {
        private readonly IList<CartItem> items;

        public ShoppingCart()
        {
            this.items = new List<CartItem>();
        }

        public IEnumerable<CartItem> Items => new List<CartItem>(this.items);

        public void AddToCard(CartItem item)
        {
            if (item==null)
            {
                throw new NullReferenceException("Item was not privided");
            }

            this.items.Add(item);
        }

        public void RemoveFromCart(int productId)
        {
            var cartItem = this.items
                .FirstOrDefault(ci => ci.ProductId == productId);

            if (cartItem!=null)
            {
                this.items.Remove(cartItem);
            }            
        }

    }
}
