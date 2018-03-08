using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Test
    {
        static void Main()
        {
            Shape recti = new Rectangle(2, 5);
            Console.WriteLine(recti.Surface());

             ISurface[] surfaces = new ISurface[]
            {
                new Rectangle(5, 8.9),
                new RightAngleTriangle(3.6, 2.3),
                new Square(7),
                new RightAngleTriangle(78,90.6),
                new Rectangle(56,89.2)
            };

            foreach (ISurface item in surfaces)
            {
                Console.WriteLine(item.Surface());
            }
        }
    }
}
