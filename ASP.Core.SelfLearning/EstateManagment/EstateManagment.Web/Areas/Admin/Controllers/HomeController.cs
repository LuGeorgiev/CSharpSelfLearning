using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Data.Models;
using EstateManagment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Admin.Controllers
{   
    public class HomeController : AdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IUsersService users;

        public HomeController(UserManager<User> userManager, IUsersService users)
        {
            this.userManager = userManager;
            this.users = users;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var model = await this.users.AllNonAdminsAsync(user.Id);

            return View(model);
        }
    }
}