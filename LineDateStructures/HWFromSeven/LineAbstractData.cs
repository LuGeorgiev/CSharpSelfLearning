using System;
using System.Collections.Generic;
using HWFroFirst;

namespace HWFromSeven
{
    class LineAbstractData
    {
        static void Main()
        {
            //var list = new List<int>(); 
            //list = Startup.WriteListTillEnter();
            //var numCounts = CountNumOccurencies(list); //Seventh task
            //PrintOccurencies(numCounts);                //Seventh Task

            PrintSequence(2);
        }

        public static int[] CountNumOccurencies(List<int> list)
        {
            var numOccurency = new int[1001]; // numbers to be between 0 and 1000 in the list

            for (int i = 0; i < list.Count; i++)
            {
                numOccurency[list[i]]++;
            }
            return numOccurency;
        }
        public static void PrintOccurencies(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i]!=0)
                {
                    Console.WriteLine("{0} was met {1} times in the list", i,nums[i]);
                }
            }
        }           //Seven

        public static void PrintSequence(int first)
        {
            Queue<int> queue = new Queue<int>();
            int index = 1;
            int num = first;
            queue.Enqueue(num);
            Console.WriteLine(queue.Dequeue());
            while (index <= 50)
            {                
                queue.Enqueue(num + 1);
                queue.Enqueue(2 * num + 1);
                queue.Enqueue(num + 2);
                index += 3;
                num = queue.Peek();
                Console.WriteLine(queue.Dequeue());                
            }

            while (queue.Count>0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
