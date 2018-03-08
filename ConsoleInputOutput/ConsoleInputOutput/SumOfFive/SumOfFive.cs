using System;


namespace SumOfFive
{
    class SumOfFive
    {
        static void Main()
        {
            int[] num = new int[5];
            long sum = 0;
            for (int i = 0; i <5; i++)
            {
                Console.WriteLine("Please enter integer number");
                while (!int.TryParse(Console.ReadLine(), out num[i]))
                {
                    Console.WriteLine("Please focus and enter integer value");

                }
                sum += num[i];
            }

            Console.WriteLine("sum of those five integers is:"+sum);
        }
    }
}
