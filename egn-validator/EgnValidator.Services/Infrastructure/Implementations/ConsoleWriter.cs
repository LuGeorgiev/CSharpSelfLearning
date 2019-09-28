using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Infrastructure.Implementations
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string contents)
        {
            Console.Write(contents);
        }

        public void WriteLine(string contents)
        {
            Console.WriteLine(contents);
        }
    }
}
