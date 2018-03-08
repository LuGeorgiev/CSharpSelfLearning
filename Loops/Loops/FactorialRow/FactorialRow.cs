using System;


namespace FactorialRow
{
    class FactorialRow
    {
        static void Main()
        {    //S=1+1!/x+ 2!/x^2+.......+n!/x^n

            int n = 3;
            int x = 2;
            decimal member = 1m;
            decimal sum = 1m;

            for (int i = 1; i <= n; i++)
            {
                member *= (decimal)i / x;

                sum += member;
            }

            Console.WriteLine(sum);
        }
    }
}
