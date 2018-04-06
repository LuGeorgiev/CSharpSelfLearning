using System;
using System.Linq;

namespace KnightsOfHonour
{
    class KnightsOfHonour
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(x => becomeKnight(x));
        }

        static Action<string> becomeKnight = x => Console.WriteLine($"Sir {x}");
    }
}
