using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHWLINQ
{
    interface ISutudent
    {
        string FirstName { get;}
        string LastName { get; }
        int Age { get; }
        int FN { get; }
        string Tel { get; }
        string Email { get;  }
        List<int> Marks { get;  }
        int GroupNumber { get;  }
    }
}
