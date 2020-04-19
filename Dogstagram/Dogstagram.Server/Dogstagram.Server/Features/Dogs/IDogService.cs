using Dogstagram.Server.Features.Dogs.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Dogs
{
    public interface IDogService
    {
        Task<string> CreateDog(string userId, string url, string description);

        Task<IEnumerable<DogListingServiceModel>> ByUser(string userId);

        Task<DogDetailsServiceModel> DetailsByDogId(string dogId);

        Task<bool> Update(string dogId, string description, string userId);
    }
}
