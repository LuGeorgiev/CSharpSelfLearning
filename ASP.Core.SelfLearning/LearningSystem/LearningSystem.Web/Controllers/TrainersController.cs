namespace LearningSystem.Web.Controllers
{
    using Data.Models;
    using Services;
    using Models.Trainer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using LearningSystem.Services.Models;
    using System;

    [Authorize(Roles =WebConstants.TrainerRole)]
    public class TrainersController:Controller
    {
        private readonly ITrainerService trainers;
        private readonly UserManager<User> userManager;
        private readonly ICourseService courses;

        public TrainersController(ITrainerService trainers, UserManager<User> userManager, ICourseService courses)
        {
            this.trainers = trainers;
            this.userManager = userManager;
            this.courses = courses;
        }

        public async Task< IActionResult> Courses()
        {
            var userId = this.userManager.GetUserId(User);

            var courses = await this.trainers.CoursesAsync(userId);

            return View(courses);
        }

        public async Task<IActionResult> Students(int id)
        {
            var userId = this.userManager.GetUserId(User);

            if (!await this.trainers.IsTrainerAsync(id, userId))
            {
                return NotFound();
            }

            var students = await this.trainers.StudentsInCourseAsync(id);

            return View(new StudentsInCourseViewModel
            {
                Students=students,
                Course = await this.courses.ByIdAsync<CourseListingServiceModel>(id)
            });
        }

        [HttpPost]
        public async Task<IActionResult> GradeStudent(int id, string studentId, Grade grade)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);
            if (!await this.trainers.IsTrainerAsync(id, userId))
            {
                return BadRequest();
            }

            var success = await this.trainers.AddGradeAsync(id, studentId, grade);
            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Students), new { id });
        }

        public async Task<IActionResult> DownloadExam(int id, string studentId)
        {
            if (string.IsNullOrEmpty(studentId))
            {
                return BadRequest();
            }

            var userId = this.userManager.GetUserId(User);
            if (!await this.trainers.IsTrainerAsync(id, userId))
            {
                return BadRequest();
            }

            var examContent = await this.trainers.GetExamSubmissionAsync(id, studentId);

            if (examContent == null)
            {
                return BadRequest();
            }

            var studentInCourse = await this.trainers
                .StudentsInCourseNamesAsync(id, studentId);
            if (studentInCourse==null)
            {
                return BadRequest();
            }

            return File(
                examContent, 
                "application/zip",
                $"{studentInCourse.CourseTitle}-{studentInCourse.UserName}-{DateTime.UtcNow.ToString("MM-dd-yyyy")}.zip");
        }
    }
}
