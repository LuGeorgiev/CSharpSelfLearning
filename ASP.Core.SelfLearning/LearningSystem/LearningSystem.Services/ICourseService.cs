namespace LearningSystem.Services
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Models;

    public interface ICourseService
    {
        Task<IEnumerable<CourseListingServiceModel>> Active();
    }
}
