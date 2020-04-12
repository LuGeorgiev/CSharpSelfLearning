
using System.ComponentModel.DataAnnotations;

namespace Dogstagram.Server.Features.Identity
{
    public class RegisterUserRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
