
namespace Dogstagram.Server.Features.Dogs.Models
{
    public class DogDetailsServiceModel : DogListingServiceModel
    {
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }
    }
}
