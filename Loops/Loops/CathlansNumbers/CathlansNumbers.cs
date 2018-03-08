using System;
using System.Numerics;

namespace N1multK1
{
    class N1multK1
    {
        static void Main(string[] args)
        {
            int n = 9;
            decimal cathlanNumerator=1, catlanDenuminator=1;
            decimal cathlan;

            for (int i = n+2; i <= 2*n; i++)
            {
                cathlanNumerator *= i;
            }
            Console.WriteLine(cathlanNumerator);
            for (int i = 1; i <= n; i++)
            {
                catlanDenuminator *= i;
            }
            Console.WriteLine(catlanDenuminator);
            Console.WriteLine();

            cathlan = (decimal)cathlanNumerator / catlanDenuminator;
            Console.WriteLine(cathlan);
        }
    }
}
