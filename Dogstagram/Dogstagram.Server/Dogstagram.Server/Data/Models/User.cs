using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Data.Models
{
    public class User : IdentityUser
    {

        public IEnumerable<Dog> Dogs { get; set; } = new HashSet<Dog>();
    }
}
