using Dogstagram.Server.Infrastructure.Services;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Follows
{
    public interface IFollowService
    {
        Task<Result> Follow(string userId, string followerId);
    }
}
