using EstateManagment.Data.Models;
using EstateManagment.Services.ServiceModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<UserShortModel>> AllNonAdminsAsync(string loggedUserId);

        Task<UserInfoModel> GetUserWithRolesAsync(string userId);

        Task<User> GetUserAsync(string userId); 
    }
}
