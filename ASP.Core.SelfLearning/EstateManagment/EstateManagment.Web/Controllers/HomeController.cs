using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EstateManagment.Web.Models;
using EstateManagment.Services.Areas.Payments;

namespace EstateManagment.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPaymentsService payments;

        public HomeController(IPaymentsService payments)
        {
            this.payments = payments;
        }

        public async Task<IActionResult> Index()
        {
            var model = await payments.MonthIncomeStatistic(DateTime.Today.AddMonths(-1));
            return View(model);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
