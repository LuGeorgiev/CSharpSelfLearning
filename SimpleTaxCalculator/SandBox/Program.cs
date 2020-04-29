using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace SandBox
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() { 1, 2, 3, 4 , 5, 6, 7, 8, 9};
            var queue = new Queue<int>();
            var stringQueu = new Queue<string>();
            queue.Enqueue(1);
            stringQueu.Enqueue("1");

            for (int i = 1; i < list.Count; i++)
            {
                var currentValue = list[i];
                var quenLen = queue.Count;

                for(int j =0; j < quenLen ; j++)
                {
                    var fromQueue = queue.Dequeue();
                    var stringValue = stringQueu.Dequeue();

                    queue.Enqueue(fromQueue + currentValue);
                    stringQueu.Enqueue($"{stringValue} + {currentValue}");

                    queue.Enqueue(fromQueue - currentValue);
                    stringQueu.Enqueue($"{stringValue} - {currentValue}");

                    queue.Enqueue(int.Parse($"{fromQueue}{currentValue}"));
                    stringQueu.Enqueue($"{stringValue}{currentValue}");
                }
            }

            while (queue.Count > 0)
            {
                var value = queue.Dequeue();
                if (value == 100)
                {
                    Console.WriteLine(stringQueu.Dequeue());                    
                }
                else
                {
                    stringQueu.Dequeue();
                }
            }
        }
       

    }
}
