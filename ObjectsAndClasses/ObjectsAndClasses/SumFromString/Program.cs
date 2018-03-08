using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumFromString
{
    class Program
    {
         static public int SumOfInt(int[] num)
         {
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
                 sum += num[i];
            
            return sum;
         } 

        static void Main()
        {
            string text = Console.ReadLine();

            string[] strNumbs = text.Split(' ');
            int[] numbers = new int[strNumbs.Length];
            for (int i = 0; i < numbers.Length; i++)
                  numbers[i] = int.Parse(strNumbs[i]);
            

            Console.WriteLine(SumOfInt(numbers));            
        }
    }
}
