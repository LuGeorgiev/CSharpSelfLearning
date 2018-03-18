using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueue
{
    class BasicQueue
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var numbersToAddInQueue = input[0];
            var numbersToRemoveInQueue = input[1];
            var numberToSearchInQueue = input[2];

            var queueNumbers = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            var queue = new Queue<int>(queueNumbers);
            for (int i = 0; i < numbersToRemoveInQueue; i++)
            {
                queue.Dequeue();
            }
            var smallestNumber = int.MaxValue;
            if (queue.Count==0)
            {
                Console.WriteLine(0);
            }
            else
            {
                while (queue.Count>0)
                {
                    var currentValue = queue.Dequeue();
                    if (currentValue== numberToSearchInQueue)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else if(smallestNumber> currentValue)
                    {
                        smallestNumber = currentValue;
                    }
                }
                Console.WriteLine(smallestNumber);
            }

        }
    }
}
