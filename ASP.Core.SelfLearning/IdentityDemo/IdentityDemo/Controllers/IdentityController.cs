
namespace IdentityDemo.Controllers
{
    using IdentityDemo.Data;
    using IdentityDemo.Infrastructure;
    using IdentityDemo.Models;
    using IdentityDemo.Models.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles =GlobalConstants.AdministatorRole)]
    public class IdentityController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public IdentityController(ApplicationDbContext db, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult All()
        {
            var users = db.Users
                .OrderBy(x=>x.Email)
                .Select(x => new ListUserViewModel
                {
                    Username=x.UserName,
                    Email=x.Email,
                    Id=x.Id
                })
                .ToList();

            return View(users);
        }

        public async Task<IActionResult> Roles(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user==null)
            {
                return NotFound();
            }

            var roles = await this.userManager.GetRolesAsync(user);

            return View(new UserWithRolesViewModel
            {
                Id=user.Id,
                Email=user.Email,
                Roles=roles
            });
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result =await this.userManager.CreateAsync(new User
            {
                Email=model.Email,
                UserName=model.Email
            }, model.Password);

            if (result.Succeeded)
            {
                this.TempData["SuccessMessage"] = $"User with email: {model.Email} created";
                return RedirectToAction(nameof(All));
            }
            else
            {
                AddModelErrors(result);
                return View(model);
            }

        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);

            if (user==null)
            {
                return NotFound();
            }

            return View(new IdentityChangePasswordViewModel
            {
                Email = user.Email
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(string id, IdentityChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await this.userManager.FindByIdAsync(id);
            if (user==null)
            {
                return NotFound();
            }

            var token = await this.userManager.GeneratePasswordResetTokenAsync(user);
            var result = await this.userManager.ResetPasswordAsync(user, token, model.Password);

            if (result.Succeeded)
            {
                this.TempData["SuccessMessage"] = $"Password changed to user {user.Email}";
                return RedirectToAction(nameof(All));
            }
            else
            {
                AddModelErrors(result);

                return View(model);
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user==null)
            {
                return NotFound();
            }

            return View(new DeleteUserViewModel
            {
                Id=id,
                Email=user.Email
            });
        }

        public async Task<IActionResult> Destroy(string id)
        {
            var user = await this.userManager.FindByIdAsync(id);
            if (user==null)
            {
                return NotFound();
            }

            await this.userManager.DeleteAsync(user);

            TempData["SuccessMessage"] = $"User {user.Email} deleted!";
            return RedirectToAction(nameof(All));
        }

        public IActionResult AddToRole(string id)
        {
            var rolesSelectListItems = this.roleManager.Roles
                .Select(r=> new SelectListItem
                {
                    Text=r.Name,
                    Value=r.Name
                })
                .ToList();

            return View(rolesSelectListItems);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToRole(string id, string role)
        {
            var user = await this.userManager.FindByIdAsync(id);
            var roleExists = await this.roleManager.RoleExistsAsync(role);
            if (user == null|| !roleExists)
            {
                return NotFound();
            }

            await this.userManager.AddToRoleAsync(user, role);

            TempData["SuccessMessage"] = $"User {user.Email} added to {role} role!";
            return RedirectToAction(nameof(All));
        }

        private void AddModelErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
