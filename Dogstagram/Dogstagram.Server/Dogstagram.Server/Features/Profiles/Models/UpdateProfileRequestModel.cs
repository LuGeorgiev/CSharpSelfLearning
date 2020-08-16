using Dogstagram.Server.Data.Models;
using System.ComponentModel.DataAnnotations;

using static Dogstagram.Server.Data.Validation.User;

namespace Dogstagram.Server.Features.Profiles.Models
{
    public class UpdateProfileRequestModel
    {
        [EmailAddress]
        public string Email { get; set; }

        public string UserName { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string MainPhotoUrl { get; set; }

        public string WebSite { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }

        [MaxLength(MaxBioraphyLength)]
        public string Biography { get; set; }
    }
}
