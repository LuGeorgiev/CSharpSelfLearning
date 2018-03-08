using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class Program
    {
        static void Main()
        {
            var miro = new Cat("Miro", 4, true);
            miro.Sound();
            var suke = new Kitten("Sukke", 4, true);
            suke.Sound();
            Console.WriteLine(suke.Sex);
            var ivko = new Tomcat("Ivko", 7, true);
            ivko.Sound();
            Console.WriteLine(ivko.Name+ " "+ivko.Age);

            Console.WriteLine("My name is {0}, I,m {1} old {2} cat", suke.Name, suke.Age,suke.Sex?"male":"female");
            Console.WriteLine("My name is {0}, I,m {1} old {2} cat", ivko.Name, ivko.Age,ivko.Sex?"male":"female");
        }
    }
}
