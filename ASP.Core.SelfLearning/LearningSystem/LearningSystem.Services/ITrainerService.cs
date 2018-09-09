﻿namespace LearningSystem.Services
{
    using Data.Models;
    using Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ITrainerService
    {
        Task<IEnumerable<CourseListingServiceModel>> CoursesAsync(string trainerId);

        Task<IEnumerable<StudentInCourseServiceModel>> StudentsInCourseAsync(int courseId);

        Task<bool> IsTrainerAsync(int courseId, string trainerId);

        Task<bool> AddGradeAsync(int courseId, string studentId, Grade grade);

        Task<byte[]> GetExamSubmissionAsync(int courseId, string studentId);

        Task<StudentInCourseNamesServiceModel> StudentsInCourseNamesAsync(int courseId, string studentId);
    }
}
