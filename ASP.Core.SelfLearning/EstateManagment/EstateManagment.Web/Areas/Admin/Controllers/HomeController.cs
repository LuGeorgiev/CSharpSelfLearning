using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Admin.Controllers
{   
    public class HomeController : AdminController
    {
        private readonly UserManager<User> userManager;

        public HomeController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}