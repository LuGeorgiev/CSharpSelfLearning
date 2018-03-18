using System;
using System.Collections.Generic;

namespace StackFibonnachi
{
    class StackFibonachi
    {
        static void Main(string[] args)
        {
            int fibN = int.Parse(Console.ReadLine());
            int counter = 2;
            var fibonacciStack = new Stack<ulong>();
            fibonacciStack.Push(0);
            fibonacciStack.Push(1);            

            while (counter<= fibN)
            {
                var lastFib = fibonacciStack.Pop();
                var previousFib = fibonacciStack.Peek();
                var nextFib = lastFib + previousFib;

                fibonacciStack.Push(lastFib);
                fibonacciStack.Push(nextFib);
                counter++;
            }

            Console.WriteLine(fibonacciStack.Pop());
        }
    }
}
