using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Data
{
    public class Validation
    {
        public class Dog
        {
            public const int MaxDescriptionLength = 2000;
        }

        public class User
        {
            public const int MaxNameLength = 40;
            public const int MaxBioraphyLength = 150;
        }
    }
}
