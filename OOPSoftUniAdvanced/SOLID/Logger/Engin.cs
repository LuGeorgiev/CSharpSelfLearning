using Logger.Models;
using Logger.Models.Contracts;
using Logger.Models.Factories;
using System;


namespace Logger
{
    public class Engin
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engin(ILogger logger, ErrorFactory errorFactory)
        {
            this.logger = logger;
            this.errorFactory = errorFactory;
        }

        public void Run()
        {
            string input = "";
            while ((input = Console.ReadLine())!="END")
            {
                var errorArgs = input.Split('|');
                string level = errorArgs[0];
                string dateTime = errorArgs[1];
                string message = errorArgs[2];


                IError error = errorFactory.CreateError(dateTime,level,message);
                this.logger.Log(error);
            }
            Console.WriteLine("Logger info");
            foreach (IAppender appender in this.logger.Appenders)
            {
                Console.WriteLine(appender);
            }

        }
    }
}
