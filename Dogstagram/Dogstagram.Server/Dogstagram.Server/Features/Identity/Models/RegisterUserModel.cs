
using System.ComponentModel.DataAnnotations;

namespace Dogstagram.Server.Features.Identity.Models
{
    public class RegisterUserModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
