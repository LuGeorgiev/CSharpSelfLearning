using System;
using System.Numerics;


namespace SumOfFibonacci
{
    class SumOfFibonacci
    {
        static void Main()
        {
            int num=0;
            BigInteger[] member = new BigInteger[] {0,1};
            BigInteger sum = 1;

            Console.WriteLine("Please enter number of fibonacci line");

            while (!(int.TryParse(Console.ReadLine(), out num) && num>0))
            {
                Console.WriteLine("Try again");
            }
            Console.WriteLine();

            Array.Resize(ref member, num);

            for (int i = 2; i < num; i++)
            {

                member[i] = member[i - 1] + member[i - 2];
                sum += member[i];
                
            }
            Console.WriteLine("the sum is: {0}",sum);
        }
    }
}
