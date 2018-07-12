using System;

namespace Demo
{
    class Program
    {
        public delegate void DelegatToPrint(string stringToPrint);
        static void Main(string[] args)
        {
            Action<string> actionToPrint = str => Console.WriteLine(str);
            
            DelegatToPrint delegatToPrint = PrintToConsole1;
            delegatToPrint += PrintToConsole2;
            delegatToPrint += PrintToConsole1;
            delegatToPrint("hello World!"); //Multicast example. This way a lot of event handlers can be chained
            // This si sinchronous chaining - One after the other

            delegatToPrint.GetInvocationList(); //Array of Delegats

            DelegatToPrint funcNothig = DoNothing;
            DoNothing("Hello World!");

            PrintStringByFunction(PrintToConsole1, "Heloo World!");
        }

        private static void PrintToConsole1(string stringToPrint)
        {
            Console.WriteLine("1: "+stringToPrint);
        }
        private static void PrintToConsole2(string stringToPrint)
        {
            Console.WriteLine("2: " + stringToPrint);
        }

        private static void DoNothing(string myStr)
        { }

        private static void PrintStringByFunction(DelegatToPrint delegatToPrint, string stringToPrint)
        {
            delegatToPrint(stringToPrint);
        }
    }
}
