using System;
using System.Linq;

namespace LegoBlock
{
    class Program
    {
        static void Main(string[] args)
        {
            var jaggedLen =int.Parse( Console.ReadLine());
            var jaggedOne = new int[jaggedLen][];
            for (int i = 0; i < jaggedLen; i++)
            {
                var elements = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jaggedOne[i] = new int[elements.Length];
                for (int j = 0; j < elements.Length; j++)
                {
                    jaggedOne[i][j] = elements[j];
                }
            }

            var jaggedTwo = new int[jaggedLen][];
            for (int i = 0; i < jaggedLen; i++)
            {
                var elements = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                elements.Reverse();
                    
                jaggedTwo[i] = new int[elements.Count];
                for (int j = 0; j < elements.Count; j++)
                {
                    jaggedTwo[i][j] = elements[j];
                }
            }

            bool areFitting = CalculateIfBothFit(jaggedOne, jaggedTwo);

            if (areFitting)
            {
                PrintBoth(jaggedOne,jaggedTwo);
            }
            else
            {
                CalculateAndPrintAllElements(jaggedOne, jaggedTwo);
            }

           
        }

        private static void CalculateAndPrintAllElements(int[][] jaggedOne, int[][] jaggedTwo)
        {
            var counter = 0;
            var jaggedLength = jaggedOne.Length;
            for (int i = 0; i < jaggedLength; i++)
            {                
                for (int j = 0; j < jaggedOne[i].Length; j++)
                {
                    counter++;
                }
                for (int j = 0; j < jaggedTwo[i].Length; j++)
                {
                    counter++;
                }                
            }
            Console.WriteLine($"The total number of cells is: {counter}");
        }

        private static void PrintBoth(int[][] jaggedOne, int[][] jaggedTwo)
        {
            var jaggedLength = jaggedOne.Length;

            for (int i = 0; i < jaggedLength; i++)
            {
                Console.Write("[");
                for (int j = 0; j < jaggedOne[i].Length; j++)
                {
                    Console.Write(jaggedOne[i][j] + ", ");
                }
                for (int j = 0; j < jaggedTwo[i].Length; j++)
                {
                    if (j== jaggedTwo[i].Length-1)
                    {
                        Console.Write(jaggedTwo[i][j]);
                        break;
                    }

                    Console.Write(jaggedTwo[i][j] + ", ");
                }
                Console.Write("]");
                Console.WriteLine();
            }
        }

        private static bool CalculateIfBothFit(int[][] jaggedOne, int[][] jaggedTwo)
        {
            var jaggedLength = jaggedOne.Length;
            var totalLength = jaggedOne[0].Length + jaggedTwo[0].Length;
            for (int i = 1; i < jaggedLength; i++)
            {
                if (jaggedOne[i].Length+jaggedTwo[i].Length!=totalLength)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
