
namespace CamaraBazar.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterViewModel
    {
        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage ="Username must have only letters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"\+[0-9]{10,12}", ErrorMessage ="Phone must start with '+' sign, folllowed by 9 to 11 symbols")]
        public string Phone { get; set; }
    }
}
