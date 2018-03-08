using System;
using System.Linq;

class SequenceOfMaxSumInArray
{
    // EASE OF USE: The program contains test method that show us how the program work on diffent inputs
    // The method that tests the program is called "TestRunner"

    static int bestStart = 0, bestEnd = 0, bestSum = 0;

    static void Main()
    {
        //Console.Write("Enter a number N (size of array): ");
        //int n = int.Parse(Console.ReadLine());

        //int[] numbers = new int[n];
        //Console.WriteLine("\nEnter a {0} number(s) to array: ", n);
        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    Console.Write("   {0}: ", i + 1);
        //    numbers[i] = int.Parse(Console.ReadLine());
        //}

        //Console.WriteLine();
        int[] numbers = { -2, -3, -6, -1,-7 ,1 ,2 , -1, -6, -4, -8, -8 };

        FindBestSequence(numbers);
        PrintResult(numbers, bestStart, bestEnd, bestSum);

        //TestRunner(); // <- TEST METHOD
    }

    static void FindBestSequence(int[] numbers)
    {
        bestStart = 0; bestEnd = 0; bestSum = 0;

        int startIndex = 0, currentSum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (currentSum <= 0)
            {
                startIndex = i;
                currentSum = 0;
            }

            currentSum += numbers[i];

            if (currentSum > bestSum)
            {
                bestSum = currentSum;
                bestStart = startIndex;
                bestEnd = i;
            }
        }
    }

    static void PrintResult(int[] numbers, int start, int end, int bestSum)
    {
        Console.WriteLine("Array's elements: {0} ", string.Join(" ", numbers));
        Console.WriteLine("Maximal sum: {0}", bestSum);

        Console.Write("Sequence of maximal sum: ");
        for (int i = start; i <= end; i++)
            Console.Write(numbers[i] + " ");

        Console.WriteLine("\n");
    }
}