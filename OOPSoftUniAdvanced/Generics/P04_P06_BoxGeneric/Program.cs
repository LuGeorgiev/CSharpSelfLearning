using System;
using System.Linq;

namespace P04_P06_BoxGeneric
{
    public class Program
    {
        static void Main()
        {
            //Problem 04 solved 100/100
            // Problem04Solve();           


            //Problem 03 Solved 100/100
            // Problem03Solve();

            //Problem 05 Solved 100/100
            //Problem05Solved();

            //Problem 06 Solved 100/100
            Problem06Solved();

        }

        private static void Problem06Solved()
        {
            var entriesNumber = int.Parse(Console.ReadLine());
            var box = new Box<double>();
            for (int i = 0; i < entriesNumber; i++)
            {
                var nextItem = double.Parse( Console.ReadLine());
                box.Add(nextItem);
            }
            var compareTo = double.Parse( Console.ReadLine());
            var numberOfGreater = box.GreaterThan(compareTo);
            Console.WriteLine(numberOfGreater);
        }

        private static void Problem05Solved()
        {
            var entriesNumber = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < entriesNumber; i++)
            {
                var nextItem = Console.ReadLine();
                box.Add(nextItem);
            }
            var compareTo = Console.ReadLine();
            var numberOfGreater = box.GreaterThan(compareTo);
            Console.WriteLine(numberOfGreater);
        }

        private static void Problem04Solve()
        {
            var entriesNumber = int.Parse(Console.ReadLine());
            var box = new Box<int>();
            for (int i = 0; i < entriesNumber; i++)
            {
                var nextItem = int.Parse(Console.ReadLine());
                box.Add(nextItem);
            }

            var toBeSwapped = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            box.SwapItems(toBeSwapped[0], toBeSwapped[1]);
            Console.WriteLine(box);
        }

        private static void Problem03Solve()
        {
            var entriesNumber = int.Parse(Console.ReadLine());
            var box = new Box<string>();
            for (int i = 0; i < entriesNumber; i++)
            {
                var nextItem = Console.ReadLine();
                box.Add(nextItem);
            }
            var toBeSwapped = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
            box.SwapItems(toBeSwapped[0], toBeSwapped[1]);
            Console.WriteLine(box);
        }
    }
}
