using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArythmetics
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);
            string command;
            while ((command=Console.ReadLine())!="end")
            {
                if (command == "add")
                {
                    numbers = ApplyOnEach(numbers, num => num + 1);
                }
                else if (command == "multiply")
                {
                    numbers = ApplyOnEach(numbers, num => num *2);
                }
                else if (command == "subtract")
                {
                    numbers = ApplyOnEach(numbers, num => num - 1);

                }
                else if (command == "print")
                {
                    Console.WriteLine(String.Join(" ",numbers));
                }
            }
        }

        private static IEnumerable<int> ApplyOnEach(IEnumerable<int> numbers, Func<int, int> p)
        {
            return numbers.Select(n => p(n));
            
        }
    }
}
