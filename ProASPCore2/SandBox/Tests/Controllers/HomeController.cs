using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tests.Infrastructure.Filters;
using Tests.Models;

namespace Tests.Controllers
{
    [TypeFilter(typeof(DiagnosticFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository repo;

        public HomeController(ILogger<HomeController> logger, IRepository repo)
        {
            _logger = logger;
            this.repo = repo;
        }

        public IActionResult Index()
            => this.View(repo.Reservations);

        [HttpPost]
        public IActionResult AddReservation(Reservation reservation)
        {
            this.repo.AddReservation(reservation);

            return this.RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
