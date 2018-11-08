using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services;
using EstateManagment.Web.Areas.Admin.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EstateManagment.Web.Areas.Admin.Controllers
{
    public class UsersController : AdminController
    {
        private readonly IUsersService users;
        private readonly UserManager<User> userManager;
        private readonly IMapper mapper;

        public UsersController(IUsersService users, UserManager<User> userManager, IMapper mapper)
        {
            this.users = users;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        //TODO create filter to check  that logged user is different than one that is to be promoted
        public async Task<IActionResult> MakeAdmin(string id)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            if (id==currentUser.Id)
            {
                return BadRequest();
            }

            var userToMake = await this.users.GetUserWithRolesAsync(id);            
            return View(userToMake);
        }

        public async Task<IActionResult> ConfirmAdmin(string id)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);
            if (id == currentUser.Id)
            {
                return BadRequest();
            }

            var userConfirmed = await this.users.GetUserAsync(id);
            await this.userManager.AddToRoleAsync(userConfirmed, WebConstants.AdminRole);

            return Redirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> MakeAccountant(string id)
        {           

            var userToSetAccountant = await this.users.GetUserAsync(id);
            await this.userManager.AddToRoleAsync(userToSetAccountant, WebConstants.AccountantRole);

            var model = await this.users.GetUserWithRolesAsync(id);
            return View(model);
        }

        public async Task<IActionResult> RemoveRole(string id)
        {
            var userToRemoveRole = await this.users.GetUserWithRolesAsync(id);           

            return View(userToRemoveRole);
        }

        [HttpPost]
        public async Task<IActionResult> DoRemoveRole(string role, string id)
        {
            var userToRemoveRole = await this.users.GetUserAsync(id);
            var result = await this.userManager.RemoveFromRoleAsync(userToRemoveRole, role);

            return Redirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> MakeManager(string id)
        {    
            var userToSetManager = await this.users.GetUserAsync(id);
            await this.userManager.AddToRoleAsync(userToSetManager, WebConstants.ManagerRole);
            var model = await this.users.GetUserWithRolesAsync(id);

            return View(model);
        }

        public async Task<IActionResult> Ban(string id)
        {
            var model = await this.users.GetUserWithRolesAsync(id);
            return View(model);
        }

        public async Task<IActionResult> ConfirmBan(string id)
        {
            var userToBan = await this.users.GetUserAsync(id);
            await this.userManager.SetLockoutEndDateAsync(userToBan,new DateTimeOffset(new DateTime(2000,12,12)));

            return Redirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await this.users.GetUserWithRolesAsync(id);

            return View(model);
        }

    }
}