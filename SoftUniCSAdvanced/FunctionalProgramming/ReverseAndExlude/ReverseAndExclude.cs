using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExlude
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse);
            var excludeDevisiblesTo = int.Parse(Console.ReadLine());

            //Canot find way to Add number in result (CustomFunc)
            //Func<IEnumerable<int>, int, IEnumerable<int>> reversAndExclude = CustomFunc();

            numbers = ExcludeDevisible(numbers, n=>n % excludeDevisiblesTo!=0);
            Console.WriteLine(String.Join(" ",numbers));
        }

        private static IEnumerable<int> ExcludeDevisible(IEnumerable<int> numbers, Func<int, bool> fun)
        {
            return numbers.Where(x=>fun(x)).Reverse();
        }

        //private static Func<IEnumerable<int>, int, IEnumerable<int>> CustomFunc()
        //{
        //    IEnumerable<int> result = new LinkedList<int>();

        //    return (numbers,x) => 
        //    {
        //        foreach (var number in numbers.Reverse())
        //        {
        //            if (number%x!=0)
        //            {
        //                result.Append(number);
        //            }
        //        }
        //        return result;
        //    };
        //}
    }
}
