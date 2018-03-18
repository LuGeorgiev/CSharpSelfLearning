using System;
using System.Collections.Generic;
using System.Linq;

namespace PoisonousPlants
{
    class PoisonPlants
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
            var flowersLine = Console.ReadLine().Split(' ').Select(uint.Parse).ToArray();
            var flowersQueue = new Queue<uint>(flowersLine);
            int pastDays = 0;           
            int len = flowersQueue.Count;

            while (true)
            {
                uint previousFlower = uint.MaxValue;

                for (int i = 0; i < len; i++)
                {
                    uint currentFlower = flowersQueue.Dequeue();
                    if (previousFlower>= currentFlower)
                    {
                        flowersQueue.Enqueue(currentFlower);
                    }
                    previousFlower = currentFlower;
                }

                if (len== flowersQueue.Count)
                {
                    //No flowers were erased
                    Console.WriteLine(pastDays);
                    break;
                }
                else
                {
                    pastDays++;
                    len = flowersQueue.Count;
                }
            }

        }
    }
}
