using System;
using System.Collections.Generic;
using System.Text;

namespace EgnValidator.Services.Infrastructure.Implementations
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
