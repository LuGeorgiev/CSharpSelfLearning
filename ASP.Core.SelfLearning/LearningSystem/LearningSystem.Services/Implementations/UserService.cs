namespace LearningSystem.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using LearningSystem.Data;
    using LearningSystem.Data.Models;
    using LearningSystem.Services.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly LearningSystemDbContext db;
        private readonly IMapper mapper;
        private readonly IPdfGenerator pdfGenerator;

        public UserService(LearningSystemDbContext db, IMapper mapper, IPdfGenerator pdfGenerator)
        {
            this.db = db;
            this.mapper = mapper;
            this.pdfGenerator = pdfGenerator;
        }

        public async Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText)
        {
            searchText = searchText ?? string.Empty;

            var users = await this.db
                .Users
                .OrderBy(u => u.UserName)
                .Where(u => u.UserName.ToLower().Contains(searchText.ToLower())
                || u.Name.ToLower().Contains(searchText.ToLower()))
                .Include(u=>u.Courses)
                .ToListAsync();

            var mappedUsers = mapper.Map<IEnumerable<UserListingServiceModel>>(users);

            return mappedUsers;
        }

        public async Task<byte[]> GetPdfCertificate(int courseId, string studentId)
        {
            var studentInCourse = await this.db
                .FindAsync<StudentCourse>(courseId, studentId);
            if (studentInCourse==null)
            {
                return null;
            }

            var certificate = await this.db
                .Courses
                .Where(c => c.Id == courseId)
                .Select(c => new
                {
                    CourseName = c.Name,
                    CoursStartDate = c.StartDate,
                    CourseEndDate = c.EndDate,
                    StudentName = c.Stiudents
                        .Where(s=>s.StudentId==studentId)
                        .Select(s=>s.Student.Name)
                        .FirstOrDefault(),
                    StudentGrade = c.Stiudents
                        .Where(s=>s.StudentId==studentId)
                        .Select(s=>s.Grade)
                        .FirstOrDefault(),
                    Trainer = c.Trainer.Name
                })
                .FirstOrDefaultAsync();


            return this.pdfGenerator.GeneratePdfFromHtml(string.Format(
                ServiceConstants.PdfCertificateFormat,
                certificate.CourseName,
                certificate.CoursStartDate.ToShortDateString(),
                certificate.CourseEndDate.ToShortDateString(),
                certificate.StudentName,
                certificate.StudentGrade,
                certificate.Trainer,
                DateTime.UtcNow.ToShortDateString()));
        }

        public async Task<UserProfileServiceModel> ProfileAsync(string id)
        {
            //This way automapper cannot retrive correctly courses and I cannot fix it :(

            //var student = await this.db
            //    .Users
            //    .Include(u=>u.Courses)
            //    .Where(u => u.Id == id)
            //    .FirstOrDefaultAsync();
            //var mappedModel = mapper.Map<UserProfileServiceModel>(student);

            var mappedModel = await this.db
                .Users
                //.Include(u => u.Courses)
                //.ThenInclude(c => c.Course)
                .Where(u => u.Id == id)
                .Select(u => new UserProfileServiceModel
                {
                    Name = u.Name,
                    UserName = u.UserName,
                    BirthDate = u.BirthDate,
                    Courses = u.Courses
                        .Where(sc => sc.StudentId == u.Id)
                        .Select(sc => new UserProfileCourseServiceModel
                        {
                            Name = sc.Course.Name,
                            Id = sc.CourseId,
                            Grade = sc.Grade
                        })
                        .ToList()
                })
                .FirstOrDefaultAsync();


            return mappedModel;
        }
    }
}
