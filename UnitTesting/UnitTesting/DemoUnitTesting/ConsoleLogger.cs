using System;

namespace DemoUnitTesting
{
    internal class ConsoleLogger: ILogger
    {
        public ConsoleLogger()
        {
        }

        public string ReturnMessage()
        {
            var msg = Console.ReadLine();
            
            return msg;
        }
    }
}