
namespace EstateManagment.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class User :IdentityUser
    {
        public string Nickname { get; set; }
    }
}
