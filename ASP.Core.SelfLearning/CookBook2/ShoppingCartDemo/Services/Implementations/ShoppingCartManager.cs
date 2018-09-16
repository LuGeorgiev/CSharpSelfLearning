namespace ShoppingCartDemo.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using ShoppingCartDemo.Services.Models;

    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> carts;

        public ShoppingCartManager()
        {
            this.carts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string cartId, int productId)
        {
            //Will return the card if it doesnt exist will be created
            var shoppingCart = this.GetShoppingCart(cartId);

            shoppingCart.AddToCart(productId);
        }

        public void RemoveFromCart(string cartId, int productId)
        {
            var shoppingCart = this.GetShoppingCart(cartId);

            shoppingCart.RemoveFromCart(productId);
        }

        public IEnumerable<CartItem> GetItems(string cartId)
        {
            var shoppingCart = this.GetShoppingCart(cartId);

            return new List<CartItem>(shoppingCart.Items);
        }

        private ShoppingCart GetShoppingCart(string id)
        {
            return this.carts.GetOrAdd(id, new ShoppingCart());
        }

        public void Clear(string cartId)
            =>this.GetShoppingCart(cartId).Clear();
        
    }
}
