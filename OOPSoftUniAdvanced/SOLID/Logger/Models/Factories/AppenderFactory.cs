using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Factories
{
    public class AppenderFactory
    {
        const string DefaulFileName = "logFile{0}.txt";

        private LayoutFactory layoutFactory;
        private int fileNumber;

        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.fileNumber = 0;
        }
        public IAppender CreateAppender(string appenderType, string levelString, string layoutType)
        {
            ILayout layout = this.layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = this.PareseErrorLevel(levelString);
            IAppender appender = null;
            switch (appenderType)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(layout, errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile = new LogFile(string.Format(DefaulFileName, this.fileNumber));
                    appender = new FileAppender(layout, errorLevel,logFile);
                    break;
                default:
                    throw new ArgumentException("Invalid appender type");                    
            }
            return appender;
        }

        private ErrorLevel PareseErrorLevel(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException("Invalid ErrorLevel type", ex);
            }
        }
    }
}
