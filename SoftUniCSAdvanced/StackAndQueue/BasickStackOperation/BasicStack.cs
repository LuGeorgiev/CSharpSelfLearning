using System;
using System.Collections.Generic;
using System.Linq;

namespace BasickStackOperation
{
    class BasicStack
    {
        static void Main()
        {
            var stackInformation = Console.ReadLine()
                .Split(' ')
                .ToArray();
            var numbersToPushInStack = int.Parse(stackInformation[0]);
            var numbersToPopFromStack = int.Parse(stackInformation[1]);
            var numbersToLookForInStack = int.Parse(stackInformation[2]);

            var numbersToBeStacked = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            var stack = new Stack<int>();
            for (int i = 0; i < numbersToPushInStack; i++)
            {
                stack.Push(numbersToBeStacked[i]);
            }
            for (int i = 0; i < numbersToPopFromStack; i++)
            {
                stack.Pop();
            }
            if (stack.Count==0)
            {
                Console.WriteLine(0);
                return;
            }
            else
            {

                var minInStack = stack.Peek();
                while (stack.Count>0)
                {
                    var stackCurrentValue = stack.Pop();
                    if (stackCurrentValue== numbersToLookForInStack)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    if (stackCurrentValue< minInStack)
                    {
                        minInStack = stackCurrentValue;
                    }
                }
                Console.WriteLine(minInStack);
            }
        }
    }
}
