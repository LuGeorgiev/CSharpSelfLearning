using System;


namespace ConsoleInputOutput
{
    class SumOfThree
    {
        static void Main()
        {
            Console.WriteLine("Please insert three integer numbers");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine("The sum of those three number is: {0}", a+b+c);
        }
    }
}
