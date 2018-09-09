
namespace LearningSystem.Services.Implementations
{
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using LearningSystem.Data;
    using LearningSystem.Services.Models;
    using System;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;
    using LearningSystem.Data.Models;

    public class CourseService : ICourseService
    {
        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;

        public CourseService(LearningSystemDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> ActiveAsync()
        {
            var courses = await this.db
                            .Courses
                            .OrderByDescending(x => x.Id)
                            .Where(c => c.StartDate >= DateTime.UtcNow)
                            .ToListAsync();

            return this.mapper.Map<IEnumerable<CourseListingServiceModel>>(courses);
        }

        public async Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            var courses = await this.db
                          .Courses
                          .OrderByDescending(x => x.Id)
                          .Where(c => c.Name.ToLower().Contains(searchText.ToLower()))
                          .ToListAsync();

            return this.mapper.Map<IEnumerable<CourseListingServiceModel>>(courses);
        }

        public async Task<TModel> ByIdAsync<TModel>(int id) 
            where TModel : class
        {
            var course = await this.db
                .Courses
                .Where(x => x.Id == id)
                .Include(x=>x.Stiudents)
                .Include(x=>x.Trainer)
                .FirstOrDefaultAsync();

            return mapper.Map<TModel>(course);               
        }


        // In order to use this in TrainersController also have to refactor to be used with Generic. Check above
        //public async Task<CourseDetailsServiceModel> ByIdAsync(int id)
        //{
        //    var course = await this.db
        //        .Courses
        //        .Where(x => x.Id == id)
        //        .Include(x => x.Stiudents)
        //        .Include(x => x.Trainer)
        //        .FirstOrDefaultAsync();

        //    return mapper.Map<CourseDetailsServiceModel>(course);
        //}
        public async Task<bool> SignOutStudentAsync(int courseId, string studentId)
        {
            var courseInfo =  await this.GetCourseStudentInfo(courseId, studentId);

            if (courseInfo==null
                ||courseInfo.StartDate<DateTime.UtcNow
                ||!courseInfo.StudentIsEnrolledInCourse)
            {
                return false;
            }

            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);

            this.db.Remove(studentInCourse);
            await this.db.SaveChangesAsync();

            return true;
        }        

        public async Task<bool> SignUpStudentAsync(int courseId, string studentId)
        {
            var courseInfo = await  this.GetCourseStudentInfo(courseId, studentId);

            if (courseInfo==null||courseInfo.StartDate<DateTime.UtcNow || courseInfo.StudentIsEnrolledInCourse)
            {
                return false;
            }

            var studentInCourst = new StudentCourse
            {
                CourseId=courseId,
                StudentId=studentId
            };
            await db.AddAsync(studentInCourst);
            await db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> StudentIsEnrolledInCourseAsync(int courseId, string userId)
            => await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId && c.Stiudents.Any(s => s.StudentId == userId));

        private async Task<CourseWithStudentInfo> GetCourseStudentInfo(int courseId, string studentId)
                => await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new CourseWithStudentInfo
                {
                    StartDate=c.StartDate,
                    StudentIsEnrolledInCourse = c.Stiudents.Any(s => s.StudentId == studentId)
                })
                .FirstOrDefaultAsync();

        public async Task<bool> SaveExamSubmissionAsync(int courseId, string studentId, byte[] examSubmission)
        {
            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse==null)
            {
                return false;
            }

            studentInCourse.ExamSubmission = examSubmission;
            await this.db.SaveChangesAsync();
            return true;
        }
    }
}
