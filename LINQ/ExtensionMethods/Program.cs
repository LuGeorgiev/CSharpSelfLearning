using System;
using System.Collections.Generic;
using ExtensionMethods.List;

namespace ExtensionMethods
{
     
    class Program
    {
        static void Main()
        {
            var numbers = new List<int> { 1, 4, 6, 4, 45, 76, 23, 56 };
            numbers.IncreaseBY(10);
            Console.WriteLine(string.Join(",",numbers));
        }
    }
}
