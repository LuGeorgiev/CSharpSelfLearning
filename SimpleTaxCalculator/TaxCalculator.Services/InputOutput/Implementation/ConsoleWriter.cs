using System;

namespace TaxCalculator.Services.InputOutput.Implementation
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string data)
            => Console.WriteLine(data);
    }
}
