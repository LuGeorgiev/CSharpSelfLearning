using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomDataStructures;

namespace Generics
{
    
    class Startup
    {
        static void Main()
        {
            var list1 = new GenericList<int>()+1+2+6;
            var list2 = new GenericList<int>()+1+2+5+6;
            Console.WriteLine(GenericList<int>.Compare(list1,list2));




        }
    }
}
