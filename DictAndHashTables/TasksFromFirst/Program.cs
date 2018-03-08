using System;
using System.Collections.Generic;
using System.Numerics;


namespace TasksFromFirst
{
    class Program
    {
        static void Main()
        {
            //List<int> line = new List<int>() { 3, 4, 4, 5, 2, 1, 3, 4, 5, 3, 2, 21, 3, 4, 5 }; // Firts and Second Task
            //Dictionary<int, int> count = new Dictionary<int, int>(CountOccurency(line)); // First Task
            //PrintDictionarry(count);                                                      //First Task
            //PrintEvenFromList(line);                                                      //Second Task

            List<BigInteger> line1 = new List<BigInteger>(LineCreation(1, 2, 3));   // Task ten lines not finished
            for (int i = 99000; i < 100000; i++)
            {
                Console.WriteLine(line1[i]);
            }
        }

        public static void PrintEvenFromList(List<int> list)
        {
            Dictionary<int, int> ocurrency = new Dictionary<int, int>(CountOccurency(list));
            Console.Write("{ ");
            foreach (var num in list)
            {
                if (ocurrency[num]%2==0)
                {
                    Console.Write("{0} ",num);
                }
            }
            Console.Write("}");
            Console.WriteLine();
        }
        public static void PrintDictionarry(Dictionary<int, int> numbers)
        {
            foreach (var number in numbers)
            {
                Console.WriteLine("{0} -> {1} times", number.Key,number.Value);
            }
        }
        public static Dictionary<int, int> CountOccurency(List<int> nums)
        {
            Dictionary<int, int> occurency = new Dictionary<int, int>();
            foreach (var num in nums)
            {
                if (occurency.ContainsKey(num))
                {
                    occurency[num]++;
                }
                else
                {
                    occurency.Add(num, 1);
                }
            }
            return occurency;
        }

        public static List<BigInteger> LineCreation(int firstMember, int multiply, int add)
        {
            List < BigInteger > line = new List<BigInteger>(100001);
            line.Add((BigInteger)firstMember);
            for (int i = 1; i < 100000; i++)
            {
                line.Add((BigInteger)multiply*line[i - 1]+(BigInteger)add);
            }
            return line;
        }
    }
}
