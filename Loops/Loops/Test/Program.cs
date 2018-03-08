using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string bin = Console.ReadLine();
            bool digit;

            while (bin.Length != 0)
            {
                digit = bin.EndsWith("1");
                Console.WriteLine(digit);
                bin = bin.Remove(bin.Length - 1);
                                
            }
        }   
    }
}
