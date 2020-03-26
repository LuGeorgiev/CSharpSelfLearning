using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Users.Models;
using Users.Models.Enums;

namespace Users.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public HomeController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        //[Authorize]
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login","Account");
            }

            //return View(new Dictionary<string, object> {["Placeholder"] = "Placeholder" });
            return View(GetData(nameof(Index)));
        }

        //[Authorize(Roles = "Users")]
        [Authorize(Policy = "DCUsers")]
        public IActionResult OtherAction() => ViewComponent("Index", GetData(nameof(OtherAction)));

        [Authorize]
        public async Task<IActionResult> UserProps()
        {
            return View(await CurrentUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UserProps([Required] Cities city, [Required] QualificationLevels qualification)
        {
            if (ModelState.IsValid)
            {
                var user = await CurrentUser;
                user.City = city;
                user.Qualification = qualification;
                await userManager.UpdateAsync(user);

                return RedirectToAction("Index");
            }

            return View(await CurrentUser);
        }


        private Dictionary<string, object> GetData(string actionName)
            => new Dictionary<string, object> 
            {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["Is In Role"] = HttpContext.User.IsInRole("User"),
                ["City"] = CurrentUser.Result.City,
                ["Qualification"] = CurrentUser.Result.Qualification
            };

        private Task<AppUser> CurrentUser
            => userManager.FindByNameAsync(HttpContext.User.Identity.Name);        
        
    }
}
