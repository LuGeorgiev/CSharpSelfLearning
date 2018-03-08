using System;
using System.Collections.Generic;

namespace DivisionBy3JaggedList
{
    class DivisionBy3JaggedList
    {
        static void Main()
        {
            int[] nums = {2,4,6,78,12,23,11,12,34,678,90,32,34,3,2,6,890,65,4,56,3,22234,67 };
            List<int>[] jagged = new List<int>[3];

            for (int i = 0; i < jagged.Length; i++)
            {
                jagged[i] = new List<int>();
            }

            for (int i = 0; i < nums.Length; i++)
            {
                int index = nums[i] % 3;
                jagged[index].Add(nums[i]);
            }

            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(String.Join(" ", jagged[i]));
            }
        }
    }
}
