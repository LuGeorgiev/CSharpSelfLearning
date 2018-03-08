using System;
using System.Numerics;

namespace N1multK1
{
    class N1multK1
    {
        static void Main(string[] args)
        {
            int n = 8;
            int k = 4;
            BigInteger result=1;

            for (int i = 1; i <= k; i++)
            {
                result *= i;
            }
            Console.WriteLine(result);

            for (int i = (n-k+1); i < n; i++)
            {
                result *= i;
            }

            Console.WriteLine(result);
        }
    }
}
