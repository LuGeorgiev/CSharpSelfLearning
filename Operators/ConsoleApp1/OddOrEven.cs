using System;


namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
        int oddOrEven =0;
            int k;
            Console.WriteLine("Please, enter a number to check");
            oddOrEven =Convert.ToInt32( Console.ReadLine());
            k = Math.Abs((oddOrEven % 2));
            k == 1 ? Console.WriteLine("Enen") : Console.WriteLine("odd"); // where is the mistake

            Console.WriteLine(k==1?"dig is even":"dig is odd"); // correct

        }
    }
}
