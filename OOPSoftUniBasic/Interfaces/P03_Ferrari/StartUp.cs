using System;

namespace P03_Ferrari
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var driver = Console.ReadLine();
            var ferrari = new Car(driver);

            Console.WriteLine(ferrari);
        }
    }
}
