using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstateManagment.Web.Controllers
{
    public class RentsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(int model)
        {
            return View();
        }

        public async Task<IActionResult> Terminate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Terminate(DateTime endDate)
        {
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string description, string parkingDescriptionpre)
        {
            return View();
        }

        public async Task<IActionResult> ReSign()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReSign(string description, string parkingDescriptionpre)
        {
            return View();
        }
    }
}
