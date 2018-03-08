using Lecture.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Core.Providers
{
    class ConsooleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
