
namespace ShoppingCartDemo.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using ShoppingCartDemo.Services;
    using System.Linq;
    using ShoppingCartDemo.Infrastructure.Extensions;
    using ShoppingCartDemo.Data;
    using ShoppingCartDemo.Models.ShoppingCart;
    using Microsoft.AspNetCore.Authorization;
    using ShoppingCartDemo.Data.Models;
    using ShoppingCartDemo.Models;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using ShoppingCartDemo.Services.Models;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public ShoppingCartController(IShoppingCartManager shoppingCartManager,
            ApplicationDbContext db,
            UserManager<ApplicationUser> userManager)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.userManager = userManager;
            this.db = db;
        }

        public IActionResult Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager
                .GetItems(shoppingCartId);

            var itemsWithDetails = this.GetCartItems(items);

            return View(itemsWithDetails);
        }

        public IActionResult AddToCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        [Authorize]
        public IActionResult FinishOrder()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();
            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemsDetails = this.GetCartItems(items);

            var order = new Order
            {
                UserId = this.userManager.GetUserId(User),
                TotalPrice = itemsDetails.Sum(i=>i.Price*i.Quantity)                  
            };

            foreach (var item in itemsDetails)
            {
                order.Items.Add(new OrderItem
                {
                    ProductId=item.ProductId,
                    ProductPrice=item.Price,
                    Quantity=item.Quantity
                });
            }

            this.db.Add(order);
            this.db.SaveChanges();

            shoppingCartManager.Clear(shoppingCartId);

            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        private List<CartItemViewModel> GetCartItems(IEnumerable<CartItem> items)
        {
            var itemIds = items.Select(i => i.ProductId);

            var itemsWithDetails=this.db
                .Products
                .Where(pr => itemIds.Contains(pr.Id))
                .Select(pr => new CartItemViewModel
                {
                    ProductId = pr.Id,
                    Price = pr.Price,
                    Title = pr.Title
                })
                .ToList();

            var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);
            itemsWithDetails.ForEach(i => i.Quantity = itemQuantities[i.ProductId]);

            return itemsWithDetails;
        }
        
    }
}
