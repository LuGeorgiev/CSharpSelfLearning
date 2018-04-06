using System;
using System.Linq;

namespace ActionPoint
{
    class AactioPoint
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .ToList()
                .ForEach(x=>print(x));
        }

        static Action<string> print = x => Console.WriteLine(x);
    }
}
