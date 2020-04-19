using System.ComponentModel.DataAnnotations;

namespace Dogstagram.Server.Features.Identity.Models
{
    public class LoginRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
