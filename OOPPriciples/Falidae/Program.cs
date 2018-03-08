using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falidae
{
    class Program
    {
        static void Main()
        {
            { 
            Lion lion = new Lion(true, 90);
            lion.CatchPray(null);
            }

            {
                AfricanLion lion = new AfricanLion(true, 120);
                lion.CatchPray(null);
            }

            {
                Lion lion = new AfricanLion(false, 60);
                lion.CatchPray(null);
            }
        }
    }
}
