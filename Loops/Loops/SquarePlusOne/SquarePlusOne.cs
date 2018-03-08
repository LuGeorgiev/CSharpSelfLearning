using System;


namespace SquarePlusOne
{
    class SquarePlusOne
    {
        static void Main()
        {   //N=4
            // 1 2 3 4 
            // 2 3 4 5
            // 3 4 5 6
            // 4 5 6 7

            int n,k;
            Console.WriteLine("inserd N<20");
            n = int.Parse(Console.ReadLine());
            k = n;

            for (int i = 1; i <= n; i++,k++)
            {
                for (int j = i; j <= k; j++)
                {
                    Console.Write("{0,3}",j);
                }
                Console.WriteLine();
            }
        
        }
    }
}
