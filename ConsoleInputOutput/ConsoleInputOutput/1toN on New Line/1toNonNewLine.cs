using System;


namespace _1toN_on_New_Line
{
    class Program
    {
        static void Main()
        {
            uint n = 0;
            Console.WriteLine("Plese enter a number to frint from 1");

            while (!uint.TryParse(Console.ReadLine() , out n))
            {
                Console.WriteLine("Please enter positive integer");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(n+i);
            }

        }
    }
}
