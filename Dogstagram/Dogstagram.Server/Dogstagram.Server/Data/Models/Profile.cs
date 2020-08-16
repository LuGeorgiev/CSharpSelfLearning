using System.ComponentModel.DataAnnotations;

using static Dogstagram.Server.Data.Validation.User;

namespace Dogstagram.Server.Data.Models
{
    public class Profile
    {
        public int Id { get; set; }

        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        public string ManinPhotoUrl { get; set; }

        public string WebSite { get; set; }

        public Gender Gender { get; set; }

        public bool IsPrivate { get; set; }

        [MaxLength(MaxBioraphyLength)]
        public string Biography { get; set; }

        public User User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
