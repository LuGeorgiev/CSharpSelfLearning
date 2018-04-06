using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Array.Sort(numbers,new CustomCompare());
            Console.WriteLine(string.Join(" ",numbers));
        }
    }

    class CustomCompare : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if (x % 2 == 0 && y % 2 != 0)
            {
                return -1;
            }
            else if (x % 2 != 0 && y % 2 == 0)
            {
                return 1;
            }
            else
            {
                if (x < y)
                {
                    return -1;
                }
                else if (x > y)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
                
    }
}
