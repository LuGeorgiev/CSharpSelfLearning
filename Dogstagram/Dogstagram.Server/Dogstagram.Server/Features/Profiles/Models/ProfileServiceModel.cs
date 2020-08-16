using Dogstagram.Server.Data.Models;

namespace Dogstagram.Server.Features.Profiles.Models
{
    public class ProfileServiceModel
    {
        public string Name { get; set; }

        public string ProfilePhotoUrl { get; set; }

        public bool IsPrivate { get; set; }
    }
}
