using System.Collections.Generic;

namespace IdentityDemo.Models.Identity
{
    public class UserWithRolesViewModel
    {
        public string Id { get; set; }

        public string  Email{ get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
