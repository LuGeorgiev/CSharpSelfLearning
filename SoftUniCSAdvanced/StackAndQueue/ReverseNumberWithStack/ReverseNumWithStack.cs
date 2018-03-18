using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumberWithStack
{
    class ReverseNumWithStack
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            if (input.Length>0)
            {
                var stack = new Stack<int>(input);
                while (stack.Count>0)
                {
                    Console.Write(stack.Pop().ToString());
                    if (stack.Count > 0)
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
