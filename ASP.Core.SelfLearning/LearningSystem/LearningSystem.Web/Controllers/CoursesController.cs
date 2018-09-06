
namespace LearningSystem.Web.Controllers
{
    using Services;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Data.Models;
    using Models.Courses;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;

    public class CoursesController :Controller
    {
        private readonly ICourseService courses;
        private readonly UserManager<User> userManger;

        public CoursesController(ICourseService courses, UserManager<User> userManger)
        {
            this.courses = courses;
            this.userManger = userManger;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = new CourseDetailsViewModel
            {
                Course = await this.courses.ByIdAsync(id)
            };

            if (model.Course==null)
            {
                return NotFound();
            }
            
            if (User.Identity.IsAuthenticated)
            {
                var userId = this.userManger.GetUserId(User);

                model.UserIsEnrolledInCourse = await this.courses.StudentIsEnrolledInCourseAsync(id, userId);
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task< IActionResult> SignUp(int id)
        {
            var userId = this.userManger.GetUserId(User);

            var success = await this.courses.SignUpStudentAsync(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Thank you for your registration!");
            return RedirectToAction(nameof(Details), new { id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SignOut(int id)
        {
            var userId = this.userManger.GetUserId(User);
            var success = await this.courses.SignOutStudentAsync(id, userId);

            if (!success)
            {
                return BadRequest();
            }

            TempData.AddSuccessMessage("Sorry to see you left!");
            return RedirectToAction(nameof(Details), new { id });
        }
    }
}
