using System;
using Tasker.Core.Contracts;

namespace Tasker.Core.IdProviders
{
    public class ConsoleLogger :ILogger
    {
        public void Log(string meessage)
        {
            Console.WriteLine(meessage);
        }
    }
}
