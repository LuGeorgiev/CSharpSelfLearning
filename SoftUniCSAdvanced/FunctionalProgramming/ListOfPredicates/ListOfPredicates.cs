using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    class ListOfPredicates
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int [] devisors = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            List<int> numbers = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                numbers.Add(i);
            }

            Func<int,bool> predicat = CreatePredicated(devisors);
            numbers.Where(x=>predicat(x))
                .ToList()
                .ForEach(x=>Console.Write(x+" "));

            Console.WriteLine();
        }

        private static Func<int, bool> CreatePredicated(int[] devisors)
        {
            //return num => devisors.All(d => num % d == 0); //uses MORE memory and last test cannot PASS. Probably very big input collection

            // This is the LONG way
            return num =>
            {
                foreach (var dev in devisors)
                {
                    if (num % dev != 0)
                    {
                        return false;
                    }
                }
                return true;
            };
        }
    }
}
