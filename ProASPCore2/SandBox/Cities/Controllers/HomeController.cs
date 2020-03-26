using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Cities.Models;

namespace Cities.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository repo;

        public HomeController(IRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Index()
            => View(repo.Cities);


        public ViewResult Create()
            => View();


        [HttpPost]
        public IActionResult Create(City city)
        {
            this.repo.AddCity(city);
            return RedirectToAction(nameof(Index));
        }
    }
}
