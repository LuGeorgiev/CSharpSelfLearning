using System;
using System.Linq;

namespace CustomMinFunction
{
    class MinFunct
    {
        static void Main()
        {
            var numbers = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> min = CustomMin;

            int minNumber = min(numbers);
            Console.WriteLine(minNumber);
        }

        private static int CustomMin(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                throw new ArgumentNullException("Array should contain numbers");
            }
            else
            {
                int min = int.MaxValue;
                foreach (var number in numbers)
                {
                    if (min > number)
                    {
                        min = number;
                    }
                }
                return min;
            }
        }
    }
}
