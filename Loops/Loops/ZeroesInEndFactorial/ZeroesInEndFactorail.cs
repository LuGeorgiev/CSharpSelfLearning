using System;
using System.Numerics;

namespace ZeroesInEndFactorial
{
    class ZeroesInEndFactorail
    {
        static void Main()
        {
            // Dispaly how many ZEROES are theer in the end of a given factorial

            int n = int.Parse(Console.ReadLine());
            BigInteger fact=1;
            int zeroCounter=0;

            for (int i = 1; i <= n; i++)
            {
                fact *= i;
            }
            
            n = 0;
            for (int i = 0; ; i++)
            {
                if (fact%10==0)
                {
                    zeroCounter++;
                    fact = fact / 10;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(zeroCounter);

        }
    }
}
