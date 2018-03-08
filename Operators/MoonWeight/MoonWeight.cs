using System;


namespace MoonWeight
{
    class MoonWeight
    {
        static void Main()
        {
            Console.WriteLine("Please, enter your weight");
            float weight = float.Parse(Console.ReadLine());

            Console.WriteLine("Your weight on the Moon will be:"+(float)weight*83/100);
        }
    }
}
