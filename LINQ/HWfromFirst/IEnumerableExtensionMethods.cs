using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWfromFirst
{
    public static class IEnumerableExtensionMethod 
    {

        //Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
        //sum, product, min, max, average.
        public static T SumIEnumerable<T>(this IEnumerable<T> numbers) where T : struct
        {
            T sum=(dynamic)0;
            foreach (var item in numbers)
            {
                sum += (dynamic)item;
            }
            return sum;
        }

        public static T PoductIEnumerable<T>(this IEnumerable<T> numbers) where T : struct
        {
            T prod = (dynamic)1;
            foreach (var item in numbers)
            {
                prod *= (dynamic)item;
            }
            return prod;
        }

        public static T MinIEnumerable<T>(this IEnumerable<T> numbers) where T : struct
        {
            T min = numbers.First();
            foreach (var item in numbers)
            {
                if ((dynamic)item<min)
                {
                    min = item;
                };
            }
            return min;
        }

        public static T MaxIEnumerable<T>(this IEnumerable<T> numbers) where T : struct
        {
            T max = numbers.First();
            foreach (var item in numbers)
            {
                if ((dynamic)item > max)
                {
                    max = item;
                };
            }
            return max;
        }

        public static T AvgIEnumerable<T>(this IEnumerable<T> numbers) where T : struct
        {
            T sum = numbers.SumIEnumerable();
            return sum / (dynamic)numbers.Count();
        }
    }
}
