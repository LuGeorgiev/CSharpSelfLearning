using System;
using System.Threading.Tasks;

namespace LearningSystem.Services.Admin
{
    public interface IAdminCourseService
    {
        // void metnhods do not have to be async void because we cannot catch exceptions etc.
        Task CreateAsync(
            string name,
            string description,
            DateTime startDate,
            DateTime endDate,
            string trainerId);
    }
}
