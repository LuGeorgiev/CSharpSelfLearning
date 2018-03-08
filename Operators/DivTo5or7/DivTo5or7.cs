using System;


namespace DivTo5or7
{
    class Program
    {
        static void Main()
        {
            int digit = 0;
            bool surplus;
            
            Console.WriteLine("Please, enter a number to check");
            digit = Convert.ToInt32(Console.ReadLine());
            surplus = ((digit % 5 == 0) && (digit % 7 == 0));
            Console.WriteLine(surplus);

        }
    }
}
