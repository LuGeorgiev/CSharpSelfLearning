using System;

namespace TestForJoro
{
    class Program
    {
        static void Main()
        {
            for (int i = 2; i < 101; i++)
            {
                Console.WriteLine(Math.Pow(-1,i)*i);
            }
        }
    }
}
