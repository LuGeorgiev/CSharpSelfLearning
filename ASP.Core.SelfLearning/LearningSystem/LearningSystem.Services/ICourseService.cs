namespace LearningSystem.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> ActiveAsync();

        Task<CourseDetailsServiceModel> ByIdAsync(int id);

        Task<bool> SignUpStudentAsync(int courseId, string userId);

        Task<bool> StudentIsEnrolledInCourseAsync(int courseId, string userId);

        Task<bool> SignOutStudentAsync(int courseId, string userId);
    }
}
