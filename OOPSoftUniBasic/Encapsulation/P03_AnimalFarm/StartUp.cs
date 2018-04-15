using System;

namespace P03_AnimalFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var name = Console.ReadLine();
            var age = int.Parse(Console.ReadLine());
            try
            {
                var chick = new Chicken(name, age);
                Console.WriteLine(chick);
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
