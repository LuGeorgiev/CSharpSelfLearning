namespace ShoppingCartDemo.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using ShoppingCartDemo.Data;
    using ShoppingCartDemo.Models;

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            ////Initial Data seed
            //var db = (ApplicationDbContext)this.HttpContext.RequestServices.GetService(typeof(ApplicationDbContext));
            //for (int i = 0; i < 20; i++)
            //{
            //    db.Products.Add(new Data.Models.Product
            //    {
            //        Title = "Product"+i.ToString(),
            //        Price = i* 100
            //    });
            //}
            //db.SaveChanges();

            var products = this.db.Products
                .OrderByDescending(x=>x.Id)
                .ToList();

            return View(products);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
