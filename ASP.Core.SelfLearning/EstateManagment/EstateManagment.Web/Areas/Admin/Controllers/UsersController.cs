using System;
using System.Threading.Tasks;
using AutoMapper;
using EstateManagment.Data.Models;
using EstateManagment.Services;
using EstateManagment.Web.Common.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
            var result = await this.userManager.AddToRoleAsync(userConfirmed, WebConstants.AdminRole);
            if (!result.Succeeded)
            {
                TempData.AddErrorMessage("Добавянето на ролята администратор не беше успешно");
                return Redirect("/Admin/Home/Index");
            }

            TempData.AddSuccessMessage("Добавянето на ролята администратор мина беше успешно");
            return Redirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> MakeAccountant(string id)
        {           

            var userToSetAccountant = await this.users.GetUserAsync(id);
            var result = await this.userManager.AddToRoleAsync(userToSetAccountant, WebConstants.AccountantRole);
            if (!result.Succeeded)
            {
                TempData.AddErrorMessage("Добавянето на ролята счетоводител не беше успешно");
                return Redirect("/Admin/Home/Index");
            }

            var model = await this.users.GetUserWithRolesAsync(id);
            TempData.AddSuccessMessage("Добавянето на ролята счетоводител беше успешно");
            return View(model);
        }

        public async Task<IActionResult> RemoveRole(string id)
        {
            var userToRemoveRole = await this.users.GetUserWithRolesAsync(id);
            if (userToRemoveRole==null)
            {
                return BadRequest();
            }
            return View(userToRemoveRole);
        }

        [HttpPost]
        public async Task<IActionResult> DoRemoveRole(string role, string id)
        {
            var userToRemoveRole = await this.users.GetUserAsync(id);
            if (userToRemoveRole == null)
            {
                return BadRequest();
            }

            var result = await this.userManager.RemoveFromRoleAsync(userToRemoveRole, role);
            if (!result.Succeeded)
            {
                TempData.AddErrorMessage("Релоята не беше премахната!");
                return Redirect("/Admin/Home/Index");
            }

            TempData.AddSuccessMessage("Ролята беше успешно премахната!");
            return Redirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> MakeManager(string id)
        {    
            var userToSetManager = await this.users.GetUserAsync(id);
            if (userToSetManager==null)
            {
                return BadRequest();
            }
            var result = await this.userManager.AddToRoleAsync(userToSetManager, WebConstants.ManagerRole);
            if (!result.Succeeded)
            {
                TempData.AddErrorMessage("Ролята мениджър не беше добавена!");
                return Redirect("/Admin/Home/Index");
            }
            var model = await this.users.GetUserWithRolesAsync(id);

            TempData.AddSuccessMessage("Ролята мениджър беше успешно добавена!");
            return View(model);
        }

        public async Task<IActionResult> Ban(string id)
        {
            var model = await this.users.GetUserWithRolesAsync(id);
            if (model==null)
            {
                return BadRequest();
            }
            return View(model);
        }

        public async Task<IActionResult> ConfirmBan(string id)
        {
            var userToBan = await this.users.GetUserAsync(id);
            if (userToBan==null)
            {
                return BadRequest();
            }
            var result = await this.userManager.SetLockoutEndDateAsync(userToBan,new DateTimeOffset(new DateTime(2000,12,12)));
            if (!result.Succeeded)
            {
                TempData.AddErrorMessage($"{userToBan.UserName} не беше премахнат!");
                return Redirect("/Admin/Home/Index");
            }
            TempData.AddSuccessMessage($"{userToBan.UserName} беше премахнат!");
            return Redirect("/Admin/Home/Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var model = await this.users.GetUserWithRolesAsync(id);

            return View(model);
        }

    }
}