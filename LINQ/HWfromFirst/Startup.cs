using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWfromFirst
{
    class Startup
    {
        static void Main(string[] args)
        {
            string test = "Zemi toq string";
            var builder = new StringBuilder();
            builder.Append(test);
            builder.SubString(11, 4);
            //Console.WriteLine(builder.ToString());

            IEnumerable<int> nums = new int[] { 1,5, 21,5,7,14,33,23,42,71,16,67};
            // Second HW task
            //Console.WriteLine("Sum is: "+nums.SumIEnumerable());
            //Console.WriteLine("Produst is"+nums.PoductIEnumerable());
            //Console.WriteLine("Min is: "+nums.MinIEnumerable());
            //Console.WriteLine("Max is: "+nums.MaxIEnumerable());
            //Console.WriteLine("Avg is: "+nums.AvgIEnumerable());

            //Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
            //Use the built-in extension methods and lambda expressions.Rewrite the same with LINQ.
            var devisibleBy7and3 = nums
                .Where(x => x % 7 == 0 && x % 3 == 0)
                .Select(x => x);
            foreach (var num in devisibleBy7and3)
            {
                Console.WriteLine(num);
            }
        }
    }
}
