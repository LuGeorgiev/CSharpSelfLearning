using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    class TriFunction
    {
        static void Main(string[] args)
        {
            int sumInput = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split().ToList();

            ////Second way
            //Func<string, int, bool> filter = (name, sum) => name.ToCharArray().Sum(c =>c) >= sum;
            //Console.WriteLine(names.FirstOrDefault(name=>filter(name,sumInput)));


            //Console.WriteLine(names.FirstOrDefault(name=>name.ToCharArray().Sum(c=>c)>=sum));

            //third Way
            var filter = CreateFilter(sumInput);
            Console.WriteLine(names.FirstOrDefault(filter));
        }

        static Func<string, bool> CreateFilter(int sum)
        {
            return name => name.ToCharArray().Sum(c => c) >= sum;
        }
    }
}
