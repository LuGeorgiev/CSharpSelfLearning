namespace LearningSystem.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<IEnumerable<CourseListingServiceModel>> FindAsync(string searchText);

        Task<TModel> ByIdAsync<TModel>(int id) where TModel:class;

        Task<bool> SignUpStudentAsync(int courseId, string userId);

        Task<bool> StudentIsEnrolledInCourseAsync(int courseId, string userId);

        Task<bool> SignOutStudentAsync(int courseId, string userId);

    
        Task<bool> SaveExamSubmissionAsync(int courseId, string studentId, byte[] examSubmission);
    }
}
