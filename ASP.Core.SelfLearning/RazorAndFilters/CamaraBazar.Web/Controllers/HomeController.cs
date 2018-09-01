
namespace CamaraBazar.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using CamaraBazar.Web.Models;
    using CamaraBazar.Web.Infrastricture.Filters;

    [Log]
    public class HomeController : Controller
    {
        [MeasureTime]
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
