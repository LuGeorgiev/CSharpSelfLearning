namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Services.Admin;
    using Microsoft.AspNetCore.Identity;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using LearningSystem.Web.Areas.Admin.Models.Users;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Data.Models;
    using Infrastructure.Extensions;

   
    public class UsersController: BaseAdminController
    {
        private readonly IAdminUserService users;
        private readonly RoleManager<IdentityRole> rolesManager;
        private readonly UserManager<User> userManager;

        public UsersController(IAdminUserService users, RoleManager<IdentityRole> rolesManager, UserManager<User> userManager)
        {
            this.users = users;
            this.rolesManager = rolesManager;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this.users.AllAsync();

            var roles = await this.rolesManager
                .Roles
                .Select(r => new SelectListItem
                {
                     Text = r.Name,
                     Value=r.Name
                })
                .ToListAsync();

            return View( new UserListingsViewModel
            {
                Users=users,
                Roles=roles
            });
        }

        [HttpPost]
        public async Task<IActionResult> AddToRole(AddUserToRoleFormModel model)
        {
            var roleExists = await this.rolesManager.RoleExistsAsync(model.Role);
            var user = await this.userManager.FindByIdAsync(model.UserId);
            var userExists = user !=null;

            if (!roleExists||!userExists)
            {
                ModelState.AddModelError(string.Empty, "Invalid identity details");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            await this.userManager.AddToRoleAsync(user, model.Role);
            TempData.AddSuccessMessage($"User {user.UserName} successfully added to {model.Role} role!");
            return RedirectToAction(nameof(Index));
        }
    }
}
