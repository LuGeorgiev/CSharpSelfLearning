﻿
namespace LearningSystem.Services
{
    using LearningSystem.Services.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<UserProfileServiceModel> ProfileAsync(string username);

        Task<IEnumerable<UserListingServiceModel>> FindAsync(string searchText);

        Task<byte[]> GetPdfCertificate(int courseId, string studentId);
    }
}
