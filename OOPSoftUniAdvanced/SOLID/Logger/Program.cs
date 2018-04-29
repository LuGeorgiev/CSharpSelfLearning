using Logger.Models;
using Logger.Models.Contracts;
using Logger.Models.Factories;
using System;
using System.Collections.Generic;

namespace Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial TEST

            //ILayout layout = new SimpleLayout();
            //IAppender appender = new ConsoleAppender(layout, ErrorLevel.INFO);

            //var logger = new Models.Logger(new IAppender[] { appender });
            //IError error = new Error(DateTime.Now, ErrorLevel.CRITICAL, "Critical error!");
            //logger.Log(error);


            // Using factories, InitializeLogger and Engine

            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory = new ErrorFactory();
            Engin engine = new Engin(logger,errorFactory);
            engine.Run();


        }

        static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);
            
            
            int appenderCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < appenderCount; i++)
            {
                string[] args = Console.ReadLine().Split();

                string appnderType = args[0];
                string layoutType = args[1];
                string errorLevel = "INFO";
                if (args.Length==3)
                {
                    errorLevel = args[2];
                }
                IAppender appender = appenderFactory.CreateAppender(appnderType, errorLevel, layoutType);

                appenders.Add(appender);
            }

            ILogger logger = new Models.Logger(appenders);
            return logger;
        }
    }
}
