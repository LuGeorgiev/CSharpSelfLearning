
namespace IdentityDemo.Controllers
{
    using IdentityDemo.Data;
    using IdentityDemo.Infrastructure;
    using IdentityDemo.Models;
    using IdentityDemo.Models.Identity;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;

    [Authorize(Roles =GlobalConstants.AdministatorRole)]
    public class IdentityController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<User> userManager;

        public IdentityController(ApplicationDbContext db, UserManager<User> userManager)
        {
            this.db = db;
            this.userManager = userManager;
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

    }
}
