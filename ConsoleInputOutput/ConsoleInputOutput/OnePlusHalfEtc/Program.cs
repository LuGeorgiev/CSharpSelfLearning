using System;


namespace OnePlusHalfEtc
{
    class Program
    {
        static void Main()
        {
            
            Double sum = 1.0;
            Double sum1 = 0.0;
            int i = 2;

            while (Math.Abs(sum-sum1) > 0.001)
            {
                sum1 = sum;
                sum = sum + (1.0 / i);
                i++;
            }
            
            Console.WriteLine("The Limes of the row is {0}", sum);
        }
    }
}
