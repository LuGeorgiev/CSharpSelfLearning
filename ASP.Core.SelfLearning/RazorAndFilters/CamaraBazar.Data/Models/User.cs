
namespace CamaraBazar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<Camera> Camers { get; set; } = new List<Camera>();
    }
}
