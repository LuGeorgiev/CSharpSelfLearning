namespace LearningSystem.Web.Areas.Admin.Controllers
{
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Admin;
    using LearningSystem.Web.Areas.Admin.Models.Courses;
    using LearningSystem.Web.Controllers;
    using LearningSystem.Web.Infrastructure.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CoursesController : BaseAdminController
    {
        private readonly UserManager<User> userManager;
        private readonly IAdminCourseService courses;

        public CoursesController(UserManager<User> userManager, IAdminCourseService courses)
        {
            this.userManager = userManager;
            this.courses = courses;
        }

        public async Task<IActionResult> Create()
        {
            var trainerListItems = await this.GetTrainers();

            return View(new AddCourseFormModel
            {
                StartDate=DateTime.UtcNow,
                EndDate=DateTime.UtcNow.AddDays(30),
                Trainers = trainerListItems
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddCourseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Trainers = await this.GetTrainers();
                return View(model);
            }
                        
            await this.courses.CreateAsync(
                model.Name,
                model.Description, 
                model.StartDate, 
                model.EndDate.AddDays(1), 
                model.TrainerId);

            TempData.AddSuccessMessage($"Coures {model.Name } created successfully!");

            //instead redirect ("/Home/Index") , new {} in order to get out of this area SAME AS return Redirect("/")
            return RedirectToAction(nameof(HomeController.Index),
                "Home",
                new { area=string.Empty});
        }

        private async Task<IEnumerable<SelectListItem>> GetTrainers()
        {
            var trainers = await this.userManager
                .GetUsersInRoleAsync(WebConstants.TrainerRole);

            var trainerListItems = trainers
                .Select(t => new SelectListItem
                {
                    Text = t.UserName,
                    Value = t.Id
                })
                .ToList();
            
            return trainerListItems;
        }
    }
}
