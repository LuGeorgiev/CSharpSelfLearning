using System;

namespace DemoUnitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();
            var util = new Utils(logger);
        }
    }

    class Utils
    {
        private ILogger logger;

        public Utils(ILogger logger)
        {
            this.logger = logger;
        }

        public string CapitalizeText(string msg)
        {
            var str = this.logger.ReturnMessage();

            return msg + str;
        }
    }

    interface ILogger
    {
        string ReturnMessage();
    }
}
