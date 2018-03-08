using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousTypes
{
    class Program
    {
        static void Main()
        {
            var point = new { X = 10, Y = 12 };
            var point1 = new { X = 15, Y = 12 };
            var point2 = new { X = 15, Y = 12 };

            Console.WriteLine(point1==point2);          //Compares references
            Console.WriteLine(point1.Equals(point2));   //Compares property to property

            var hoomans = new[] 
            {
                new { Name="kutrw", Age =13},
                new { Name="Smurt", Age =132},
                new { Name="Mila", Age =91}
            };
            foreach (var item in hoomans)
            {
                Console.WriteLine(item.Name);
            }

            var user = new
            {
                UserID = 12,
                Username = "gosho.pesho",
                Email = "kor@abv.bg"
            };         

            Console.WriteLine(user);


        }
    }
}
