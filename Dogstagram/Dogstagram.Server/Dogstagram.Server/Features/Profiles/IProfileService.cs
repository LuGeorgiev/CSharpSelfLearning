using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Features.Profiles.Models;
using Dogstagram.Server.Infrastructure.Services;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Profiles
{
    public interface IProfileService
    {
        Task<ProfileServiceModel> ByUser(string id, bool allInformation = false);

        Task<Result> Update(
            string userId, 
            string email, 
            string userName, 
            string name, 
            string mainPhotoUrl, 
            string webSite, 
            string biography, 
            Gender gender, 
            bool isPrivate);

        Task<bool> IsPublic(string userId);
    }
}
