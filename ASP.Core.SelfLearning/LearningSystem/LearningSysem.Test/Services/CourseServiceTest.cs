namespace LearningSysem.Test.Services
{
    using Xunit;
    using FluentAssertions;
    using System.Threading.Tasks;
    using LearningSystem.Services.Implementations;
    using LearningSystem.Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using AutoMapper;
    using LearningSystem.Web.Infrastructure.Mapping;
    using LearningSystem.Data.Models;
    using System.Linq;
    using System.Collections.Generic;

    public class CourseServiceTest
    {
        [Fact]
        public async Task FindAsyncShouldReturnCorrectResultsWithFilterAndOrder()
        {
            //To Have static Mapper initialization:
            //Mapper.Initialize(cfg => cfg.AddProfile<AutoMapperProfile>());

            //Arrange            
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            var firstCourses = new Course { Id = 1, Name = "First" };
            var secondCourses = new Course { Id = 2, Name = "Second" };
            var thirdCourses = new Course { Id = 3, Name = "Third" };
            db.Courses.AddRange(firstCourses, secondCourses, thirdCourses);
            await db.SaveChangesAsync();

            var courseService = new CourseService(db, mapper);

            //Act
            var result = await courseService.FindAsync("t");

            //Assert
            result
                .Should()
                .Match(r =>
                        r.ElementAt(0).Id == 3
                        && r.ElementAt(1).Id == 1)
                .And
                .HaveCount(2);
        }

        [Fact]
        public async Task SignUpStudentAsyncShouldSaveCorrectDateWithValidCourseIdAndStudentId()
        {
            var db = this.GetDatabase();
            var mapper = this.GetMapper();

            const int courseId = 1;
            const string studentId = "TestStudentId";
            var course = new Course
            {
                Id = courseId,
                StartDate = DateTime.MaxValue,
                Stiudents = new List<StudentCourse>()
            };

            db.Courses.Add(course);
            await db.SaveChangesAsync();

            var courseService = new CourseService(db, mapper);

            //Act
            var result = await courseService.SignUpStudentAsync(courseId, studentId);
            var savedEntry = db.Find<StudentCourse>(courseId, studentId);

            //Assert
            result
                .Should()
                .Be(true);

            savedEntry
                .Should()
                .NotBeNull();
        }

        private LearningSystemDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<LearningSystemDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())  // Or we can use some TestName with GUID new Db
                .Options;
            var db = new LearningSystemDbContext(dbOptions);

            return db;
        }

        private IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });

            return config.CreateMapper();
        }
    }
}
