
using System.Collections.Generic;

namespace ExtensionMethods.List
{
    public static class ListExtensions
    {
        public static void IncrementAll(this IList<int> numbers)
        {
            IncreaseBY(numbers);
            
        }

        public static void IncreaseBY(this IList<int> numbers, int by=1)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i]+=by;
            }
        }
    }
}
