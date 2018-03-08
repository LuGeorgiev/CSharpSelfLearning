using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumbersMethods
{
    class NumbersMethods
    {
        static int ReturnBigger(int num1, int num2)
        {
            int bigger = 0;
            if (num1 > num2)
                bigger = num1;
            else
                bigger = num2;
            return bigger;
        }
        static void Main(string[] args)
        {
            int a = 4, b = 8, c = 9;
            int maxNum = 0;

            maxNum = ReturnBigger(a, b);
            Console.WriteLine("Max is: {0}",ReturnBigger(maxNum,c));
        }
    }
}
