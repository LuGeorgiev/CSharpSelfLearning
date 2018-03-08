using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    interface IAnimal
    {
        string Name {get; }
        bool Sex { get; }
        int Age { get; }
        
    }
}
