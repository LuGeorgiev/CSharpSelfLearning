
namespace ShoppingCartDemo.Services
{
    using ShoppingCartDemo.Services.Models;
    using System.Collections.Generic;

    public interface IShoppingCartManager
    {
        void AddToCart(string cartId, CartItem cartItem);

        void RemoveFromCart(string cartId, int productId);

        IEnumerable<CartItem> GetItems(string cartId);
    }
}
