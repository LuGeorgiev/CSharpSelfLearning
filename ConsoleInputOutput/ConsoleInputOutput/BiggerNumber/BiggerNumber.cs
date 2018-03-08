using System;


namespace BiggerNumber
{
    class BiggerNumber
    {
        static void Main()
        {
            Console.WriteLine("Please enter a number");
            float num1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Please enter a number");
            float num2 = float.Parse(Console.ReadLine());

            Console.WriteLine("The bigger number is:{0}", Math.Max(num1,num2));
        }
    }
}
