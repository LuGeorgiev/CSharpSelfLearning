using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateManagment.Data.Models;
using EstateManagment.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EstateManagment.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IUsersService users;
        private readonly UserManager<User> userManager;

        public UsersController(IUsersService users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public async Task<IActionResult> MakeAdmin(string id)
        {
            var currentUSer = await this.userManager.GetUserAsync(this.User);
            if (id==currentUSer.Id)
            {
                return BadRequest();
            }

            var userToMake = await this.users.GetUserWithRolesAsync(id);

            return View(userToMake);
        }

        public async Task<IActionResult> ConfirmAdmin(string id)
        {
            var currentUSer = await this.userManager.GetUserAsync(this.User);
            if (id == currentUSer.Id)
            {
                return BadRequest();
            }
            var userConfirmed = await this.users.GetUserAsync(id);
            await this.userManager.AddToRoleAsync(userConfirmed, WebConstants.AdminRole);

            return Redirect("/");
        }

        public async Task<IActionResult> MakeAccountant(string id)
        {
            return View();
        }

        public async Task<IActionResult> RemoveRole(string id)
        {
            return View();
        }

        public async Task<IActionResult> MakeManager(string id)
        {
            var currentUSer = await this.userManager.GetUserAsync(this.User);
            if (id == currentUSer.Id)
            {
                return BadRequest();
            }

            return View();
        }

        public async Task<IActionResult> Ban(string id)
        {
            return View();
        }

    }
}