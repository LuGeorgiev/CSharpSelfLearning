using System;

namespace TaxCalculator.Services.InputOutput.Implementation
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
            => Console.ReadLine();
    }
}
