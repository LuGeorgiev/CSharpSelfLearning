using System;
using System.Collections.Generic;


namespace HWFroFirst
{
    public class Startup
    {
        static void Main(string[] args)
        {
            List<int> list = WriteListTillEnter();               //First Task and third
            //Console.WriteLine(Average(list));                  //First Task
            //PrintSortedList(list);                             //third task
            //PrintSortedList(ExtackLongestEqualSequence(list));     // Forth Task
            PrintList(ExtractElementsFromList(list, ExtractEvenTimeMet(list))); //Sixth Task
        }
        public static void PrintList(List<int> list)
        {
            Console.Write("{ ");
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]);
                Console.Write(" ");
            }
            Console.WriteLine(" }");
        }
        public static List<int> WriteListTillEnter()
        {
            List<int> list = new List<int>();
            while (true)
            {
                var num = Console.ReadLine();
                int result = 0;
                if (num==string.Empty||num==null)
                {
                    break;
                }
                else if (int.TryParse(num,out result))
                {
                    list.Add(result);
                }                
            }
            return list;
        }

        public static double Average(List<int> list)
        {
            int sum = 0;
            foreach (var item in list)
            {
                sum += item;
            }
            return (double)sum / list.Count;
        }

        public static void ReadsNandPrintInvers(int n)
        {
            Stack<int> stack = new Stack<int>();
            
            for (int i = 0; i < n; i++)
            {
                stack.Push(int.Parse(Console.ReadLine()));
            }

            while (stack.Count>0)
            {
                Console.WriteLine(stack.Pop());
            }
        }       //Second Task

        public static void PrintSortedList(List<int> list)
        {
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write("\"{0}\" ", list[i]);
            }
            Console.WriteLine();
        }   //Thisrd Tast

        public static List<int> ExtackLongestEqualSequence(List<int> nums)
        {
            int num = nums[0];
            int maxSeq = 0;
            int numWithMaxSeq = 1;
            int count = 1;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i]==num)
                {
                    count++;
                    if (count>maxSeq)
                    {
                        maxSeq = count;
                        numWithMaxSeq = num;
                    }
                }
                else
                {
                    num = nums[i];
                    count = 1;
                }
            }

            List<int> result = new List<int>();
            for (int i = 0; i < maxSeq; i++)
            {
                result.Add(numWithMaxSeq);
            }
            return result;
        } //Forth Task

        public static List<int> ExtractEvenTimeMet(List<int> list)
        {
            List<int> even = new List<int>();
            List<int> result = new List<int>();

            foreach (var item in list)
            {
                even.Add(item);
            }
                       
            even.Sort();
            var count = 1;            
            for (int i = 1; i < even.Count; i++)
            {
                if (even[i-1]== even[i])
                {
                    count++;
                }
                else
                {
                    if (count%2==1)
                    {
                        result.Add(even[i-1]);
                    }
                    count = 1;
                }
            }        
            return result;
        } //Sixth

        public static List<int> ExtractElementsFromList(List<int> extractFrom, List<int> extract)
        {
            List<int> result = new List<int>();

            foreach (var item in extractFrom)
            {
                if (!extract.Contains(item))
                    result.Add(item);
            }
            return result;
        } //Sixth

    }
}
