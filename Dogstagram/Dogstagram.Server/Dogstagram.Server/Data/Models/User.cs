using Dogstagram.Server.Data.Models.Base;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Dogstagram.Server.Data.Models
{
    public class User : IdentityUser, IEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public IEnumerable<Dog> Dogs { get; set; } = new HashSet<Dog>();
    }
}
