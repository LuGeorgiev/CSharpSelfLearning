using EstateManagment.Data.Models;
using EstateManagment.Services.Models.Users;
using System.Collections.Generic;
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
