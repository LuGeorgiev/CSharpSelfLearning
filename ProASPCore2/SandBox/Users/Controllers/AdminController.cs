using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;
        private readonly IUserValidator<AppUser> userValidator;
        private readonly IPasswordValidator<AppUser> passwordValidator;
        private readonly IPasswordHasher<AppUser> passwordHasher;


        public AdminController(UserManager<AppUser> userManager,
            IUserValidator<AppUser> userValidator,
            IPasswordValidator<AppUser> passwordValidator,
            IPasswordHasher<AppUser> passwordHasher)
        {
            this.userManager = userManager;
            this.userValidator = userValidator;
            this.passwordValidator = passwordValidator;
            this.passwordHasher = passwordHasher;
        }

        public ViewResult Index() => View(userManager.Users);

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser
            {
                UserName = model.Name,
                Email = model.Email
            };

            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "UserNotFound");
            }

            return View("Index", userManager.Users);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string mail, string password)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                user.Email = mail;
                IdentityResult validMail = await userValidator.ValidateAsync(userManager, user);
                if (!validMail.Succeeded)
                {
                    AddErrorsFromResult(validMail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrWhiteSpace(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validMail.Succeeded && validPass == null) || password != String.Empty && validPass.Succeeded)
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }

            return View(user);
        }
    }
}
