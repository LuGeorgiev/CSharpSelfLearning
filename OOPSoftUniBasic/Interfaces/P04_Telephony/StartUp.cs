using System;
using System.Linq;

namespace P04_Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbersToCall = Console.ReadLine().Split();
            var sitesToBrowse = Console.ReadLine().Split();
            var smartphone = new Smartphone();

            foreach (var number in numbersToCall)
            {
                Console.WriteLine(smartphone.Call(number)); 
            }

            foreach (var site in sitesToBrowse)
            {
                Console.WriteLine(smartphone.Browse(site)); 
            }
        }
    }
}
