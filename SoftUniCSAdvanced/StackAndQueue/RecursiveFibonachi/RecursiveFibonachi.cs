using System;
using System.Collections.Generic;

namespace RecursiveFibonachi
{
    class RecursiveFibonachi
    {
        static Dictionary<int,ulong> fibonachMembers = new Dictionary<int, ulong>();

        static void Main(string[] args)
        {
            fibonachMembers.Add(0,0);
            fibonachMembers.Add(1,1);            
            fibonachMembers.Add(2,1);
            fibonachMembers.Add(3,2);
            fibonachMembers.Add(4,3);
            fibonachMembers.Add(5,5);
           
            int n = int.Parse(Console.ReadLine());

            ulong fibonachi = GetFibonachi(n);
            Console.WriteLine(fibonachi);
        }

        private static ulong GetFibonachi(int n)
        {
            ulong fibResult = 0;
            if (fibonachMembers.ContainsKey(n))
            {
                return fibonachMembers[n];
            }
            else
            {
                fibResult = GetFibonachi(n - 1) + GetFibonachi(n - 2);
                fibonachMembers.Add(n, fibResult);
                return fibResult;
            }

        }
    }
}
