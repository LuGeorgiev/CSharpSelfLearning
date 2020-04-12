
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Dogs
{
    public interface IDogService
    {
        Task<string> CreateDog(string userId, string url, string description);
    }
}
