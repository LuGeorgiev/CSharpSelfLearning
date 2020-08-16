using Dogstagram.Server.Features.Dogs.Models;
using Dogstagram.Server.Infrastructure.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Dogs
{
    public interface IDogService
    {
        Task<string> CreateDog(string userId, string url, string description);

        Task<IEnumerable<DogListingServiceModel>> ByUser(string userId);

        Task<DogDetailsServiceModel> DetailsByDogId(string dogId);

        Task<Result> Update(string dogId, string description, string userId);

        Task<Result> Delete(string id, string userId);
    }
}
