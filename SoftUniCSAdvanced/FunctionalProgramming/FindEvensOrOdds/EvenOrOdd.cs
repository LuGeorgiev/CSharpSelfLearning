using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    class EvenOrOdd
    {
        static void Main(string[] args)
        {
            int[] boundaries = Console.ReadLine().Split().Select(int.Parse).ToArray();
            List<int> numbers = new List<int>();
            for (int i = boundaries[0]; i <= boundaries[1]; i++)
            {
                numbers.Add(i);
            }
            string oddOrEven = Console.ReadLine();
            Func<int, bool> evenOrOdd = CustomEvenOrOdd(oddOrEven);

            numbers.Where(x => evenOrOdd(x)).ToList().ForEach(x => Console.Write(x + " "));               

        }

        private static Func<int, bool> CustomEvenOrOdd(string arg)
        {
            return num =>
            {
                if (arg == "odd" && (num % 2 != 0))
                {
                    return true;
                }
                else if (arg == "even"&&(num % 2 == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };            
        }
    }
}
