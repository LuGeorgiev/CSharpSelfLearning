using System;
using System.Linq;

namespace PedicateForNames
{
    class PredicatForNames
    {
        static void Main(string[] args)
        {
            var maxLength = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Func<string, bool> shorter = CustomFilter(maxLength);
            names.Where(x => shorter(x)).ToList().ForEach (x => Console.WriteLine(x)) ;

            //Second way
            //Print(names, n => n.Length <= maxLength);
        }

        private static void Print(string[] names, Func<string, bool> p)
        {
            names = names.Where(p).ToArray();
            Console.WriteLine(String.Join(Environment.NewLine,names));
        }

        private static Func<string, bool> CustomFilter(int maxLength)
        {
            return word => word.Length <= maxLength;
        }
    }
}
