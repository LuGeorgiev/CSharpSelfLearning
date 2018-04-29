using Logger.Models.Contracts;
using System;


namespace Logger.Models
{
    public class Error : IError
    {
        public Error(DateTime dateTime, ErrorLevel level, string messagee)
        {
            this.DateTime = dateTime;
            this.Level = level;
            this.Message = messagee;
        }

        public DateTime DateTime { get; }

        public string Message { get; }

        public ErrorLevel Level { get; }
    }
}
