using System;


namespace BiggestFromFive
{
    class Program
    {
        static void Main()
        {
            int[] num = new int [5];
            int biggest=int.MinValue;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Please enter integer number which to compare");
                while (!int.TryParse(Console.ReadLine(), out num[i]))
                {
                    Console.WriteLine("Please pay attention and enter integer number");
                }

            }

            for (int i = 1; i < 5; i++)
            {
                biggest = Math.Max(num[i], num[i - 1]);
                
            }
            Console.WriteLine("The biggest of all five numbers is:{0}", biggest);
        }
    }
}
