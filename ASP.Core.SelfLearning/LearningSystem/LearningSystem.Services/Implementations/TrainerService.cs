namespace LearningSystem.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class TrainerService : ITrainerService
    {
        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;

        public TrainerService(LearningSystemDbContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task<bool> AddGradeAsync(int courseId, string studentId, Grade grade)
        {
            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);

            if (studentInCourse == null)
            {
                return false;
            }

            studentInCourse.Grade = grade;
            await this.db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId)
        {
            var courses = await this.db
                .Courses
                .Where(c => c.TrainerId == trainerId)
                .ToListAsync();

            return mapper.Map<IEnumerable<CourseListingServiceModel>>(courses);
        }

        public async Task<byte[]> GetExamSubmissionAsync(int courseId, string studentId)
            => (await this.db
                .FindAsync<StudentCourse>(courseId, studentId))
                ?.ExamSubmission;

        public async Task<bool> IsTrainerAsync(int courseId, string trainerId)
            => await this.db
                .Courses
                .AnyAsync(c => c.Id == courseId && c.TrainerId == trainerId);

        public async Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId)
        {
            //var studentsInCourse = await this.db
            //    .Courses
            //    .Where(c => c.Id == courseId)               
            //    .SelectMany(c => c.Stiudents.Select(s => s.Student))
            //    .ToListAsync();

            //return mapper.Map<IEnumerable<StudentInCourseServiceModel>>(studentsInCourse);

            var course = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Include(c => c.Stiudents)
                .ThenInclude(c => c.Student)
                .FirstOrDefaultAsync();

            var students = course
                .Stiudents
                .Select(s => new StudentInCourseServiceModel
                {
                    Id = s.StudentId,
                    Email = s.Student.Email,
                    Name = s.Student.Name,
                    Grade = s.Grade
                })
                .ToList();

            return students;
        }

        public async Task<StudentInCourseNamesServiceModel> StudentsInCourseNamesAsync(int courseId, string studentId)
        {
            var courseName = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();

            if (courseName == null)
            {
                return null;
            }

            var studentName = await this.db
                .Users
                .Where(c => c.Id == studentId)
                .Select(c => c.UserName)
                .FirstOrDefaultAsync();

            if (studentName == null)
            {
                return null;
            }

            return new StudentInCourseNamesServiceModel
            {
                 CourseTitle=courseName,
                 UserName = studentName
            };
        }
    }
}
