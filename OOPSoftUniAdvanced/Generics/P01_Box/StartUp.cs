using System;

namespace P01_Box
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var inputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < inputs; i++)
            {
                var nextStr = Console.ReadLine();
                var box = new Box<string>(nextStr);
                Console.WriteLine(box);
            }            
        }
    }
}
