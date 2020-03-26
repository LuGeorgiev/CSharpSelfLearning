using Microsoft.AspNetCore.Identity;
using Users.Models.Enums;

namespace Users.Models
{
    public class AppUser : IdentityUser
    {
        public Cities City { get; set; }

        public QualificationLevels Qualification { get; set; }
    }
}
